using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public partial class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Product name is a required field.")]
        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string Name { get; set; } = null!;
        public int? DefaultQuantity { get; set; }
    }
}
