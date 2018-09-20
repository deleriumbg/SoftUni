using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_HospitalDatabase.Data.Models;

namespace P01_Hospital_Database.Data.EntityConfiguration
{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.PatientId);
            builder.Property(x => x.FirstName).HasMaxLength(50).IsUnicode();
            builder.Property(x => x.LastName).HasMaxLength(50).IsUnicode();
            builder.Property(x => x.Address).HasMaxLength(250).IsUnicode();
            builder.Property(x => x.Email).HasMaxLength(80).IsUnicode(false);
            builder.HasMany(x => x.Prescriptions).WithOne(x => x.Patient).HasForeignKey(x => x.PatientId);
            builder.HasMany(x => x.Visitations).WithOne(x => x.Patient).HasForeignKey(x => x.PatientId);
            builder.HasMany(x => x.Diagnoses).WithOne(x => x.Patient).HasForeignKey(x => x.PatientId);
        }
    }
}
