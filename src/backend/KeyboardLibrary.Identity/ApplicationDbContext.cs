using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using KeyboardLibrary.Identity.Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace KeyboardLibrary.Identity;

public class ApplicationDbContext: IdentityDbContext<User>
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): 
    base(options)
  {
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer("Server=localhost;User Id=sa;Password=sa@123456;Database=Identity;Trusted_Connection=False;TrustServerCertificate=True;");
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);
  }
}
