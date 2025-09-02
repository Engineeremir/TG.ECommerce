using Ardalis.Specification;
using TG.ECommerce.Domain.AggregateModels.CategoryAggregate;

namespace TG.ECommerce.Application.Specifications.Categories
{
    public class GetCategoryByIdSpecification : Specification<Category>
    {
        public GetCategoryByIdSpecification(Guid categoryId)
        {
            Query.Where(x => x.Id == categoryId);
        }
    }
}