using FluentValidation;
using LibraryMgtApiApplication.UxarProfile.Commands.CreateProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgtApiApplication.Dto
{
    public class CreateProfileCommandValidator : AbstractValidator<CreateProfileCommand>
    {
        public CreateProfileCommandValidator()
        {
            RuleFor(x => x.Bio)
            .NotEmpty().WithMessage("Bio is required.")
            .MinimumLength(10).WithMessage("Bio must be at least 10 characters long.")
            .MaximumLength(500).WithMessage("Bio cannot exceed 500 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Phone number must be valid and contain 10 to 15 digits.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be a positive number.");
        }
    }
 }

