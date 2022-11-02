using Contracts.Interfaces;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

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

        public void DeleteFridge(Fridge fridge)
        {
            Delete(fridge);
        }

        public async Task<IEnumerable<Fridge>> GetAllFridgesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<Fridge> GetFridgeAsync(Guid id)
        {
            return await FindByCondition(fm => fm.Id == id, false).FirstOrDefaultAsync();
        }
    }
}
