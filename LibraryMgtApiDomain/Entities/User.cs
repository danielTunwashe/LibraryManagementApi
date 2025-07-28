namespace LibraryMgtApiDomain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        // Navigation Property
        public UserProfile Profile { get; set; } = default!;
    }
}
