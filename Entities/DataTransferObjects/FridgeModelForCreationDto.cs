﻿using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class FridgeModelForCreationDto
    {
        [Required(ErrorMessage = "FridgeModel name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }

        public int? Year { get; set; }
    }
}
