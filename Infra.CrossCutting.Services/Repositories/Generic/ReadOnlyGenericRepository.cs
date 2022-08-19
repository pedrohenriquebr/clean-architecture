using Domain.Interfaces.Repositories;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.CrossCutting.Services;

public class ReadOnlyGenericRepository : BaseRepository, IReadOnlyGenericRepository
{
    public ReadOnlyGenericRepository(MyDBContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<T> Set<T>()
    {
        return base.Set<T>().AsNoTracking();
    }
}
