using FluentValidation;

namespace TG.ECommerce.Application.Handlers.Products.Commands.AddProduct
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("product name can not be empty")
                .MaximumLength(200).WithMessage("product name length must be maximum 200 character");

            RuleFor(x => x.Price).GreaterThan(0).WithMessage("price must be higher than zero");            
        }
    }
}
