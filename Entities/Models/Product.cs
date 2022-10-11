using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public int FridgeId { get; set; }
        public int? DefaultQuantity { get; set; }
    }
}
