using System;
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
        DisplayApplicationsTable();
        if (AnsiConsole.Confirm("Add New Application?"))
        {
            ClearDisplay();
            DisplayCompanyInformationTable();
            AnsiConsole.MarkupLine("[gray]Create new application[/]");
            string companyName = AnsiConsole.Ask<string>($"[green]Enter Company Name:[/] ");
            string currentStatus = AnsiConsole.Ask<string>($"[green]Enter Current Status:[/] ");
            string jobLocation = AnsiConsole.Ask<string>($"[green]Enter Job Location:[/] ");
            string jobTitle = AnsiConsole.Ask<string>($"[green]Enter Job Title:[/] ");
            string jobDescription = AnsiConsole.Ask<string>($"[green]Enter Job Description:[/] ");

            await CreateNewApplication(new()
            {
                CompanyName = companyName,
                CurrentStatus = currentStatus,
                JobLocation = jobLocation,
                JobTitle = jobTitle,
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
                        Description = reader.GetString(2),
                        JobBoardLink = reader.GetString(3)
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
            AnsiConsole.MarkupLine("    -> [gray]Fetching job_applications...[/]");
            await using (var cmd = dataSource.CreateCommand("SELECT * FROM application"))
            await using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    var jobApp = new JobApplication()
                    {
                        CompanyName = reader.GetString(1),
                        CurrentStatus = reader.GetString(2),
                        CurrentStatusDate = reader.GetDateTime(3),
                        JobLocation = reader.GetString(4),
                        JobTitle = reader.GetString(5),
                        JobDescription = reader.GetString(6)
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
    private async Task CreateNewApplication(JobApplication jobApplication)
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

            await using var command1 = new NpgsqlCommand("INSERT into application (company_name, current_status, current_status_date, job_location, job_title, job_description)" +
            $" VALUES ('{jobApplication.CompanyName}', '{jobApplication.CurrentStatus}', '{today}', '{jobApplication.JobLocation}', '{jobApplication.JobTitle}', '{jobApplication.JobDescription}')", connection, transaction);
            await command1.ExecuteNonQueryAsync();

            await transaction.CommitAsync();
            AnsiConsole.MarkupLine($"        -> [green]Done.[/][gray]New Application added.[/]");
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
        }

    }
    private void DisplayCompanyInformationTable()
    {
        var companiesTable = new Table().ShowRowSeparators();
        companiesTable.AddColumn("Id");
        companiesTable.AddColumn("Name");
        companiesTable.AddColumn("Description");
        companiesTable.AddColumn("JobBoardLink");
        foreach (var company in companies)
        {
            companiesTable.AddRow(
                company.Id.ToString(),
                company.Name,
                company.Description,
                company.JobBoardLink
            );
        }
        AnsiConsole.Write(companiesTable);
    }
    private void DisplayApplicationsTable()
    {
        var applicationsTable = new Table().ShowRowSeparators();
        applicationsTable.AddColumn("CompanyName");
        applicationsTable.AddColumn("CurrentStatus");
        applicationsTable.AddColumn("CurrentStatusDate");
        applicationsTable.AddColumn("JobLocation");
        applicationsTable.AddColumn("JobTitle");
        applicationsTable.AddColumn("JobDescription");

        foreach (JobApplication jobApp in jobApplications)
        {
            applicationsTable.AddRow(
                jobApp.CompanyName,
                jobApp.CurrentStatus,
                jobApp.CurrentStatusDate.ToString(),
                jobApp.JobLocation,
                jobApp.JobTitle,
                jobApp.JobDescription
            );
        }
        AnsiConsole.Write(applicationsTable);
    }
}