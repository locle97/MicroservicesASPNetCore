using Library.Identity.Core;
using Microsoft.EntityFrameworkCore;

namespace Library.Identity.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected ApplicationDbContext()
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=localhost;User Id=sa;Password=sa@123456;Database=Identity;Trusted_Connection=False;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>(action =>
        {
            action.HasKey("Id");
            action.HasData(new User()
            {
                Id = 1,
                Username = "admin",
                Password = "123456",
                Email = "admin@mailinator.com"
            });
        });
    }


}
