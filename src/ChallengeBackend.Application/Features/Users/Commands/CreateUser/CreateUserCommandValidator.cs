using ChallengeBackend.Application.ViewModels;
using FluentValidation;


namespace ChallengeBackend.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {

            RuleFor(p => p.Name)
                .NotNull().WithMessage("Should not be null")
                .NotEmpty().WithMessage("Should not be empty")
                .MaximumLength(100).WithMessage("Should not exceed 100 characters");

            RuleFor(p => p.Email)
                .NotNull().WithMessage("Should not be null")
                .NotEmpty().WithMessage("Should not be empty")
                .MaximumLength(50).WithMessage("Should not exceed 50 characters")
                .EmailAddress().WithMessage("Should not valid");

            RuleFor(p => p.BirthDate)
                .NotNull().WithMessage("Should not be null")
                .NotEmpty().WithMessage("Should not be empty")
                .Must(BeAValidDate).WithMessage("Should be a valid date");

            RuleFor(p => p.Address)
                .SetValidator(new AddressVmValidator());

        }

        private bool BeAValidDate(string value)
        {
            DateTime date;
            return DateTime.TryParse(value, out date);
        }
    }

    public class AddressVmValidator : AbstractValidator<AddressVm>
    {
        public AddressVmValidator()
        {
            RuleFor(p => p.Street)
               .NotNull().WithMessage("Should not be null")
               .NotEmpty().WithMessage("Should not be empty")
               .MaximumLength(100).WithMessage("Should not exceed 100 characters");

            RuleFor(p => p.State)
                .NotNull().WithMessage("Should not be null")
                .NotEmpty().WithMessage("Should not be empty")
                .MaximumLength(50).WithMessage("Should not exceed 50 characters");

            RuleFor(p => p.City)
                .NotNull().WithMessage("Should not be null")
                .NotEmpty().WithMessage("Should not be empty")
                .MaximumLength(50).WithMessage("Should not exceed 50 characters");

            RuleFor(p => p.Country)
                .NotNull().WithMessage("Should not be null")
                .NotEmpty().WithMessage("Should not be empty")
                .MaximumLength(50).WithMessage("Should not exceed 50 characters");

            RuleFor(p => p.Zip)
                .NotNull().WithMessage("Should not be null")
                .NotEmpty().WithMessage("Should not be empty")
                .MaximumLength(50).WithMessage("Should not exceed 50 characters");
        }
    }

}
