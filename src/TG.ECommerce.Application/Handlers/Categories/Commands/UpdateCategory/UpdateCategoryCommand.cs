using MediatR;
using TG.ECommerce.Shared.Models;

namespace TG.ECommerce.Application.Handlers.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<ApiResult<bool>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
