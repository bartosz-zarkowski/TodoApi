using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Api.Configs;

namespace TodoList.IntegrationTests.Configs;

public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    private readonly PostgresTestContainer _postgresContainer = new();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TodoDbContext>));
            if (descriptor != null) services.Remove(descriptor);

            services.AddDbContext<TodoDbContext>(options =>
            {
                options.UseNpgsql(_postgresContainer.ConnectionString);
            });

            using var scope = services.BuildServiceProvider().CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<TodoDbContext>();
            db.Database.Migrate();
        });
    }

    public async Task InitializeAsync() => await _postgresContainer.InitializeAsync();
    public async Task DisposeAsync() => await _postgresContainer.DisposeAsync();
}
