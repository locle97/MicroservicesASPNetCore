using Library.Identity.Core;

namespace Library.Identity.Services;

public class TokenService : ITokenService
{
    public string GenerateToken(User user)
    {
        string token = "Token";
        return token;
    }
}

