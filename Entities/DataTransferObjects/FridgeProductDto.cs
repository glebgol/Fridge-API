namespace Entities.DataTransferObjects
{
    public class FridgeProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
