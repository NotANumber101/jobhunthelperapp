using System;
using cdbv1.Models;
using Spectre;
using Spectre.Console;

public class ApplicationsPage(List<CompanyInformation> companies, List<JobApplication> jobApplications, List<DsaProblem> dsaProblems)
{
    // Initialize capacity field to a default value of 10:
    private int _capacity = 10;
    private List<CompanyInformation> companies = companies;
    private List<JobApplication> jobApplications = jobApplications;
    public void Display()
    {
        // view all companies
        DisplayCompanyInformationTable();
        // view all applications
        DisplayApplicationsTable();
        ReturnToMainMenu();
    }
    private void ReturnToMainMenu()
    {
        if (AnsiConsole.Confirm("Return to main menu?"))
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[gray]Returning to main menu...[/]");
            MainMenuPage mainMenuPage = new MainMenuPage(companies, jobApplications, dsaProblems);
            mainMenuPage.Display();

        }
    }
    private void AddNewApplication()
    {
        // select company (spectre select)
        // if company not in list
        // add company 
        // else add companyid to application model
        // build application model
        // try push application to db
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