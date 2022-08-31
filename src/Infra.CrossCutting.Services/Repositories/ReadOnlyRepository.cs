using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Generic;

namespace Infra.CrossCutting.Services.Repositories;

public class ReadOnlyRepository<T> : BaseRepository<T>, IReadOnlyRepository<T>
    where T : class
{
    public ReadOnlyRepository(IReadOnlyGenericRepository repository) : base(repository)
    {
    }
}
