using WorkOrderAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace WorkOrderAPI.DataLayer
{   
    public class DL_UserLogin
    {
        Common obj = new Common();
        SqlCommand cmd = null;
        
        public DataTable dtGetUserLogin(Login objLogin)
        {
                DataTable dt = new DataTable();
                try
                {
                    cmd = new SqlCommand();
                    cmd.CommandText = "USP_USERLOGIN";
                    cmd.Parameters.AddWithValue("@type", "ApiLogin");
                    cmd.Parameters.AddWithValue("@USERID", objLogin.user_id);
                    cmd.Parameters.AddWithValue("@PASSWORD", objLogin.password);
                DataSet ds = obj.ExecuteDataset(cmd);
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                }
                catch (Exception ex)
                {
                    Common.objLogs.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                    throw ex;
                }
                return dt;
        }
       
    }
}