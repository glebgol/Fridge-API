using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges);
        void CreateProduct(Product product);
        Task<Product> GetProductAsync(Guid id);
        void DeleteProduct(Product product);
    }
}
