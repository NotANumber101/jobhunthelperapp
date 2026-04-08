using System;
using Microsoft.Extensions.Logging;
using Spectre.Console;
using Spectre;
using Npgsql;
using cdbv1.Helpers;
using cdbv1.Models;
using cdbv1.Pages;

try
{
    DbInfoController dbIc = new();
    var dbsb = new DbSourceBuilder("db,localhost");
    await using var dataSource = dbsb.Builder().BuildMultiHost();
    // FETCH DATA
    await using var connection = await dataSource.OpenConnectionAsync();
    // SELECT 8 verifies Logging
    await using var loggingCommand = new NpgsqlCommand("SELECT 8", connection);
    _ = await loggingCommand.ExecuteScalarAsync();
    AnsiConsole.MarkupLine("LOG: Database Connection: [green]OK![/]");
}
catch (NpgsqlException e)
{
    AnsiConsole.MarkupLine("[red]WARN: Unable to retrieve data...[/]");
    AnsiConsole.MarkupLine("[red]ERROR: Database server connection has failed.[/]");
    Console.WriteLine(e.Message);
}
if (AnsiConsole.Profile.Capabilities.Interactive)
{
    AnsiConsole.MarkupLine("LOG: Interactive mode detected.[green]Input Mode Enabled.[/]");
    HomePage homePage = new();
    await homePage.Display();
}
else
{
    AnsiConsole.MarkupLine("[red]LOG: Interactive Mode Disabled... Input Mode Disabled.[/]");
    NonInteractiveFallbackPage fallbackPage = new();
    await fallbackPage.Display();
}
