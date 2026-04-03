using System;
using cdbv1.Models;
using Spectre;
using Spectre.Console;

public class NetworkPage(List<CompanyInformation> companies, List<JobApplication> jobApplications, List<DsaProblem> dsaProblems)
{
    public void Display()
    {
        // TODO: messages
        // TODO: contacts
        AnsiConsole.MarkupLine($"[gray]NETWORK PAGE[/]");
        AnsiConsole.MarkupLine($"[gray]Coming soon...[/]");
        // this name is stupid: should be ReturnToMainMenuPrompt
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
}