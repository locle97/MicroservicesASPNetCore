using Library.Identity.Core;
using Loclep.Generic.EFCore;

namespace Library.Identity.Infrastructure.Repository;

public interface IUserRepository: IBaseRepository<User, int>
{
}
