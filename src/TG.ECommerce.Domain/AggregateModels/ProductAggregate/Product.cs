using TG.ECommerce.Domain.AggregateModels.CategoryAggregate;
using TG.ECommerce.Shared.SeedWork.Entity;

namespace TG.ECommerce.Domain.AggregateModels.ProductAggregate;

public class Product : Entity
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }

    protected Product() {}

    public Product(string name, decimal price, int stock, Guid categoryId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Stock = stock;
        CategoryId = categoryId;

        CreatedOn = DateTime.UtcNow;
    }
}
