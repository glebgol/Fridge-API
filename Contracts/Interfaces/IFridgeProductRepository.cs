using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IFridgeProductRepository
    {
        Task<IEnumerable<FridgeProduct>> GetFridgeProductsAsync(Guid fridgeId, bool trackChanges);
        void CreateFridgeProduct(Guid fridgeId, Guid productId, FridgeProduct fridgeProduct);
        void DeleteFridgeProduct(FridgeProduct fridgeProduct);
        Task<FridgeProduct> GetFridgeProductAsync(Guid id);
    }
}
