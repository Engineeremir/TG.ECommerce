using MediatR;
using TG.ECommerce.Shared.Models;

namespace TG.ECommerce.Application.Handlers.Products.Commands.AddProduct;

public class AddProductCommand : IRequest<ApiResult<bool>>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public Guid CategoryId { get; set; }
}