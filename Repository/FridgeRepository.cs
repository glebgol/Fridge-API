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

        public void CreateFridge(int fridgeModelId, Fridge fridge)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fridge> GetAllFridges(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public Fridge GetFridge(int id)
        {
            return FindById(id);
        }
    }
}
