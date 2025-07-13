
using LibraryMgtApiDomain.Entities;

namespace LibraryMgtApiDomain.Repositories
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
    }
}
