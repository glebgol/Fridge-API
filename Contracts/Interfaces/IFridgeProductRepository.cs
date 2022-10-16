using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IFridgeProductRepository
    {
        IEnumerable<FridgeProduct> GetFridgeProducts(Guid fridgeId, bool trackChanges);
        void CreateFridgeProduct(Guid fridgeId, Guid productId, FridgeProduct fridgeProduct);
        void DeleteFridgeProduct(FridgeProduct fridgeProduct);
        FridgeProduct GetFridgeProduct(Guid id);
    }
}
