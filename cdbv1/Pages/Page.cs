using System;
using cdbv1.Models;
using Spectre;
using Spectre.Console;
using cdbv1.Helpers;
using Npgsql;
using Microsoft.Extensions.Logging;

namespace cdbv1.Pages;




public class Page()
// public interface IPage()

{
    public void HelloWorld()
    {
        AnsiConsole.MarkupLine("[red]HELLO WORLD[/]");
        AnsiConsole.MarkupLine("[blue]HELLO WORLD[/]");
        AnsiConsole.MarkupLine("[gray]HELLO WORLD[/]");
        AnsiConsole.MarkupLine("[red]HELLO WORLD[/]");
        AnsiConsole.MarkupLine("[blue]HELLO WORLD[/]");
        AnsiConsole.MarkupLine("[gray]HELLO WORLD[/]");
        AnsiConsole.MarkupLine("[red]HELLO WORLD[/]");
        AnsiConsole.MarkupLine("[blue]HELLO WORLD[/]");
        AnsiConsole.MarkupLine("[gray]HELLO WORLD[/]");
    }
}