using System.Linq.Expressions;
using TodoList.Api.Interfaces.Dtos.Common;
using TodoList.Api.Interfaces.Entities;

namespace TodoList.Api.Interfaces.Services;

public interface IEntityService<TEntity, TViewDto, TCreateDto, TUpdateDto>
    where TEntity : class, IEntity
    where TViewDto : class, IViewDto
    where TCreateDto : class, IDto
    where TUpdateDto : class, IDto
{
    Task<TViewDto> GetByIdAsync(Guid id);
    Task<IEnumerable<TViewDto>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task<TViewDto> CreateAsync(TCreateDto createDto);
    Task<TViewDto> UpdateByIdAsync(Guid id, TUpdateDto updateDto);
    Task DeleteByIdAsync(Guid id);
}
