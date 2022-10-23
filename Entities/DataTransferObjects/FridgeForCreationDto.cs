using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class FridgeForCreationDto
    {
        [Required(ErrorMessage = "Fridge name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }

        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string? OwnerName { get; set; }
    }
}
