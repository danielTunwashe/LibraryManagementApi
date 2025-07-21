using LibraryMgtApiDomain.Entities;

namespace LibraryMgtApiDomain.Repositories
{
    public interface IAuthorRepository
    {
        Task<Author> Create(Author author);
        Task Delete(Author author);
        Task <IEnumerable<Author>> GetAll();
        Task <Author> GetById(int id);
        Task<Author?> GetByName(string authorName);
        Task <Author> Update(Author author);
    }
}
