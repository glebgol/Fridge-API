using Contracts.Interfaces;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class FridgeProductRepository : RepositoryBase<FridgeProduct>, IFridgeProductRepository
    {
        public FridgeProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateFridgeProduct(Guid fridgeId, Guid productId, FridgeProduct fridgeProduct)
        {
            fridgeProduct.ProductId = productId;
            fridgeProduct.FridgeId = fridgeId;
            Create(fridgeProduct);
        }

        public void DeleteFridgeProduct(FridgeProduct fridgeProduct)
        {
            Delete(fridgeProduct);
        }

        public async Task<FridgeProduct> GetFridgeProductAsync(Guid id)
        {
            return await FindByCondition(fp => fp.Id == id, false).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<FridgeProduct>> GetFridgeProductsAsync(Guid fridgeId, bool trackChanges)
        {
            return await FindByCondition(fp => fp.FridgeId == fridgeId, trackChanges).ToListAsync();
        }
    }
}
