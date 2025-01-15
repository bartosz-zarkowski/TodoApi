using TodoList.Api.Dtos.TodoItem;
using TodoList.Api.Entities;

namespace TodoList.Api.Interfaces.Services;

public interface ITodoItemService : IEntityService<TodoItem, TodoItemViewDto, TodoItemCreateDto, TodoItemUpdateDto>
{
    Task<TodoItemViewDto?> UpdateStatusByIdAsync(Guid id, TodoItemStatusDto todoItemStatusDto);
}
