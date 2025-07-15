
using LibraryMgtApiDomain.Entities;

namespace LibraryMgtApiDomain.Repositories
{
    public interface IUserProfileRepository
    {
        Task<UserProfile> Create(UserProfile userProfile);
        Task<IEnumerable<UserProfile>> GetAll();
        Task<UserProfile> GetById(int id);
        Task<UserProfile> Update(UserProfile userProfile);
    }
}
