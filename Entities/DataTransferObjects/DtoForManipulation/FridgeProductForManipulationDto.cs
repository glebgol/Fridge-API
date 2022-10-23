using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.DtoForManipulation
{
    public abstract class FridgeProductForManipulationDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Quantity is required and it can't be lower than 1")]
        public int Quantity { get; set; }
    }
}
