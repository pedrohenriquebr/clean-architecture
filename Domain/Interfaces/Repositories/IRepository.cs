namespace Domain.Interfaces.Repositories;

public interface IRepository<T> : IBaseRepository<T>
    where T : class
{
    Task Add(T e);
    void Update(T e);
    void Remove(T e);
}
