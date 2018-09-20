﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data.EntityConfiguration
{
    public class StoreConfig : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(x => x.StoreId);
            builder.Property(x => x.Name).HasMaxLength(80).IsUnicode();
            builder.HasMany(x => x.Sales).WithOne(x => x.Store).HasForeignKey(x => x.StoreId);
        }
    }
}
