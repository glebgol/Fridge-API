using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IFridgeProductRepository
    {
        IEnumerable<FridgeProduct> GetFridgeProducts(Guid fridgeId, bool trackChanges);
    }
}
