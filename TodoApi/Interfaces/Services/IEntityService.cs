using System.Linq.Expressions;
using TodoApi.Interfaces.Dtos;
using TodoApi.Interfaces.Entities;

namespace TodoApi.Interfaces.Services;

public interface IEntityService<TEntity, TViewDto, TCreateDto, TUpdateDto>
    where TEntity : class, IEntity
    where TViewDto : class, IViewDto
    where TCreateDto : class, IDto
    where TUpdateDto : class, IDto
{
    Task<TViewDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<TViewDto>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task<TViewDto> CreateAsync(TCreateDto createDto);
    Task<TViewDto?> UpdateByIdAsync(Guid id, TUpdateDto updateDto);
    Task DeleteByIdAsync(Guid id);
}
