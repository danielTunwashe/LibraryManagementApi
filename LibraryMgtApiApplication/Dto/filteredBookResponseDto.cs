

using LibraryMgtApiDomain.Entities;

namespace LibraryMgtApiApplication.Dto
{
    public class filteredBookResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public DateTime PublishedDate { get; set; }

        // Foreign Key (One-to-Many with Author)
        public int AuthorId { get; set; }
        public AuthorDto Author { get; set; } = default!;

        // Many-to-Many with Genre
        public ICollection<BookGenreDto> BookGenres { get; set; } = new List<BookGenreDto>();
    }
}
