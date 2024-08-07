using KeyboardLibrary.Product.Domain.Entities;
using Loclep.Generic.EFCore;

namespace KeyboardLibrary.Product.Repositories
{
    public interface IKeycapRepository: IBaseRepository<Keycap, int>
    {
    }
}

