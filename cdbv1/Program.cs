using Microsoft.Extensions.Logging;
using Spectre.Console;
using Spectre;
using Npgsql;
using cdbv1.Helpers;
using cdbv1.Models;
using System;

string host = "db";

if (AnsiConsole.Profile.Capabilities.Interactive)
{
    // Open terminal, go to Projects/cdbv1/cdbv1 and run `dotnet run`
    host = "localhost";
}
else
{
    // Open docker, go to container and verify tables printed
    Console.WriteLine("Interactive mode: DISABLED");
    host = "db";
}

AsyncPrompt helloWorld = new();
DbInfoController dbIc = new();

AnsiConsole.WriteLine($"LOG: Host={host}");
var connectionString = $"Host={host};Port=5432;Username=postgres;Password=password;Database=test_db";
using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
var npgsqlDataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
npgsqlDataSourceBuilder
    .EnableParameterLogging(true);
// uncomment below to enable logging
    // .UseLoggerFactory(factory);

// DATA SOURCE
await using var dataSource = npgsqlDataSourceBuilder.Build();

// DATA LISTS
List<CompanyInformation> companies = new List<CompanyInformation>();
List<JobApplication> jobApplications = new List<JobApplication>();
List<DsaProblem> dsaProblems = new List<DsaProblem>();
// set permanent company ids because these companies will always exist on my list of desired companies. Mayaswell reserve ids for them
// use uniqu
// spacexId = 999, anduril 888, palantir 777

try
{
    // FETCH DATA
    await using var connection = await dataSource.OpenConnectionAsync();
    // SELECT 8 verifies Logging
    await using var loggingCommand = new NpgsqlCommand("SELECT 8", connection);
    _ = await loggingCommand.ExecuteScalarAsync();
    AnsiConsole.MarkupLine("Database Connection: [green]OK![/]");
    // loading all data required now for simplicity(mvp)
    // TODO: use spinner to visualize fetching data
    AnsiConsole.MarkupLine("[gray]Fetching data...[/]");
    // TODO: use multiple spinners to visualize fetching data
    // no matter what order or the speed laoded, just have them complete one by one in order
    //////////////////////////////
    //// COMPANY_INFORMATION ////
    ////////VVVVVVVVVVVV/////////
    AnsiConsole.MarkupLine("    -> [gray]Fetching company_information...[/]");
    // List<CompanyInformation> companies = new List<CompanyInformation>();
    await using (var cmd = dataSource.CreateCommand("SELECT * FROM company_information"))
    await using (var reader = await cmd.ExecuteReaderAsync())
        while (await reader.ReadAsync())
        {
            var company = new CompanyInformation()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = reader.GetString(2),
                JobBoardLink = reader.GetString(3)
            };
            companies.Add(company);
        }
    AnsiConsole.MarkupLine($"        -> [green]Done. {companies.Count}[/]");
    // TODO REPLACE THE BELOW CODE WITH A TABLE
    // THE TABLE APPEARS FOR 2 seconds and dissapears?
    // foreach(var company in companies)
    // {
    //     AnsiConsole.Markup($"[purple]{company.Name}[/]");
    //     AnsiConsole.Markup($"[purple]{company.Description}[/]");
    // }
    //////////////////////////////
    //// COMPANY_CONTACT ////////
    ////////VVVVVVVVVVVV/////////
    /// 
    /// 
    /// 
    //////////////////////////////
    //// COMPANY_PROMPT  ////////
    ////////VVVVVVVVVVVV/////////
    /// 
    /// 
    /// 
    //////////////////////////////
    //// CONTACT_MESSAGE ////////
    ////////VVVVVVVVVVVV/////////
    /// 
    /// 
    /// 
    //////////////////////////////
    //// JOB_APPLICATION ////////
    ////////VVVVVVVVVVVV/////////
    AnsiConsole.MarkupLine("    -> [gray]Fetching job_applications...[/]");
    // List<JobApplication> jobApplications = new List<JobApplication>();
    await using (var cmd = dataSource.CreateCommand("SELECT * FROM application"))
    await using (var reader = await cmd.ExecuteReaderAsync())
        while (await reader.ReadAsync())
        {
            JobApplication jobApp = new(
                reader.GetInt32(0), reader.GetInt32(1),
                reader.GetString(2), reader.GetString(3),
                reader.GetString(4), reader.GetString(5),
                reader.GetString(6)
            );
            jobApplications.Add(jobApp);
        }
    AnsiConsole.MarkupLine($"        -> [green]Done. {jobApplications.Count}[/]");
    //////////////////////////////
    //// DSA_PROBLEM ////////////
    ////////VVVVVVVVVVVV/////////
    AnsiConsole.MarkupLine("    -> [gray]Fetching dsa_problems...[/]");
    await using (var cmd = dataSource.CreateCommand("SELECT * FROM dsa_problem"))
    await using (var reader = await cmd.ExecuteReaderAsync())
        while (await reader.ReadAsync())
        {
            DsaProblem dsaProblem = new(
                reader.GetInt32(0), reader.GetString(1),
                reader.GetString(2), reader.GetString(3),
                reader.GetString(4)
            );
            dsaProblems.Add(dsaProblem);
        }
    AnsiConsole.MarkupLine($"        -> [green]Done. {dsaProblems.Count}[/]");
}
catch (NpgsqlException e)
{
    AnsiConsole.MarkupLine("[red]WARN[/] Unable to retrieve data...");
    AnsiConsole.MarkupLine("[red]ERROR[/] Database server connection has failed.");
    Console.WriteLine(e.Message);
}
////////////// PAGES - NAVIGATION /////////////////
/// if interactive mode is enabled, input and navigation is enabled
/// if iteractive mode is disabled, only database information is logged
if (AnsiConsole.Profile.Capabilities.Interactive)
{
    Console.WriteLine("LOG: Interactive mode detected. Input Mode Enabled.");

    ///////// Shared header
    AnsiConsole.MarkupLine($"[red]--------------START PAGE---------------[/]");
    // AnsiConsole.MarkupLine($"[gray]{pageChoice} page[/]");

    MainMenuPage mainMenuPage = new MainMenuPage(companies, jobApplications, dsaProblems);
    mainMenuPage.Display();

    // idea: page navigation option on every footer/header.
    AnsiConsole.MarkupLine($"[red]--------------END PAGE---------------[/]");
}
else
{
    try
    {
        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
        ///// Get all database names
        var databaseNames = new Table().ShowRowSeparators();
        databaseNames.AddColumn("Databases", col => col.Centered());
        await using (var cmd = dataSource.CreateCommand("SELECT datname FROM pg_database WHERE datistemplate = false;"))
        await using (var reader = await cmd.ExecuteReaderAsync())
            while (await reader.ReadAsync())
            {
                databaseNames.AddRow(reader.GetString(0));
            }
        AnsiConsole.Write(databaseNames);
        ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////
        /// Get db table names and table fields 
        var myDbTree = new Tree("job_app database TABLES");
        await using (var getDbTableNames = dataSource.CreateCommand(dbIc.GetDbTableNamesSql()))
        await using (var tNameReader = await getDbTableNames.ExecuteReaderAsync())
            while (await tNameReader.ReadAsync())
            {
                var tname = myDbTree.AddNode(tNameReader.GetString(0));
                await using (var getTableFieldNames = dataSource
                    .CreateCommand(dbIc.GetTableFieldNamesSql(tNameReader.GetString(0))))
                await using (var fNameReader = await getTableFieldNames.ExecuteReaderAsync())
                    while (await fNameReader.ReadAsync())
                    {
                        tname.AddNode(fNameReader.GetString(0));
                    }
            }
        AnsiConsole.Write(myDbTree);
    }
    catch (NpgsqlException e)
    {
        Console.WriteLine(e.Message);
    }
    Console.WriteLine("NON-FATAL ERROR OCCURED: INTERACTIVE MODE IS DISABLED... Exiting...");
}
