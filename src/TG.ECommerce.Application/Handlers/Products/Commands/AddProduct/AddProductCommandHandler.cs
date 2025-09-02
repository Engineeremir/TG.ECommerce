using MediatR;
using TG.ECommerce.Application.Specifications.Categories;
using TG.ECommerce.Domain.AggregateModels.CategoryAggregate;
using TG.ECommerce.Domain.AggregateModels.ProductAggregate;
using TG.ECommerce.Shared.Models;

namespace TG.ECommerce.Application.Handlers.Products.Commands.AddProduct;

public class AddProductCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<AddProductCommand, ApiResult<bool>>
{
    public async Task<ApiResult<bool>> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var categorySpec = new GetCategoryByIdSpecification(request.CategoryId);
        var category = await categoryRepository.FirstOrDefaultAsync(categorySpec, cancellationToken);

        if (category == null)
        {
            throw new Exception("not found"); //TODO Error Handling
        }

        var product = new Product(request.Name, request.Price, request.Stock, request.CategoryId);
        
        category.AddProduct(product);
        await categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return new ApiResult<bool>().ResponseOk(true);
    }
}
