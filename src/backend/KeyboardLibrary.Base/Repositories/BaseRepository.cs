
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace KeyboardLibrary.Base.Repositories
{
  public class BaseRepository<TDbContext, T>: IBaseRepository<T> 
    where T: class 
    where TDbContext: DbContext
  {
    protected readonly TDbContext _dbContext;

    public BaseRepository(TDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<T> AddAsync(T entity)
    {
      await _dbContext.Set<T>().AddAsync(entity);
      await _dbContext.SaveChangesAsync();
      return entity;
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
      await _dbContext.Set<T>().AddRangeAsync(entities);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
      IEnumerable<T> result = await _dbContext.Set<T>().Where(predicate).ToListAsync();
      return result;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
      return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetAsync(int id)
    {
      return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task RemoveAsync(T entity)
    {
      _dbContext.Set<T>().Remove(entity);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<T> UpdateAsync(T entity)
    {
      _dbContext.Set<T>().Update(entity);
      await _dbContext.SaveChangesAsync();
      return entity;
    }
  }
}
