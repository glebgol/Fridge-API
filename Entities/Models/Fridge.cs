using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Fridge
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? OwnerName { get; set; }
        public int ModelId { get; set; }

        public virtual FridgeModel Model { get; set; } = null!;
    }
}
