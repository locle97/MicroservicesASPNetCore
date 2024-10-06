using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Library.BaseAuthentication;

public static class JwtAuthenticationExtension
{
    public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            string jwtSecretKey,
            string jwtIssuer)
    {
        // Argument validation
        ArgumentNullException.ThrowIfNullOrEmpty(jwtSecretKey);
        ArgumentNullException.ThrowIfNullOrEmpty(jwtIssuer);

        var keyByteCount = Encoding.UTF8.GetByteCount(jwtSecretKey);
        if (keyByteCount < 256)
            throw new ArgumentException(
                    $"Jwt secret key is required 256, your key is just {keyByteCount}");

        // Jwt configuration
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidIssuer = jwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey))
                };
            });

        // Add policy
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy =>
            {
                policy.RequireRole("ADM");
            });
        });

        return services;
    }
}
