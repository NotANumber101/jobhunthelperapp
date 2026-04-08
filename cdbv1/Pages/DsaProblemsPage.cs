using System;
using cdbv1.Models;
using Spectre;
using Spectre.Console;
using cdbv1.Helpers;
using Npgsql;
using Microsoft.Extensions.Logging;

namespace cdbv1.Pages;

public class DsaProblemsPage() : Page

{
    List<DsaProblem> dsaProblems = [];
    public async Task Display()

    {

        AnsiConsole.MarkupLine($"[gray]DSA Problems[/]");
        await GetAllDsaProblems();
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
        // AnsiConsole.Clear();
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
            await MainMenuWithConfirm();
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
                    try
                    {
                        await CreateNewSolution(randomProblem.Id, solution, postMortem);
                        await MainMenuWithConfirm();
                    }
                    catch (NpgsqlException e)
                    {
                        Console.Write(e.Message);
                    }
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
    private async Task GetAllDsaProblems()
    {
        try
        {
            DbInfoController dbIc = new();
            var dbsb = new DbSourceBuilder("localhost");
            await using var dataSource = dbsb.Builder().Build();
            AnsiConsole.MarkupLine("[gray]Fetching data...[/]");
            AnsiConsole.MarkupLine("    -> [gray]Fetching dsa_problems...[/]");
            await using (var cmd = dataSource.CreateCommand("SELECT * FROM dsa_problem"))
            await using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    DsaProblem dsaProblem = new(
                        reader.GetInt32(0), reader.GetString(1),
                        reader.GetString(2), reader.GetString(3),
                        reader.GetString(4), reader.GetDateTime(5)
                    );
                    dsaProblems.Add(dsaProblem);
                }
            AnsiConsole.MarkupLine($"        -> [green]Done. {dsaProblems.Count}[/]");
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
        }
    }
    private async Task CreateNewSolution(int problemId, string solution, PostMortem postMortem)
    {
        try
        {
            DbInfoController dbIc = new();
            var dbsb = new DbSourceBuilder("localhost");
            await using var dataSource = dbsb.Builder().Build();
            AnsiConsole.MarkupLine("[gray]Inserting data...[/]");
            AnsiConsole.MarkupLine("    -> [gray]Inserting new solution...[/]");
            await using var connection = await dataSource.OpenConnectionAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            await using var command1 = new NpgsqlCommand(dbIc.CreateNewDsaSolution(problemId, solution), connection, transaction);
            int solutionId = (int)command1.ExecuteScalar();

            postMortem.SolutionId = solutionId;

            Console.WriteLine($"SolutionId: {solutionId} inserted!");
            // await command1.ExecuteNonQueryAsync();
            // var cmd = new NpgsqlCommand("UPDATE foo SET bar=@bar WHERE baz=@baz; UPDATE foo SET bar=@bar WHERE baz=@baz");
            await using var command2 = new NpgsqlCommand(dbIc.UpdateDsaProblemDateCompletedTodayId(problemId), connection, transaction);
            await command2.ExecuteNonQueryAsync();


            await using var command3 = new NpgsqlCommand(
                $"INSERT INTO dsa_postmortem (solution_id, design_time_ms, code_time_ms, mistakes, analysis, rubric_problem_solving_score, rubric_coding_score, rubric_verification_score, rubric_communication_score) VALUES ({solutionId}, {postMortem.DesignTimeMs}, {postMortem.CodeTimeMs}, '{postMortem.Mistakes}', '{postMortem.Analysis}', {postMortem.RubricCodingScore}, {postMortem.RubricCommunicationScore}, {postMortem.RubricProblemSolvingScore}, {postMortem.RubricVerificationScore});",
            connection, transaction);
            // WOW IM DUMB AS FUCK. I spent an hour debuging this bull fuck.
            // I was connected to command2.
            // I should have been conneted to command3 which is the command im making. Dum,b asss.
            await command3.ExecuteNonQueryAsync();

            await transaction.CommitAsync();
            AnsiConsole.MarkupLine($"        -> [green]Done.[/][gray]ProblemId:{problemId} has new solution.[/]");
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
        }

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