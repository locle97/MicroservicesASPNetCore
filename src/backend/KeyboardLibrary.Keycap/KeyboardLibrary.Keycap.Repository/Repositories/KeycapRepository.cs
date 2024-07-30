using KeyboardLibrary.Keycap.Domain.Entities;
using KeyboardLibrary.Keycap.Repository.Interfaces;

namespace KeyboardLibrary.Keycap.Repository.Repositories
{
    public class KeycapRepository : BaseRepository<KeycapEntity>, IKeycapRepository
    {
      public KeycapRepository(KeycapDbContext context): base(context)
      {
      }
    }
}
