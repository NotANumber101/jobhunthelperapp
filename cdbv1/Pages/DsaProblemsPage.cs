using System;
using System.Timers;
using cdbv1.Models;
using Spectre;
using Spectre.Console;
using cdbv1.Helpers;

public class DsaProblemsPage(List<CompanyInformation> companies, List<JobApplication> jobApplications, List<DsaProblem> dsaProblems)
{
    // private static System.Timers.Timer aTimer;
    private static CustomTimer aTimer;


    public void Display()
    {
        AnsiConsole.MarkupLine($"[gray]DSA Problems[/]");
        // todo: multiselect -> breakdown problems by a. diffuclty b. type. attempted/notattempted
        DisplayProblemsBarChart();

        NavigateDsaProblemsPage();

    }
    // TODO: Parent class: Page.method return to main menu
    // because too much repeated code.
    private async Task NavigateDsaProblemsPage()
    {
        var pageOptions = new List<string> { "Add New Problem", "View Problems", "Solve Problem", "Main Menu" };
        var pageChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select a page to view:")
                .PageSize(10)
                .AddChoices(pageOptions));

        if (pageChoice == "Add New Problem")
        {
            AnsiConsole.MarkupLine($"[gray]Add New Problem[/]");
            AnsiConsole.MarkupLine($"[gray]Coming soon...[/]");

        }
        else if (pageChoice == "View Problems")
        {
            AnsiConsole.MarkupLine($"[gray]View Problems[/]");
            AnsiConsole.MarkupLine($"[gray]Coming soon...[/]");

        }
        else if (pageChoice == "Solve Problem")
        {

            // Random randomizer = new Random();
            AnsiConsole.MarkupLine($"[gray]Solve Problems[/]");

            DsaProblem selectedProblem = SelectProblemFilter();

            AnsiConsole.MarkupLine($"[blue]Problem: {selectedProblem.Name}[/]");
            AnsiConsole.MarkupLine($"{selectedProblem.Description}");

            // use selections to buld LINQ query

            // print list size. ie 20 problems found matching filter!
            // pick problem

            // todo: implement spectre timer



            // timer and display problem
            int tenMinute = 60000 * 10;
            // CustomTimer timer = new CustomTimer(tenMinute);
            aTimer = new CustomTimer(tenMinute);
            AnsiConsole.MarkupLine("Timer: 10m");
            if (AnsiConsole.Confirm("Start timer?"))
            {
                aTimer.SolutionTimer();
            }

            // fix layout
            // TODO Move counter into a grid layout



        }
        else if (pageChoice == "Main Menu")
        {
            ReturnToMainMenu();
        }
        // NavigateDsaProblemsPage();
    }

    private DsaProblem SelectProblemFilter()
    {
        var difficultyFilterOptions = new List<string> { "easy", "medium", "hard" };
        var difficultyFilterSelected = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select difficulty")
                .PageSize(10)
                .AddChoices(difficultyFilterOptions));

        // option: select completed with in certain time window

        // TODO: multi select
        var topicFilterOptions = new List<string> { "string", "array", "graph", "random" };
        var topicFilterSelected = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select topic")
                .PageSize(10)
                .AddChoices(topicFilterOptions));
        AnsiConsole.MarkupLine($"[blue]Your selected options: {difficultyFilterSelected} | {topicFilterSelected}[/]");
        // hard coded for now
        return dsaProblems[0];
    }
    private void ReturnToMainMenu()
    {
        if (AnsiConsole.Confirm("Return to main menu?"))
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[gray]Returning to main menu...[/]");
            // todo: there is way too much data being passed around. This is okay for now, mvp
            // THIS IS A PROBLEMMMMMMM. I DONT WANT TO KEEEP HAVING TO PASS ALL THIS DATA.
            // naturally this will fall into place. when pages handle their own data, rather than
            // what is happening now. which sucks, passing through the main menu page.
            MainMenuPage mainMenuPage = new MainMenuPage(companies, jobApplications, dsaProblems);
            mainMenuPage.Display();

        }
    }
    private List<DsaProblem> FilterProblemSetByDifficulty(string diffuclty)
    {
        List<DsaProblem> difficultSet = new() { };
        foreach (var problem in dsaProblems)
        {
            if (problem != null)
            {
                // todo switch enum statement
                if (problem.Difficulty == diffuclty)
                {
                    difficultSet.Add(problem);
                }
                else
                {
                    continue;
                }
            }
        }

        return difficultSet;
    }
    private void DisplayProblemsBarChart()
    {
        //
        List<DsaProblem> easySet = new() { };
        List<DsaProblem> mediumSet = new() { };
        // testing out this filter method for the hard set.
        // But perhaps it makes more sense to filter in one pass
        // TODO LINQ
        List<DsaProblem> hardSet = FilterProblemSetByDifficulty("hard");
        // sort problems 
        foreach (var problem in dsaProblems)
        {
            // todo switch enum statement
            if (problem.Difficulty.ToLower() == "easy")
            {
                easySet.Add(problem);
            }
            else if (problem.Difficulty.ToLower() == "medium")
            {
                mediumSet.Add(problem);
            }
            else
            {
                AnsiConsole.WriteLine("DsaProblem: Unknown Difficulty");
            }
        }
        // incraseing count manually to simulate larger data set
        AnsiConsole.Write(new BarChart()
            .Label("[green]Problems[/]")
            .AddItem("Easy", easySet.Count + 10, Color.Blue)
            .AddItem("Medium", mediumSet.Count + 20, Color.Yellow)
            .AddItem("Hard", hardSet.Count + 14, Color.Green));
    }
}






//    public static void Main()
//    {
//       SetTimer();

//       Console.WriteLine("\nPress the Enter key to exit the application...\n");
//       Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
//       Console.ReadLine();
//       aTimer.Stop();
//       aTimer.Dispose();

//       Console.WriteLine("Terminating the application...");
//    }

//    private static void SetTimer()
//    {
//         // Create a timer with a two second interval.
//         aTimer = new System.Timers.Timer(2000);
//         // Hook up the Elapsed event for the timer. 
//         aTimer.Elapsed += OnTimedEvent;
//         aTimer.AutoReset = true;
//         aTimer.Enabled = true;
//     }

//     private static void OnTimedEvent(Object source, ElapsedEventArgs e)
//     {
//         Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
//                           e.SignalTime);
//     }

// The example displays output like the following:
//       Press the Enter key to exit the application...
//
//       The application started at 09:40:29.068
//       The Elapsed event was raised at 09:40:31.084
//       The Elapsed event was raised at 09:40:33.100
//       The Elapsed event was raised at 09:40:35.100
//       The Elapsed event was raised at 09:40:37.116
//       The Elapsed event was raised at 09:40:39.116
//       The Elapsed event was raised at 09:40:41.117
//       The Elapsed event was raised at 09:40:43.132
//       The Elapsed event was raised at 09:40:45.133
//       The Elapsed event was raised at 09:40:47.148
//
//       Terminating the application...