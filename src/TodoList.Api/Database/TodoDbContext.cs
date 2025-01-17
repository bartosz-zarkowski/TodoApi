using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TodoList.Api.Database.Entities;

namespace TodoList.Api.Database;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<TodoItem> Items { get; set; }
    public DbSet<TodoItemCategory> Categories { get; set; }
}
