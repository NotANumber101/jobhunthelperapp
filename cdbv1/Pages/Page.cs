using System;
using cdbv1.Models;
using Spectre;
using Spectre.Console;
using cdbv1.Helpers;
using Npgsql;
using Microsoft.Extensions.Logging;

namespace cdbv1.Pages;




public class Page()
// public interface IPage()

{
    static Page()
    {
        Console.WriteLine("TeST Page should log every page");
    }
    public async Task MainMenu()
    {
        if (AnsiConsole.Confirm("Return to main menu?"))
        {
            ClearDisplay();
            AnsiConsole.MarkupLine("[gray]Returning to main menu...[/]");


            var pageOptions = new List<string> { "Applications", "Network", "DSA Problems", "DSA Review" };
            var pageChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select a page to view:")
                    .PageSize(10)
                    .AddChoices(pageOptions));

            if (pageChoice == "Applications")
            {
                // ApplicationsPage applicationsPage = new(companies, jobApplications, dsaProblems);
                ApplicationsPage applicationsPage = new();
                await applicationsPage.Display();
            }
            else if (pageChoice == "Network")
            {
                // NetworkPage networkPage = new(companies, jobApplications, dsaProblems);
                NetworkPage networkPage = new();
                await networkPage.Display();
            }
            else if (pageChoice == "DSA Problems")
            {
                // this is what im talking about...
                // repeat on repeat.  gross
                // DsaProblemsPage dsaProblemsPage = new(companies, jobApplications, dsaProblems);
                DsaProblemsPage dsaProblemsPage = new();
                await dsaProblemsPage.Display();
            }
            else if (pageChoice == "DSA Review")
            {
                // DsaReviewPage dsaReviewPage = new(companies, jobApplications, dsaProblems);
                DsaReviewPage dsaReviewPage = new();
                await dsaReviewPage.Display();
            }
            else
            {
                AnsiConsole.MarkupLine($"[gray]Unknown page[/]");
            }

        }

    }
    public static void HelloWorld()
    {
        AnsiConsole.MarkupLine("[red]HELLO WORLD[/], log from Page().HelloWorld()");
    }
    public static void ClearDisplay()
    {
        AnsiConsole.Clear();
    }

}