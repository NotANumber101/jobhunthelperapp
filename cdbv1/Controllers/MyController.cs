using System;
using cdbv1.Helpers;
using cdbv1.Models;
using Npgsql;
using Spectre.Console;

namespace cdbv1.Controllers;

public class MyController()
{
    public async Task<List<JobApplication>> GetAllApplications()
    {
        List<JobApplication> jobApplications = [];
        try
        {
            DbInfoController dbIc = new();
            var dbsb = new DbSourceBuilder("localhost");
            await using var dataSource = dbsb.Builder().Build();



            AnsiConsole.MarkupLine("    -> [gray]Fetching applications...[/]");
            await using (var cmd = dataSource.CreateCommand("SELECT * FROM application"))
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