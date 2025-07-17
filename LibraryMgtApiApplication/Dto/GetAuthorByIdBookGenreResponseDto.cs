using LibraryMgtApiDomain.Entities;

namespace LibraryMgtApiApplication.Dto
{
    public class GetAuthorByIdBookGenreResponseDto
    {
        public int BookId { get; set; }

        public int GenreId { get; set; }
    }
}
