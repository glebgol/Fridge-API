namespace Entities.DataTransferObjects.Dto
{
    public class FridgeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? OwnerName { get; set; }
        public Guid ModelId { get; set; }
    }
}
