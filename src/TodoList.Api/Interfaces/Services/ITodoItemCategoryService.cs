using TodoList.Api.Dtos.TodoItemCategory;
using TodoList.Api.Entities;

namespace TodoList.Api.Interfaces.Services;

public interface ITodoItemCategoryService : IEntityService<TodoItemCategory, TodoItemCategoryViewDto, TodoItemCategoryCreateDto, TodoItemCategoryUpdateDto>
{
    Task<bool> IsExistingCategoryAsync(Guid id);
}
