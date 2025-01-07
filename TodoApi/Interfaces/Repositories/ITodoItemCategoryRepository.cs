using TodoApi.Entities;

namespace TodoApi.Interfaces.Repositories;

public interface ITodoItemCategoryRepository : IEntityRepository<TodoItemCategory>
{
    Task<bool> IsExisiingCategory(Guid id);
}
