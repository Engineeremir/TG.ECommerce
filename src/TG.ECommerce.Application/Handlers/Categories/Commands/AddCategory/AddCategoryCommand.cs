using MediatR;
using TG.ECommerce.Shared.Models;

namespace TG.ECommerce.Application.Handlers.Categories.Commands.AddCategory;

public class AddCategoryCommand : IRequest<ApiResult<bool>>
{
    public string Name { get; set; }
}