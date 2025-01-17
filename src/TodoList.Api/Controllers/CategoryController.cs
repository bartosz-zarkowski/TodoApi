using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Database.Entities;
using TodoList.Api.Dtos.TodoItemCategory;
using TodoList.Api.Interfaces.Services;

namespace TodoList.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CategoryController : BaseController<TodoItemCategory, TodoItemCategoryViewDto, TodoItemCategoryCreateDto, TodoItemCategoryUpdateDto>
{

    public CategoryController(
        IEntityService<TodoItemCategory, TodoItemCategoryViewDto, TodoItemCategoryCreateDto, TodoItemCategoryUpdateDto> service
    ) : base(service)
    {
    }
}
