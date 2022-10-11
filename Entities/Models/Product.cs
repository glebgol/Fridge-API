namespace Entities.Models
{
    public partial class Product
    {
        public Product()
        {
            FridgeProducts = new HashSet<FridgeProduct>();
        }

        public int Id { get; set; }
        public int FridgeId { get; set; }
        public int? DefaultQuantity { get; set; }

        public virtual ICollection<FridgeProduct> FridgeProducts { get; set; }
    }
}
