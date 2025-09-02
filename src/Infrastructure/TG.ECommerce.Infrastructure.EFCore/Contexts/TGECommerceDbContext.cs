using MediatR;
using Microsoft.EntityFrameworkCore;
using TG.ECommerce.Infrastructure.EFCore.Extensions;
using TG.ECommerce.Shared.SeedWork.Repository;

namespace TG.ECommerce.Infrastructure.EFCore.Contexts;

public class TGECommerceDbContext : DbContext, IUnitOfWork
{
    public const string DefaultSchema = "public";
    private readonly IMediator _mediator = null!;

    public TGECommerceDbContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimeStampBehaviour", true);
        AppContext.SetSwitch("Npgsql.EnableDiscardEvents", false);
    }

    public TGECommerceDbContext(DbContextOptions<TGECommerceDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimeStampBehaviour", true);
        AppContext.SetSwitch("Npgsql.EnableDiscardEvents", false);
    }

    public TGECommerceDbContext(DbContextOptions<TGECommerceDbContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimeStampBehaviour", true);
        AppContext.SetSwitch("Npgsql.EnableDiscardEvents", false);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
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
}
