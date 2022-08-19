namespace Domain.Interfaces.Repositories;

public interface IReadOnlyRepository<T> : IBaseRepository<T>
    where T : class
{

}
