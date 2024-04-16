using System.Linq.Expressions;
using SharedCore.BaseClasses;

namespace SharedCore.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity?, bool>> predicate);
    IQueryable<TEntity?> GetAll();
    IQueryable<TEntity?> Where(Expression<Func<TEntity?, bool>> predicate);
    Task AddAsync(TEntity? entity);
    Task UpdateAsync(TEntity? entity);
    Task RemoveAsync(TEntity? entity);
}