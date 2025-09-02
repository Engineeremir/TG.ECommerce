using MediatR;
using TG.ECommerce.Domain.AggregateModels.CategoryAggregate;
using TG.ECommerce.Shared.Models;

namespace TG.ECommerce.Application.Handlers.Categories.Commands.AddCategory;

public class AddCategoryCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<AddCategoryCommand, ApiResult<bool>>
{
    public async Task<ApiResult<bool>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(request.Name);
        await categoryRepository.AddAsync(category, cancellationToken);
        await categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return new ApiResult<bool>().ResponseOk(true);
    }
}
