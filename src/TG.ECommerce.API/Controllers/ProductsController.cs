using MediatR;
using Microsoft.AspNetCore.Mvc;
using TG.ECommerce.Application.Handlers.Products.Commands.AddProduct;
using TG.ECommerce.Application.Handlers.Products.Queries.GetProductList;
using TG.ECommerce.Shared.Models;

namespace TG.ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        [HttpPost("add-product")]
        public async Task<ApiResult<bool>> AddProduct([FromBody] AddProductCommand command, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(command, cancellationToken);
        }

        [HttpPost("get-list")]
        public async Task<ApiResult<GetProductListFilterQueryDto>> GetList([FromBody] GetProductListQuery query, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(query, cancellationToken);
        }
    }
}
