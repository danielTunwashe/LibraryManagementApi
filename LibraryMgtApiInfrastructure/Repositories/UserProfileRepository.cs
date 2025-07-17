using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Repositories;
using LibraryMgtApiInfrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace LibraryMgtApiInfrastructure.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly LibraryMgtDbContext _context;
        public UserProfileRepository(LibraryMgtDbContext context)
        {
            _context = context;
        }


        public async Task<UserProfile> Create(UserProfile userProfile)
        {
            await _context.userProfiles.AddAsync(userProfile);
            await _context.SaveChangesAsync();

            return userProfile;
        }

        public async Task Delete(UserProfile profile)
        {
            _context.userProfiles.Remove(profile);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserProfile>> GetAll()
        {
            var userProfiles = await _context.userProfiles.ToListAsync();
            if (userProfiles == null || !userProfiles.Any())
            {
                return new List<UserProfile>();
            }
            return userProfiles.AsEnumerable();
        }


        public async Task<UserProfile?> GetById(int id)
        {
            var userProfile = await _context.userProfiles
                .Include(up => up.User) // Assuming User is a navigation property in UserProfile
                .FirstOrDefaultAsync(up => up.Id == id);

            return userProfile;
        }

        public async Task<UserProfile> Update(UserProfile userProfile)
        {
            _context.userProfiles.Update(userProfile);
            await _context.SaveChangesAsync();
            return userProfile;
        }
    }
}
