﻿using System.Linq.Expressions;
using _Expression = System.Linq.Expressions.Expression;

namespace Domain.Specifications.Common.Operators;

public class OrSpecification<T> : ExpressionSpecification<T>
    where T : class
{
    public OrSpecification(ISpecification<T> left, Expression<Func<T, bool>> spec)
    {
        var leftExpression = left.Expression;
        var param = _Expression.Parameter(typeof(T), leftExpression.Parameters.FirstOrDefault()?.Name);
        var body = _Expression.Or(_Expression.Invoke(leftExpression, param),
            _Expression.Invoke(spec, param));
        Where(_Expression.Lambda<Func<T, bool>>(body, param));
    }
}