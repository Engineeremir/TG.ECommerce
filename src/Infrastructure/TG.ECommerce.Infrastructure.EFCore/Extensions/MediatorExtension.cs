using MediatR;
using TG.ECommerce.Infrastructure.EFCore.Contexts;
using TG.ECommerce.Shared.SeedWork.Entity;

namespace TG.ECommerce.Infrastructure.EFCore.Extensions;

public static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, TGECommerceDbContext context)
    {
        var domainEntites = context.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Count != 0);

        var domainEvents = domainEntites
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        domainEntites.ToList()
            .ForEach(entity => entity.Entity.ClearedDomainEvents());

        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);
        }
    }
}
