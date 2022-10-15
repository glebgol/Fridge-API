using Contracts.Interfaces;
using Entities;
using Entities.Models;

namespace Repository
{
    public class FridgeRepository : RepositoryBase<Fridge>, IFridgeRepository
    {
        public FridgeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateFridge(Guid fridgeModelId, Fridge fridge)
        {
            fridge.ModelId = fridgeModelId;
            Create(fridge);
        }

        public IEnumerable<Fridge> GetAllFridges(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public Fridge GetFridge(Guid id)
        {
            return FindById(id);
        }
    }
}
