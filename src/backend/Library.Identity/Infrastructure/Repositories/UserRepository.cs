using Microsoft.EntityFrameworkCore;
using Library.Identity.Core;
using Loclep.Generic.EFCore;

namespace Library.Identity.Infrastructure.Repository;

public class UserRepository : BaseRepository<ApplicationDbContext, User, int>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> CheckUserExistByEmail(string email)
    {
        return await _dbContext.Users.AnyAsync(user => user.Email == email);
    }

    public async Task<User> GetByUsernamePassword(string username, string password)
    {
        return await _dbContext.Users.Include(t => t.Role).FirstOrDefaultAsync(user => user.Username == username && user.Password == password);
    }
}
