using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.DtoForCreation
{
    public class FridgeModelForCreationDto
    {
        [Required(ErrorMessage = "FridgeModel name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }

        [Required, Range(1913, int.MaxValue)]
        public int? Year { get; set; }
    }
}
