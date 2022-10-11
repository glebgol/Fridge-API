using Contracts.Interfaces;
using Entities.Models;

namespace Repository
{
    public class FridgeProductRepository : RepositoryBase<FridgeProduct>, IFridgeProductRepository
    {
        public FridgeProductRepository(FridgeDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
