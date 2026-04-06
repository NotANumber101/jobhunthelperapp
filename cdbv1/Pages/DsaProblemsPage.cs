using System;
using System.Timers;
using cdbv1.Models;
using Spectre;
using Spectre.Console;
using cdbv1.Helpers;

public class DsaProblemsPage(List<CompanyInformation> companies, List<JobApplication> jobApplications, List<DsaProblem> dsaProblems)
{
    // private static System.Timers.Timer aTimer;
    private static CustomTimer aTimer = new CustomTimer(100);


    public void Display()
    {
        AnsiConsole.MarkupLine($"[gray]DSA Problems[/]");
        // todo: multiselect -> breakdown problems by a. diffuclty b. type. attempted/notattempted
        NavigateDsaProblemsPage();
    }
    private IEnumerable<DsaProblem> FilterProblemLinq(string difficultyIso, string topicIso)
    {
        // Specify the data source.
        // int[] scores = [97, 92, 81, 60];

        // Define the query expression.
        IEnumerable<DsaProblem> scoreQuery =
            from problem in dsaProblems
            where problem.Difficulty == difficultyIso
            where problem.Topic == topicIso
            select problem;

        // Execute the query.
        foreach (var i in scoreQuery)
        {
            Console.WriteLine(i.Name + " ");
        }

        return scoreQuery;

        // Output: 97 92 81
    }
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
            DisplayProblemsBarChart();
            DisplayProblemsTable();
        }
        else if (pageChoice == "Solve Problem")
        {
            AnsiConsole.MarkupLine($"[gray]Solve Problems[/]");

            IEnumerable<DsaProblem> problems = SelectProblemFilter();
            foreach(var problem in problems)
            {
                            AnsiConsole.MarkupLine($"[blue]Problem: {problem.Name}[/]");
            AnsiConsole.MarkupLine($"[blue]{problem.Description}[/]");
            }
            AnsiConsole.MarkupLine("[red]Timer: 10m[/]");

            // timer
            int tenMinute = 60000 * 10;
            // CustomTimer timer = new CustomTimer(tenMinute);
            // aTimer = new CustomTimer(tenMinute);
            if (AnsiConsole.Confirm("Start timer?"))
            {
                AnsiConsole.Clear();
                // AnsiConsole.MarkupLine($"[blue]{.Description}[/]");
                aTimer.SolutionTimer();
            }
        }
        else if (pageChoice == "Main Menu")
        {
            ReturnToMainMenu();
        }
    }
    private void DisplayProblemsTable()
    {
        var problemsTable = new Table().ShowRowSeparators();
        problemsTable.AddColumn("Name");
        foreach (var problem in dsaProblems)
        {
            problemsTable.AddRow(
                problem.Name
            );
        }
        AnsiConsole.Write(problemsTable);
    }
    private IEnumerable<DsaProblem> SelectProblemFilter()
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
        return FilterProblemLinq(difficultyFilterSelected, topicFilterSelected);
        // return dsaProblems[0];
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
            else if (problem.Difficulty.ToLower() == "hard")
            {
                continue;
            }
            else
            {
                AnsiConsole.WriteLine($"DsaProblem:{problem.Name} has Unknown Difficulty");
            }
        }
        AnsiConsole.Write(new BarChart()
            .Label("[green]Problems[/]")
            .AddItem("Easy", easySet.Count, Color.Green)
            .AddItem("Medium", mediumSet.Count, Color.Yellow)
            .AddItem("Hard", hardSet.Count, Color.Red));
    }
}