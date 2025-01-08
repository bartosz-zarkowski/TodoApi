using System.Linq.Expressions;
using TodoApi.Interfaces.Entities;

namespace TodoApi.Interfaces.Repositories;

public interface IEntityRepository<TEntity> where TEntity : class, IEntity
{
    Task<TEntity?> FindByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task DeleteByIdAsync(Guid id);
    Task SaveAsync();
}
