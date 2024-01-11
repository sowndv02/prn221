using DemoADOModel.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoADOModel.Models;
using LoadDB_Exercise2.Models;

namespace LoadDB_Exercise2.DAL
{
    public class DepartmentDAO
    {
        public static List<Department> GetAllDepartments()
        {
            string sql = "Select * from Department";
            DataTable dt = DAO.GetDataBySql(sql);
            List<Department> departments = new List<Department>();
            foreach (DataRow dr in dt.Rows)
            {
                departments.Add(new Department(
                    dr["id"].ToString(),
                    dr["name"].ToString()
                    ));
            }

            return departments;
        }


        public static Department GetDepartmentById(string id)
        {
            string sql = "Select * from Department where Id = @sid";
            SqlParameter parameter1 = new SqlParameter("@sid", DbType.String);
            parameter1.Value = id;
            DataTable dt = DAO.GetDataBySql(sql, parameter1);
            if (dt.Rows.Count == 0) return null;
            DataRow dr = dt.Rows[0];
            return new Department(
                    dr["id"].ToString(),
                    dr["name"].ToString()
                    );
        }

        public static Department GetDepartmentByName(string name)
        {
            string sql = "Select * from Department where Name = @name";
            SqlParameter parameter1 = new SqlParameter("@name", DbType.String);
            parameter1.Value = name;
            DataTable dt = DAO.GetDataBySql(sql, parameter1);
            if (dt.Rows.Count == 0) return null;
            DataRow dr = dt.Rows[0];
            return new Department(
                    dr["id"].ToString(),
                    dr["name"].ToString()
                    );
        }
    }
}
