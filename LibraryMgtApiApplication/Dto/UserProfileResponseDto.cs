namespace LibraryMgtApiApplication.Dto
{
    public class UserProfileResponseDto
    {
        public int Id { get; set; }
        public string Bio { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;

        public int UserId { get; set; }
    }
}
