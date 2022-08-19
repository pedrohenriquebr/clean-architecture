using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories;

public interface IBaseRepository<T>
    where T : class
{
    IQueryable<T> Query();
    IQueryable<T> Query(Expression<Func<T, bool>> expr);

    Task<T?> FirstOrDefaultAsync();
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expr);

    Task<T> FirstAsync();
    Task<T> FirstAsync(Expression<Func<T, bool>> expr);

    Task<T?> SingleOrDefaultAsync();
    Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> expr);

    Task<T> SingleAsync();
    Task<T> SingleAsync(Expression<Func<T, bool>> expr);

    Task<bool> AnyAsync();
    Task<bool> AnyAsync(Expression<Func<T, bool>> expr);
}