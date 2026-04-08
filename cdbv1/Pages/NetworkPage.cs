using System;
using cdbv1.Models;
using Spectre;
using Spectre.Console;

using cdbv1;
namespace cdbv1.Pages;
public class NetworkPage() : Page
{
    public async Task Display()
    {
        // TODO: messages
        // TODO: contacts
        AnsiConsole.MarkupLine($"[gray]NETWORK PAGE[/]");
        AnsiConsole.MarkupLine($"[gray]Coming soon...[/]");
        // this name is stupid: should be ReturnToMainMenuPrompt
        await ReturnToMainMenu();
    }
        private async Task ReturnToMainMenu()
    {
        if (AnsiConsole.Confirm("Return to main menu?"))
        {
            await MainMenu();
        }
    }
}