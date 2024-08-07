using KeyboardLibrary.Keycap.Domain.Entities;
using KeyboardLibrary.Keycap.Repositories;

namespace KeyboardLibrary.Keycap.Services
{
    public class KeycapService : IKeycapService
    {
      private readonly IKeycapRepository _keycapRepository;

      public KeycapService(IKeycapRepository keycapRepository)
      {
          _keycapRepository = keycapRepository;
      }

      public async Task<KeycapEntity> Create(KeycapEntity keycap)
      {
        return await _keycapRepository.Create(keycap);
      }

      public async Task<bool> Delete(int id)
      {
        await _keycapRepository.Delete(id);
        return true;
      }

        public async Task<KeycapEntity> Get(int id)
      {
        return await _keycapRepository.GetById(id);
      }

      public async Task<IEnumerable<KeycapEntity>> GetListKeycaps()
      {
        return await _keycapRepository.GetAll();
      }

      public Task<KeycapEntity> Update(KeycapEntity keycap)
      {
        return _keycapRepository.Update(keycap);
      }
    }
}

