﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryPilot.Domain.Entities;
using InventoryPilot.Domain.Interfaces;
using InventoryPilot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryPilot.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        { return await _context.Products.ToListAsync(); }
        public async Task<Product?> GetByIdAsync(Guid id)
        {
           return await _context.Products.FindAsync(id);
        }
        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is not null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
           
        }

    }
}
