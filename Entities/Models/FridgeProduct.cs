using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class FridgeProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int FridgeId { get; set; }
        public int Quantity { get; set; }
    }
}
