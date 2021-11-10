using ConsoleApp4.DbData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp4.DbConfiguration
{
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable("Title").HasKey(t => t.TitleId);
            builder.Property(t => t.TitleId).IsRequired().HasColumnName("TitleId");
            builder.Property(t => t.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
        }
    }
}