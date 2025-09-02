using TG.ECommerce.Domain.AggregateModels.ProductAggregate;
using TG.ECommerce.Shared.SeedWork.Entity;

namespace TG.ECommerce.Domain.AggregateModels.CategoryAggregate;

public class Category : Entity
{
    public string Name { get; private set; }
    public ICollection<Product> Products { get; private set; } = new List<Product>();

    protected Category() {}

    public Category(string name)
    {
        Id = Guid.NewGuid();
        Name = name;

        CreatedOn = DateTime.Now;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }
}
