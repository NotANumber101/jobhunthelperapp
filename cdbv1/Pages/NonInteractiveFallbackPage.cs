using System;
using Spectre;
using Spectre.Console;
using cdbv1.Helpers;
using cdbv1.Queries;
using Npgsql;
using cdbv1.Controllers;

namespace cdbv1.Pages;

public class NonInteractiveFallbackPage() : Page

{
    private MyController myController = new();

    public async Task Display()
    {
        try
        {
            var res1 = await myController.GetDbTableNames();

            var res2 = await myController.GetTableFieldNames();
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine("NON-FATAL ERROR OCCURED: INTERACTIVE MODE IS DISABLED...");
        Console.WriteLine("Nothing left to do.");
        Console.WriteLine("Exiting...");
    }
}