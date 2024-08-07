using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using StockManagementAPI.Models;

namespace StockManagementAPI.Data
{
    public class StockManagementDbContext : IdentityDbContext
    {
        public StockManagementDbContext(DbContextOptions<StockManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<StockManagementAPI.Models.User> User { get; set; } = default!;
        public DbSet<StockManagementAPI.Models.Product> Product { get; set; } = default!;
        public DbSet<StockManagementAPI.Models.Category> Category { get; set; } = default!;
    }
}
