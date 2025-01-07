using System.Linq.Expressions;
using AutoMapper;
using TodoApi.Interfaces.Dtos;
using TodoApi.Interfaces.Entities;
using TodoApi.Interfaces.Repositories;
using TodoApi.Interfaces.Services;

namespace TodoApi.Services;

public class BaseEntityService<TEntity, TViewDto, TCreateDto, TUpdateDto> : IEntityService<TEntity, TViewDto, TCreateDto, TUpdateDto>
    where TEntity : class, IEntity
    where TViewDto : class, IViewDto
    where TCreateDto : class, IDto
    where TUpdateDto : class, IDto
{

    private IEntityRepository<TEntity> _repository;
    private IMapper _mapper;

    public BaseEntityService(IEntityRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<TViewDto?> GetByIdAsync(Guid id)
    {
        TEntity? entity = await _repository.FindByIdAsync(id);
        if (entity == null)
        {
            return null;
        }

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

        await _repository.CreateAsync(entity);

        return _mapper.Map<TViewDto>(entity);
    }

    public virtual async Task<TViewDto?> UpdateByIdAsync(Guid id, TUpdateDto updateDto)
    {
        TEntity? entity = await _repository.FindByIdAsync(id);
        if (entity == null)
        {
            return null;
        }

        _mapper.Map(updateDto, entity);

        await _repository.UpdateAsync(entity);

        return _mapper.Map<TViewDto>(entity);
    }

    public virtual async Task DeleteByIdAsync(Guid id)
    {
        await _repository.DeleteByIdAsync(id);
    }
}
