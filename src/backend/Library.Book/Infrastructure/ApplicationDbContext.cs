using Library.Book.Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Book.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            _ = optionsBuilder.UseSqlServer(@"
                    Server=localhost;User Id=sa;
                    Password=sa@123456;
                    Database=Book;
                    Trusted_Connection=False;
                    TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>(static author =>
            {
                author.HasKey(static t => t.Id);
                author.HasData(new Author()
                {
                    Id = 1,
                    Name = "Steve \"ardalis\" Smith"
                },
                new Author
                {
                    Id = 2,
                    Name = "Wikibooks"
                });
            });

            modelBuilder.Entity<BookEntity>(static book =>
            {
                int bookIndex = 1;

                book.HasKey(static t => t.Id);
                book.HasOne(static t => t.Author);
                book.HasData(new BookEntity()
                {
                    Id = bookIndex++,
                    Name = "Architect Modern Web Applications with ASP.NET Core and Azure",
                    Quantity = 5,
                    AuthorId = 1,
                }, new BookEntity
                {
                    Id = bookIndex++,
                    Name = "C# Programming ",
                    Quantity = 5,
                    AuthorId = 2,
                });
            });
        }
    }
}
