using MediatR;
using Microsoft.AspNetCore.Mvc;
using TG.ECommerce.Application.Handlers.Categories.Commands.AddCategory;
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
    }
}
