using System;
using System.Collections.Generic;

namespace ConsoleApp4.DbData
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string Name { get; set; }

        public decimal Budget { get; set; }

        public DateTime StartedDate { get; set; }

        public List<EmployeeProject> EmployeeProjects { get; set; }
    }
}