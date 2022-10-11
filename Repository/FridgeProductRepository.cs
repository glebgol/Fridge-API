using Contracts.Interfaces;
using Entities.Models;

namespace Repository
{
    public class FridgeProductRepository : RepositoryBase<FridgeProduct>, IFridgeProductRepository
    {
        public FridgeProductRepository(FridgeDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<FridgeProduct> GetAllFridgeProducts(int fridgeId, bool trackChanges)
        {
            return FindByCondition(fp => fp.FridgeId == fridgeId, trackChanges).ToList();
        }
    }
}
