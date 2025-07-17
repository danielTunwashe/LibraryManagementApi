
namespace LibraryMgtApiApplication.Dto
{
    public class CreateAuthorResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Biography { get; set; } = default!;
    }
}
