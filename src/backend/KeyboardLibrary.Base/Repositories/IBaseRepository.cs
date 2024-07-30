using System.Linq.Expressions;

namespace KeyboardLibrary.Base.Repositories
{
  public interface IBaseRepository<T> where T : class
  {
    Task<T> GetAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task RemoveAsync(T entity);
  }
}
