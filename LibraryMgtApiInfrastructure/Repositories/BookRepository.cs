
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

        public async Task<Book?> GetById(int id)
        {
            var book = await _context.books.FirstOrDefaultAsync(b => b.Id == id);
            return book;
        }

        public async Task Update(Book mappedBook)
        {
            _context.books.Update(mappedBook);
            await _context.SaveChangesAsync();
        }
    }
}
