namespace LibraryMgtApiApplication.Dto
{
    public class GetUserByIdResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;

        // Navigation Property
        public UserProfileDto Profile { get; set; } = default!;
    }
}
