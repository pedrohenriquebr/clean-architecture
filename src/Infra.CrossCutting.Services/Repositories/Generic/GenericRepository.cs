using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Generic;
using Infra.Data;

namespace Infra.CrossCutting.Services;

public class GenericRepository : BaseRepository, IGenericRepository
{

    public GenericRepository(MyDbContext dbContext) : base(dbContext)
    {
    }

    public void Remove<T>(T e) where T : class
    {
        _dbContext.Set<T>().Remove(e);
    }

    public async Task Add<T>(T e) where T : class
    {
        await _dbContext.Set<T>().AddAsync(e);
    }

    public void Update<T>(T e) where T : class
    {
        _dbContext.Set<T>().Update(e);
    }
}
