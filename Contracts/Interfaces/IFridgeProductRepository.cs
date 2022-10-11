using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IFridgeProductRepository
    {
        IEnumerable<FridgeProduct> GetAllFridgeProducts(int fridgeId, bool trackChanges);
    }
}
