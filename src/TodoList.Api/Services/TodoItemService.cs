using AutoMapper;
using FluentValidation;
using TodoList.Api.Database.Entities;
using TodoList.Api.Dtos.TodoItem;
using TodoList.Api.Interfaces.Repositories;
using TodoList.Api.Interfaces.Services;

namespace TodoList.Api.Services;

public class TodoItemService : BaseEntityService<TodoItem, TodoItemViewDto, TodoItemCreateDto, TodoItemUpdateDto>, ITodoItemService
{
    private readonly IEntityRepository<TodoItem> _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<TodoItem> _validator;

    public TodoItemService(IEntityRepository<TodoItem> repository, IMapper mapper, IValidator<TodoItem> validator) : base(repository, mapper, validator)
    {
        _repository = repository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<TodoItemViewDto?> UpdateStatusByIdAsync(Guid id, TodoItemStatusDto todoItemStatusDto)
    {
        TodoItem? todoItem = await _repository.FindByIdAsync(id);

        if (todoItem == null)
        {
            return null;
        }

        _mapper.Map(todoItemStatusDto, todoItem);

        await _validator.ValidateAndThrowAsync(todoItem);

        await _repository.SaveAsync();

        return _mapper.Map<TodoItemViewDto>(todoItem);
    }
}
