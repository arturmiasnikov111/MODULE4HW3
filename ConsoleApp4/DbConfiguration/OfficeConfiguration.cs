using ConsoleApp4.DbData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ConsoleApp4.DbConfiguration
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office").HasKey(o => o.OfficeId);
            builder.Property(o => o.OfficeId).IsRequired().HasColumnName("OfficeId");
            builder.Property(o => o.Ttitle).IsRequired().HasColumnName("Ttitle").HasMaxLength(100);
            builder.Property(o => o.Location).IsRequired().HasColumnName("Location").HasMaxLength(100);
        }
    }
}