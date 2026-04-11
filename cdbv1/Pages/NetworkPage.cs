using System;
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

    // dispaly list of all contacts
        // select contact to view most recent message
    

    // display: Bored? Heres how to get network
    //              1. find contacts
    //              2. cold outreach
        await MainMenuWithConfirm();
    }
}