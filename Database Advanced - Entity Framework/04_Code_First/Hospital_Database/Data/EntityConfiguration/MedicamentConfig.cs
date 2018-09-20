using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_HospitalDatabase.Data.Models;

namespace P01_Hospital_Database.Data.EntityConfiguration
{
    public class MedicamentConfig : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(x => x.MedicamentId);
            builder.Property(x => x.Name).HasMaxLength(50).IsUnicode();
            builder.HasMany(x => x.Prescriptions).WithOne(x => x.Medicament).HasForeignKey(x => x.MedicamentId);
        }
    }
}
