namespace KeyboardLibrary.Product.Domain.Entities
{
    public class KeycapImage
    {
      public int Id { get; set; }

      public string Url { get; set; }

      public int? KeycapId { get; set; }

      public Keycap? Keycap { get; set; }
    }
}
