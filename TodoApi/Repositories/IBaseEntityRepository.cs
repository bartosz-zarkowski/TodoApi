using System.Linq.Expressions;
using TodoApi.Entities;

namespace TodoApi.Repository;

public interface IBaseEntityRepository<TEntity> where TEntity : class, IEntity
{
    Task<TEntity?> FindByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteByIdAsync(Guid id);
    Task SaveAsync();
}
