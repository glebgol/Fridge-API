namespace Contracts.Interfaces
{
    public interface IRepositoryManager
    {
        IProductRepository Products { get; }
        IFridgeModelRepository FridgeModels { get; }
        IFridgeRepository Fridges { get; }
        IFridgeProductRepository FridgeProducts { get; }
        Task SaveAsync();
    }
}
