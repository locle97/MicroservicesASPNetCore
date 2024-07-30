using KeyboardLibrary.Keycap.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KeyboardLibrary.Keycap.Repository.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly KeycapDbContext _dbContext;
        public BaseRepository(KeycapDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
          await _dbContext.Set<TEntity>().AddAsync(entity);
          await _dbContext.SaveChangesAsync();
          return entity;
        }

        public async Task Delete(int id)
        {
          TEntity entity = await GetById(id);
          _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
          return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
          return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
          _dbContext.Set<TEntity>().Update(entity);
          await _dbContext.SaveChangesAsync();
          return entity;
        }
    }
}
