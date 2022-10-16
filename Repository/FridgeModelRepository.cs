using Contracts.Interfaces;
using Entities;
using Entities.Models;

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

        public IEnumerable<FridgeModel> GetAllFridgeModels(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public FridgeModel GetFridgeModel(Guid Id)
        {
            return FindById(Id);
        }
    }
}
