using System.Linq.Expressions;
using Domain.Specifications.Common;

namespace Domain.Specifications;

public interface ISpecification<T>
    where T : class
{
    public Expression<Func<T, bool>> Expression { get; }
    bool IsSatisfied(T obj);
    public void Where(Expression<Func<T, bool>> expr);
    public void Where(ISpecification<T> spec);

    public static ISpecification<T> operator &(ISpecification<T> left, ISpecification<T> right)
    {
        return left.And(right);
    }

    public static ISpecification<T> operator &(ISpecification<T> left, Expression<Func<T, bool>> right)
    {
        return left.And(right);
    }

    public static ISpecification<T> operator &(Expression<Func<T, bool>> left, ISpecification<T> right)
    {
        return new AnonymousSpecification<T>(left).And(right);
    }
}