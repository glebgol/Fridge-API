using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IFridgeRepository
    {
        IEnumerable<Fridge> GetAllFridges(bool trackChanges);
        Fridge GetFridge(Guid id);
        void CreateFridge(Guid fridgeModelId, Fridge fridge);
    }
}
