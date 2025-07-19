
using FluentValidation;
using LibraryMgtApiApplication.AuthorBooks.Queries.GetBookByIdForAuthor;

namespace LibraryMgtApiApplication.Dto
{
    public class GetBookByIdForAuthorQueryValidator : AbstractValidator<GetBookByIdForAuthorQuery>
    {
        public GetBookByIdForAuthorQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Book Id must be greater than 0.");

            RuleFor(x => x.AuthorId)
                .GreaterThan(0).WithMessage("Author Id must be greater than 0.");
        }
    }
}
