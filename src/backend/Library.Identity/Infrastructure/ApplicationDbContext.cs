using Library.Identity.Core;
using Microsoft.EntityFrameworkCore;

namespace Library.Identity.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Role> UserRoles { get; set; }

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
        var adminRole = new Role()
        {
            Id = 1,
            Name = "Admin",
            Code = "ADM",
        };
        var userRole = new Role()
        {
            Id = 2,
            Name = "User",
            Code = "USR",
        };

        modelBuilder.Entity<Role>(role =>
        {
            role.HasKey("Id");
            role.HasMany(t => t.Users);
            role.HasData(adminRole, userRole);
        });

        modelBuilder.Entity<User>(user =>
        {
            user.HasKey("Id");
            user.HasOne(t => t.Role);

            user.HasData(new User()
            {
                Id = 1,
                Username = "admin",
                Password = "testing@123",
                Email = "admin@mailinator.com",
                RoleId = adminRole.Id
            });

            user.HasData(new User()
            {
                Id = 2,
                Username = "user",
                Password = "testing@123",
                Email = "user@mailinator.com",
                RoleId = userRole.Id
            });
        });
    }


}
