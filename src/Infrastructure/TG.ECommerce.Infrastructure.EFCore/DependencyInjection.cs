using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TG.ECommerce.Domain.AggregateModels.CategoryAggregate;
using TG.ECommerce.Domain.AggregateModels.ProductAggregate;
using TG.ECommerce.Infrastructure.EFCore.Contexts;
using TG.ECommerce.Infrastructure.EFCore.Repositories;
using TG.ECommerce.Shared.Settings;

namespace TG.ECommerce.Infrastructure.EFCore;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureEfCore(this IServiceCollection services)
    {
        services.AddDbContext<TGECommerceDbContext>((serviceProvider, options) =>
        {
            var dbSettings = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>().Value;
            options.UseNpgsql(dbSettings.ProductDatabase);
        });

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