using KeyboardLibrary.Keycap.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KeyboardLibrary.Keycap
{
  public class KeycapDbContext: DbContext
  {
    public DbSet<KeycapEntity> Keycaps { get; set; }
    public DbSet<KeycapImage> KeycapImages { get; set; }

    public KeycapDbContext(DbContextOptions<KeycapDbContext> options) : base(options)
    {
    }

    public KeycapDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=localhost;User Id=sa;Password=sa@123456;Database=Keycap;Trusted_Connection=False;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<KeycapEntity>().ToTable("Keycaps");
      modelBuilder.Entity<KeycapImage>().ToTable("KeycapImages");
      modelBuilder.Entity<KeycapEntity>().HasMany<KeycapImage>().WithOne();
    }
  }
}
