using System;
using cdbv1.Models;
using Spectre;
using Spectre.Console;
using cdbv1.Helpers;
using Npgsql;
using Microsoft.Extensions.Logging;

using cdbv1.Pages;
namespace cdbv1.Pages;

// public class DsaProblemsPage(List<CompanyInformation> companies, List<JobApplication> jobApplications, List<DsaProblem> dsaProblems)
public class NonInteractiveFallbackPage() : Page

{
    public async Task Display()
    {
        DbInfoController dbIc = new();
        var dbsb = new DbSourceBuilder("db,localhost");
        try
        {
            await using var dataSource = dbsb.Builder().BuildMultiHost();
            //////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////
            ///// Get all database names
            var databaseNames = new Table().ShowRowSeparators();
            databaseNames.AddColumn("Databases", col => col.Centered());
            await using (var cmd = dataSource.CreateCommand("SELECT datname FROM pg_database WHERE datistemplate = false;"))
            await using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    databaseNames.AddRow(reader.GetString(0));
                }
            AnsiConsole.Write(databaseNames);
            ////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////
            /// Get db table names and table fields 
            var myDbTree = new Tree("job_app database TABLES");
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
        Console.WriteLine("NON-FATAL ERROR OCCURED: INTERACTIVE MODE IS DISABLED... Exiting...");
    }


}