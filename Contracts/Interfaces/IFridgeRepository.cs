using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IFridgeRepository
    {
        IEnumerable<Fridge> GetAllFridges(bool trackChanges);
        void AddFridge(Fridge fridge);
        Fridge GetFridge(int id);
    }
}
