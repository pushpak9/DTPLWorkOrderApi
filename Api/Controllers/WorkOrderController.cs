using WorkOrderAPI.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Data;
using System.Reflection;
using WorkOrderAPI.DataLayer;
using System.Linq;
using System.Data.Entity.Infrastructure;

namespace WorkOrderAPI.Controllers
{
    [RoutePrefix("API")]
    public class WorkOrderController : ApiController
    {
        DataTable dt = new DataTable();
        DL_Common objCust = new DL_Common();

        [HttpPost]
        [Route("WorkOrder")]
        public IHttpActionResult SaveOrderJson(OrderRequestModel objOrderRequest)
        {
            SaveOrderResponseModel objModel = new SaveOrderResponseModel();
            DataTable dt = new DataTable();

            try
            {
                // 1. Validate Request
                if (objOrderRequest == null)
                {
                    objModel.Result = "ERROR~Invalid Request Payload";
                    objModel.Status = false;
                    return Json(objModel);
                }

                // 2. Validate Order Number
                if (string.IsNullOrWhiteSpace(objOrderRequest.OrderNumber))
                {
                    objModel.Result = "ERROR~Please Enter Order Number";
                    objModel.Status = false;
                    return Json(objModel);
                }

                // 3. Validate MCBox
                if (objOrderRequest.MCBox == null ||
                    objOrderRequest.MCBox.Count == 0)
                {
                    objModel.Result = "ERROR~Please Provide MCBox Details";
                    objModel.Status = false;
                    return Json(objModel);
                }

                // 4. Call Data Access Layer
                dt = objCust.SaveOrderJsonDetails(objOrderRequest);

                // 5. Process Database Result
                if (dt != null && dt.Rows.Count > 0)
                {
                    string sResult = dt.Rows[0]["Result"].ToString();

                    if (sResult.StartsWith("SUCCESS"))
                    {
                        objModel.OrderNumber = objOrderRequest.OrderNumber;
                        objModel.Result = sResult;
                        objModel.Status = true;
                    }
                    else
                    {
                        objModel.OrderNumber = objOrderRequest.OrderNumber;
                        objModel.Result = sResult;
                        objModel.Status = false;
                    }
                }
                else
                {
                    objModel.OrderNumber = objOrderRequest.OrderNumber;
                    objModel.Result = "ERROR~Failed to save order details";
                    objModel.Status = false;
                }
            }
            catch (Exception ex)
            {
                Common.objLogs.WriteLog(
                    ex.Message,
                    DTPLLogs.DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod()
                );

                objModel.Result = "ERROR~Internal server error";
                objModel.Status = false;
            }

            return Json(objModel);
        }

    }

}



    
