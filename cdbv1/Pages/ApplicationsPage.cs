using System;
// using System.Threading.Tasks;
using cdbv1.Models;
using cdbv1;
using Spectre;
using Spectre.Console;
using cdbv1.Controllers;
using cdbv1.Helpers;
using Npgsql;

namespace cdbv1.Pages;

public class ApplicationsPage() : Page
{
    private List<CompanyInformation> companies = [];
    private List<JobApplication> jobApplications = [];
    private MyController myController = new();

    // static ApplicationsPage() {}
    public async Task Display()
    {
        // view all companies
        await GetAllCompanies();

        // view all applications
  ////////////      // await myController.GetAllApplications();

        await DisplayApplicationsTable();
        await ApplicationPageRedirectMenu();

    }
    private async Task ApplicationPageRedirectMenu()
    {
        // var mainMenuPageRedirectOptions = MainMenuRedirectPageOptions;
        // var pageOptions = Page.PageOptions; ? is this better? with using Page;
        var applicationPageRedirectOptions = new List<string> { "add new application", "view application details" };
        applicationPageRedirectOptions.AddRange(MainMenuRedirectPageOptions);
        var pageName = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select page")
                .PageSize(10)
                .AddChoices(applicationPageRedirectOptions));
        await PageRedirect(pageName);
    }
    public async Task DisplayAddApplication()
    {
        if (AnsiConsole.Confirm("Add New Application?"))
        {
            await ClearDisplay();
            await GetAllCompanies();
            await DisplayCompanyInformationTable();
            AnsiConsole.MarkupLine("[gray]Create new application[/]");
            string companyName = AnsiConsole.Ask<string>($"[green]Enter Company Name:[/] ");
            string currentStatus = AnsiConsole.Ask<string>($"[green]Enter Current Status:[/] ");
            string jobDescription = AnsiConsole.Ask<string>($"[green]Enter Job Description:[/] ");


            await CreateNewApplication(new()
            {
                CompanyName = companyName,
                CurrentStatus = currentStatus,
                JobDescription = jobDescription
            });
        }
        await MainMenuWithConfirm();
    }
    public async Task DisplayApplicationDetails()
    {
        var res = await myController.GetAllApplications();
        if (res.Count <= 0)
        {
            AnsiConsole.MarkupLine("[red]no applications[/]");
        }
        else
        {
            var jobApplicationRedirectOptions = new List<string> { };
            var jobApplicationDescriptionMap = new Dictionary<string, List<string>>();
            foreach (var jobApp in res)
            {
                jobApplicationRedirectOptions.Add(jobApp.CompanyName);
                jobApplicationDescriptionMap[jobApp.CompanyName] = [jobApp.JobDescription];
            }
            var companyName = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Select application to view requirments[/]")
                    .PageSize(10)
                    .AddChoices(jobApplicationRedirectOptions));

            AnsiConsole.MarkupLine("[blue]APPLICATION DETAILS[/]");
            AnsiConsole.MarkupLine($"Company Name[blue]{companyName}[/]");
            AnsiConsole.MarkupLine($"Company Description:");
            AnsiConsole.MarkupLine($"{jobApplicationDescriptionMap[companyName][0]}");
        }
        await MainMenuWithConfirm();
    }
    private async Task GetAllCompanies()
    {
        try
        {
            DbInfoController dbIc = new();
            var dbsb = new DbSourceBuilder("localhost");
            await using var dataSource = dbsb.Builder().Build();
            AnsiConsole.MarkupLine("[gray]Fetching data...[/]");
            AnsiConsole.MarkupLine("    -> [gray]Fetching company_information...[/]");
            await using (var cmd = dataSource.CreateCommand("SELECT * FROM company_information"))
            await using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    var company = new CompanyInformation()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        JobBoardLink = reader.GetString(2),
                        CompanyDescription = reader.GetString(3)
                    };
                    companies.Add(company);
                }
            AnsiConsole.MarkupLine($"        -> [green]Done. {companies.Count}[/]");
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    // private async Task GetAllApplications()
    // {
    //     AnsiConsole.MarkupLine("    -> [gray]Fetching applications...[/]");

    //     // var my controller = new MyController().GetAllApplications();
    //     // todo implement cache
    //     var res = await myController.GetAllApplications();

    //     AnsiConsole.MarkupLine($"        -> [green]Done. {res.Count}[/]");

    //     // try
    //     // {
    //     //     DbInfoController dbIc = new();
    //     //     var dbsb = new DbSourceBuilder("localhost");
    //     //     await using var dataSource = dbsb.Builder().Build();
    //     //     AnsiConsole.MarkupLine("    -> [gray]Fetching applications...[/]");
    //     //     await using (var cmd = dataSource.CreateCommand("SELECT * FROM application"))
    //     //     await using (var reader = await cmd.ExecuteReaderAsync())
    //     //         while (await reader.ReadAsync())
    //     //         {
    //     //             var jobApp = new JobApplication()
    //     //             {
    //     //                 CompanyName = reader.GetString(1),
    //     //                 CurrentStatus = reader.GetString(2),
    //     //                 CurrentStatusDate = reader.GetDateTime(3),
    //     //                 JobDescription = reader.GetString(4)
    //     //             };
    //     //             jobApplications.Add(jobApp);
    //     //         }
    //     //     AnsiConsole.MarkupLine($"        -> [green]Done. {jobApplications.Count}[/]");
    //     // }
    //     // catch (NpgsqlException e)
    //     // {
    //     //     Console.WriteLine(e.Message);
    //     // }

    // }
    private static async Task CreateNewApplication(JobApplication jobApplication)
    {
        /////// TODO: abort feature
        ///     ---> tell user: leave field empty to cancel
        try
        {
            DbInfoController dbIc = new();
            var dbsb = new DbSourceBuilder("localhost");
            await using var dataSource = dbsb.Builder().Build();
            AnsiConsole.MarkupLine("[gray]Inserting data...[/]");
            AnsiConsole.MarkupLine("    -> [gray]Inserting new application...[/]");
            await using var connection = await dataSource.OpenConnectionAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            DateOnly today = DateOnly.FromDateTime(DateTime.Now);

            await using var command1 = new NpgsqlCommand("INSERT into application (company_name, current_status, current_status_date, job_description)" +
            $" VALUES ('{jobApplication.CompanyName}', '{jobApplication.CurrentStatus}', '{today}', '{jobApplication.JobDescription}')", connection, transaction);
            await command1.ExecuteNonQueryAsync();

            await transaction.CommitAsync();
            AnsiConsole.MarkupLine($"        -> [green]Done.[/][gray]New Application added.[/]");
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
        }
    }
    private async Task DisplayCompanyInformationTable()
    {
        var companiesTable = new Table().ShowRowSeparators();
        companiesTable.AddColumn("Id");
        companiesTable.AddColumn("Name");
        companiesTable.AddColumn("JobBoardLink");
        companiesTable.AddColumn("CompanyDescription");

        foreach (var company in companies)
        {
            companiesTable.AddRow(
                company.Id.ToString(),
                company.Name,
                company.JobBoardLink,
                company.CompanyDescription
            );
        }
        AnsiConsole.Write(companiesTable);
    }
    private async Task DisplayApplicationsTable()
    {
        var applicationsTable = new Table().ShowRowSeparators();
        applicationsTable.AddColumn("CompanyName");
        applicationsTable.AddColumn("CurrentStatus");
        applicationsTable.AddColumn("CurrentStatusDate");
        applicationsTable.AddColumn("JobDescription");

        var res = await myController.GetAllApplications();

        foreach (JobApplication jobApp in res)
        {
            // pick smallest to display in table
            int previewLength = Math.Min(jobApp.JobDescription.Length, 20);
            applicationsTable.AddRow(
                jobApp.CompanyName,
                jobApp.CurrentStatus,
                jobApp.CurrentStatusDate.ToString(),
                jobApp.JobDescription.Substring(0, previewLength)
            );
        }
        AnsiConsole.Write(applicationsTable);
    }
}