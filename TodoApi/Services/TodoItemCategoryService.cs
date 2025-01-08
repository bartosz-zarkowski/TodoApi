using AutoMapper;
using FluentValidation;
using TodoApi.Dtos.TodoItemCategory;
using TodoApi.Entities;
using TodoApi.Interfaces.Repositories;
using TodoApi.Interfaces.Services;

namespace TodoApi.Services;

public class TodoItemCategoryService : BaseEntityService<TodoItemCategory, TodoItemCategoryViewDto, TodoItemCategoryCreateDto, TodoItemCategoryUpdateDto>, ITodoItemCategoryService
{
    private ITodoItemCategoryRepository _repository;

    public TodoItemCategoryService(
        ITodoItemCategoryRepository repository, 
        IMapper mapper, 
        IValidator<TodoItemCategory> validator
    ) : base (repository, mapper, validator)
    {
        _repository = repository;
    }

    public async Task<bool> IsExistingCategoryAsync(Guid id)
    {
        return await _repository.IsExisiingCategoryAsync(id);
    }
}
