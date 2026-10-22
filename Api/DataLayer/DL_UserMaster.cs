using WorkOrderAPI.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace WorkOrderAPI.DataLayer
{
    public class DL_UserMaster
    {
        Common obj = new Common();
        SqlCommand cmd = null;
        public DataTable dtBindDepartment() 
        {
            DataTable dt = new DataTable();
			try
			{
                cmd = new SqlCommand();
                cmd.CommandText = "USP_DepartmentMASTER";
                cmd.Parameters.AddWithValue("@type", "BINDDEPARTEMENT");
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
        public DataTable dtBindSiteCode()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_SITEMASTER";
                cmd.Parameters.AddWithValue("@type", "BINDSiteCode");
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
        public DataTable dtBindUser(string sSiteCode)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_USERMASTER";
                cmd.Parameters.AddWithValue("@type", "GETUSER");
                cmd.Parameters.AddWithValue("@SITECODE", sSiteCode);
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
        public DataTable dtGetUserByID(string sUserID,string sSiteCode)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_USERMASTER";
                cmd.Parameters.AddWithValue("@type", "GETUSERBYID");
                cmd.Parameters.AddWithValue("@UserID", sUserID);
                cmd.Parameters.AddWithValue("@SITECODE", sSiteCode);
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