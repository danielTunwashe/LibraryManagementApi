
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Repositories;
using LibraryMgtApiInfrastructure.DataAccess;

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



    }
}
