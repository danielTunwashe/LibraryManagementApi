

namespace LibraryMgtApiApplication.Dto
{
    public class CreateUserResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;

    }
}
