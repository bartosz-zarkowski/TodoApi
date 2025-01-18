using System.Linq.Expressions;
using AutoMapper;
using FluentValidation;
using TodoList.Api.Exceptions;
using TodoList.Api.Interfaces.Dtos.Common;
using TodoList.Api.Interfaces.Entities;
using TodoList.Api.Interfaces.Repositories;
using TodoList.Api.Interfaces.Services;

namespace TodoList.Api.Services;

public class BaseEntityService<TEntity, TViewDto, TCreateDto, TUpdateDto> : IEntityService<TEntity, TViewDto, TCreateDto, TUpdateDto>
    where TEntity : class, IEntity
    where TViewDto : class, IViewDto
    where TCreateDto : class, IDto
    where TUpdateDto : class, IDto
{

    private readonly IEntityRepository<TEntity> _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<TEntity> _validator;

    public BaseEntityService(IEntityRepository<TEntity> repository, IMapper mapper, IValidator<TEntity> validator)
    {
        _repository = repository;
        _mapper = mapper;
        _validator = validator;
    }

    public virtual async Task<TViewDto> GetByIdAsync(Guid id)
    {
        TEntity entity = await _repository.FindByIdAsync(id)
            ?? throw new NotFoundException();

        return _mapper.Map<TViewDto>(entity);
    }

    public virtual async Task<IEnumerable<TViewDto>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        IEnumerable<TEntity> entities = await _repository.FindAllAsync();

        return _mapper.Map<IEnumerable<TViewDto>>(entities);
    }

    public virtual async Task<TViewDto> CreateAsync(TCreateDto createDto)
    {
        TEntity entity = _mapper.Map<TEntity>(createDto);

        await _validator.ValidateAndThrowAsync(entity);

        await _repository.CreateAsync(entity);

        return _mapper.Map<TViewDto>(entity);
    }

    public virtual async Task<TViewDto> UpdateByIdAsync(Guid id, TUpdateDto updateDto)
    {
        TEntity entity = await _repository.FindByIdAsync(id)
            ?? throw new NotFoundException();

        _mapper.Map(updateDto, entity);

        await _validator.ValidateAndThrowAsync(entity);

        await _repository.UpdateAsync(entity);

        return _mapper.Map<TViewDto>(entity);
    }

    public virtual async Task DeleteByIdAsync(Guid id)
    {
        await _repository.DeleteByIdAsync(id);
    }
}
