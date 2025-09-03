using MediatR;
using TG.ECommerce.Application.Specifications.Categories;
using TG.ECommerce.Domain.AggregateModels.CategoryAggregate;
using TG.ECommerce.Shared.Models;
using TG.ECommerce.Shared.SeedWork;

namespace TG.ECommerce.Application.Handlers.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<UpdateCategoryCommand, ApiResult<bool>>
{
    public async Task<ApiResult<bool>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var categorySpec = new GetCategoryByIdSpecification(request.Id);
        var category = await categoryRepository.FirstOrDefaultAsync(categorySpec, cancellationToken);

        if (category is null)
        {
            throw new ApplicationGeneralException("category not found");
        }

        category.Update(request.Name);

        await categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return new ApiResult<bool>().ResponseOk(true);
    }
}