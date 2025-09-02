using TG.ECommerce.Shared.Models;

namespace TG.ECommerce.Application.Handlers.Products.Queries.GetProductList;

public class GetProductListFilterQueryDto
{
    public PagedResults<GetProductListQueryDto> Products { get; set; }
    public GetProductsFilterDto Filters { get; set; }
}

public class GetProductListQueryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public Guid CategoryId { get; set; }
    public string Category { get; set; }
}
public class GetProductsFilterDto
{
    public List<GetProductsCategoryQueryFilterDto> Categories { get; set; }
}

public class GetProductsCategoryQueryFilterDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}