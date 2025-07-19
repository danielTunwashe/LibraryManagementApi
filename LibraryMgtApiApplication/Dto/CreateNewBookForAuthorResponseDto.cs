
using LibraryMgtApiDomain.Entities;

namespace LibraryMgtApiApplication.Dto
{
    public class CreateNewBookForAuthorResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public DateTime PublishedDate { get; set; }

        public int AuthorId { get; set; }
    }
}
