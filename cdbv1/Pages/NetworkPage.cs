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
        AnsiConsole.MarkupLine($"[gray]NETWORK PAGE[/]");
        AnsiConsole.MarkupLine($"[gray]Coming soon...[/]");
        await MainMenuWithConfirm();
    }
}