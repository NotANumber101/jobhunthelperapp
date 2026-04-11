using System;
using cdbv1.Helpers;
using cdbv1.Models;
using cdbv1.Queries;
using Npgsql;
using Spectre.Console;

namespace cdbv1.Controllers;

public class MyController()
{
    private static readonly string host = "localhost";
    NpgsqlDataSourceBuilder dbBuilder = new DbSourceBuilder(host).Builder();

    public async Task<List<JobApplication>> GetAllApplications()
    {
        List<JobApplication> jobApplications = [];
        try
        {
            // var dbsb = new DbSourceBuilder(host);
            // await using var dataSource = dbsb.Builder().Build();
            await using var dataSource = dbBuilder.Build();
            // AnsiConsole.MarkupLine("    -> [gray]Fetching applications...[/]");
            await using (var cmd = dataSource.CreateCommand(MyQueries.GetAllApplicationsQuery()))
            await using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    var jobApp = new JobApplication()
                    {
                        CompanyName = reader.GetString(1),
                        CurrentStatus = reader.GetString(2),
                        CurrentStatusDate = reader.GetDateTime(3),
                        JobDescription = reader.GetString(4)
                    };
                    jobApplications.Add(jobApp);
                }
            // AnsiConsole.MarkupLine($"        -> [green]Done. {jobApplications.Count}[/]");
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
        }
        return jobApplications;
    }
    public async Task<List<CompanyInformation>> GetAllCompanies()
    {
        List<CompanyInformation> companies = [];
        try
        {
            await using var dataSource = dbBuilder.Build();

            // AnsiConsole.MarkupLine("[gray]Fetching data...[/]");
            // AnsiConsole.MarkupLine("    -> [gray]Fetching company_information...[/]");
            await using (var cmd = dataSource.CreateCommand(MyQueries.GetAllCompanies()))
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
            // AnsiConsole.MarkupLine($"        -> [green]Done. {companies.Count}[/]");
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
        }
        return companies;
    }
    public async Task InsertNewApplication(JobApplication jobApplication)
    {
        try
        {
            await using var dataSource = dbBuilder.Build();

            // AnsiConsole.MarkupLine("[gray]Inserting data...[/]");
            // AnsiConsole.MarkupLine("    -> [gray]Inserting new application...[/]");
            await using var connection = await dataSource.OpenConnectionAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            // DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            jobApplication.CurrentStatusDate = DateTime.Today;

            await using var command1 = new NpgsqlCommand(MyQueries.InsertNewApplicationQuery(jobApplication), connection, transaction);
            await command1.ExecuteNonQueryAsync();

            await transaction.CommitAsync();
            // AnsiConsole.MarkupLine($"        -> [green]Done.[/][gray]New Application added.[/]");
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
        }

    }
    public async Task<List<string>> GetDbTableNames()
    {
        List<string> res = [];
        var dbsb = new DbSourceBuilder("db,localhost");
        await using var dataSource = dbsb.Builder().BuildMultiHost();
        // Table: Database names
        var databaseNames = new Table().ShowRowSeparators();
        databaseNames.AddColumn("Databases", col => col.Centered());

        await using (var cmd = dataSource.CreateCommand(MyQueries.GetDbNamesQuery()))
        await using (var reader = await cmd.ExecuteReaderAsync())
            while (await reader.ReadAsync())
            {
                res.Add(reader.GetString(0));
                databaseNames.AddRow(reader.GetString(0));
            }
        AnsiConsole.Write(databaseNames);
        return res;
    }
    public async Task<List<string>> GetTableFieldNames()
    {
        List<string> res = [];

        var dbsb = new DbSourceBuilder("db,localhost");
        await using var dataSource = dbsb.Builder().BuildMultiHost();
        // Tree: Table Names
        var myDbTree = new Tree("Database Tables Tree...");

        await using (var getDbTableNames = dataSource.CreateCommand(MyQueries.GetDbTableNamesQuery()))

        await using (var tNameReader = await getDbTableNames.ExecuteReaderAsync())
            while (await tNameReader.ReadAsync())
            {
                var tname = myDbTree.AddNode(tNameReader.GetString(0));
                await using (var getTableFieldNames = dataSource
                    .CreateCommand(MyQueries.GetTableFieldNamesQuery(tNameReader.GetString(0))))
                await using (var fNameReader = await getTableFieldNames.ExecuteReaderAsync())
                    while (await fNameReader.ReadAsync())
                    {
                        tname.AddNode(fNameReader.GetString(0));
                        res.Add(fNameReader.GetString(0));
                    }
            }
        AnsiConsole.Write(myDbTree);
        return res;
    }
    public async Task<List<DsaProblem>> GetAllDsaProblems()
    {
        List<DsaProblem> res = [];
        DbInfoController dbIc = new();
        var dbsb = new DbSourceBuilder("localhost");
        await using var dataSource = dbsb.Builder().Build();
        AnsiConsole.MarkupLine("[gray]Fetching data...[/]");
        AnsiConsole.MarkupLine("    -> [gray]Fetching dsa_problems...[/]");
        await using (var cmd = dataSource.CreateCommand("SELECT * FROM dsa_problem"))
        await using (var reader = await cmd.ExecuteReaderAsync())
            while (await reader.ReadAsync())
            {
                DsaProblem dsaProblem = new(
                    reader.GetInt32(0), reader.GetString(1),
                    reader.GetString(2), reader.GetString(3),
                    reader.GetString(4), reader.GetDateTime(5)
                );
                res.Add(dsaProblem);
            }
        AnsiConsole.MarkupLine($"        -> [green]Done. {res.Count}[/]");
        return res;
    }
    public async Task InsertNewSolution(int problemId, string solutionText, PostMortem postMortem)
    {
        DbInfoController dbIc = new();
            var dbsb = new DbSourceBuilder("localhost");
            await using var dataSource = dbsb.Builder().Build();
            AnsiConsole.MarkupLine("[gray]Inserting data...[/]");
            AnsiConsole.MarkupLine("    -> [gray]Inserting new solution...[/]");
            await using var connection = await dataSource.OpenConnectionAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            await using var command1 = new NpgsqlCommand(dbIc.CreateNewDsaSolution(problemId, solutionText), connection, transaction);
            int solutionId = (int)command1.ExecuteScalar()!;

            postMortem.SolutionId = solutionId;

            Console.WriteLine($"SolutionId: {solutionId} inserted!");
            // await command1.ExecuteNonQueryAsync();
            // var cmd = new NpgsqlCommand("UPDATE foo SET bar=@bar WHERE baz=@baz; UPDATE foo SET bar=@bar WHERE baz=@baz");
            await using var command2 = new NpgsqlCommand(dbIc.UpdateDsaProblemDateCompletedTodayId(problemId), connection, transaction);
            await command2.ExecuteNonQueryAsync();

            await using var command3 = new NpgsqlCommand(
                "INSERT INTO dsa_postmortem (solution_id, design_time_ms, code_time_ms, mistakes, analysis, rubric_problem_solving_score, rubric_coding_score, rubric_verification_score, rubric_communication_score)" +
                $" VALUES ({solutionId}, {postMortem.DesignTimeMs}, {postMortem.CodeTimeMs}, '{postMortem.Mistakes}', '{postMortem.Analysis}', {postMortem.RubricCodingScore}, {postMortem.RubricCommunicationScore}, {postMortem.RubricProblemSolvingScore}, {postMortem.RubricVerificationScore});",
            connection, transaction);
            await command3.ExecuteNonQueryAsync();

            await transaction.CommitAsync();
            AnsiConsole.MarkupLine($"        -> [green]Done.[/][gray]ProblemId:{problemId} has new solution.[/]");
    }
}
