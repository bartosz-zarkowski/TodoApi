using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TodoList.Api.Configs;
using TodoList.Api.Interfaces.Entities;
using TodoList.Api.Interfaces.Repositories;

namespace TodoList.Api.Repositories;

public class BaseEntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity
{
    private readonly TodoDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public BaseEntityRepository(TodoDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity?> FindByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null)
            query = query.Where(filter);

        return await query.ToListAsync();
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveAsync();

        return entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await SaveAsync();

        return entity;
    }

    public virtual async Task DeleteByIdAsync(Guid id)
    {
        var entityToDelete = await _dbSet.FindAsync(id);

        if (entityToDelete != null)
        {
            _dbSet.Remove(entityToDelete);
            await SaveAsync();
        }
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
