using Microsoft.EntityFrameworkCore;
using TodoApi.Configs;
using TodoApi.Entities;
using TodoApi.Interfaces.Repositories;
using TodoApi.Repository;

namespace TodoApi.Repositories;

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
