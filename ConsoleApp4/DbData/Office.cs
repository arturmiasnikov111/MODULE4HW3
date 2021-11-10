using System.Collections.Generic;

namespace ConsoleApp4.DbData
{
    public class Office
    {
        public int OfficeId { get; set; }

        public string Ttitle { get; set; }

        public string Location { get; set; }

        public List<Employee> Employees { get; set; }
    }
}