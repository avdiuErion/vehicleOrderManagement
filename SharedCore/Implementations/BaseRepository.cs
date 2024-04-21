using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SharedCore.BaseClasses;
using SharedCore.Interfaces;

namespace SharedCore.Implementations;

public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    protected BaseRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    
    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity?, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public IQueryable<TEntity?> GetAll()
    {
        return _dbSet.AsQueryable();
    }

    public IQueryable<TEntity?> Where(Expression<Func<TEntity?, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public async Task AddAsync(TEntity? entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity? entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(TEntity? entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}