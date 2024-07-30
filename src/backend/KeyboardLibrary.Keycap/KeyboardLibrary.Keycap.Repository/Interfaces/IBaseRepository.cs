namespace KeyboardLibrary.Keycap.Repository.Interfaces
{
    public interface IBaseRepository<T> where T: class
    {
      Task<T> GetById(int id);
      Task<IEnumerable<T>> GetAll();
      Task<T> Create(T entity);
      Task<T> Update(T entity);
      Task Delete(int id);
    }
}
