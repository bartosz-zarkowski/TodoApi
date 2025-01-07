using TodoApi.Dtos.TodoItem;
using TodoApi.Entities;

namespace TodoApi.Interfaces.Services;

public interface ITodoItemService : IEntityService<TodoItem, TodoItemViewDto, TodoItemCreateDto, TodoItemUpdateDto>
{
    Task<TodoItemViewDto?> UpdateStatusById(Guid id, TodoItemStatusDto todoItemStatusDto);
}
