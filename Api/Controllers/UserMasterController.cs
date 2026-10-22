using WorkOrderAPI.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Data;
using System.Reflection;
using WorkOrderAPI.DataLayer;
using System.Linq;
using System.ComponentModel;

namespace WorkOrderAPI.Controllers
{
    [RoutePrefix("API")]
    public class UserMasterController : ApiController
    {
        DataTable dt = new DataTable();
        DL_UserMaster objDLUserMaster = new DL_UserMaster();
        [HttpGet]
        [Route("BindDepartment")]
        public IHttpActionResult Bindepartment()
        {
            List<DepartmentMasterModel> objModel = new List<DepartmentMasterModel>();
            try
            {
                dt = objDLUserMaster.dtBindDepartment();
                objModel = (from DataRow dr in dt.Rows
                            select new DepartmentMasterModel()
                            {
                                DepartmentName = Convert.ToString(dr["DeptName"]),
                                DepartmentValue = Convert.ToString(dr["DeptName"])
                            }).ToList();
            }
            catch (Exception ex)
            {
                Common.objLogs.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
            }
            return Json(objModel);

        }

        [HttpGet]
        [Route("GetUser")]
        public IHttpActionResult BindUser(UserMasterModel request)
        {
            List<UserMasterModel> objModel = new List<UserMasterModel>();
            try
            {
                dt = objDLUserMaster.dtBindUser(request.SiteCode);
                objModel = (from DataRow dr in dt.Rows
                            select new UserMasterModel()
                            {
                                SiteCode = Convert.ToString(dr["SiteCode"]),
                                UserID = Convert.ToString(dr["UserID"]),
                                UserName = Convert.ToString(dr["UserName"]),
                                UserType = Convert.ToString(dr["UserType"]),
                                Password = Convert.ToString(dr["Password"]),
                            }).ToList();
            }
            catch (Exception ex)
            {
                Common.objLogs.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                objModel.Add(
                        new UserMasterModel
                        {
                            Result = ex.Message
                        });
            }
            return Json(objModel);
        }

        [HttpPost]
        [Route("GetUserByID")]
        public IHttpActionResult GetUserByID(UserMasterModel request)
        {
            UserMasterModel objModel = new UserMasterModel();
            try
            {
                dt = objDLUserMaster.dtGetUserByID(request.UserID, request.SiteCode);
                foreach (DataRow dr in dt.Rows)
                {
                    objModel.SiteCode = Convert.ToString(dr["SiteCode"]);
                    objModel.UserID = Convert.ToString(dr["UserID"]);
                    objModel.UserName = Convert.ToString(dr["UserName"]);
                    objModel.UserType = Convert.ToString(dr["UserType"]);
                    objModel.Password = Convert.ToString(dr["Password"]);
                    objModel.Result = "";
                }
            }
            catch (Exception ex)
            {
                Common.objLogs.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                objModel.Result = ex.Message;
            }
            return Json(objModel);
        }
        [HttpGet]
        [Route("BindSiteCode")]
        public IHttpActionResult BindSiteCode()
        {
            List<SiteMasterModel> objModel = new List<SiteMasterModel>();
            try
            {
                dt = objDLUserMaster.dtBindSiteCode();
                objModel = (from DataRow dr in dt.Rows
                            select new SiteMasterModel()
                            {
                                SiteName = Convert.ToString(dr["SiteCode"]),
                                SiteValue = Convert.ToString(dr["SiteCode"])
                            }).ToList();
            }
            catch (Exception ex)
            {
                Common.objLogs.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
            }
            return Json(objModel);

        }
        

    }


    
}