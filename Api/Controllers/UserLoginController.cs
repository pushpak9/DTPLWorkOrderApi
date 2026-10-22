using WorkOrderAPI.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Data;
using System.Reflection;
using Newtonsoft.Json;
using WorkOrderAPI.DataLayer;
using System.Linq;
using System.ComponentModel;
using System.Web.Http.Results;
using System.Web.Razor.Editor;

namespace WorkOrderAPI.Controllers
{
    [RoutePrefix("API")]
    public class UserLoginController : ApiController
    {
        DataTable dt = new DataTable();
        DL_UserLogin objdlUserLogin = new DL_UserLogin();
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult UserLogin(Login objLogin)

        {
            
            Common.objLogs.WriteLog("Login Method Called for user ID : " + objLogin.user_id, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
            Login obj = new Login();
            string sResult = string.Empty;
            try
            {
                dt = objdlUserLogin.dtGetUserLogin(objLogin);
                if (dt.Rows.Count != 0)
                {
                    sResult = dt.Rows[0][0].ToString();
                    if (sResult.StartsWith("N~") || sResult.StartsWith("ERROR~"))
                    {
                        obj.user_id = null;
                        obj.SiteCode = null;
                        obj.Result = "Incorrect Username and password ";
                    }
                    else
                    {
                        obj.user_id = dt.Rows[0]["USERID"].ToString();
                        obj.SiteCode = dt.Rows[0]["SiteCode"].ToString();
                        obj.Result = "success";
                    }
                    
                }
              
            }
            catch (Exception ex)
            {
                Common.objLogs.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                obj.Result = ex.Message;
            }
            return Json(obj);
        }
    

    }
    
    public static class ListToDatatable
    {
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        public static DataTable ToDataTable1<T>(this IEnumerable<T> collection)
        {
            DataTable dt = new DataTable();
            Type t = typeof(T);
            PropertyInfo[] pia = t.GetProperties();
            object temp;
            DataRow dr;

            for (int i = 0; i < pia.Length; i++)
            {
                dt.Columns.Add(pia[i].Name, Nullable.GetUnderlyingType(pia[i].PropertyType) ?? pia[i].PropertyType);
                dt.Columns[i].AllowDBNull = true;
            }

            //Populate the table
            foreach (T item in collection)
            {
                dr = dt.NewRow();
                dr.BeginEdit();

                for (int i = 0; i < pia.Length; i++)
                {
                    temp = pia[i].GetValue(item, null);
                    if (temp == null || (temp.GetType().Name == "Char" && ((char)temp).Equals('\0')))
                    {
                        dr[pia[i].Name] = (object)DBNull.Value;
                    }
                    else
                    {
                        dr[pia[i].Name] = temp;
                    }
                }

                dr.EndEdit();
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
