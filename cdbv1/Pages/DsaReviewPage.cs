using System;
using cdbv1.Models;
using Spectre;
using Spectre.Console;

namespace cdbv1.Pages;

public class DsaReviewPage() : Page
{
    public async Task Display()
    {
        var DsaReviewPageChoice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("[green]Please select topic[/]")
        .AddChoices("problem solving boosters", "string"));

        AnsiConsole.MarkupLine($"[gray]{DsaReviewPageChoice.ToUpper()} Review[/]");

        ///////// TODO
        /// Switch statements will look nice here
        /// 
        if (DsaReviewPageChoice == "problem solving boosters")
        {
            ProblemSolvingBoostersReviewPage();
        }
        else if (DsaReviewPageChoice == "string")
        {
            StringReviewPage();
        }
        else
        {
            Console.WriteLine("WARN: This page is incomplete");
        }
        await MainMenuWithConfirm();
    }
    public static void ProblemSolvingBoostersReviewPage()
    {
        AnsiConsole.MarkupLine("[red]Reusable Ideas[/]");
        AnsiConsole.MarkupLine("[black]Transform The Input[/]");
        AnsiConsole.MarkupLine("[gray]... coming soon[/]");
        AnsiConsole.MarkupLine("[black]Length-26 Array[/]");
        AnsiConsole.MarkupLine("[gray]... coming soon[/]");
    }
    public static void StringReviewPage()
    {
        AnsiConsole.MarkupLine("[red]Reusable Ideas - String[/]");
        AnsiConsole.MarkupLine("[black]Building Strings With Dynamic Arrays[/]");
        AnsiConsole.MarkupLine("[gray]Check if strings are mutable in your language of choice. If you need to build a string character by character, and the strings in your langauge are immutabl;e, put the characters in a dynamic array instead. When you are done, convert the array to a string with the built-in JOIN method.[/]");
    }
    public static void TwoPointersReviewPage()
    {
        AnsiConsole.MarkupLine("[red]Reusable Ideas - Two Pointers[/]");
        AnsiConsole.MarkupLine("[black]Search With Inward Pointers[/]");
        AnsiConsole.MarkupLine("[gray]... coming soon[/]");
    }
        public static void GridsAndMatrices()
    {
        AnsiConsole.MarkupLine("[red]Reusable Ideas[/]");
        AnsiConsole.MarkupLine("[black]... coming soon[/]");
        AnsiConsole.MarkupLine("[gray]... coming soon[/]");
    }
            public static void BinarySearch()
    {
        AnsiConsole.MarkupLine("[red]Reusable Ideas[/]");
        AnsiConsole.MarkupLine("[black]... coming soon[/]");
        AnsiConsole.MarkupLine("[gray]... coming soon[/]");
    }
    
    /////// use SomeReviewPage as template to get started when creating new review page.
    public static void SomeReviewPage()
    {
        AnsiConsole.MarkupLine("[red]Reusable Ideas[/]");
        AnsiConsole.MarkupLine("[black]... coming soon[/]");
        AnsiConsole.MarkupLine("[gray]... coming soon[/]");
    }
    public async Task NavigateTopicPage()
    {

    }
}