using TodoList.Api.Database.Entities;
using TodoList.Api.Dtos.TodoItemCategory;

namespace TodoList.Api.Interfaces.Services;

public interface ITodoItemCategoryService : IEntityService<TodoItemCategory, TodoItemCategoryViewDto, TodoItemCategoryCreateDto, TodoItemCategoryUpdateDto>
{
    Task<bool> IsExistingCategoryAsync(Guid id);
}
