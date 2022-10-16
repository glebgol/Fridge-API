using Contracts.Interfaces;
using Entities;
using Entities.Models;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public void DeleteProduct(Product product)
        {
            Delete(product);
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public Product GetProduct(Guid id)
        {
            return FindById(id);
        }
    }
}
