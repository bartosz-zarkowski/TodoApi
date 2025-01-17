using TodoList.Api.Database.Entities;

namespace TodoList.Api.Interfaces.Repositories;

public interface ITodoItemCategoryRepository : IEntityRepository<TodoItemCategory>
{
    Task<bool> IsExisiingCategoryAsync(Guid id);
}
