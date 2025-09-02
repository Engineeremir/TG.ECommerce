using MediatR;
using TG.ECommerce.Application.Specifications.Categories;
using TG.ECommerce.Application.Specifications.Products;
using TG.ECommerce.Domain.AggregateModels.ProductAggregate;
using TG.ECommerce.Shared.Models;

namespace TG.ECommerce.Application.Handlers.Products.Queries.GetProductList;

public class GetProductListQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductListQuery, ApiResult<GetProductListFilterQueryDto>>
{
    public async Task<ApiResult<GetProductListFilterQueryDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        var productFilterSpecification = new GetProductListFilterSpecification(request);
        var productList = await productRepository.ListAsync(productFilterSpecification, cancellationToken);

        var count = await productRepository.CountAsync(productFilterSpecification, cancellationToken);
        var responseData = await PaginationHelper.CreatePagedResults(productList, request.Page ?? 1, request.PageSize ?? 10, count);

        var productCategoryFilterSpecification = new ProductCategoryFilterSpecification(request);
        var productCategoryList = await productRepository.ListAsync(productCategoryFilterSpecification, cancellationToken);
        productCategoryList = productCategoryList.DistinctBy(x => x.Id).ToList();

        var response = new GetProductListFilterQueryDto
        {
            Products = responseData,
            Filters = new GetProductsFilterDto
            {
                Categories = productCategoryList.Select(x => new GetProductsCategoryQueryFilterDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            }
        };

        return new ApiResult<GetProductListFilterQueryDto>().ResponseOk(response);
    }
}