using KeyboardLibrary.Keycap.Domain.Entities;
using Loclep.Generic.EFCore;

namespace KeyboardLibrary.Keycap.Repositories
{
    public class KeycapRepository : BaseRepository<KeycapDbContext, KeycapEntity, int>, IKeycapRepository
    {
      public KeycapRepository(KeycapDbContext context): base(context)
      {
      }
    }
}

