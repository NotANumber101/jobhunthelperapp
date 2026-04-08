using System;
using cdbv1.Models;
using Spectre;
using Spectre.Console;

using cdbv1;
namespace cdbv1.Pages;

public class MainMenuPage(List<CompanyInformation> companies, List<JobApplication> jobApplications, List<DsaProblem> dsaProblems)
{
    readonly List<CompanyInformation> companies = companies;
    readonly List<JobApplication> jobApplications = jobApplications;
    readonly List<DsaProblem> dsaProblems = dsaProblems;
    public async Task Display()
    {
        var pageOptions = new List<string> { "Applications", "Network", "DSA Problems", "DSA Review" };
        var pageChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select a page to view:")
                .PageSize(10)
                .AddChoices(pageOptions));
        
        if (pageChoice == "Applications")
        {
            ApplicationsPage applicationsPage = new(companies, jobApplications, dsaProblems);
            await applicationsPage.Display();
        }
        else if (pageChoice == "Network")
        {
            NetworkPage networkPage = new(companies, jobApplications, dsaProblems);
            await networkPage.Display();
        }
        else if (pageChoice == "DSA Problems")
        {
            // this is what im talking about...
            // repeat on repeat.  gross
            DsaProblemsPage dsaProblemsPage = new(companies, jobApplications, dsaProblems);
            await dsaProblemsPage.Display();
        }
        else if (pageChoice == "DSA Review")
        {
            DsaReviewPage dsaReviewPage = new(companies, jobApplications, dsaProblems);
            await dsaReviewPage.Display();
        }
        else
        {
            AnsiConsole.MarkupLine($"[gray]Unknown page[/]");
        }
    }
}   