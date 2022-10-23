namespace Entities.DataTransferObjects.Dto
{
    public class FridgeModelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Year { get; set; }
    }
}
