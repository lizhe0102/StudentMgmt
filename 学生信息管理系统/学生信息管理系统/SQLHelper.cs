using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace UserLoginDemo
{
    public abstract class SqlHelper
    {
        public static readonly string ConnectionStringProfile = "server=(localdb)\\ProjectsV13;database=StuMgt;uid=;pwd=";
            /*"server=(localdb)\\ProjectsV13;database=StuMgt;uid=;pwd=";*/


        public static void RunSQL(string strsql, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(ConnectionStringProfile))
            {
                PrepareCommand(cmd, conn, strsql, commandParameters);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
        }

        public static int RunSQLReturnValue(string strsql, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(ConnectionStringProfile))
            {
                PrepareCommand(cmd, connection, strsql, commandParameters);
                int val = (int)cmd.ExecuteScalar();//执行语句且，返回受影响的行数
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static string RunSQLReturnString(string strsql, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(ConnectionStringProfile))
            {
                PrepareCommand(cmd, connection, strsql, commandParameters);
                string val = (string)cmd.ExecuteScalar();//执行语句
                cmd.Parameters.Clear();
                return val;
            }
        }


        public static int RunSQLReturnDataTable(string strsql,out DataTable objTable, params SqlParameter[] commandParameters)
        {
            objTable = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            int val = 0;

            using (SqlConnection conn = new SqlConnection(ConnectionStringProfile))
            {
                PrepareCommand(cmd, conn, strsql, commandParameters);
                try
                {
                    da.Fill(objTable);
                    cmd.Parameters.Clear();
                    val = 1;
                }
                catch (Exception)
                {
                    cmd.Parameters.Clear();
                    val = 0;
                }
                return val;
            }
        }


        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }                   
            }
        }
    }
}
