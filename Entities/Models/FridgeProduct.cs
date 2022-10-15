using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class FridgeProduct
    {
        [Key]
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey(nameof(Fridge))]
        public Guid FridgeId { get; set; }
        public virtual Fridge Fridge { get; set; }

    }
}
