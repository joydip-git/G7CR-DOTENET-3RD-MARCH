using FluentValidation;

namespace WebApplication1.Models.Validators
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            this.RuleFor<string>(p => p.ProductName)
                .NotNull()
                .WithMessage("should not be null")
                .NotEmpty()
                .WithMessage("should npt be empty")
                .MaximumLength(50)
                .WithMessage("product name should have max 50 characters");

            this.RuleFor<decimal?>(p => p.Price)
                .LessThan(10000)
                .GreaterThan(0)
                .WithMessage("value should be more than 0 and less than 10000");



        }
    }
}
