using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public partial class Fridge
    {
        public Fridge()
        {
            FridgeProducts = new HashSet<FridgeProduct>();
        }

        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string Name { get; set; } = null!;
        [StringLength(50, ErrorMessage = "OwnerName length can't be more than 50.")]
        public string? OwnerName { get; set; }
        public int ModelId { get; set; }

        public virtual FridgeModel Model { get; set; } = null!;
        public virtual ICollection<FridgeProduct> FridgeProducts { get; set; }
    }
}
