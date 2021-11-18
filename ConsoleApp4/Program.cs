using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ConsoleApp4.DbData;
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

            var query2 = applicationContext.Employees
                .Select(t => new { diff = EF.Functions.DateDiffYear(t.HiredDate, DateTime.Now) }).ToArray();

            var query3 = applicationContext.Clients.ToList();
            query3[0].Name = "valik";
            query3[1].Name = "valik1";

            // query 4
            applicationContext.Add(new Employee
             {
                 FirstName = "Asd",
                 LastName = "Zxc",
                 HiredDate = Convert.ToDateTime("2020-02-02"),
                 DateOfBidth = Convert.ToDateTime("1989-02-02"),
                 OfficeId = 2,
                 Title = new Title
                 {
                     Name = "Nurse",
                 },
                 EmployeeProjects = new List<EmployeeProject>
                 {
                     new EmployeeProject
                     {
                         StartedDate = DateTime.Now,
                         Rate = 2222222,
                         Project = new Project
                         {
                             StartedDate = DateTime.Now,
                             Budget = 2000213,
                             ClientId = 1,
                             Name = "ChtotoIgrovoe"
                         },
                     },
                 },
             });

            var query5 = applicationContext.Employees.OrderByDescending(e => e.EmployeeId).FirstOrDefault();
            applicationContext.Employees.Remove(query5);
            
            var query6 = applicationContext
                .Employees.Select(e => new
                {
                    Title = e.Title.Name
                })
                .Where(t => !t.Title.Contains("a"))
                .AsEnumerable()
                .GroupBy(t => t.Title).ToList();
        }
    }
}