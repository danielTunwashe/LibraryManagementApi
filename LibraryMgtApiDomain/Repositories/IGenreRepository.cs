


using LibraryMgtApiDomain.Entities;

namespace LibraryMgtApiDomain.Repositories
{
    public interface IGenreRepository
    {
        Task<Genre> GetById(int id);
        Task<List<Genre>> GetById(List<int> ids);
    }
}
