using KeyboardLibrary.Product.Domain.Entities;
using Loclep.Generic.EFCore;

namespace KeyboardLibrary.Product.Repositories
{
    public class KeycapRepository : BaseRepository<ProductDbContext, Keycap, int>, IKeycapRepository
    {
      public KeycapRepository(ProductDbContext context): base(context)
      {
      }
    }
}

