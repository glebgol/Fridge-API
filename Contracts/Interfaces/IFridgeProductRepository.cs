using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IFridgeProductRepository
    {
        IEnumerable<FridgeProduct> GetFridgeProducts(int fridgeId, bool trackChanges);
    }
}
