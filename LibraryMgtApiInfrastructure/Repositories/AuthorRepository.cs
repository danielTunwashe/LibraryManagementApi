
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Repositories;
using LibraryMgtApiInfrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace LibraryMgtApiInfrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryMgtDbContext _context;
        public AuthorRepository(LibraryMgtDbContext context)
        {
            _context = context;
        }

        public async Task<Author> Create(Author author)
        {
            var createdAuthor = await _context.authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return createdAuthor.Entity;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            var authors = await _context.authors.ToListAsync();
            return authors.AsEnumerable();
        }

        public async Task<Author?> GetById(int id)
        {
            var author = await _context.authors
            .Include(a => a.Books)
            .ThenInclude(b => b.BookGenres)
            .FirstOrDefaultAsync(a => a.Id == id);

            return author;
        }

        public async Task<Author> Update(Author author)
        {
            var updatedAuthor = _context.authors.Update(author);
            await _context.SaveChangesAsync();
            return updatedAuthor.Entity;
        }
    }
}
