namespace Entities.Models
{
    public partial class FridgeProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int FridgeId { get; set; }
        public int Quantity { get; set; }

        public virtual Fridge Fridge { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
