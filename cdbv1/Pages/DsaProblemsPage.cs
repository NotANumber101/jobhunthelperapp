using System;
using cdbv1.Models;
using Spectre;
using Spectre.Console;
using cdbv1.Helpers;
using Npgsql;
using Microsoft.Extensions.Logging;
using cdbv1.Controllers;

//test commit

namespace cdbv1.Pages;

public class DsaProblemsPage() : Page

{
    MyController myController = new();

    public async Task Display()

    {
        AnsiConsole.MarkupLine($"[gray]DSA Problems[/]");
        await GetAllDsaProblems();
        await NavigateDsaProblemsPage();
    }
    private async Task<IEnumerable<DsaProblem>> FilterProblems(string difficultyIso, string topicIso)
    {
        var dsaProblems = await myController.GetAllDsaProblems();

        IEnumerable<DsaProblem> problemQuery =
            from problem in dsaProblems
            where problem.Difficulty == difficultyIso
            where problem.Topic == topicIso
            select problem;
        return problemQuery;
    }
    private async Task NavigateDsaProblemsPage()
    {
        // AnsiConsole.Clear();
        // HelloWorld();
        ///////// TODO
        /// 1. View Solutions page.
        ///           -> Shows list of all problems, select which one, to load solutions for that problem
        ///           -> Solutions also show post mortem
        var pageOptions = new List<string> { "View Problems", "Solve Problem", "Main Menu" };
        var pageChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select a page to view:")
                .PageSize(10)
                .AddChoices(pageOptions));
        if (pageChoice == "View Problems")
        {
            AnsiConsole.MarkupLine($"[gray]View Problems[/]");
            DisplayProblemsBarChart();
            var dsaProblems = await myController.GetAllDsaProblems(); 
            DisplayProblemsTable(dsaProblems, false);
            await MainMenuWithConfirm();
        }
        else if (pageChoice == "Solve Problem")
        {
            AnsiConsole.MarkupLine($"[gray]Solve Problems[/]");
            IEnumerable<DsaProblem> filteredProblems = await DisplaySelectProblemFilter();
            if (AnsiConsole.Confirm("Stale only?"))
            {
                DisplayProblemsTable(filteredProblems, true);
            }
            else
            {
                DisplayProblemsTable(filteredProblems, false);
            }
            if (AnsiConsole.Confirm("Ready?"))
            {
                if (filteredProblems.Any())
                {
                    DsaProblem randomProblem = filteredProblems.ElementAt(0);
                    await DisplayProblem(randomProblem);

                    await CreateNewSolutionInput(randomProblem.Id);
                    await MainMenuWithConfirm();

                    // MainMenuWithConfirm();

                }
                else
                {
                    AnsiConsole.MarkupLine("[red]No Problems found. Please Try again.[/]");
                    await NavigateDsaProblemsPage();
                }
            }
            else
            {
                await NavigateDsaProblemsPage();
                // AnsiConsole.MarkupLine("[red]returning to problem selection tool...[/]");
            }
        }
        else if (pageChoice == "Main Menu")
        {
            await MainMenu();
        }
    }
    private async Task DisplayProblem(DsaProblem problem)
    {
        AnsiConsole.MarkupLine("[red] Starting... new problem[/]");
        AnsiConsole.MarkupLine($"ProblemID: {problem.Id} | Name: [green]{problem.Name}[/]");
        AnsiConsole.MarkupLine($"Difficulty: {problem.Difficulty} | Topic: [green]{problem.Topic}[/]");
        AnsiConsole.WriteLine("");
        Console.WriteLine($"Description:{problem.Description}");
        AnsiConsole.WriteLine("");
    }
    private async Task GetAllDsaProblems()
    {
        var res = await myController.GetAllDsaProblems();
    }
    private async Task CreateNewSolutionInput(int problemId)
    {
        string solution = AnsiConsole.Ask<string>($"[green]Please enter your solution: [/]");
        ////// TODO
        /// POST MORTEM
        string pmMistakes = AnsiConsole.Ask<string>($"[green]Post-Mortem | Mistakes:[/] ");
        string pmAnalysis = AnsiConsole.Ask<string>($"[green]Post-Mortem | Analysis:[/] ");
        int pmRubricCodingScore = 0;
        int pmRubricCommunicationScore = 0;
        int pmRubricProblemSolvingScore = 0;
        int pmRubricVerificationScore = 0;

        PostMortem postMortem = new()
        {
            DesignTimeMs = 10000,
            CodeTimeMs = 60000,
            Mistakes = pmMistakes,
            Analysis = pmAnalysis,
            RubricCodingScore = pmRubricCodingScore,
            RubricCommunicationScore = pmRubricCommunicationScore,
            RubricProblemSolvingScore = pmRubricProblemSolvingScore,
            RubricVerificationScore = pmRubricVerificationScore
        };
        await myController.InsertNewSolution(problemId, solution, postMortem);
    }
    private static void DisplayProblemsTable(IEnumerable<DsaProblem> problems, bool staleOnly)
    {
        var problemsTable = new Table().ShowRowSeparators();
        problemsTable.AddColumn("Name");
        problemsTable.AddColumn("Difficulty");
        problemsTable.AddColumn("Topic");
        problemsTable.AddColumn("DateCompleted");
        foreach (var problem in problems)
        {
            if (staleOnly)
            {
                if (IsStale(problem))
                {
                    problemsTable.AddRow(
                        problem.Name,
                        problem.Difficulty,
                        problem.Topic,
                        problem.DateCompleted.ToString()
                    );
                }
            }
            else
            {
                problemsTable.AddRow(
                    problem.Name,
                    problem.Difficulty,
                    problem.Topic,
                    problem.DateCompleted.ToString()
                );
            }
        }
        AnsiConsole.Write(problemsTable);
    }
    private static bool IsStale(DsaProblem problem)
    {
        DateTime thisDay = DateTime.Today;
        if (problem != null)
        {
            if ((problem.DateCompleted - thisDay).TotalDays < -14)
            {
                return true;
            }
        }
        return false;
    }
    private async  Task<IEnumerable<DsaProblem>> DisplaySelectProblemFilter()
    {
        // TODO: add lazy option
        // this means that the first option will bypass all other options,
        // allowing the user to quickly tap, enter, enter, enter to get to a problem.
        // TODO: add any option
        // var difficultyFilterOptions = new List<string> { "easy", "medium", "hard", "add new"};
        var difficultyFilterOptions = new List<string> { "easy", "medium", "hard" };
        var difficultyFilterSelected = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select difficulty")
                .PageSize(10)
                .AddChoices(difficultyFilterOptions));
        // option: select completed with in certain time window
        // TODO: add select multiple option
        // TODO: add any option
        var topicFilterOptions = new List<string> { "string", "array", "two pointers",
        "sliding window", "stack", "binary search", "linked list",
        "tree", "heap", "backtracking", "tries", "graphs", "1D dynamic programming",
        "2D dynamic programming", "greedy", "intervals", "math and geometry", "bit manipulation"};
        var topicFilterSelected = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select topic")
                .PageSize(10)
                .AddChoices(topicFilterOptions));
        AnsiConsole.MarkupLine($"[blue]Your selected options: {difficultyFilterSelected} | {topicFilterSelected}[/]");
        // hard coded for now
        return await FilterProblems(difficultyFilterSelected, topicFilterSelected);
        // return dsaProblems[0];
    }
 
    private async Task DisplayProblemsBarChart()
    {
        var dsaProblems = await myController.GetAllDsaProblems();
        List<DsaProblem> easySet = new() { };
        List<DsaProblem> mediumSet = new() { };
        List<DsaProblem> hardSet = new() { };
        // testing out this filter method for the hard set.
        // But perhaps it makes more sense to filter in one pass
        // List<DsaProblem> hardSet = FilterProblemSetByDifficulty("hard");
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
                hardSet.Add(problem);
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