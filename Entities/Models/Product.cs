namespace Entities.Models
{
    public partial class Product
    {
        public Product()
        {
            FridgeProducts = new HashSet<FridgeProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? DefaultQuantity { get; set; }

        public virtual ICollection<FridgeProduct> FridgeProducts { get; set; }
    }
}
