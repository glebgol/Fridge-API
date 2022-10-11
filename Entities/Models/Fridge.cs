namespace Entities.Models
{
    public partial class Fridge
    {
        public Fridge()
        {
            FridgeProducts = new HashSet<FridgeProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? OwnerName { get; set; }
        public int ModelId { get; set; }

        public virtual FridgeModel Model { get; set; } = null!;
        public virtual ICollection<FridgeProduct> FridgeProducts { get; set; }
    }
}
