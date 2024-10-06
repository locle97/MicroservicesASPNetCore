using Library.Book.Domains.Entities;
using Loclep.Generic.EFCore;

namespace Library.Book.Infrastructure.Repositories
{
    public class BookRepository : BaseRepository<ApplicationDbContext, BookEntity, int>, IBookRepository
    {
        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

