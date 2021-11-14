using System;
using ConsoleApp4.DbData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp4.DbConfiguration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client").HasKey(c => c.ClientId);
            builder.Property(c => c.ClientId).IsRequired().HasColumnName("ClientId");
            builder.Property(c => c.Name).IsRequired().HasColumnName("Name");
            builder.Property(c => c.LastName).IsRequired().HasColumnName("LastName");
            builder.Property(c => c.BirthDate).IsRequired().HasColumnName("BirthDate");

            builder.HasData
            (
                new Client { ClientId = 1, Name = "Artur", LastName = "Miasnikov", BirthDate = Convert.ToDateTime("1995-01-01") },
                new Client { ClientId = 2, Name = "Artur2", LastName = "Miasnikov2", BirthDate = Convert.ToDateTime("1996-01-01") },
                new Client { ClientId = 3, Name = "Artur3", LastName = "Miasnikov3", BirthDate = Convert.ToDateTime("1997-01-01") },
                new Client { ClientId = 4, Name = "Artur4", LastName = "Miasnikov4", BirthDate = Convert.ToDateTime("1998-01-01") },
                new Client { ClientId = 5, Name = "Artur5", LastName = "Miasnikov5", BirthDate = Convert.ToDateTime("1999-01-01") }
                );
        }
    }
}