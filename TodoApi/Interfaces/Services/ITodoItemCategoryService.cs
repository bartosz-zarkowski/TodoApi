using TodoApi.Dtos.TodoItemCategory;
using TodoApi.Entities;

namespace TodoApi.Interfaces.Services;

public interface ITodoItemCategoryService : IEntityService<TodoItemCategory, TodoItemCategoryViewDto, TodoItemCategoryCreateDto, TodoItemCategoryUpdateDto>
{
    Task<bool> IsExistingCategory(Guid id);
}
