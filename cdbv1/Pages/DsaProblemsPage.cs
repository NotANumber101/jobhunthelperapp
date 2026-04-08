using System;
using cdbv1.Models;
using Spectre;
using Spectre.Console;
using cdbv1.Helpers;
using Npgsql;
using Microsoft.Extensions.Logging;

using cdbv1.Pages;
namespace cdbv1.Pages;

// public class DsaProblemsPage(List<CompanyInformation> companies, List<JobApplication> jobApplications, List<DsaProblem> dsaProblems)
public class DsaProblemsPage(List<CompanyInformation> companies, List<JobApplication> jobApplications, List<DsaProblem> dsaProblems) : Page

{
    public async Task Display()
    {
        AnsiConsole.MarkupLine($"[gray]DSA Problems[/]");
        await NavigateDsaProblemsPage();
    }
    private IEnumerable<DsaProblem> FilterProblems(string difficultyIso, string topicIso)
    {
        IEnumerable<DsaProblem> problemQuery =
            from problem in dsaProblems
            where problem.Difficulty == difficultyIso
            where problem.Topic == topicIso
            select problem;
        return problemQuery;
    }
    private async Task NavigateDsaProblemsPage()
    {
        AnsiConsole.Clear();
        HelloWorld();
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
            DisplayProblemsTable(dsaProblems, false);
        }
        else if (pageChoice == "Solve Problem")
        {
            AnsiConsole.MarkupLine($"[gray]Solve Problems[/]");
            IEnumerable<DsaProblem> filteredProblems = DisplaySelectProblemFilter();
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
                    AnsiConsole.Clear();
                    AnsiConsole.MarkupLine("[red] Starting... new problem[/]");
                    DsaProblem randomProblem = filteredProblems.ElementAt(0);
                    AnsiConsole.MarkupLine($"ProblemID: {randomProblem.Id} | Name: [green]{randomProblem.Name}[/]");
                    AnsiConsole.MarkupLine($"Difficulty: {randomProblem.Difficulty} | Topic: [green]{randomProblem.Topic}[/]");
                    AnsiConsole.WriteLine("");
                    Console.WriteLine($"Description:{randomProblem.Description}");
                    AnsiConsole.WriteLine("");
                    AnsiConsole.WriteLine("Example:");
                    AnsiConsole.MarkupLine($"[green]Data[/]");
                    string solution = AnsiConsole.Ask<string>($"[green]Please enter your solution: [/]");
                    ////// TODO
                    /// POST MORTEM
                    string postmortem = AnsiConsole.Ask<string>($"[green]Postmortem: [/]");
                    try
                    {
                        await CreateNewSolution(randomProblem.Id, solution);
                    } catch (NpgsqlException e)
                    {
                        Console.Write(e.Message);
                    }

                }
                else
                {
                    AnsiConsole.MarkupLine("[red]No Problems found. Please Try again.[/]");
                }
            }
            else
            {
                await NavigateDsaProblemsPage();
                AnsiConsole.MarkupLine("[red]returning to problem selection tool...[/]");
            }
        }
        else if (pageChoice == "Main Menu")
        {
            await ReturnToMainMenu();
        }
    }
    private async Task CreateNewSolution(int problemId, string solution)
    {
        DbInfoController dbIc = new();
        var dbsb = new DbSourceBuilder("localhost");
        await using var dataSource = dbsb.Builder().Build();

        await using var connection = await dataSource.OpenConnectionAsync();
        await using var transaction = await connection.BeginTransactionAsync();

        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        // await using var command1 = new NpgsqlCommand($"INSERT INTO dsa_solution (problem_id, solution, date_completed) VALUES ({problemId}, '{solution}', '{today}');", connection, transaction);
        await using var command1 = new NpgsqlCommand(dbIc.CreateNewDsaSolution(problemId, solution), connection, transaction);
        await command1.ExecuteNonQueryAsync();
        // var cmd = new NpgsqlCommand("UPDATE foo SET bar=@bar WHERE baz=@baz; UPDATE foo SET bar=@bar WHERE baz=@baz");
        await using var command2 = new NpgsqlCommand(dbIc.UpdateDsaProblemDateCompletedTodayId(problemId), connection, transaction);
        await command2.ExecuteNonQueryAsync();

        await transaction.CommitAsync();
    }
    private void DisplayProblemsTable(IEnumerable<DsaProblem> problems, bool staleOnly)
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
    private bool IsStale(DsaProblem problem)
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
    private IEnumerable<DsaProblem> DisplaySelectProblemFilter()
    {
        var difficultyFilterOptions = new List<string> { "easy", "medium", "hard" };
        var difficultyFilterSelected = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select difficulty")
                .PageSize(10)
                .AddChoices(difficultyFilterOptions));
        // option: select completed with in certain time window
        // TODO: multi select
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
        return FilterProblems(difficultyFilterSelected, topicFilterSelected);
        // return dsaProblems[0];
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
            .AddItem("Hard", FilterProblemSetByDifficulty("hard").Count, Color.Red));
    }
}