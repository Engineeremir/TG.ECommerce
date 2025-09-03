using MediatR;
using Microsoft.AspNetCore.Mvc;
using TG.ECommerce.Application.Handlers.Categories.Commands.AddCategory;
using TG.ECommerce.Application.Handlers.Categories.Commands.DeleteCategory;
using TG.ECommerce.Application.Handlers.Categories.Commands.UpdateCategory;
using TG.ECommerce.Shared.Models;

namespace TG.ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(IMediator mediator) : ControllerBase
    {
        [HttpPost("add-category")]
        public async Task<ApiResult<bool>> AddCategory([FromBody] AddCategoryCommand command, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(command, cancellationToken);
        }

        [HttpPut("update-category")]
        public async Task<ApiResult<bool>> UpdateCategory([FromBody] UpdateCategoryCommand command, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(command, cancellationToken);
        }

        [HttpDelete("delete-category")]
        public async Task<ApiResult<bool>> DeleteCategory([FromQuery] DeleteCategoryCommand command, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(command, cancellationToken);
        }
    }
}
