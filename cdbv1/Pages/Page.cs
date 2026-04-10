using System;
using Spectre;
using Spectre.Console;
using Npgsql;

namespace cdbv1.Pages;

public class Page()

{
    public async Task MainMenuWithConfirm()
    {
        if (AnsiConsole.Confirm("Return to main menu?"))
        {
            await ClearDisplay();
            AnsiConsole.MarkupLine("[gray]Returning to main menu...[/]");
            await MainMenu();
        }
    }
    public async Task MainMenu()
    {
        var pageOptions = new List<string> { "Applications", "Network", "DSA Problems", "DSA Review" };
        var pageChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[green]Select a page to view:[/]")
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
    public async Task HelloWorld()
    {
        AnsiConsole.MarkupLine("[red]HELLO WORLD[/], log from Page().HelloWorld()");
    }
    public async Task ClearDisplay()
    {
        AnsiConsole.Clear();
    }

}