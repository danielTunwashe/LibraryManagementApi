
using LibraryMgtApiDomain.Entities;

namespace LibraryMgtApiDomain.Repositories
{
    public interface IBookRepository
    {
        Task<Book> Create(Book book);
        Task Delete(Book book);
        Task Update(Book mappedBook);
        Task<Book?> GetById(int id);
    }
}
