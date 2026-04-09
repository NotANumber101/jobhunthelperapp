using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Npgsql;
namespace cdbv1.Helpers;


/// https://www.npgsql.org/doc/api/Npgsql.NpgsqlDataSource.html


public class DbSourceBuilder(string host)
{
    readonly string loadBalanaceHosts = "Load Balance Hosts=true;";
    readonly string targetSessionAttributes = "Target Session Attributes=prefer-standby;";
    readonly string connectionString = $"Host={host},localhost;Port=5432;Username=postgres;Password=password;Database=test_db;";

    public NpgsqlDataSourceBuilder Builder()
    {
        // using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        var npgsqlDataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString+loadBalanaceHosts+targetSessionAttributes);
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

