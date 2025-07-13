namespace LibraryMgtApiDomain.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        // Navigation Property for Many-to-Many relationship with Book
        public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
    }
}
