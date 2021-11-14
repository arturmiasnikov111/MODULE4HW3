using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp4
{
   public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("/Users/arturmiasnykov/RiderProjects/ConsoleApp4/ConsoleApp4/appsettings.json").Build();
            var dbOptionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            dbOptionsBuilder.UseSqlServer(connectionString);

            var applicationContext = new ApplicationContext(dbOptionsBuilder.Options);
            applicationContext.Database.Migrate();

            applicationContext.SaveChanges();
        }
    }
}