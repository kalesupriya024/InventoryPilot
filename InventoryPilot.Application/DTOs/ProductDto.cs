using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryPilot.Application.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
        public decimal Price { get; set; }

    }
}
