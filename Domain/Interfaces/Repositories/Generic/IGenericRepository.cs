using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories;

public interface IGenericRepository : IBaseRepository
{
    Task Add<T>(T e) where T : class;
    void Update<T>(T e) where T : class;
    void Remove<T>(T e) where T : class;
}
