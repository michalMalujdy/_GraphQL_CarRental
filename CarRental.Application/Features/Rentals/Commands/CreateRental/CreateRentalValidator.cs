using CarRental.Application.Common;
using FluentValidation;

namespace CarRental.Application.Features.Rentals.Commands.CreateRental
{
    public class CreateRentalValidator : AbstractValidator<CreateRentalCommand>
    {
        public CreateRentalValidator()
        {
            RuleFor(x => x.RenterFullName)
                .NotEmpty()
                .MaximumLength(Validation.Rental.RenterFullNameMaxLength);
        }
    }
}