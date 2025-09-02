using TG.ECommerce.Domain.AggregateModels.CategoryAggregate;
using TG.ECommerce.Infrastructure.EFCore.Contexts;

namespace TG.ECommerce.Infrastructure.EFCore.Repositories;

public class CategoryRepository : EfRepository<Category>, ICategoryRepository
{
    public CategoryRepository(TGECommerceDbContext context) : base(context)
    {
    }
}