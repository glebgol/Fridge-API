using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IFridgeModelRepository
    {
        IEnumerable<FridgeModel> GetAllFridgeModels(bool trackChanges);
        void CreateFridgeModel(FridgeModel model);
    }
}
