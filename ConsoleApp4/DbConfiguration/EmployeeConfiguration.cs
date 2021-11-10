using ConsoleApp4.DbData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp4.DbConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee").HasKey(e => e.EmployeeId);
            builder.Property(e => e.EmployeeId).IsRequired().HasColumnName("EmployeeId");
            builder.Property(e => e.FirstName).IsRequired().HasColumnName("FirstName").HasMaxLength(50);
            builder.Property(e => e.LastName).IsRequired().HasColumnName("LastName").HasMaxLength(50);
            builder.Property(e => e.HiredDate).IsRequired().HasColumnName("HiredDate");
            builder.Property(e => e.DateOfBidth).HasColumnName("DateofBirth");

            builder.HasOne(e => e.Office)
                .WithMany(o => o.Employees)
                .HasForeignKey(e => e.OfficeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Title)
                .WithMany(o => o.Employees)
                .HasForeignKey(e => e.TitleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}