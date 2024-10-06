namespace Library.Book.Domains.Entities
{
    public class BookEntity
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public int? Quantity { get; set; }

        public int? AuthorId { get; set; }

        public Author? Author { get; set; } = null!;
    }
}
