using FluentValidation;

namespace TG.ECommerce.Application.Handlers.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("category name can not be empty")
                .MaximumLength(200).WithMessage("category name length must be maximum 200 character");
        }
    }
}
