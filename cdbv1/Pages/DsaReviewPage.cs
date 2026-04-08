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

        AnsiConsole.MarkupLine($"[gray]{DsaReviewPageChoice} page[/]");

        if (DsaReviewPageChoice == "string")
        {

        }
        else
        {
            Console.WriteLine("err");
        }
        await MainMenuWithConfirm();
    }
    public async Task NavigateTopicPage()
    {

    }
}