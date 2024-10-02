
using Library.Identity.Infrastructure;
using Library.Identity.Infrastructure.Repository;
using Library.Identity.Services;
using Microsoft.EntityFrameworkCore;

namespace Library.Identity;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        string connectionString = builder.Configuration.GetConnectionString("Default")!;

        // Add services to the container.
        builder.Services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseSqlServer(connectionString);
        });

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

        builder.Services.AddScoped<ApplicationDbContext, ApplicationDbContext>();

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
