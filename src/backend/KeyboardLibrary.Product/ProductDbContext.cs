using KeyboardLibrary.Product.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KeyboardLibrary.Product
{
  public class ProductDbContext: DbContext
  {
    public DbSet<Keycap> Keycaps { get; set; }
    public DbSet<KeycapImage> KeycapImages { get; set; }

    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }

    public ProductDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=localhost;User Id=sa;Password=sa@123456;Database=Product;Trusted_Connection=False;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Keycap>().ToTable("Keycaps");
      modelBuilder.Entity<KeycapImage>().ToTable("KeycapImages");
      modelBuilder.Entity<Keycap>().HasMany<KeycapImage>()
                                  .WithOne()
                                  .HasForeignKey(k => k.KeycapId);
    }
  }
}
