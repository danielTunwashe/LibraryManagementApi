
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Repositories;
using LibraryMgtApiInfrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace LibraryMgtApiInfrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryMgtDbContext _context;
        public UserRepository(LibraryMgtDbContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            await  _context.users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task Delete(User user)
        {
            _context.users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users =  await _context.users.ToListAsync();
            return users.AsEnumerable();
        }

        public async Task<User?> GetById(int id)
        {
            var user = await _context.users.Include(u => u.Profile).FirstOrDefaultAsync(u => u.Id == id);   
            return user;
        }

        public async Task Update(User user)
        {
            _context.users.Update(user);
            await _context.SaveChangesAsync();
            
        }
    }
}
