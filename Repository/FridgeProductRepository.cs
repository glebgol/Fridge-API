using Contracts.Interfaces;
using Entities;
using Entities.Models;

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

        public FridgeProduct GetFridgeProduct(Guid id)
        {
            return FindById(id);
        }

        public IEnumerable<FridgeProduct> GetFridgeProducts(Guid fridgeId, bool trackChanges)
        {
            return FindByCondition(fp => fp.FridgeId == fridgeId, trackChanges).ToList();
        }
    }
}
