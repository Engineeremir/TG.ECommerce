using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TG.ECommerce.Domain.AggregateModels.CategoryAggregate;
using TG.ECommerce.Domain.AggregateModels.ProductAggregate;
using TG.ECommerce.Infrastructure.EFCore.Extensions;
using TG.ECommerce.Shared.SeedWork.Repository;
using TG.ECommerce.Shared.Utils;

namespace TG.ECommerce.Infrastructure.EFCore.Contexts;

public class TGECommerceDbContext : DbContext, IUnitOfWork
{
    public const string DefaultSchema = "public";
    private readonly IMediator _mediator = null!;
    private readonly IConfiguration _configuration = null!;

    public TGECommerceDbContext(DbContextOptions<TGECommerceDbContext> options) : base(options)
    {
    }

    public TGECommerceDbContext(DbContextOptions<TGECommerceDbContext> options, IMediator mediator, IConfiguration configuration) : base(options)
    {
        _mediator = mediator;
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            _configuration.GetSecretValue<string>("DatabaseSettings", "ProductDatabase");
            optionsBuilder.EnableDetailedErrors();
        }

        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TGECommerceDbContext).Assembly);
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        int result = await base.SaveChangesAsync(cancellationToken);

        if (result > 0)
        {
            await _mediator.DispatchDomainEventsAsync(this);
        }

        return true;
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}
