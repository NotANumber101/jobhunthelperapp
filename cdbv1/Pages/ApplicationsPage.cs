using System;
// using System.Threading.Tasks;
using cdbv1.Models;
using cdbv1;
using Spectre;
using Spectre.Console;
using cdbv1.Controllers;
using cdbv1.Helpers;
using Npgsql;

//// todo view schedule (upcomijg interviews)



namespace cdbv1.Pages;

public class ApplicationsPage() : Page
{
    private MyController myController = new();
    // private List<string> applicationPageRedirectOptions = ["add new application", "view application details"];
    public async Task Display()
    {

        await DisplayApplicationsTable();
        await ApplicationPageRedirectMenu();

    }
    private async Task ApplicationPageRedirectMenu()
    {
        var applicationPageRedirectOptions = new List<string> { "Add New Application", "View Application Details" ,"View Application Schedule"};
        applicationPageRedirectOptions.AddRange(MainMenuRedirectPageOptions);
        var pageName = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Job Applications Navigation Menu")
                .PageSize(10)
                .AddChoices(applicationPageRedirectOptions));
        await PageRedirect(pageName);
    }
    public async Task DisplayAddApplication()
    {
        await ClearDisplay();
        await GetAllCompanies();
        await DisplayCompanyInformationTable();

        AnsiConsole.MarkupLine("[gray]Create new application[/]");
        string companyName = AnsiConsole.Ask<string>($"[green]Enter Company Name:[/] ");
        string currentStatus = AnsiConsole.Ask<string>($"[green]Enter Current Status:[/] ");
        string jobDescription = AnsiConsole.Ask<string>($"[green]Enter Job Description:[/] ");
        JobApplication jobApp = new JobApplication()
            {
                CompanyName = companyName,
                CurrentStatus = currentStatus,
                JobDescription = jobDescription
            };
        if (AnsiConsole.Confirm("Save new application?"))
        {
            await myController.InsertNewApplication(jobApp);
        } else AnsiConsole.MarkupLine("Aborted");
        await MainMenuWithConfirm();
    }
    public async Task DisplayApplicationSchedule()
    {
        AnsiConsole.MarkupLine("applications schedule");
        await MainMenuWithConfirm();
    }
    public async Task DisplayApplicationDetails()
    {
        var res = await myController.GetAllApplications();
        if (res.Count <= 0)
        {
            AnsiConsole.MarkupLine("[red]Err: no applications[/]");
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
                    .Title("[green]Select an application to view in detail[/]")
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
        AnsiConsole.MarkupLine("[gray]Fetching data...[/]");
        AnsiConsole.MarkupLine("    -> [gray]Fetching company_information...[/]");
        var res = await myController.GetAllCompanies();
        AnsiConsole.MarkupLine($"        -> [green]Done. {res.Count}[/]");
    }

    private async Task GetAllApplications()
    {
        AnsiConsole.MarkupLine("[gray]Fetching data...[/]");
        AnsiConsole.MarkupLine("    -> [gray]Fetching applications...[/]");
        var res = await myController.GetAllApplications();
        AnsiConsole.MarkupLine($"        -> [green]Done. {res.Count}[/]");
    }
    private static async Task CreateNewApplication(JobApplication jobApplication)
    {
        /////// TODO: abort feature
        ///     ---> tell user: leave field empty to cancel
        // try
        // {
        //     var dbsb = new DbSourceBuilder("localhost");
        //     await using var dataSource = dbsb.Builder().Build();
        //     AnsiConsole.MarkupLine("[gray]Inserting data...[/]");
        //     AnsiConsole.MarkupLine("    -> [gray]Inserting new application...[/]");
        //     await using var connection = await dataSource.OpenConnectionAsync();
        //     await using var transaction = await connection.BeginTransactionAsync();

        //     DateOnly today = DateOnly.FromDateTime(DateTime.Now);

        //     await using var command1 = new NpgsqlCommand("INSERT into application (company_name, current_status, current_status_date, job_description)" +
        //     $" VALUES ('{jobApplication.CompanyName}', '{jobApplication.CurrentStatus}', '{today}', '{jobApplication.JobDescription}')", connection, transaction);
        //     await command1.ExecuteNonQueryAsync();

        //     await transaction.CommitAsync();
        //     AnsiConsole.MarkupLine($"        -> [green]Done.[/][gray]New Application added.[/]");
        // }
        // catch (NpgsqlException e)
        // {
        //     Console.WriteLine(e.Message);
        // }
    }
    private async Task DisplayCompanyInformationTable()
    {
        var res = await myController.GetAllCompanies();

        var companiesTable = new Table().ShowRowSeparators();
        companiesTable.AddColumn("Id");
        companiesTable.AddColumn("Name");
        companiesTable.AddColumn("JobBoardLink");
        companiesTable.AddColumn("CompanyDescription");

        foreach (var company in res)
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
                jobApp.CurrentStatusDate.ToShortDateString(),
                jobApp.JobDescription.Substring(0, previewLength)
            );
        }
        AnsiConsole.Write(applicationsTable);
    }
}