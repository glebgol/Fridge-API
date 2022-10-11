using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IFridgeRepository
    {
        IEnumerable<Fridge> GetAllFridges(bool trackChanges);
    }
}
