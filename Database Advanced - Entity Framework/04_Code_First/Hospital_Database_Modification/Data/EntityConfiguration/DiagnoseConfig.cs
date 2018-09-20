using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_HospitalDatabase.Data.Models;

namespace P01_Hospital_Database.Data.EntityConfiguration
{
    public class DiagnoseConfig : IEntityTypeConfiguration<Diagnose>
    {
        public void Configure(EntityTypeBuilder<Diagnose> builder)
        {
            builder.HasKey(x => x.DiagnoseId);
            builder.Property(x => x.Name).HasMaxLength(50).IsUnicode();
            builder.Property(x => x.Comments).HasMaxLength(250).IsUnicode();
        }
    }
}
