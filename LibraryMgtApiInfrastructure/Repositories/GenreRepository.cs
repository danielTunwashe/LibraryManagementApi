
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Exceptions;
using LibraryMgtApiDomain.Repositories;
using LibraryMgtApiInfrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace LibraryMgtApiInfrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly LibraryMgtDbContext _dbContext;    
        public GenreRepository(LibraryMgtDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Genre?> GetById(int id)
        {
            var genre = await _dbContext.genres.Include(g => g.BookGenres).FirstOrDefaultAsync(g => g.Id == id);
            return genre;
        }

        public async Task<List<Genre>> GetById(List<int> ids)
        {
            return await _dbContext.genres.Where(g => ids.Contains(g.Id)).ToListAsync();
        }
    }
}
