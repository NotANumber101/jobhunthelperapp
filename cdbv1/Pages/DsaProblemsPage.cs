using System;
using cdbv1.Models;
using Spectre;
using Spectre.Console;

public class DsaProblemsPage(List<DsaProblem> dsaProblems)
{
    public void Display()
    {
        AnsiConsole.MarkupLine($"[gray]DSA Problems[/]");
        // todo: multiselect -> breakdown problems by a. diffuclty b. type. attempted/notattempted
        this.DisplayProblemsBarChart();
        this.DisplayCompanyInformationTable();
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
            .Label("[green]Sales by Region[/]")
            .AddItem("Easy", easySet.Count + 10, Color.Blue)
            .AddItem("Medium", mediumSet.Count + 20, Color.Yellow)
            .AddItem("Hard", hardSet.Count + 14, Color.Green));
    }

    private void DisplayCompanyInformationTable()
    {
        var companiesTable = new Table().ShowRowSeparators();
        companiesTable.AddColumn("Id");
        companiesTable.AddColumn("Name");
        companiesTable.AddColumn("Description");
        companiesTable.AddColumn("Difficulty");
        companiesTable.AddColumn("Topic");
        foreach (var problem in dsaProblems)
        {
            companiesTable.AddRow(
                problem.Id.ToString(),
                problem.Name,
                problem.Description,
                problem.Difficulty,
                problem.Topic
            );
        }
        AnsiConsole.Write(companiesTable);
    }
}