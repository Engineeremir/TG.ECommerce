using Ardalis.Specification;
using TG.ECommerce.Application.Handlers.Products.Queries.GetProductList;
using TG.ECommerce.Domain.AggregateModels.ProductAggregate;

namespace TG.ECommerce.Application.Specifications.Categories;

public class ProductCategoryFilterSpecification : Specification<Product, GetProductsCategoryQueryFilterDto>
{
    public ProductCategoryFilterSpecification(GetProductListQuery query)
    {
        Query.AsNoTracking();

        Query.Select(x => new GetProductsCategoryQueryFilterDto
        {
            Id = x.CategoryId,
            Name = x.Category.Name
        });
    }
}