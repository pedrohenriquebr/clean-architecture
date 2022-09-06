using Application.Attributes;
using Application.Common.Attributes;
using Domain.Specifications.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.IoC;

public static class DIExtesions
{

    public static IServiceCollection InjectServicesFrom<T>(this IServiceCollection builder)
        where T : class
    {
        builder.Scan(scan =>
                    scan.FromAssemblyOf<T>()
                    .AddClasses(d => d.WithAttribute<ServiceAttribute>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

        return builder;
    }

    public static IServiceCollection InjectFactoriesFrom<T>(this IServiceCollection builder)
        where T : class
    {
        builder.Scan(scan =>
                    scan.FromAssemblyOf<T>()
                    .AddClasses(d => d.WithAttribute<FactoryAttribute>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

        return builder;
    }

    public static IServiceCollection InjectSpecificationsFrom<T>(this IServiceCollection builder)
        where T : class
    {
        builder.Scan(scan =>
                    scan.FromAssemblyOf<T>()
                    .AddClasses(d => d.AssignableTo(typeof(ExpressionSpecification<>)))
                    .AsSelf()
                    .WithScopedLifetime());

        return builder;
    }

    public static IServiceCollection InjectServices(this IServiceCollection builder)
    {
        return builder.InjectServicesFrom<ServiceAttribute>();
    }

    public static IServiceCollection InjectFactories(this IServiceCollection builder)
    {
        return builder.InjectFactoriesFrom<FactoryAttribute>();
    }

    public static IServiceCollection InjectSpecifications(this IServiceCollection builder)
    {
        return builder.InjectSpecificationsFrom<FactoryAttribute>();
    }
}
