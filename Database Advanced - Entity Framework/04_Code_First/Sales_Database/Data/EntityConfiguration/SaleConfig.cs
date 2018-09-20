using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data.EntityConfiguration
{
    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(x => x.SaleId);
            builder.HasOne(x => x.Product).WithMany(x => x.Sales).HasForeignKey(x => x.SaleId);
            builder.HasOne(x => x.Customer).WithMany(x => x.Sales).HasForeignKey(x => x.SaleId);
            builder.HasOne(x => x.Store).WithMany(x => x.Sales).HasForeignKey(x => x.SaleId);
        }
    }
}
