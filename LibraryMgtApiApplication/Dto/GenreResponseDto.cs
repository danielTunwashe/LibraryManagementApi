

namespace LibraryMgtApiApplication.Dto
{
    public class GenreResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public ICollection<BookGenreDto> BookGenres { get; set; } = new List<BookGenreDto>();
    }
}
