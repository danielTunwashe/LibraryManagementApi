using LibraryMgtApiApplication.Dto;
using MediatR;

namespace LibraryMgtApiApplication.AuthorBooks.Commands.CreateNewBookForAuthor
{
    public class CreateNewBookForAuthorCommand : IRequest<CreateNewBookForAuthorResponseDto>
    {
        public string Title { get; set; } = default!;
        public DateTime PublishedDate { get; set; }

        public int AuthorId { get; set; }
    }
}
