using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProductShop.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProductShopContext>
    {
        public ProductShopContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProductShopContext>();
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);

            return new ProductShopContext(optionsBuilder.Options);
        }
    }
}
