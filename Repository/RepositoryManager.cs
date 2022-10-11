using Contracts.Interfaces;
using Entities.Models;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private FridgeDbContext _repositoryContext;
        private IFridgeModelRepository _fridgeModelRepository;
        private IFridgeRepository _fridgeRepository;
        private IFridgeProductRepository _fridgeProductRepository;
        private IProductRepository _productRepository;

        public RepositoryManager(FridgeDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IFridgeModelRepository FridgeModels
        {
            get
            {
                _fridgeModelRepository ??= new FridgeModelRepository(_repositoryContext);
                return _fridgeModelRepository;
            }
        }

        public IFridgeRepository Fridges
        {
            get
            {
                _fridgeRepository ??= new FridgeRepository(_repositoryContext);
                return _fridgeRepository;
            }
        }

        public IFridgeProductRepository FridgeProducts
        {
            get
            {
                _fridgeProductRepository ??= new FridgeProductRepository(_repositoryContext);
                return _fridgeProductRepository;
            }
        }

        public IProductRepository Products
        {
            get
            {
                _productRepository ??= new ProductRepository(_repositoryContext);
                return _productRepository;
            }
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
