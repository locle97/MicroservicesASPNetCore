using KeyboardLibrary.Keycap.Domain.Entities;
using KeyboardLibrary.Keycap.Repository.Interfaces;
using KeyboardLibrary.Keycap.Service.Interfaces;

namespace KeyboardLibrary.Keycap.Service.Services
{
    public class KeycapService : IKeycapService
    {
      private readonly IKeycapRepository _keycapRepository;

      public KeycapService(IKeycapRepository keycapRepository)
      {
          _keycapRepository = keycapRepository;
      }

      public async Task<KeycapEntity> Get(int id)
      {
        return await _keycapRepository.GetById(id);
      }

      public async Task<IEnumerable<KeycapEntity>> GetListKeycaps()
      {
        return await _keycapRepository.GetAll();
      }
    }
}
