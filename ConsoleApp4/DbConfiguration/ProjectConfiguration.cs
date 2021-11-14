using System;
using ConsoleApp4.DbData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp4.DbConfiguration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project").HasKey(p => p.ProjectId);
            builder.Property(p => p.ProjectId).IsRequired().HasColumnName("ProjectId");
            builder.Property(p => p.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
            builder.Property(p => p.Budget).IsRequired().HasColumnName("Budget");
            builder.Property(p => p.StartedDate).IsRequired().HasColumnName("StartedDate");

            builder.HasOne(p => p.Client)
                .WithMany(p => p.Projects)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData
            (
                new Project { ProjectId = 1, Name = "BigBan", Budget = 1233222, StartedDate = Convert.ToDateTime("2010-01-01"), ClientId = 1},
                new Project { ProjectId = 2, Name = "SmallBan", Budget = 1232132, StartedDate = Convert.ToDateTime("2011-01-01"), ClientId = 2 },
                new Project { ProjectId = 3, Name = "MediumBan", Budget = 2832382, StartedDate = Convert.ToDateTime("2012-01-01"), ClientId = 3 },
                new Project { ProjectId = 4, Name = "BigSmallBan", Budget = 23841283, StartedDate = Convert.ToDateTime("2013-01-01"), ClientId = 4 },
                new Project { ProjectId = 5, Name = "BigMediumBan", Budget = 2381238, StartedDate = Convert.ToDateTime("2014-01-01"), ClientId = 5 }
            );
        }
    }
}