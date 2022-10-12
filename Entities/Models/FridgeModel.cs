using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public partial class FridgeModel
    {
        public FridgeModel()
        {
            Fridges = new HashSet<Fridge>();
        }

        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string Name { get; set; } = null!;
        public int? Year { get; set; }

        public virtual ICollection<Fridge> Fridges { get; set; }
    }
}
