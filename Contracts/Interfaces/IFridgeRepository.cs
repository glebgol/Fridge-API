using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IFridgeRepository
    {
        IEnumerable<Fridge> GetAllFridges(bool trackChanges);
        Fridge GetFridge(int id);
        void CreateFridge(int fridgeModelId, Fridge fridge);
    }
}
