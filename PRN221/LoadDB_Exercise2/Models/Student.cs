using LoadDB_Exercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADOModel.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public string DepartmentId { get; set; }
        public DateTime Dob { get; set; }
        public decimal GPA { get; set; }
        public Department Major { get; set; }

        public Student(int studentId, string studentName, bool gender, Department department, DateTime dob, decimal gpa)
        {
            Id = studentId;
            Name = studentName;
            Gender = gender;
            Major = department;
            Dob = dob;
            GPA = gpa;
        }

        public Student()
        {
        }
    }
}
