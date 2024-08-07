namespace KeyboardLibrary.Keycap.Domain.Entities
{
    public class KeycapEntity
    {
      public int Id { get; set; }

      public string Name { get; set; }

      public string? SourceUrl { get; set; }

      public List<KeycapImage> Images { get; set; } = new List<KeycapImage>();
    }
}
