using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
    }
}
