namespace Entities.DataTransferObjects.Dto
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int? DefaultQuantity { get; set; }
    }
}
