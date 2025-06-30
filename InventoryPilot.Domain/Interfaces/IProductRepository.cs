using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryPilot.Domain.Entities;

namespace InventoryPilot.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync(); // Returns a list of all products.
        Task<Product?> GetByIdAsync(Guid id); //Retrieves one product by its ID.
        Task AddAsync(Product product); //Adds a new product.
        Task UpdateAsync(Product product); //Updates an existing product.
        Task DeleteAsync(Guid id); //Deletes a product by its ID.
    }
}
