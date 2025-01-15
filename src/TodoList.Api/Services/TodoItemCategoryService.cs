using AutoMapper;
using FluentValidation;
using TodoList.Api.Dtos.TodoItemCategory;
using TodoList.Api.Entities;
using TodoList.Api.Interfaces.Repositories;
using TodoList.Api.Interfaces.Services;

namespace TodoList.Api.Services;

public class TodoItemCategoryService : BaseEntityService<TodoItemCategory, TodoItemCategoryViewDto, TodoItemCategoryCreateDto, TodoItemCategoryUpdateDto>, ITodoItemCategoryService
{
    private ITodoItemCategoryRepository _repository;

    public TodoItemCategoryService(
        ITodoItemCategoryRepository repository,
        IMapper mapper,
        IValidator<TodoItemCategory> validator
    ) : base(repository, mapper, validator)
    {
        _repository = repository;
    }

    public async Task<bool> IsExistingCategoryAsync(Guid id)
    {
        return await _repository.IsExisiingCategoryAsync(id);
    }
}
