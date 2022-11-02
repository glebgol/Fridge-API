using Contracts.Interfaces;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            return await FindByCondition(p => p.Id == id, false).FirstOrDefaultAsync();
        }
    }
}
