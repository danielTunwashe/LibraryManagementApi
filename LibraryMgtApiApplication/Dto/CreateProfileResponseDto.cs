
namespace LibraryMgtApiApplication.Dto
{
    public class CreateProfileResponseDto
    {
        public int Id { get; set; }
        public string Bio { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;

        // Foreign Key
        public int UserId { get; set; }
    }
}
