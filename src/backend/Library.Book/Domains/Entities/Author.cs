namespace Library.Book.Domains.Entities
{
    public class Author
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public BookEntity[] Books { get; set; } = [];
    }
}

