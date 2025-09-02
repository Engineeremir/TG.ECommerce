using FluentValidation;

namespace TG.ECommerce.Application.Handlers.Categories.Commands.AddCategory
{
    public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("category name can not be empty")
                .MaximumLength(200).WithMessage("category name length must be maximum 200 character");
        }
    }
}
