namespace Entities.DataTransferObjects
{
    public class FridgeProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
