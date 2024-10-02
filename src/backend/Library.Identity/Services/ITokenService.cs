using Library.Identity.Core;

namespace Library.Identity.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}
