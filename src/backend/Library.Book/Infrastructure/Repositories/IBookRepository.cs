using Library.Book.Domains.Entities;
using Loclep.Generic.EFCore;

namespace Library.Book.Infrastructure.Repositories
{
    public interface IBookRepository : IBaseRepository<BookEntity, int>
    {
        Task<IEnumerable<BookEntity>> GetBooks();
    }
}
