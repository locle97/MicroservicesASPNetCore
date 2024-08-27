
using KeyboardLibrary.Identity.Domains.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KeyboardLibrary.Identity;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var config = builder.Configuration;

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Adding authentication
        // Build service for identity store
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        });

        // Add Identity endpoints
        builder.Services.AddIdentityApiEndpoints<User>(options =>
        {
            /*options.SignIn.RequireConfirmedEmail = true;*/
        }).AddEntityFrameworkStores<ApplicationDbContext>();

        // Use JWT Bearer authentication
        builder.Services.AddAuthentication();

        // Add authorization services
        builder.Services.AddAuthorization();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // Use Authentication and Authorization
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapIdentityApi<User>();

        app.Run();
    }
}
