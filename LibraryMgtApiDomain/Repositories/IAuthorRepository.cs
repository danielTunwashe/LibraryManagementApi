using LibraryMgtApiDomain.Entities;

namespace LibraryMgtApiDomain.Repositories
{
    public interface IAuthorRepository
    {
        Task<Author> Create(Author author);
        Task <IEnumerable<Author>> GetAll();
        Task <Author> GetById(int id);
        Task <Author> Update(Author author);
    }
}
