using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp4
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
            {
                IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("/Users/arturmiasnykov/RiderProjects/ConsoleApp4/ConsoleApp4/appsettings.json").Build();
                var dbOptionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                dbOptionsBuilder.UseSqlServer(connectionString);

                return new ApplicationContext(dbOptionsBuilder.Options);
            }
    }
}