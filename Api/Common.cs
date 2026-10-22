using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WorkOrderAPI
{
    public class Common
    {
        public static string conn = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
        public static DTPLLogs.DTPLLogsWrite objLogs;
        public DataSet ExecuteDataset(SqlCommand cmd) 
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Common.conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            return ds;
        }
        public DataTable ExecuteDatatable(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Common.conn;
            cmd.CommandType = CommandType.StoredProcedure;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            return ds.Tables[0];
        }

        public int OLEDBExecuteNonQuery(SqlCommand cmd)
        {
            int iResult = 0;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Common.conn;
            cmd.Connection = con;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            iResult = cmd.ExecuteNonQuery();
            con.Close();
            return iResult;
        }
    }
}