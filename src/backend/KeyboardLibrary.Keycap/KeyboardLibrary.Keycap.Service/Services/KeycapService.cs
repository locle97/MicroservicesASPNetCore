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

      public async Task<KeycapEntity> Create(KeycapEntity keycap)
      {
        return await _keycapRepository.AddAsync(keycap);
      }

      public async Task<bool> Delete(int id)
      {
        KeycapEntity entity = await _keycapRepository.GetAsync(id);
        if (entity == null)
          return false;

        await _keycapRepository.RemoveAsync(entity);
        return true;
      }

        public async Task<KeycapEntity> Get(int id)
      {
        return await _keycapRepository.GetAsync(id);
      }

      public async Task<IEnumerable<KeycapEntity>> GetListKeycaps()
      {
        return await _keycapRepository.GetAllAsync();
      }

      public Task<KeycapEntity> Update(KeycapEntity keycap)
      {
        return _keycapRepository.UpdateAsync(keycap);
      }
    }
}
