namespace Entities.DataTransferObjects
{
    public class FridgeModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Year { get; set; }
    }
}
