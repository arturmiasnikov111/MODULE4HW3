using System;
using System.Collections.Generic;

namespace ConsoleApp4.DbData
{
    public class Client
    {
        public int ClientId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }
        
        public DateTime BirthDate { get; set; }

        public List<Project> Projects { get; set; }
    }
}