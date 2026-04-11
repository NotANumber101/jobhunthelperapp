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
            AnsiConsole.MarkupLine("    -> [gray]Fetching applications...[/]");
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
            AnsiConsole.MarkupLine($"        -> [green]Done. {jobApplications.Count}[/]");
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
        }
        return jobApplications;
    }
}