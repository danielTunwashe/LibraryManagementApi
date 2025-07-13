namespace LibraryMgtApiDomain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public DateTime PublishedDate { get; set; }

        // Foreign Key (One-to-Many with Author)
        public int AuthorId { get; set; }
        public Author Author { get; set; } = default!;

        // Many-to-Many with Genre
        public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
    }
}