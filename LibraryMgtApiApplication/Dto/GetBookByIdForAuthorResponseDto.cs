
using LibraryMgtApiDomain.Entities;

namespace LibraryMgtApiApplication.Dto
{
    public class GetBookByIdForAuthorResponseDto 
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public DateTime PublishedDate { get; set; }

        public int AuthorId { get; set; }
        public ICollection<BookGenreDto> BookGenres { get; set; } = new List<BookGenreDto>();
    }
}
