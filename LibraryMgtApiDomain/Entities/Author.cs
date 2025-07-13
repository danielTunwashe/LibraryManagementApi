namespace LibraryMgtApiDomain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Biography { get; set; } = default!;

        // Navigation Property
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
