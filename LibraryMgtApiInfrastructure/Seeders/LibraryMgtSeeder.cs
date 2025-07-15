


using LibraryMgtApiDomain.Entities;
using LibraryMgtApiInfrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace LibraryMgtApiInfrastructure.Seeders
{
    public class LibraryMgtSeeder : ILibraryMgtSeeder
    {
        private readonly LibraryMgtDbContext _context;
        public LibraryMgtSeeder(LibraryMgtDbContext context)
        {
            _context = context;
        }
        public async Task seed()
        {
            if (!_context.genres.Any())
            {
                var genre = GetGenres();
                _context.genres.AddRange(genre);
                await _context.SaveChangesAsync();
            }

            if (!_context.authors.Any())
            {
                var author = GetAuthors();
                _context.authors.AddRange(author);
                await _context.SaveChangesAsync();
            }

            if (!_context.users.Any())
            {
                var user = GetUsers();
                _context.users.AddRange(user);
                await _context.SaveChangesAsync();
            }
        }

        private IEnumerable<Author> GetAuthors()
        {
            return new List<Author>
    {
        new Author
        {
            Name = "George Orwell",
            Biography = "British novelist and journalist.",
            Books = new List<Book>
            {
                new Book
                {
                    Title = "1984",
                    PublishedDate = new DateTime(1949, 6, 8),
                    AuthorId = 1,
                    BookGenres = new List<BookGenre>
                    {
                        new BookGenre { BookId = 1, GenreId = 2 } // Science Fiction
                    }
                },
                new Book
                {
                    Title = "Animal Farm",
                    PublishedDate = new DateTime(1945, 8, 17),
                    AuthorId = 1,
                    BookGenres = new List<BookGenre>
                    {
                        new BookGenre { BookId = 2, GenreId = 1 } // Fiction
                    }
                },
                new Book
                {
                    Title = "Homage to Catalonia",
                    PublishedDate = new DateTime(1938, 4, 25),
                    AuthorId = 1,
                    BookGenres = new List<BookGenre>
                    {
                        new BookGenre { BookId = 3, GenreId = 3 } // Historical
                    }
                },
                new Book
                {
                    Title = "The Road to Wigan Pier",
                    PublishedDate = new DateTime(1937, 3, 8),
                    AuthorId = 1,
                    BookGenres = new List<BookGenre>
                    {
                        new BookGenre { BookId = 4, GenreId = 3 } // Historical
                    }
                },
                new Book
                {
                    Title = "Down and Out in Paris and London",
                    PublishedDate = new DateTime(1933, 1, 9),
                    AuthorId = 1,
                    BookGenres = new List<BookGenre>
                    {
                        new BookGenre { BookId = 5, GenreId = 3 } // Historical
                    }
                }
            }
        },
        new Author
        {
            Name = "Chinua Achebe",
            Biography = "Nigerian novelist, poet, and critic.",
            Books = new List<Book>
            {
                new Book
                {

                    Title = "Things Fall Apart",
                    PublishedDate = new DateTime(1958, 1, 1),
                    AuthorId = 2,
                    BookGenres = new List<BookGenre>
                    {
                        new BookGenre { BookId = 6, GenreId = 1 },
                        new BookGenre { BookId = 6, GenreId = 3 }
                    }
                },
                new Book
                {
                    Title = "No Longer at Ease",
                    PublishedDate = new DateTime(1960, 1, 1),
                    AuthorId = 2,
                    BookGenres = new List<BookGenre>
                    {
                        new BookGenre { BookId = 7, GenreId = 1 }
                    }
                },
                new Book
                {
  
                    Title = "Arrow of God",
                    PublishedDate = new DateTime(1964, 1, 1),
                    AuthorId = 2,
                    BookGenres = new List<BookGenre>
                    {
                        new BookGenre { BookId = 8, GenreId = 3 }
                    }
                }
            }
        }
    };
        }

        private IEnumerable<Genre> GetGenres()
        {
            return new List<Genre>
            {
                new Genre { Name = "Fiction" },
                new Genre { Name = "Science Fiction" },
                new Genre { Name = "Historical" }
            };
        }

        private IEnumerable<User> GetUsers()
        {
            return new List<User>
    {
        new User
        {
            Username = "john_doe",
            Email = "john@example.com",
            Profile = new UserProfile
            {
                UserId = 1,
                Bio = "Avid reader of dystopian fiction.",
                PhoneNumber = "0803-123-4567"
            }
        },
        new User
        {   
            Username = "jane_smith",
            Email = "jane@example.com",
            Profile = new UserProfile
            {
                UserId = 2,
                Bio = "Enjoys African literature and poetry.",
                PhoneNumber = "0812-234-5678"
            }
        },
        new User
        {   
            Username = "alex_brown",
            Email = "alex@example.com",
            Profile = new UserProfile
            {
                UserId = 3,
                Bio = "Sci-fi enthusiast and writer.",
                PhoneNumber = "0701-345-6789"
            }
        },
        new User
        {   
            Username = "lisa_white",
            Email = "lisa@example.com",
            Profile = new UserProfile
            {
                UserId = 4,
                Bio = "Book club organizer and mystery fan.",
                PhoneNumber = "0902-456-7890"
            }
        },
        new User
        {
 
            Username = "michael_lee",
            Email = "michael@example.com",
            Profile = new UserProfile
            {

                UserId = 5,
                Bio = "History buff and classic literature lover.",
                PhoneNumber = "0806-567-8901"
            }
        }
    };
        }

    }
}
