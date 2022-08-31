namespace Domain.Interfaces.Repositories.Generic;

public interface IGenericRepository : IBaseRepository
{
    Task Add<T>(T e) where T : class;
    void Update<T>(T e) where T : class;
    void Remove<T>(T e) where T : class;
}
