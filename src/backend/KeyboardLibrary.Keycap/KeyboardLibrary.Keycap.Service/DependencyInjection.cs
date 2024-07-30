using KeyboardLibrary.Keycap.Service.Interfaces;
using KeyboardLibrary.Keycap.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace KeyboardLibrary.Keycap.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddKeycapServices(this IServiceCollection services)
        {
            services.AddScoped<IKeycapService, KeycapService>();
            return services;
        }
    }
}
