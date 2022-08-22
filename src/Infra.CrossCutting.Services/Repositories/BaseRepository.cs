using Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace Infra.CrossCutting.Services.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T>
where T : class
{

    protected readonly IBaseRepository repository;

    public BaseRepository(IBaseRepository repository)
    {
        this.repository = repository;
    }

    public Task<bool> AnyAsync()
    {
        return repository.AnyAsync<T>();
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> expr)
    {
        return repository.AnyAsync(expr);
    }

    public Task<T> FirstAsync()
    {
        return repository.FirstAsync<T>();
    }

    public Task<T> FirstAsync(Expression<Func<T, bool>> expr)
    {
        return repository.FirstAsync(expr);
    }

    public Task<T?> FirstOrDefaultAsync()
    {
        return repository.FirstOrDefaultAsync<T>();
    }

    public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expr)
    {
        return repository.FirstOrDefaultAsync(expr);
    }

    public IQueryable<T> Query()
    {
        return repository.Query<T>();
    }

    public IQueryable<T> Query(Expression<Func<T, bool>> expr)
    {
        return repository.Query(expr);
    }

    public Task<T> SingleAsync()
    {
        return repository.SingleAsync<T>();
    }

    public Task<T> SingleAsync(Expression<Func<T, bool>> expr)
    {
        return repository.SingleAsync(expr);
    }

    public Task<T?> SingleOrDefaultAsync()
    {
        return repository.SingleOrDefaultAsync<T>();
    }

    public Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> expr)
    {
        return repository.SingleOrDefaultAsync(expr);
    }
}
