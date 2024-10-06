using Library.Book.Domains.Entities;
using Loclep.Generic.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Book.Infrastructure.Repositories
{
    public class BookRepository : BaseRepository<ApplicationDbContext, BookEntity, int>, IBookRepository
    {
        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<BookEntity>> GetBooks()
        {
            return await _dbContext.Books.Include(b => b.Author).ToListAsync();
        }
    }
}

