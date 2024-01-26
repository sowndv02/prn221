using LoadDB_ADONet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDB_ADONet.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public string DepartId { get; set; }
        public DateTime Dob { get; set; }
        public decimal Gpa { get; set; }
        public Department? Depart { get; set; }

        public Student(int studentId, string studentName, bool gender, Department department, DateTime dob, decimal gpa)
        {
            Id = studentId;
            Name = studentName;
            Gender = gender;
            Depart = department;
            Dob = dob;
            Gpa = gpa;
        }

        public Student()
        {
        }
    }
}
