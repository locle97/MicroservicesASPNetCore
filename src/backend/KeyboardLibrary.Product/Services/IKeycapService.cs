using KeyboardLibrary.Product.Domain.Entities;

namespace KeyboardLibrary.Product.Services
{
    public interface IKeycapService
    {
      Task<Keycap> Get(int id);
      Task<IEnumerable<Keycap>> GetListKeycaps();
      Task<Keycap> Create(Keycap keycap);
      Task<bool> Delete(int id);
      Task<Keycap> Update(Keycap keycap);
    }
}

