using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_HospitalDatabase.Data.Models;

namespace P01_Hospital_Database.Data.EntityConfiguration
{
    public class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(x => x.DoctorId);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100).IsUnicode();
            builder.Property(x => x.Specialty).IsRequired().HasMaxLength(100).IsUnicode();
            builder.HasMany(x => x.Visitations).WithOne(x => x.Doctor).HasForeignKey(x => x.DoctorId);
        }
    }
}
