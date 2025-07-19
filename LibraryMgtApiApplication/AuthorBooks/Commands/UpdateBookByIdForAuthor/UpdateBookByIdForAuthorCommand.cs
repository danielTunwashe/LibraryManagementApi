

using LibraryMgtApiDomain.Entities;
using MediatR;

namespace LibraryMgtApiApplication.AuthorBooks.Commands.UpdateBookByIdForAuthor
{
    public class UpdateBookByIdForAuthorCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public DateTime PublishedDate { get; set; }

        public int AuthorId { get; set; }
    }
}
