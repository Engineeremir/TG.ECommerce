using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TG.ECommerce.Domain.AggregateModels.CategoryAggregate;
using TG.ECommerce.Domain.AggregateModels.ProductAggregate;
using TG.ECommerce.Infrastructure.EFCore.Contexts;
using TG.ECommerce.Infrastructure.EFCore.Repositories;
using TG.ECommerce.Shared.Utils;

namespace TG.ECommerce.Infrastructure.EFCore;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureEfCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TGECommerceDbContext>(options =>
            options.UseNpgsql(configuration.GetSecretValue<string>("DatabaseSettings", "ProductDatabase")));

        services.AddRepositories();

        var serviceProvider = services.BuildServiceProvider();
        var db = serviceProvider.GetRequiredService<TGECommerceDbContext>();
        db.Database.Migrate();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped(typeof(EfRepository<>));

        return services;
    }
}