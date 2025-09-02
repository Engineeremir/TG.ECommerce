using TG.ECommerce.Domain.AggregateModels.ProductAggregate;
using TG.ECommerce.Shared.SeedWork.Entity;

namespace TG.ECommerce.Domain.AggregateModels.CategoryAggregate;

public class Category : Entity
{
    public string Name { get; private set; }
    public ICollection<Product> Products { get; private set; }

    protected Category() {}

    public Category(string name)
    {
        Id = Guid.NewGuid();
        Name = name;

        CreatedOn = DateTime.Now;
    }
}
