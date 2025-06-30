using FluentValidation;
using InventoryPilot.Application.DTOs;

namespace InventoryPilot.API.Validators;

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(100);

        RuleFor(p => p.SKU)
            .NotEmpty().WithMessage("SKU is required.")
            .Matches(@"^[A-Z0-9\-]+$").WithMessage("SKU must be alphanumeric with dashes.");

        RuleFor(p => p.Quantity)
            .GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative.");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");
    }
}