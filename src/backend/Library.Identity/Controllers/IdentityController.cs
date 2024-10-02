using Library.Identity.Core;
using Library.Identity.Core.Dtos;
using Library.Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Identity.Controllers;

[ApiController]
[Route("[controller]")]
public class IdentityController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;

    public IdentityController(IUserService userService, ITokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }

    [HttpPost("register", Name = "Register")]
    public async Task<IActionResult> Register(UserRegisterDto userDto) 
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        // Return Bad request if user exists
        bool isUserExisted = await _userService.CheckUserExistByEmail(userDto.Email);
        if(isUserExisted)
            return BadRequest("User existed");

        User createdUser = await _userService.RegisterNewUser(userDto);
        return Ok(createdUser);
    }

    [HttpPost("login", Name = "Login")]
    public async Task<IActionResult> Login(LoginDto loginDto) 
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        User user = await _userService.Login(loginDto.Username, loginDto.Password);
        if(user is null)
            return Unauthorized();

        string createdToken = _tokenService.GenerateToken(user);
        return Ok(createdToken);
    }
}
