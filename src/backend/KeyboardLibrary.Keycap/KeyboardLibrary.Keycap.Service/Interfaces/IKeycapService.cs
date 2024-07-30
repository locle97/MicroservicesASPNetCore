using KeyboardLibrary.Keycap.Domain.Entities;

namespace KeyboardLibrary.Keycap.Service.Interfaces
{
    public interface IKeycapService
    {
      Task<KeycapEntity> Get(int id);

      Task<IEnumerable<KeycapEntity>> GetListKeycaps();
    }
}
