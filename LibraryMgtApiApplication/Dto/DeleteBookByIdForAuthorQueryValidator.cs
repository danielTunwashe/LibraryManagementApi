
using FluentValidation;
using LibraryMgtApiApplication.AuthorBooks.Queries.DeleteBookByIdForAuthor;

namespace LibraryMgtApiApplication.Dto
{
    public class DeleteBookByIdForAuthorQueryValidator : AbstractValidator<DeleteBookByIdForAuthorQuery>
    {
        public DeleteBookByIdForAuthorQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Book Id must be greater than 0.");

            RuleFor(x => x.AuthorId)
                .GreaterThan(0).WithMessage("Author Id must be greater than 0.");
        }
    }
}
