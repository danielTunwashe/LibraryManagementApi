

using FluentValidation;
using LibraryMgtApiApplication.Uxar.Commands.CreateUser;

namespace LibraryMgtApiApplication.Dto
{
    public class CreateUserResponseDtoValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserResponseDtoValidator()
        {
            RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MinimumLength(3).WithMessage("Username must be at least 3 characters.")
            .MaximumLength(20).WithMessage("Username must not exceed 20 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
