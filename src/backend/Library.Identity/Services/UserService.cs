using Library.Identity.Core;
using Library.Identity.Infrastructure.Repository;

namespace Library.Identity.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateUser(User user)
    {
        User createdUser = await _userRepository.Create(user);
        return createdUser;
    }

    public async Task DeleteUser(int id)
    {
        await _userRepository.Delete(id);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        IEnumerable<User> users = await _userRepository.GetAll();
        return users;
    }

    public async Task<User> GetUserById(int id)
    {
        User user = await _userRepository.GetById(id);
        return user;
    }

    public async Task<User> UpdateUser(User user)
    {
        User dbUser = await _userRepository.Update(user);
        return dbUser;
    }
}

