using Contracts.Interfaces;
using Entities.Models;

namespace Repository
{
    public class FridgeRepository : RepositoryBase<Fridge>, IFridgeRepository
    {
        public FridgeRepository(FridgeDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Fridge> GetAllFridges(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }
    }
}
