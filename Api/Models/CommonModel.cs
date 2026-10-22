using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkOrderAPI.Models
{
    public class ChangeDepartmentModel
    {
        public String FromDepartment { get; set; }
        public String ToDepartment { get; set; }
        public String CreatedBy { get; set; }
        public string Result { get; set; }
        public String SerialNo { get; set; }
        public String FromSiteCode { get; set; }
        public String ToSiteCode { get; set;}
        public string GradeName { get; set; }
        public string Userid { get; set; }
        public string SpoolWeight { get; set; }
        public String MCWeightBox { get; set;}
        public String NETWT { get; set; }

        public String DrawnSizeName { get; set; }

        public string BaseSizeName { get; set; }


        public string ConditionName { get; set; }


    }
    

public class OrderRequestModel
    {
        public string OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public int OrderQty { get; set; }
        public PartDetailsModel PartDetails { get; set; }
        public List<MCBoxModel> MCBox { get; set; }
    }

    public class PartDetailsModel
    {
        public string Code { get; set; }
        public string Content { get; set; }
        public int PackSize { get; set; }
    }

    public class MCBoxModel
    {
        public string MCBoxSerial { get; set; }
        public List<string> IBSerial { get; set; }
    }
    public class SaveOrderResponseModel
    {
        public string Result { get; set; }        // Stores "SUCCESS~..." or "ERROR~..."
        public string OrderNumber { get; set; }   // Stores "W001"
        public bool Status { get; set; }          // true or false
        //public string Message { get; set; }       // Human-readable message
    }
}