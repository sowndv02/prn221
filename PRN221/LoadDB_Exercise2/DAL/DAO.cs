using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DemoADOModel.DAL
{
    internal class DAO
    {
        public static SqlConnection GetConnection()
        {
            string ConnectionStr = "server=COOKIE\\SQLEXPRESS;database=PRN211_1;user=sa;password=123456";
            return new SqlConnection(ConnectionStr);
        }

        public static DataTable GetDataBySql(string sql, params SqlParameter[] parameters) // Từ khoá params nếu kh truyền vào thì là null
        {
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            if(parameters != null || parameters.Length != 0)cmd.Parameters.AddRange(parameters);    
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}
