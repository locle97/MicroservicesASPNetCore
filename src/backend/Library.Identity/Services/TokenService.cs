using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Library.Identity.Core;
using Microsoft.IdentityModel.Tokens;

namespace Library.Identity.Services
{
    public class TokenService(IConfiguration configuration) : ITokenService
    {
        private readonly IConfiguration _configuration = configuration;

        public string GenerateToken(User user)
        {
            // Load key
            string secretKey = _configuration.GetSection("Jwt").GetValue<string>("SecretKey");
            string issuer = _configuration.GetSection("Jwt").GetValue<string>("Issuer");

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(secretKey));

            // Define credentials
            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

            // build token object
            int id = user.Id;
            JwtSecurityToken payload = new(
                issuer: issuer,
                claims:
                [
                    new Claim("id", id.ToString()),
                    new Claim("username", user.Username),
                    new Claim(ClaimTypes.Role, user.Role?.Code ?? string.Empty)
                ],
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            // Generate
            return new JwtSecurityTokenHandler().WriteToken(payload);
        }
    }

}
