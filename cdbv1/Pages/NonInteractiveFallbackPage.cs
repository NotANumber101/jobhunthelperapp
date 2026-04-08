using System;
using Spectre;
using Spectre.Console;
using cdbv1.Helpers;
using Npgsql;

namespace cdbv1.Pages;

public class NonInteractiveFallbackPage() : Page

{
    public async Task Display()
    {
        try
        {
            DbInfoController dbIc = new();
            var dbsb = new DbSourceBuilder("db,localhost");
            await using var dataSource = dbsb.Builder().BuildMultiHost();
            // Table: Database names
            var databaseNames = new Table().ShowRowSeparators();
            databaseNames.AddColumn("Databases", col => col.Centered());

            await using (var cmd = dataSource.CreateCommand(dbIc.GetDbNames()))
            await using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    databaseNames.AddRow(reader.GetString(0));
                }
            AnsiConsole.Write(databaseNames);
            
            // Tree: Table Names
            var myDbTree = new Tree("Database Tables Tree...");
            await using (var getDbTableNames = dataSource.CreateCommand(dbIc.GetDbTableNamesSql()))
            await using (var tNameReader = await getDbTableNames.ExecuteReaderAsync())
                while (await tNameReader.ReadAsync())
                {
                    var tname = myDbTree.AddNode(tNameReader.GetString(0));
                    await using (var getTableFieldNames = dataSource
                        .CreateCommand(dbIc.GetTableFieldNamesSql(tNameReader.GetString(0))))
                    await using (var fNameReader = await getTableFieldNames.ExecuteReaderAsync())
                        while (await fNameReader.ReadAsync())
                        {
                            tname.AddNode(fNameReader.GetString(0));
                        }
                }
            AnsiConsole.Write(myDbTree);
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