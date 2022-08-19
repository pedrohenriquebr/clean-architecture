using Domain.Interfaces.Repositories;

namespace Infra.CrossCutting.Services.Repositories;

public class ReadOnlyRepository<T> : BaseRepository<T>, IReadOnlyRepository<T>
    where T : class
{
    public ReadOnlyRepository(IReadOnlyRepository repository) : base(repository)
    {
    }
}
