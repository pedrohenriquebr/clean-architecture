using System.Linq.Expressions;
using Domain.Specifications.Common.Operators;

namespace Domain.Specifications.Common;

public static class OperatorsExtensions
{
    public static ISpecification<T> And<T>(this ISpecification<T> @this, Expression<Func<T, bool>> spec)
        where T : class =>
        new AndSpecification<T>(@this, spec);

    public static ISpecification<T> And<T>(this ISpecification<T> @this, ISpecification<T> spec)
        where T : class =>
        And(@this, spec.Expression);

    public static ISpecification<T> AndNot<T>(this ISpecification<T> @this, Expression<Func<T, bool>> spec)
        where T : class =>
        new AndNotSpecification<T>(@this, spec);

    public static ISpecification<T> Or<T>(this ISpecification<T> @this, Expression<Func<T, bool>> spec)
        where T : class =>
        new OrSpecification<T>(@this, spec);

    public static ISpecification<T> Not<T>(this ISpecification<T> @this, Expression<Func<T, bool>> spec)
        where T : class =>
        new NotSpecification<T>(spec);

    public static ISpecification<T> AndNot<T>(this ISpecification<T> @this, ISpecification<T> spec)
        where T : class =>
        AndNot(@this, spec.Expression);

    public static ISpecification<T> Or<T>(this ISpecification<T> @this, ISpecification<T> spec)
        where T : class =>
        Or(@this, spec.Expression);

    public static ISpecification<T> Not<T>(this ISpecification<T> @this, ISpecification<T> spec)
        where T : class =>
        Not(@this, spec.Expression);
}