using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IFridgeModelRepository
    {
        Task<IEnumerable<FridgeModel>> GetAllFridgeModelsAsync(bool trackChanges);
        void CreateFridgeModel(FridgeModel model);
        Task<FridgeModel> GetFridgeModelAsync(Guid Id);
        void DeleteFridgeModel(FridgeModel fridgeModel);
    }
}
