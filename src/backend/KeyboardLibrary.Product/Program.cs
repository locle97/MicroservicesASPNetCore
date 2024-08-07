using KeyboardLibrary.Product.Repositories;
using KeyboardLibrary.Product.Services;
using Microsoft.EntityFrameworkCore;

namespace KeyboardLibrary.Product;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        // Add services to the container.
        builder.Services.AddKeycapServices();
        builder.Services.AddKeycapRepository(connectionString ?? string.Empty);

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

internal static class DependencyInjection
{
    public static IServiceCollection AddKeycapRepository(this IServiceCollection services, string connectionString)
    {
      services.AddDbContext<ProductDbContext>(options => {
        options.UseSqlServer(connectionString);
      });

      services.AddScoped<IKeycapRepository, KeycapRepository>();
      return services;
    }

    public static IServiceCollection AddKeycapServices(this IServiceCollection services)
    {
        services.AddScoped<IKeycapService, KeycapService>();
        return services;
    }
}
