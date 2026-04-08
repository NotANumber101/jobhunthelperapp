using System;
using Spectre;
using Spectre.Console;

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