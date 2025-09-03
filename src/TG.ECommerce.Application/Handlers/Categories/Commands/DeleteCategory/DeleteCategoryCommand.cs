using MediatR;
using TG.ECommerce.Shared.Models;

namespace TG.ECommerce.Application.Handlers.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand : IRequest<ApiResult<bool>>
{
    public Guid Id { get; set; }
}