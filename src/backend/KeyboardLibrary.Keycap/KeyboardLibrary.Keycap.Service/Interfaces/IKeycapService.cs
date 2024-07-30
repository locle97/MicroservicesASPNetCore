using KeyboardLibrary.Keycap.Domain.Entities;

namespace KeyboardLibrary.Keycap.Service.Interfaces
{
    public interface IKeycapService
    {
      Task<KeycapEntity> Get(int id);

      Task<IEnumerable<KeycapEntity>> GetListKeycaps();

      Task<KeycapEntity> Create(KeycapEntity keycap);
      Task<bool> Delete(int id);
      Task<KeycapEntity> Update(KeycapEntity keycap);
    }
}
