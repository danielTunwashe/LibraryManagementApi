
using LibraryMgtApiApplication.Dto;
using MediatR;

namespace LibraryMgtApiApplication.Books.Queries.GetListOfBooksBasedOnAuthorAndGenre
{
    public class GetListOfBooksBasedOnAuthorAndGenreQuery : IRequest<IEnumerable<GetAllListOfBooksForAuthorResponseDto>>
    {
        public GetListOfBooksBasedOnAuthorAndGenreQuery(string? authorName, string? genreName)
        {
            AuthorName = authorName;
            GenreName = genreName;
        }

        public string? AuthorName { get; set; }
        public string? GenreName { get; set; }
    }
}
