using Library.Identity.Core;
using Loclep.Generic.EFCore;

namespace Library.Identity.Infrastructure.Repository;

public class UserRepository : BaseRepository<ApplicationDbContext, User, int>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
