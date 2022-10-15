using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public partial class FridgeModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "FridgeModel name is a required field.")]
        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string Name { get; set; }
        public int? Year { get; set; }
    }
}
