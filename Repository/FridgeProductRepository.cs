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

        public IEnumerable<FridgeProduct> GetFridgeProducts(Guid fridgeId, bool trackChanges)
        {
            return FindByCondition(fp => fp.FridgeId == fridgeId, trackChanges).ToList();
        }
    }
}
