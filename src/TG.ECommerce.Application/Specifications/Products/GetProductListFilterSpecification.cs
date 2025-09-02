using Ardalis.Specification;
using TG.ECommerce.Application.Handlers.Products.Queries.GetProductList;
using TG.ECommerce.Domain.AggregateModels.ProductAggregate;
using TG.ECommerce.Shared.Models;

namespace TG.ECommerce.Application.Specifications.Products;

public class GetProductListFilterSpecification : Specification<Product, GetProductListQueryDto>
{
    public GetProductListFilterSpecification(GetProductListQuery query)
    {
        Query.Include(x => x.Category);

        Query.AsNoTracking().AsSplitQuery();

        Query.Skip(PaginationHelper.CalculateSkip(query))
            .Take(PaginationHelper.CalculateTake(query));

        //search text by category name or product name
        if (!string.IsNullOrEmpty(query.SearchText))
        {
            Query.Where(x =>
                x.Category.Name.ToLower().Contains(query.SearchText.ToLower()) ||
                x.Name.ToLower().Contains(query.SearchText.ToLower()));
        }

        //category
        if (query.CategoryIds is not null && query.CategoryIds.Count > 0)
        {
            Query.Where(x => query.CategoryIds.Contains(x.CategoryId));
        }

        Query.Select(x => new GetProductListQueryDto
        {
            Id = x.Id,
            CategoryId = x.CategoryId,
            Name = x.Name,
            Price = x.Price,
            Stock = x.Stock,
            Category = x.Category.Name
        });

        Query.OrderByDescending(x => x.CreatedOn);
    }
}
