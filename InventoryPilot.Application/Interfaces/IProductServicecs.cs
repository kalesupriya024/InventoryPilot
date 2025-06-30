using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryPilot.Application.DTOs;
using InventoryPilot.Domain.Entities;

namespace InventoryPilot.Application.Interfaces
{
    public interface IProductServicecs
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(Guid id);
        Task AddAsync(ProductDto dto);
        Task UpdateAsync(Guid id, ProductDto dto);
        Task DeleteAsync(Guid id);
       
    }
}
