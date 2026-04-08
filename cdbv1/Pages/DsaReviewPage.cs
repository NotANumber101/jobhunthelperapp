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
        .AddChoices("string", "array", "recursion", "graph", "bigo"));

        AnsiConsole.MarkupLine($"[gray]{DsaReviewPageChoice.ToUpper()} Review[/]");

        ///////// TODO
        /// Switch statements will look nice here
        if (DsaReviewPageChoice == "string")
        {
            await StringReviewPage();
        }
        else
        {
            Console.WriteLine("WARN: This page is incomplete");
        }
        await MainMenuWithConfirm();
    }
    public async Task StringReviewPage()
    {
        
    }
    public async Task NavigateTopicPage()
    {

    }
}