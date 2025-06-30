using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryPilot.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }                  // Primary Key
        public string Name { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;  // Stock Keeping Unit
        public int Quantity { get; set; }            // How many items currently in stock
        public int ReorderLevel { get; set; }        // Threshold for restocking
        public decimal Price { get; set; }           // Selling price
    }

}
