using Microsoft.AspNetCore.Mvc;
using TodoApi.Dtos.TodoItem;
using TodoApi.Entities;
using TodoApi.Interfaces.Services;

namespace TodoApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class ItemController : BaseController<TodoItem, TodoItemViewDto, TodoItemCreateDto, TodoItemUpdateDto>
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
            TodoItemViewDto? todoItemViewDto = await _service.UpdateStatusByIdAsync(id, todoItemStatusDto);

            if (todoItemViewDto == null)
            {
                return NotFound();
            }

            return Ok(todoItemViewDto);
        }
    }
}
