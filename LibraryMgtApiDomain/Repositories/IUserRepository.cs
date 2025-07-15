
using LibraryMgtApiDomain.Entities;

namespace LibraryMgtApiDomain.Repositories
{
    public interface IUserRepository
    {
        Task<User> Create(User user);

        Task<User> GetById(int id);

        Task<IEnumerable<User>> GetAll();

        Task Update(User user);

        Task Delete(User user);
    }
}
