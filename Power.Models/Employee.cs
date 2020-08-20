using System;
using System.Collections.Generic;
using System.Text;

namespace Power.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        public Dept? Departman { get; set; }
    }
}
