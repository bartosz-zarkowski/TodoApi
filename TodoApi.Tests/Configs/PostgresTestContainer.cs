
using Testcontainers.PostgreSql;

namespace TodoApi.Tests.Configs;

public class PostgresTestContainer : IAsyncLifetime
{
    private readonly PostgreSqlContainer _container;

    public string ConnectionString => _container.GetConnectionString();

    public PostgresTestContainer()
    {
        _container = new PostgreSqlBuilder()
            .WithDatabase("TestDb")
            .WithUsername("postgres")
            .WithPassword("password")
            .WithCleanUp(true)
            .Build();
    }

    public async Task InitializeAsync()
    {
        await _container.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await _container.DisposeAsync();
    }
}
