
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Repositories;
using LibraryMgtApiInfrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace LibraryMgtApiInfrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryMgtDbContext _context;
        public BookRepository(LibraryMgtDbContext context)
        {
            _context = context;
        }
        public async Task<Book> Create(Book book)
        {
            var createdBook = await _context.books.AddAsync(book);
            await _context.SaveChangesAsync();
            return createdBook.Entity;
        }

        public async Task Delete(Book book)
        {
            _context.books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetBookByAuthorOrGenre(string? authorName, string? genreName)
        {
            var query = _context.books
            .Include(book => book.Author)
            .Include(book => book.BookGenres)
            .ThenInclude(bg => bg.Genre)
            .AsQueryable();

            if (!string.IsNullOrEmpty(authorName))
            {
                query = query.Where(b => b.Author.Name == authorName);
            }

            if (!string.IsNullOrEmpty(genreName))
            {
                query = query.Where(b => b.BookGenres.Any(bg => bg.Genre.Name == genreName));   
            }

            var result = await query.ToListAsync();
            return result.AsEnumerable();
        }

        public async Task<Book?> GetById(int id)
        {
            var book = await _context.books.FirstOrDefaultAsync(b => b.Id == id);
            return book;
        }

        public async Task<IEnumerable<Book>> GetFilteredBook(string title, string authorName, string genreName)
        {
            var query = _context.books
            .Include(b => b.Author)
            .Include(b => b.BookGenres)
            .ThenInclude(bg => bg.Genre)
            .AsQueryable();

            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(b => b.Title.Contains(title));
            }

            if (!string.IsNullOrWhiteSpace(authorName))
            {
                query = query.Where(b => b.Author.Name.Contains(authorName));
            }

            if (!string.IsNullOrWhiteSpace(genreName))
            {
                query = query.Where(b =>
                    b.BookGenres.Any(bg => bg.Genre.Name.Contains(genreName))
                );
            }

            var result = await query.ToListAsync();

            return result.AsEnumerable();
        }

        

        public async Task Update(Book mappedBook)
        {
            _context.books.Update(mappedBook);
            await _context.SaveChangesAsync();
        }
    }
}
