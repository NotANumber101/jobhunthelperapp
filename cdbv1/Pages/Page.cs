using System;
using cdbv1.Models;
using Spectre;
using Spectre.Console;
using cdbv1.Helpers;
using Npgsql;
using Microsoft.Extensions.Logging;

namespace cdbv1.Pages;

public class Page()

{
    static Page()
    {
        // Console.WriteLine("TeST Page should log every page");
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
                ApplicationsPage applicationsPage = new();
                await applicationsPage.Display();
            }
            else if (pageChoice == "Network")
            {
                NetworkPage networkPage = new();
                await networkPage.Display();
            }
            else if (pageChoice == "DSA Problems")
            {
                DsaProblemsPage dsaProblemsPage = new();
                await dsaProblemsPage.Display();
            }
            else if (pageChoice == "DSA Review")
            {
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