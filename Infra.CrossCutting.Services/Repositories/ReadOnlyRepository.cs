using Domain.Interfaces.Repositories;

namespace Infra.CrossCutting.Services.Repositories;

public class ReadOnlyRepository<T> : BaseRepository<T>, IReadOnlyRepository<T>
    where T : class
{
    public ReadOnlyRepository(IReadOnlyGenericRepository repository) : base(repository)
    {
    }
}
