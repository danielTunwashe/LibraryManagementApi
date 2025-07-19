
using LibraryMgtApiApplication.Dto;
using MediatR;

namespace LibraryMgtApiApplication.AuthorBooks.Queries.GetBookByIdForAuthor
{
    public class GetBookByIdForAuthorQuery : IRequest<GetBookByIdForAuthorResponseDto>
    {

        public GetBookByIdForAuthorQuery(int id, int authorId)
        {
            Id = id;
            AuthorId = authorId;
        }

        public int Id { get; }
        public int AuthorId { get; }
    }
}
