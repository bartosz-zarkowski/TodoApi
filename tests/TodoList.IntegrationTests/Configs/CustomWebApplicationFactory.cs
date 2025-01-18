using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Api.Database;
using TodoList.TestFixtures.Fixtures;

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
            var dbContext = scope.ServiceProvider.GetRequiredService<TodoDbContext>();

            dbContext.Database.Migrate();
            
            SeedTestData(dbContext);
        });
    }

    private void SeedTestData(TodoDbContext dbContext)
    {
        dbContext.Categories.AddRange(TodoItemCategoryFixture.TodoItemCategories);
        dbContext.Items.AddRange(TodoItemFixture.TodoItems);

        dbContext.SaveChanges();
    }

    public async Task InitializeAsync() => await _postgresContainer.InitializeAsync();
    public async Task DisposeAsync() => await _postgresContainer.DisposeAsync();
}
