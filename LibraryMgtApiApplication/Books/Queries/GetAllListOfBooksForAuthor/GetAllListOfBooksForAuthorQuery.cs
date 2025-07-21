
using LibraryMgtApiApplication.Dto;
using MediatR;

namespace LibraryMgtApiApplication.Books.Queries.GetAllListOfBooksForAuthor
{
    public class GetAllListOfBooksForAuthorQuery : IRequest<IEnumerable<GetAllListOfBooksForAuthorResponseDto>>
    {
        public GetAllListOfBooksForAuthorQuery(string authorName)
        {
            AuthorName = authorName;
        }
        public string AuthorName { get; set; }
    }
}
