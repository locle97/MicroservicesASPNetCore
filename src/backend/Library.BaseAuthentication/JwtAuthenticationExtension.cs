using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Library.BaseAuthentication
{
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

            // Jwt configuration
            _ = services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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

            return services;
        }

        public static IServiceCollection AddPolicies(
                this IServiceCollection services)
        {
            // Add policy
            _ = services.AddAuthorization(static options =>
            {
                options.AddPolicy("Admin", static policy =>
                {
                    _ = policy.RequireRole("ADM");
                });
            });

            return services;
        }
    }
}
