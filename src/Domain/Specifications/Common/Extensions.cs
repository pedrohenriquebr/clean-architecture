using Domain.Interfaces.Repositories.Generic;

namespace Domain.Specifications.Common;

public static class Extensions
{
    #region IEnumerable

    public static IEnumerable<T> Specify<T>(this IEnumerable<T> query, ISpecification<T> spec) where T : class
    {
        return query.Where(spec.Expression.Compile());
    }

    public static T? SpecifyFirstOrDefault<T>(this IEnumerable<T> query, ISpecification<T> spec) where T : class
    {
        return Specify(query, spec).FirstOrDefault();
    }

    public static bool SpecifyAll<T>(this IEnumerable<T> query, ISpecification<T> spec) where T : class
    {
        return query.All(spec.Expression.Compile());
    }

    public static bool SpecifyAny<T>(this IEnumerable<T> query, ISpecification<T> spec) where T : class
    {
        return query.Any(spec.Expression.Compile());
    }

    #endregion

    #region GenericRepository

    public static IQueryable<T> Specify<T>(this IGenericRepository query, ISpecification<T> spec) where T : class
    {
        return query.Query<T>().Specify(spec);
    }

    public static IQueryable<T> Specify<T>(this IReadOnlyGenericRepository query, ISpecification<T> spec)
        where T : class
    {
        return query.Query<T>().Specify(spec);
    }

    #endregion

    #region IQueryable

    public static IQueryable<T> Specify<T>(this IQueryable<T> query, ISpecification<T> spec) where T : class
    {
        return query.Where(spec.Expression);
    }

    public static T? SpecifyFirstOrDefault<T>(this IQueryable<T> query, ISpecification<T> spec) where T : class
    {
        return query.Where(spec.Expression).FirstOrDefault();
    }

    public static bool SpecifyAll<T>(this IQueryable<T> query, ISpecification<T> spec) where T : class
    {
        return query.All(spec.Expression);
    }

    public static bool SpecifyAny<T>(this IQueryable<T> query, ISpecification<T> spec) where T : class
    {
        return query.Any(spec.Expression);
    }

    #endregion
}