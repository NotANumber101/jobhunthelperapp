using System;
using cdbv1.Models;
using Spectre;
using Spectre.Console;

public class DsaReviewPage
{
    public void Display()
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
    }
}