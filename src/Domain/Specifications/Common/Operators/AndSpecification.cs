using System.Linq.Expressions;

namespace Domain.Specifications.Common.Operators;

using _Expression = Expression;

public class AndSpecification<T> : ExpressionSpecification<T>
    where T : class
{
    public AndSpecification(ISpecification<T> left, Expression<Func<T, bool>> spec)
    {
        var leftExpression = left.Expression;
        var param = _Expression.Parameter(typeof(T), leftExpression.Parameters.FirstOrDefault()?.Name);
        var body = _Expression.AndAlso(_Expression.Invoke(leftExpression, param),
            _Expression.Invoke(spec, param));

        Where(_Expression.Lambda<Func<T, bool>>(body, param));
    }
}