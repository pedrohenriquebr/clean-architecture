using Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace Infra.CrossCutting.Services.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T>
where T : class
{

    protected readonly IBaseRepository Repository;

    protected BaseRepository(IBaseRepository repository)
    {
        this.Repository = repository;
    }

    public Task<bool> AnyAsync()
    {
        return Repository.AnyAsync<T>();
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> expr)
    {
        return Repository.AnyAsync(expr);
    }

    public Task<T> FirstAsync()
    {
        return Repository.FirstAsync<T>();
    }

    public Task<T> FirstAsync(Expression<Func<T, bool>> expr)
    {
        return Repository.FirstAsync(expr);
    }

    public Task<T?> FirstOrDefaultAsync()
    {
        return Repository.FirstOrDefaultAsync<T>();
    }

    public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expr)
    {
        return Repository.FirstOrDefaultAsync(expr);
    }

    public IQueryable<T> Query()
    {
        return Repository.Query<T>();
    }

    public IQueryable<T> Query(Expression<Func<T, bool>> expr)
    {
        return Repository.Query(expr);
    }

    public Task<T> SingleAsync()
    {
        return Repository.SingleAsync<T>();
    }

    public Task<T> SingleAsync(Expression<Func<T, bool>> expr)
    {
        return Repository.SingleAsync(expr);
    }

    public Task<T?> SingleOrDefaultAsync()
    {
        return Repository.SingleOrDefaultAsync<T>();
    }

    public Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> expr)
    {
        return Repository.SingleOrDefaultAsync(expr);
    }
}