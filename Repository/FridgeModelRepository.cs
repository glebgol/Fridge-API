using Contracts.Interfaces;
using Entities.Models;

namespace Repository
{
    public class FridgeModelRepository : RepositoryBase<FridgeModel>, IFridgeModelRepository
    {
        public FridgeModelRepository(FridgeDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<FridgeModel> GetAllFridgeModels(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }
    }
}
