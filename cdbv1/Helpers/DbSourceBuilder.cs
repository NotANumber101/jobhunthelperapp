using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Npgsql;
namespace cdbv1.Helpers;

public class DbSourceBuilder(string host)
{
    readonly string connectionString = $"Host={host},localhost;Port=5432;Username=postgres;Password=password;Database=test_db";

    public NpgsqlDataSourceBuilder Builder()
    {
        // using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        var npgsqlDataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
        return npgsqlDataSourceBuilder
            .EnableParameterLogging(true);
            // .UseLoggerFactory(factory);
    }
    enum HttpStatus : ushort
    {
        OK = 200,
        NotFound = 404,
        InternalServerError = 500
    }

}