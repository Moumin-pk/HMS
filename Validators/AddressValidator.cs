using FluentValidation;
using HMS.Data.Models;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(a => a.Street).NotEmpty().WithMessage("Street address is required.")
            .MaximumLength(100).WithMessage("Street address cannot be more than 100 characters.");

        RuleFor(a => a.City).NotEmpty().WithMessage("City is required.")
            .MaximumLength(100).WithMessage("City cannot be more than 100 characters.");

        RuleFor(a => a.State).NotEmpty().WithMessage("State is required.")
            .MaximumLength(100).WithMessage("State cannot be more than 100 characters.");

        RuleFor(a => a.PostalCode).NotEmpty().WithMessage("Postal code is required.")
            .Matches(@"^\d{5}(-\d{4})?$").WithMessage("Invalid postal code format.");

        RuleFor(a => a.Country).NotEmpty().WithMessage("Country is required.")
            .MaximumLength(100).WithMessage("Country cannot be more than 100 characters.");
    }
}