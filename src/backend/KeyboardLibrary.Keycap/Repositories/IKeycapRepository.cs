using KeyboardLibrary.Keycap.Domain.Entities;
using Loclep.Generic.EFCore;

namespace KeyboardLibrary.Keycap.Repositories
{
    public interface IKeycapRepository: IBaseRepository<KeycapEntity, int>
    {
    }
}

