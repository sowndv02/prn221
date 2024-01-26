using  LoadDB_ADONet.Models;
using LoadDB_ADONet.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using LoadDB_ADONet.Repository;

namespace LoadDB_ADONet.DAL
{
    public class StudentDAO
    {
        public static List<Student> GetAllStudents()
        {
            string sql = "Select id, name, gender, departId, dob, gpa from Student";
            DataTable dt = DAO.GetDataBySql(sql);
            List<Student> students = new List<Student>();
            foreach (DataRow dr in dt.Rows)
            {
                students.Add(new Student(
                    Convert.ToInt32(dr["Id"]),
                    dr["Name"].ToString(),
                    bool.Parse(dr["Gender"].ToString()),
                    DepartmentDAO.GetDepartmentById(dr["departId"].ToString()),
                    DateTime.Parse(dr["dob"].ToString()),
                    decimal.Parse(dr["gpa"].ToString())
                    ));
            }

            return students;
        }

        public static Student GetStudentById(int id)
        {
            string sql = "Select id, name, gender, departId, dob, gpa from Student where Id = @sid";
            SqlParameter parameter1 = new SqlParameter("@sid", DbType.Int32);
            parameter1.Value = id;
            DataTable dt = DAO.GetDataBySql(sql, parameter1);
            if (dt.Rows.Count == 0) return null;
            DataRow dr = dt.Rows[0];
            return new Student(
                    Convert.ToInt32(dr["Id"]),
                    dr["Name"].ToString(),
                    bool.Parse(dr["Gender"].ToString()),
                    DepartmentDAO.GetDepartmentById(dr["departId"].ToString()),
                    DateTime.Parse(dr["dob"].ToString()),
                    decimal.Parse(dr["gpa"].ToString())
                    );
        }

        public static List<Student> SearchStudentByGender(bool key)
        {
            string sql = "Select id, name, gender, departId, dob, gpa from Student Where gender = @key";
            SqlParameter parameter = new SqlParameter("@key", DbType.Boolean);
            parameter.Value = key;
            DataTable dt = DAO.GetDataBySql(sql, parameter);
            List<Student> students = new List<Student>();
            foreach (DataRow dr in dt.Rows)
            {
                students.Add(new Student(
                    Convert.ToInt32(dr["Id"]),
                    dr["Name"].ToString(),
                    bool.Parse(dr["Gender"].ToString()),
                    DepartmentDAO.GetDepartmentById(dr["departId"].ToString()),
                    DateTime.Parse(dr["dob"].ToString()),
                    decimal.Parse(dr["gpa"].ToString())
                    ));
            }

            return students;
        }

        public static List<Student> SearchStudentByName(string key)
        {
            string sql = "Select id, name, gender, departId, dob, gpa from Student Where name like @key";
            SqlParameter parameter = new SqlParameter("@key", DbType.String);
            parameter.Value = $"%{key}%";
            DataTable dt = DAO.GetDataBySql(sql, parameter);
            List<Student> students = new List<Student>();
            foreach (DataRow dr in dt.Rows)
            {
                students.Add(new Student(
                    Convert.ToInt32(dr["Id"]),
                    dr["Name"].ToString(),
                    bool.Parse(dr["Gender"].ToString()),
                    DepartmentDAO.GetDepartmentById(dr["departId"].ToString()),
                    DateTime.Parse(dr["dob"].ToString()),
                    decimal.Parse(dr["gpa"].ToString())
                    ));
            }

            return students;
        }



        public static int AddStudent(Student student)
        {
            String sql = "INSERT INTO Student(id, name, gender, departId, dob, gpa) VALUES(@id, @name, @gender, @departId, @dob, @gpa)";
            SqlParameter parameter1 = new SqlParameter("@id", SqlDbType.Int);
            parameter1.Value = student.Id;
            SqlParameter parameter2 = new SqlParameter("@name", SqlDbType.NVarChar);
            parameter2.Value = student.Name;
            SqlParameter parameter3 = new SqlParameter("@gender", SqlDbType.Bit);
            parameter3.Value = student.Gender;
            SqlParameter parameter4 = new SqlParameter("@departId", SqlDbType.NVarChar);
            parameter4.Value = student.DepartId;
            SqlParameter parameter5 = new SqlParameter("@dob", SqlDbType.Date);
            parameter5.Value = student.Dob;
            SqlParameter parameter6 = new SqlParameter("@gpa", SqlDbType.Float);
            parameter6.Value = student.Gpa;
            return DAO.ExcuteBySql(sql, parameter1, parameter2, parameter3, parameter4, parameter5, parameter6);
        }


        public static int UpdateStudent(Student student)
        {
            String sql = "UPDATE Student SET name = @name, gender = @gender, departId= @departId, dob = @dob, gpa = @gpa Where id = @id";
            SqlParameter parameter1 = new SqlParameter("@id", SqlDbType.Int);
            parameter1.Value = student.Id;
            SqlParameter parameter2 = new SqlParameter("@name", SqlDbType.NVarChar);
            parameter2.Value = student.Name;
            SqlParameter parameter3 = new SqlParameter("@gender", SqlDbType.Bit);
            parameter3.Value = student.Gender;
            SqlParameter parameter4 = new SqlParameter("@departId", SqlDbType.NVarChar);
            parameter4.Value = student.DepartId;
            SqlParameter parameter5 = new SqlParameter("@dob", SqlDbType.Date);
            parameter5.Value = student.Dob;
            SqlParameter parameter6 = new SqlParameter("@gpa", SqlDbType.Float);
            parameter6.Value = student.Gpa;
            return DAO.ExcuteBySql(sql, parameter1, parameter2, parameter3, parameter4, parameter5, parameter6);
        }

        public static int DeleteStudent(int id)
        {
            String sql = "DELETE Student Where id = @id";
            SqlParameter parameter1 = new SqlParameter("@id", SqlDbType.Int);
            parameter1.Value = id;
            return DAO.ExcuteBySql(sql, parameter1);
        }
    }
}
