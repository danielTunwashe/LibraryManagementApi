
using LibraryMgtApiApplication.Dto;
using MediatR;

namespace LibraryMgtApiApplication.Books.Queries.GetAllBooksForAuthor
{
    public class GetAllBooksForAuthorQuery : IRequest<IEnumerable<CreateNewBookForAuthorResponseDto>>
    {

        public GetAllBooksForAuthorQuery(int authorId)
        {
            AuthorId = authorId;
        }
        public int AuthorId { get; }
    }
}
