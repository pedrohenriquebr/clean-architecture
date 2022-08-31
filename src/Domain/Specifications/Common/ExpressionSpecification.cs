using System.Linq.Expressions;

namespace Domain.Specifications.Common;

public abstract class ExpressionSpecification<T> : ISpecification<T>
    where T : class
{
    private Func<T, bool>? _expressionFunc;
    private Func<T, bool> ExpressionFunc => _expressionFunc ??= Expression.Compile();
    public Expression<Func<T, bool>> Expression { get; private set; }

    public bool IsSatisfied(T obj)
    {
        var result = ExpressionFunc(obj);
        return result;
    }

    public void Where(Expression<Func<T, bool>> expr)
    {
        Expression = expr;
    }

    public void Where(ISpecification<T> spec)
    {
        Where(spec.Expression);
    }


    public static ISpecification<T> operator &(ExpressionSpecification<T> left, ExpressionSpecification<T> right)
    {
        return left.And(right);
    }


    public static ISpecification<T> operator &(ExpressionSpecification<T> left, ISpecification<T> right)
    {
        return left.And(right);
    }

    public static ISpecification<T> operator &(Expression<Func<T, bool>> left, ExpressionSpecification<T> right)
    {
        return new AnonymousSpecification<T>(left).And(right);
    }


    public static ISpecification<T> operator &(ExpressionSpecification<T> left, Expression<Func<T, bool>> right)
    {
        return left.And(right);
    }

    public static ISpecification<T> operator !(ExpressionSpecification<T> right)
    {
        return new AnonymousSpecification<T>(x => true).Not(right);
    }

    public static ISpecification<T> operator |(ExpressionSpecification<T> left, ISpecification<T> right)
    {
        return left.Or(right);
    }

    public static ISpecification<T> operator |(ExpressionSpecification<T> left, Expression<Func<T, bool>> right)
    {
        return left.Or(right);
    }

    public static ISpecification<T> operator |(Expression<Func<T, bool>> left, ExpressionSpecification<T> right)
    {
        return new AnonymousSpecification<T>(left).Or(right);
    }

    public static implicit operator ExpressionSpecification<T>(Expression<Func<T, bool>> expr)
    {
        return new AnonymousSpecification<T>(expr);
    }
}