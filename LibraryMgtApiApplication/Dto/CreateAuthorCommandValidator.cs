
using FluentValidation;
using LibraryMgtApiApplication.Authors.Commands.CreateAuthor;

namespace LibraryMgtApiApplication.Dto
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name cannot be more than 100 characters.");

            RuleFor(x => x.Biography)
                .NotEmpty().WithMessage("Biography is required.")
                .MinimumLength(10).WithMessage("Biography must be at least 10 characters long.")
                .MaximumLength(1000).WithMessage("Biography cannot exceed 1000 characters.");
        }
    }
}
