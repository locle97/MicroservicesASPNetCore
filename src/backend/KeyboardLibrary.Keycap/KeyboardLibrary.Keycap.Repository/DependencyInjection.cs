using KeyboardLibrary.Keycap.Repository.Interfaces;
using KeyboardLibrary.Keycap.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KeyboardLibrary.Keycap.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddKeycapRepository(this IServiceCollection services, string connectionString)
        {
          services.AddDbContext<KeycapDbContext>(options => {
            options.UseSqlServer(connectionString);
          });

          services.AddScoped<IKeycapRepository, KeycapRepository>();
          return services;
        }
    }
}
