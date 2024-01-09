using DemoADOModel.Models;
using LoadDB_Exercise2.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
namespace DemoADOModel.DAL
{
    class StudentDAO
    {
        public static List<Student> GetAllStudents()
        {
            string sql = "Select * from Student";
            DataTable dt = DAO.GetDataBySql(sql);
            List<Student> students = new List<Student>();
            foreach (DataRow dr in dt.Rows)
            {
                students.Add(new Student(
                    Convert.ToInt32(dr["Id"]),
                    dr["Name"].ToString(),
                    ConvertBoolean(dr["Gender"].ToString()),
                    DepartmentDAO.GetDepartmentById(dr["departId"].ToString()),
                    DateTime.Parse(dr["dob"].ToString()),
                    decimal.Parse(dr["gpa"].ToString())
                    ));
            }

            return students;
        }

        public static bool ConvertBoolean(string text)
        {
            return text.Equals("1");
        }

        public static Student GetStudentById(int id)
        {
            string sql = "Select * from Student where Id = @sid";
            SqlParameter parameter1 = new SqlParameter("@sid", DbType.Int32);
            parameter1.Value = id;
            DataTable dt = DAO.GetDataBySql(sql, parameter1);
            if (dt.Rows.Count == 0) return null;
            DataRow dr = dt.Rows[0];
            return new Student(
                    Convert.ToInt32(dr["Id"]),
                    dr["Name"].ToString(),
                    ConvertBoolean(dr["Gender"].ToString()),
                    DepartmentDAO.GetDepartmentById(dr["departId"].ToString()),
                    DateTime.Parse(dr["dob"].ToString()),
                    decimal.Parse(dr["gpa"].ToString())
                    );
        }

    }
}
