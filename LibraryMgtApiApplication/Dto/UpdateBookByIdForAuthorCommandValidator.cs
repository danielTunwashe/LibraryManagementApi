

using FluentValidation;
using FluentValidation.Validators;
using LibraryMgtApiApplication.AuthorBooks.Commands.UpdateBookByIdForAuthor;

namespace LibraryMgtApiApplication.Dto
{
    public class UpdateBookByIdForAuthorCommandValidator : AbstractValidator<UpdateBookByIdForAuthorCommand>
    {
        public UpdateBookByIdForAuthorCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Book Id must be greater than 0.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(150).WithMessage("Title must not exceed 150 characters.");

            RuleFor(x => x.PublishedDate)
                .NotEmpty().WithMessage("Published date is required.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Published date cannot be in the future.");

            RuleFor(x => x.AuthorId)
                .GreaterThan(0).WithMessage("Author Id must be greater than 0.");
        }
    }
}
