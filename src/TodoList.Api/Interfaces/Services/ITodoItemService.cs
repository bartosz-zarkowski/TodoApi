using TodoList.Api.Database.Entities;
using TodoList.Api.Dtos.TodoItem;

namespace TodoList.Api.Interfaces.Services;

public interface ITodoItemService : IEntityService<TodoItem, TodoItemViewDto, TodoItemCreateDto, TodoItemUpdateDto>
{
    Task<TodoItemViewDto> UpdateStatusByIdAsync(Guid id, TodoItemStatusDto todoItemStatusDto);
}
