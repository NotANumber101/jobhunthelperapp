using System;
using cdbv1.Models;
using Spectre;
using Spectre.Console;
using cdbv1;
using cdbv1.Helpers;
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
        DisplayCompanyInformationTable();
        // view all applications
        await GetAllApplications();
        DisplayApplicationsTable();

        await MainMenuWithConfirm();

    }
    // private void AddNewApplication()
    // {
    //     // select company (spectre select)
    //     // if company not in list
    //     // add company 
    //     // else add companyid to application model
    //     // build application model
    //     // try push application to db
    // }
    private async Task GetAllCompanies()
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

    private async Task GetAllApplications()
    {
        DbInfoController dbIc = new();
        var dbsb = new DbSourceBuilder("localhost");
        await using var dataSource = dbsb.Builder().Build();
        AnsiConsole.MarkupLine("    -> [gray]Fetching job_applications...[/]");
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
        applicationsTable.AddColumn("Id");
        applicationsTable.AddColumn("CompanyId");
        applicationsTable.AddColumn("CurrentStatus");
        applicationsTable.AddColumn("CurrentStatusDate");
        applicationsTable.AddColumn("JobLocation");
        applicationsTable.AddColumn("JobTitle");
        applicationsTable.AddColumn("JobDescription");

        foreach (JobApplication jobApp in jobApplications)
        {
            applicationsTable.AddRow(
                jobApp.Id.ToString(),
                jobApp.CompanyId.ToString(),
                jobApp.CurrentStatus,
                jobApp.CurrentStatusDate,
                jobApp.JobLocation,
                jobApp.JobTitle,
                jobApp.JobDescription
            );
        }
        AnsiConsole.Write(applicationsTable);
    }
}