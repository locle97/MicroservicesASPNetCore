namespace KeyboardLibrary.Keycap.Domain.Entities
{
    public class KeycapImage
    {
      public int Id { get; set; }

      public string Url { get; set; }

      public int? KeycapId { get; set; }

      public KeycapEntity? Keycap { get; set; }
    }
}
