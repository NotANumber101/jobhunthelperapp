using System;
using Spectre.Console;

namespace cdbv1.Pages;

public class HomePage() : Page
{
    public async Task Display()
    {
        var header1 = new FigletText("Interview");
        var header2 = new FigletText("Helper");

        AnsiConsole.Write(header1);
        AnsiConsole.Write(header2);
        AnsiConsole.WriteLine();
        await MainMenu();
    }
}