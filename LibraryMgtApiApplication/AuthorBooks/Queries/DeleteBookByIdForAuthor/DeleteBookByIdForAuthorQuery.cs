
using MediatR;

namespace LibraryMgtApiApplication.AuthorBooks.Queries.DeleteBookByIdForAuthor
{
    public class DeleteBookByIdForAuthorQuery : IRequest
    {
        public DeleteBookByIdForAuthorQuery(int id, int authorId)
        {
            Id = id; 
            AuthorId = authorId;
        }

        public int Id { get; }
        public int AuthorId { get; }
    }
}
