using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class Fridge
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Fridge name is a required field.")]
        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "OwnerName length can't be more than 50.")]
        public string? OwnerName { get; set; }

        [ForeignKey(nameof(FridgeModel))]
        public Guid ModelId { get; set; }
        public FridgeModel Model { get; set; }
    }
}
