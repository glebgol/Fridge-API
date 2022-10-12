using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public partial class Product
    {
        public Product()
        {
            FridgeProducts = new HashSet<FridgeProduct>();
        }

        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string Name { get; set; } = null!;
        public int? DefaultQuantity { get; set; }

        public virtual ICollection<FridgeProduct> FridgeProducts { get; set; }
    }
}
