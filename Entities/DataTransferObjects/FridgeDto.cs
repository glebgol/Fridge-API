namespace Entities.DataTransferObjects
{
    public class FridgeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? OwnerName { get; set; }
        public int ModelId { get; set; }
    }
}
