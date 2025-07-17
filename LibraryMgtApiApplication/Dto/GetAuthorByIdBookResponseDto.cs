
using LibraryMgtApiDomain.Entities;

namespace LibraryMgtApiApplication.Dto
{
    public class GetAuthorByIdBookResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public DateTime PublishedDate { get; set; }

        // Foreign Key (One-to-Many with Author)
        public int AuthorId { get; set; }

        public ICollection<GetAuthorByIdBookGenreResponseDto> BookGenres { get; set; } = new List<GetAuthorByIdBookGenreResponseDto>();
    }
}
