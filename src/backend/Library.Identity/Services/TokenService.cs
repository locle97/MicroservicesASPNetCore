using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Library.Identity.Core;
using Microsoft.IdentityModel.Tokens;

namespace Library.Identity.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(User user)
    {
        // Load key
        string secretKey = _configuration.GetSection("Jwt").GetValue<string>("SecretKey");
        string issuer = _configuration.GetSection("Jwt").GetValue<string>("Issuer");
        string audience = _configuration.GetSection("Jwt").GetValue<string>("Audience");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        // Define credentials
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // build token object
        var payload = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: new Claim[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim("username", user.Username),
            },
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
        );

        // Generate
        return new JwtSecurityTokenHandler().WriteToken(payload);
    }
}

