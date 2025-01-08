using Microsoft.AspNetCore.Mvc;
using TodoApi.Dtos.TodoItemCategory;
using TodoApi.Entities;
using TodoApi.Interfaces.Services;

namespace TodoApi.Controllers
{
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
}
