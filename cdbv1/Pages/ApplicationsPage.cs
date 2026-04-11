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
    private MyController myController = new();
    // private List<string> applicationPageRedirectOptions = ["add new application", "view application details"];
    public async Task Display()
    {
        await ClearDisplay();
        await DisplayApplicationsTable();
        await ApplicationPageRedirectMenu();

    }
    private async Task ApplicationPageRedirectMenu()
    {
        var applicationPageRedirectOptions = new List<string> { "Add New Application", "View Application Details", "View Application Schedule" };
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
        var companies = await myController.GetAllCompanies();
        await DisplayCompanyInformationTable(companies);

        var panel = new Panel("Important message")
            .Header("[yellow]Notice[/]")
            .BorderColor(Color.Yellow);

        AnsiConsole.Write(panel);


        AnsiConsole.MarkupLine("[gray]Create new application[/]");
        string companyNameInput = AnsiConsole.Ask<string>($"[green]Enter Company Name:[/] ");

        // if company name does not exist, prompt user to make new company
        bool companyExists = false;
        foreach (var company in companies)
        {
            if (company.Name == companyNameInput)
            {
                companyExists = true;
            }
        }
        if (!companyExists)
        {
            AnsiConsole.MarkupLine("[red]company does not exists.[/]");
            if (AnsiConsole.Confirm("Create company now? Press N to skip."))
            {
                AnsiConsole.MarkupLine("[gray]Create company[/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[gray]skipping...[/]");
            }
        }

        string currentStatus = AnsiConsole.Ask<string>($"[green]Enter Current Status:[/] ");
        string jobDescription = AnsiConsole.Ask<string>($"[green]Enter Job Description:[/] ");
        JobApplication jobApp = new()
        {
            CompanyName = companyNameInput,
            CurrentStatus = currentStatus,
            JobDescription = jobDescription
        };
        if (AnsiConsole.Confirm("Save new application?"))
        {
            await AnsiConsole.Status()
                .StartAsync("Fetching data...", async ctx =>
                {
                    // await Task.Delay(2000);
                    await myController.InsertNewApplication(jobApp);
                });

        }
        else AnsiConsole.MarkupLine("Aborted");
        await MainMenuWithConfirm();
    }
    public async Task DisplayApplicationSchedule()
    {




        AnsiConsole.MarkupLine("applications schedule");
        DateTime date = DateTime.Today;



        // get application dates




        // string year = date.ToShortDateString();
        int month = date.Month;
        int year = date.Year;
        int day = date.Day;
        AnsiConsole.MarkupLine($"{year}");
        var calendar = new Calendar(year, month)
            // .AddCalendarEvent(year, month, 15)
            // .AddCalendarEvent(year, month, 20)
            // .AddCalendarEvent(year, month, day)
            // .AddCalendarEvent(year, month, day-1)
            // .AddCalendarEvent(year, month, day+1)
            .HighlightStyle(Style.Parse("yellow bold"));
        var applications = await myController.GetAllApplications();
        foreach (var jobApp in applications)
        {
            int jobAppStatusMonth = jobApp.CurrentStatusDate.Month;
            int jobAppStatusYear = jobApp.CurrentStatusDate.Year;
            int jobAppStatusDay = jobApp.CurrentStatusDate.Day;
            if (jobAppStatusMonth == month && jobAppStatusYear == year)
            {
                calendar.AddCalendarEvent(year, month, jobAppStatusDay);
            }
        }





        AnsiConsole.Write(calendar);
        AnsiConsole.MarkupLine($"{year}");

        await MainMenuWithConfirm();
    }
    public async Task DisplayApplicationDetails()
    {
        var applications = await myController.GetAllApplications();
        if (applications.Count <= 0)
        {
            AnsiConsole.MarkupLine("[red]Err: no applications[/]");
        }
        else
        {
            var jobApplicationRedirectOptions = new List<string> { };
            var jobApplicationDescriptionMap = new Dictionary<string, List<string>>();

            var header = new FigletText("App Details");
            AnsiConsole.Write(header);
            
            foreach (var jobApp in applications)
            {
                jobApplicationRedirectOptions.Add(jobApp.CompanyName);
                jobApplicationDescriptionMap[jobApp.CompanyName] = [jobApp.JobDescription, jobApp.CurrentStatus];
            }
            var companyName = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Select an application to view in detail[/]")
                    .PageSize(10)
                    .AddChoices(jobApplicationRedirectOptions));
            // await ClearDisplay();
            AnsiConsole.MarkupLine($"Company Name: [blue]{companyName}[/]");
            AnsiConsole.MarkupLine($"application current_status: [blue]{jobApplicationDescriptionMap[companyName][1]}[/]");
            AnsiConsole.MarkupLine($"--Company Description--");
            AnsiConsole.MarkupLine($"{jobApplicationDescriptionMap[companyName][0]}");
            // 
            if (AnsiConsole.Confirm("Update status?"))
            {
                string newStatus = AnsiConsole.Ask<string>($"[green]New Status:[/] ");
                DateTime newStatusDate = AnsiConsole.Ask<DateTime>($"[green]Date:[/] ");
                AnsiConsole.MarkupLine($"new status: {newStatus}");
                AnsiConsole.MarkupLine($"new status date: {newStatusDate}");
                await myController.UpdateApplicationStatus(companyName, newStatus);
            }














        }
        AnsiConsole.Write(new Rule("[blue]End[/]"));
        await MainMenuWithConfirm();
    }
    private async Task DisplayCompanyInformationTable(List<CompanyInformation> companies)
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
                jobApp.CurrentStatusDate.ToShortDateString(),
                jobApp.JobDescription.Substring(0, previewLength)
            );
        }
        AnsiConsole.Write(applicationsTable);
    }
}