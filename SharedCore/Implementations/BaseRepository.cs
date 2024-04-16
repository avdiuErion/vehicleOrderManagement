using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SharedCore.BaseClasses;
using SharedCore.Interfaces;

namespace SharedCore.Implementations;

public class BaseRepository<TEntity>(DbContext context, DbSet<TEntity> entities) : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await entities.FindAsync(id);
    }

    public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity?, bool>> predicate)
    {
        return await entities.FirstOrDefaultAsync(predicate);
    }

    public IQueryable<TEntity?> GetAll()
    {
        return entities.AsQueryable();
    }

    public IQueryable<TEntity?> Where(Expression<Func<TEntity?, bool>> predicate)
    {
        return entities.Where(predicate);
    }

    public async Task AddAsync(TEntity? entity)
    {
        await entities.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity? entity)
    {
        entities.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(TEntity? entity)
    {
        entities.Remove(entity);
        await context.SaveChangesAsync();
    }
}