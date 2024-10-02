using AutoMapper;
using Library.Identity.Core;
using Library.Identity.Core.Dtos;
using Library.Identity.Infrastructure.Repository;

namespace Library.Identity.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UserRegisterDto, User>());
        _mapper = config.CreateMapper();

    }

    public async Task<bool> CheckUserExistByEmail(string email)
    {
        return await _userRepository.CheckUserExistByEmail(email);
    }

    public async Task<User> RegisterNewUser(UserRegisterDto user)
    {
        User userDto = _mapper.Map<UserRegisterDto, User>(user);
        User createdUser = await CreateUser(userDto);
        return createdUser;
    }

    private async Task<User> CreateUser(User user)
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

    public async Task<User> Login(string username, string password)
    {
        User dbUser = await _userRepository.GetByUsernamePassword(username, password);
        return dbUser;
    }
}

