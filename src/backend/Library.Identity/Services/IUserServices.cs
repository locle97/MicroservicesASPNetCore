using Library.Identity.Core;
using Library.Identity.Core.Dtos;

namespace Library.Identity.Services;

public interface IUserService
{
    Task<IEnumerable<UserInfoDto>> GetAllUsers();
    Task<UserInfoDto> GetUserById(int id);
    Task<User> RegisterNewUser(UserRegisterDto user);
    Task<User> UpdateUser(User user);
    Task DeleteUser(int id);
    Task<bool> CheckUserExistByEmail(string email);
    Task<User> Login(string username, string password);
}
