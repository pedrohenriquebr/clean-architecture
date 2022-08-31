using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Generic;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.CrossCutting.Services;

public class ReadOnlyGenericRepository : BaseRepository, IReadOnlyGenericRepository
{
    public ReadOnlyGenericRepository(MyDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<T> Set<T>()
    {
        return base.Set<T>().AsNoTracking();
    }
}
