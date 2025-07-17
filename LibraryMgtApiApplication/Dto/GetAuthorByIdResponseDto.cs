
using LibraryMgtApiDomain.Entities;

namespace LibraryMgtApiApplication.Dto
{
    public class GetAuthorByIdResponseDto 
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Biography { get; set; } = default!;

        public ICollection<GetAuthorByIdBookResponseDto> Books { get; set; } = new List<GetAuthorByIdBookResponseDto>();
    }
}
