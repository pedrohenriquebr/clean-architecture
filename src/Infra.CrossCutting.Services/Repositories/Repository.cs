using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Generic;

namespace Infra.CrossCutting.Services.Repositories;

public class Repository<T> : BaseRepository<T>, IRepository<T>
    where T : class
{
    private new readonly IGenericRepository repository;

    public Repository(IGenericRepository repository) : base(repository)
    {
        this.repository = repository;
    }

    public Task Add(T e)
    {
        return repository.Add(e);
    }

    public void Remove(T e)
    {
        repository.Remove(e);
    }

    public void Update(T e)
    {
        repository.Update(e);
    }
}
