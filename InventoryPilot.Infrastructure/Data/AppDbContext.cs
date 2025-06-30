using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryPilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryPilot.Infrastructure.Data
{
   public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products => Set<Product>();

    }
}
