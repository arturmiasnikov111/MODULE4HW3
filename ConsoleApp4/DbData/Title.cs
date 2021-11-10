using System.Collections.Generic;

namespace ConsoleApp4.DbData
{
    public class Title
    {
        public int TitleId { get; set; }

        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}