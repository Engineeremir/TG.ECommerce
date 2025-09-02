using MediatR;
using TG.ECommerce.Shared.Filters;
using TG.ECommerce.Shared.Models;

namespace TG.ECommerce.Application.Handlers.Products.Queries.GetProductList;

public class GetProductListQuery : BaseFilter, IRequest<ApiResult<GetProductListFilterQueryDto>>
{
    public string? SearchText { get; set; }
    public List<Guid>? CategoryIds { get; set; }
}