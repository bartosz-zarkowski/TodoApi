using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Database.Entities;
using TodoList.Api.Dtos.TodoItem;
using TodoList.Api.Interfaces.Services;

namespace TodoList.Api.Controllers;

[Route("api/v1/items")]
public class ItemController : BaseCRUDController<TodoItem, TodoItemViewDto, TodoItemCreateDto, TodoItemUpdateDto>
{
    private readonly ITodoItemService _service;

    public ItemController(
        ITodoItemService service
    ) : base(service)
    {
        _service = service;
    }

    [HttpPut("{id:guid}/status")]
    public async Task<ActionResult<TodoItemViewDto>> PutStatusAsync(Guid id, TodoItemStatusDto todoItemStatusDto)
    {
        TodoItemViewDto todoItemViewDto = await _service.UpdateStatusByIdAsync(id, todoItemStatusDto);

        return Ok(todoItemViewDto);
    }
}
