using Dapper;
using FluentAssertions;
using Npgsql;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Testcontainers.PostgreSql;

namespace sqldepartmentemployee;

[TestFixture]
public class DatabaseTests
{
    private const string _createTableQuery = @"
CREATE TABLE IF NOT EXISTS datas (
    id SERIAL PRIMARY KEY,
    data TEXT NOT NULL
);";

    private const string _insertDataToTablesQuery = @"
insert into datas(data)
values
    ('Alpha'),
    ('Bravo'),
    ('Charlie'),
    ('Delta');
";
    private IDbConnection _dbconnection;

    private PostgreSqlContainer _postgresContainer;
    private string _connectionString;

    [OneTimeSetUp]
    public async Task OneTimeSetUpAsync()
    {
        _postgresContainer = new PostgreSqlBuilder()
            .WithDatabase("testdb")
            .WithUsername("postgres")
            .WithPassword("password")
            .Build();

        await _postgresContainer.StartAsync();

        _connectionString = _postgresContainer.GetConnectionString();

        _dbconnection = new NpgsqlConnection(_connectionString);

        await _dbconnection.ExecuteAsync(_createTableQuery);
        await _dbconnection.ExecuteAsync(_insertDataToTablesQuery);
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDownAsync()
    {
        if(_dbconnection != null)
        {
            _dbconnection.Close();
            _dbconnection.Dispose();
        }
        if(_postgresContainer != null)
        {
            await _postgresContainer.StopAsync();
            await _postgresContainer.DisposeAsync();
        }
    }

    [Test]
    public async Task TestSqlQuery_InsertAndRetrieveData_ShouldReturnInsertedData()
    {
        var testData = new[] { "Alpha", "Bravo", "Charlie", "Delta" };

        IEnumerable<string> retrievedData;
        var selectQuery = "SELECT data FROM datas ORDER BY data;";
        retrievedData = await _dbconnection.QueryAsync<string>(selectQuery);

        retrievedData.Should().BeEquivalentTo(testData, options => options.WithStrictOrdering());
    }
}

