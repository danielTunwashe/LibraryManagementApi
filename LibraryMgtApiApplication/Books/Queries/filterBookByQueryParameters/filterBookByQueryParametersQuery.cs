

using LibraryMgtApiApplication.Dto;
using MediatR;

namespace LibraryMgtApiApplication.Books.Queries.filterBookByQueryParameters
{
    public class filterBookByQueryParametersQuery : IRequest<IEnumerable<filteredBookResponseDto>>
    {

        public filterBookByQueryParametersQuery(string title, string authorName, string genreName)
        {
            Title = title;
            AuthorName = authorName;
            GenreName = genreName;
        }

        public string? Title { get;}
        public string? AuthorName { get; }
        public string? GenreName { get; }
    }
}
