using Contracts.Interfaces;
using Entities.Models;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(FridgeDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
