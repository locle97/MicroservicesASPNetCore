using Library.BaseAuthentication;

namespace Library.Book;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Jwt configuration starts here
        var jwtKey = builder.Configuration.GetSection("Jwt:SecretKey").Get<string>();
        var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();

        builder.Services.AddJwtAuthentication(jwtKey, jwtIssuer);
        builder.Services.AddPolicies();
        //Jwt configuration ends here

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

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
