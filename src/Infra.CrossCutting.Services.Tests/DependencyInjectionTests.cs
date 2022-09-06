using Application.Attributes;
using Application.Common.Attributes;
using Domain.Specifications.Common;
using Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.Services.Tests;

public class DependencyInjectionTests
{

    public IServiceCollection Collection { get; } = new ServiceCollection();

    [Fact]
    public void Should_Inject_My_Service()
    {
        Collection.InjectServicesFrom<Reference>();

        Assert.Equal(2, Collection.Count);

        Assert.All(Collection, x =>
        {
            Assert.Equal(ServiceLifetime.Scoped, x.Lifetime);
            Assert.Equal(typeof(IMyService), x.ServiceType);
        });
    }

    [Fact]
    public void Should_Inject_My_Factory()
    {
        Collection.InjectFactoriesFrom<Reference>();

        Assert.Equal(1, Collection.Count);

        Assert.All(Collection, x =>
        {
            Assert.Equal(ServiceLifetime.Scoped, x.Lifetime);
            Assert.Equal(typeof(IProductFactory), x.ServiceType);
        });
    }

    [Fact]
    public void Should_Inject_My_Specifications()
    {
        Collection.InjectSpecificationsFrom<Reference>();

        Assert.Equal(2, Collection.Count);

        Assert.Contains(Collection, x => 
        {
            return ServiceLifetime.Scoped == x.Lifetime 
                && typeof(ProductsWithPriceAbove10Specification) == x.ServiceType
                && typeof(ProductsWithPriceAbove10Specification) == x.ImplementationType;
        });

        Assert.Contains(Collection, x => 
        {
            return ServiceLifetime.Scoped == x.Lifetime 
                && typeof(ProductsWithPriceLower10Specification) == x.ServiceType
                && typeof(ProductsWithPriceLower10Specification) == x.ImplementationType;
        });
    }
}


public class Reference
{

}

#region Services
public interface IMyService
{
    public string DoIt();
}

[Service]
public class DefaultMyService : IMyService
{
    public string DoIt()
    {
        return nameof(DefaultMyService);
    }
}

[Service]
public class AnotherService : IMyService
{
    public string DoIt()
    {
        return nameof(AnotherService);
    }
}

#endregion Services

#region Factories
public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = "";
    public decimal Price { get; private set; }

    public Product(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
        Price = 0;
    }
}

public interface IProductFactory
{
    public Product Create(string name);    
}


[Factory]
public class DefaultFactory : IProductFactory
{
    public Product Create(string name)
    {
        return new Product(name);
    }
}

#endregion

#region Especifications
public class ProductsWithPriceAbove10Specification : ExpressionSpecification<Product>
{

    public ProductsWithPriceAbove10Specification()
    {
        Where(x => x.Price > 10);
    }
}

public class ProductsWithPriceLower10Specification : ExpressionSpecification<Product>
{

    public ProductsWithPriceLower10Specification()
    {
        Where(x => x.Price < 10);
    }
}


#endregion