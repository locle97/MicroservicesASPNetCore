using KeyboardLibrary.Product.Domain.Entities;
using KeyboardLibrary.Product.Repositories;

namespace KeyboardLibrary.Product.Services
{
    public class KeycapService : IKeycapService
    {
      private readonly IKeycapRepository _keycapRepository;

      public KeycapService(IKeycapRepository keycapRepository)
      {
          _keycapRepository = keycapRepository;
      }

      public async Task<Keycap> Create(Keycap keycap)
      {
        return await _keycapRepository.Create(keycap);
      }

      public async Task<bool> Delete(int id)
      {
        await _keycapRepository.Delete(id);
        return true;
      }

        public async Task<Keycap> Get(int id)
      {
        return await _keycapRepository.GetById(id);
      }

      public async Task<IEnumerable<Keycap>> GetListKeycaps()
      {
        return await _keycapRepository.GetAll();
      }

      public Task<Keycap> Update(Keycap keycap)
      {
        return _keycapRepository.Update(keycap);
      }
    }
}

