using AutoMapper;
using TodoApi.Dtos.TodoItem;
using TodoApi.Entities;
using TodoApi.Interfaces.Repositories;
using TodoApi.Interfaces.Services;

namespace TodoApi.Services;

public class TodoItemService : BaseEntityService<TodoItem, TodoItemViewDto, TodoItemCreateDto, TodoItemUpdateDto>, ITodoItemService
{
    private IEntityRepository<TodoItem> _repository;
    private IMapper _mapper;

    public TodoItemService(IEntityRepository<TodoItem> repository, IMapper mapper) : base (repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TodoItemViewDto?> UpdateStatusById(Guid id, TodoItemStatusDto todoItemStatusDto)
    {
        TodoItem? todoItem = await _repository.FindByIdAsync(id);
        
        _mapper.Map(todoItemStatusDto, todoItem);

        await _repository.SaveAsync();
        
        return _mapper.Map<TodoItemViewDto>(todoItem);
    }
}
