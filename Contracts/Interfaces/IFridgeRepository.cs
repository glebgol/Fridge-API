using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IFridgeRepository
    {
        Task<IEnumerable<Fridge>> GetAllFridgesAsync(bool trackChanges);
        Task<Fridge> GetFridgeAsync(Guid id);
        void CreateFridge(Guid fridgeModelId, Fridge fridge);
        void DeleteFridge(Fridge fridge);
    }
}
