using TG.ECommerce.Domain.AggregateModels.ProductAggregate;
using TG.ECommerce.Infrastructure.EFCore.Contexts;

namespace TG.ECommerce.Infrastructure.EFCore.Repositories;

public class ProductRepository : EfRepository<Product>, IProductRepository
{
    public ProductRepository(TGECommerceDbContext context) : base(context)
    {
    }
}