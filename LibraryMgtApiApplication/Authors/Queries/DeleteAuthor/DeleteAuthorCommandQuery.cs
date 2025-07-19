
using MediatR;

namespace LibraryMgtApiApplication.Authors.Queries.DeleteAuthor
{
    public class DeleteAuthorCommandQuery : IRequest
    {
        public DeleteAuthorCommandQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
