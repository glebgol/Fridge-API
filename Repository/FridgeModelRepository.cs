using Contracts.Interfaces;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class FridgeModelRepository : RepositoryBase<FridgeModel>, IFridgeModelRepository
    {
        public FridgeModelRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateFridgeModel(FridgeModel model)
        {
            Create(model);
        }

        public void DeleteFridgeModel(FridgeModel fridgeModel)
        {
            Delete(fridgeModel);
        }

        public async Task<IEnumerable<FridgeModel>> GetAllFridgeModelsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<FridgeModel> GetFridgeModelAsync(Guid Id)
        {
            return await FindByCondition(fm => fm.Id == Id, false).FirstOrDefaultAsync();
        }
    }
}
