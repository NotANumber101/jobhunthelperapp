using System;
using cdbv1.Models;
using Spectre;
using Spectre.Console;

using cdbv1;
namespace cdbv1.Pages;

public class DsaReviewPage(List<CompanyInformation> companies, List<JobApplication> jobApplications, List<DsaProblem> dsaProblems)
{
    public async Task Display()
    {

        // navigate
        var DsaReviewPageChoice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("[green]Please select topic[/]")
        .AddChoices("string", "array", "recursion", "graph", "bigo"));

        // CLEAR CONSOLE
        // AnsiConsole.Clear();
        AnsiConsole.MarkupLine($"[gray]{DsaReviewPageChoice} page[/]");

        if (DsaReviewPageChoice == "string")
        {

        }
        else
        {
            Console.WriteLine("err");
        }
        await ReturnToMainMenu();
    }
    private async Task ReturnToMainMenu()
    {
        if (AnsiConsole.Confirm("Return to main menu?"))
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[gray]Returning to main menu...[/]");
            MainMenuPage mainMenuPage = new MainMenuPage(companies, jobApplications, dsaProblems);
            await mainMenuPage.Display();

        }
    }
    public async Task NavigateTopicPage()
    {

    }
}


////////
/// 
/// 
/// what if i didnt need to pass the data to the menu page???
/// 
/// -- i wouldnt need to if i wasnt getting the data in the main()
/// 
/// -- so really, this is no big deal right now, because soon the 
/// 
/// -- application page will pull applications and main menu wont need to pass it
/// 
/// 
/// 
/// 
/// 
/// 