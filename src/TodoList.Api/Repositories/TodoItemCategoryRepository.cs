using Microsoft.EntityFrameworkCore;
using TodoList.Api.Database;
using TodoList.Api.Database.Entities;
using TodoList.Api.Interfaces.Repositories;

namespace TodoList.Api.Repositories;

public class TodoItemCategoryRepository : BaseEntityRepository<TodoItemCategory>, ITodoItemCategoryRepository
{
    private readonly DbSet<TodoItemCategory> _dbSet;

    public TodoItemCategoryRepository(TodoDbContext context) : base(context)
    {
        _dbSet = context.Set<TodoItemCategory>();
    }

    public async Task<bool> IsExisiingCategoryAsync(Guid id)
    {
        return await _dbSet.AnyAsync(x => x.Id == id);
    }
}
