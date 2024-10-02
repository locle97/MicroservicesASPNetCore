using Library.Identity.Core;
using Loclep.Generic.EFCore;

namespace Library.Identity.Infrastructure.Repository;

public interface IUserRepository: IBaseRepository<User, int>
{
    Task<bool> CheckUserExistByEmail(string email);
    Task<User> GetByUsernamePassword(string username, string password);
}
