using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadXML_RazorPage.Models
{
    public class Person
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime Dob { get; set; }
        public decimal Gpa {  get; set; }

    }
}
