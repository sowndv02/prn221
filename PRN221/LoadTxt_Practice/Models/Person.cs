using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadTxt_Practice.Models
{
    public class Person
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime Dob { get; set; }
        public decimal Gpa {  get; set; }

        public void ReadDataFromLine(string line)
        {
            string[] items = line.Split("|");
            Id = Convert.ToInt32(items[0]);
            Name = items[1];
            Gender = Convert.ToBoolean(items[2]); // Khoong convert 0/1 => true fasle
            Dob = Convert.ToDateTime(items[3]);
            Gpa = Convert.ToDecimal(items[4]);
        }

        public string GetLineFromData()
        {
            return $"{Id}|{Name}|{Gender}|{Dob.ToString("dd/MM/yyyy")}|{Gpa}";
        }

    }
}
