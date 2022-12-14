using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.DtoForCreation
{
    public class ProductForCreationDto
    {
        [Required(ErrorMessage = "Product name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }

        [Required, Range(0, int.MaxValue)]
        public int? DefaultQuantity { get; set; }
    }
}
