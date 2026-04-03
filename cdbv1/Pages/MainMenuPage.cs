using System;
using cdbv1.Models;
using Spectre;
using Spectre.Console;

public class MainMenuPage(List<CompanyInformation> companies, List<JobApplication> jobApplications, List<DsaProblem> dsaProblems)
{
    public void Display()
    {
        var pageOptions = new List<string> { "Applications", "Network", "DSA Problems", "DSA Review" };
        var pageChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select a page to view:")
                .PageSize(10)
                .AddChoices(pageOptions));
        
        if (pageChoice == "Applications")
        {
            ApplicationsPage applicationsPage = new ApplicationsPage(companies, jobApplications, dsaProblems);
            applicationsPage.Display();
        }
        else if (pageChoice == "Network")
        {
            NetworkPage networkPage = new NetworkPage(companies, jobApplications, dsaProblems);
            networkPage.Display();
        }
        else if (pageChoice == "DSA Problems")
        {
            // this is what im talking about...
            // repeat on repeat.  gross
            DsaProblemsPage dsaProblemsPage = new DsaProblemsPage(companies, jobApplications, dsaProblems);
            dsaProblemsPage.Display();
        }
        else if (pageChoice == "DSA Review")
        {
            DsaReviewPage dsaReviewPage = new DsaReviewPage(companies, jobApplications, dsaProblems);
            dsaReviewPage.Display();
        }
        else
        {
            AnsiConsole.MarkupLine($"[gray]Unknown page[/]");
        }
    }
}   