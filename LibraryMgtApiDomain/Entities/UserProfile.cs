namespace LibraryMgtApiDomain.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Bio { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;

        // Foreign Key
        public int UserId { get; set; }

        // Navigation Property
        public User User { get; set; } = default!;
    }
}