using System;
// using System.Threading.Tasks;
using cdbv1.Models;
using Spectre;
using Spectre.Console;
using cdbv1;
using cdbv1.Helpers;
using Npgsql;

namespace cdbv1.Pages;

public class ApplicationsPage() : Page
{
    private List<CompanyInformation> companies = [];
    private List<JobApplication> jobApplications = [];
    // static ApplicationsPage() {}
    public async Task Display()
    {
        // view all companies
        await GetAllCompanies();

        // view all applications
        await GetAllApplications();
        await DisplayApplicationsTable();
        if (AnsiConsole.Confirm("Add New Application?"))
        {
            ClearDisplay();
            // instead of a table; load list, select application, and open specific page for one application
            DisplayCompanyInformationTable();
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

    private async Task GetAllApplications()
    {
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
    }
    private static async Task CreateNewApplication(JobApplication jobApplication)
    {
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

        foreach (JobApplication jobApp in jobApplications)
        {
                applicationsTable.AddRow(
                    jobApp.CompanyName,
                    jobApp.CurrentStatus,
                    jobApp.CurrentStatusDate.ToString(),
                    jobApp.JobDescription
                );
            // }

        }
        AnsiConsole.Write(applicationsTable);
    }
}