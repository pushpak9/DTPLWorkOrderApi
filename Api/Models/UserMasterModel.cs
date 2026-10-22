using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WorkOrderAPI.Models
{
    public class UserMasterModel
    {
        public int Id { get; set; }
        public string SiteCode { get; set; }
        public string UserName { get; set; }
        public string UserID { get; set; }
        public string UserType { get; set; }
        public string Password { get; set; }
        
        public string Result { get; set; }
    }

    public class Login
    {
        public string user_id { get; set; }
        public string password { get; set; }
        public string SiteCode { get; set; }
        public string Result { get; set; }
    }

    public class ModuleMasterModel
    {
        public string UserName { get; set; }
        public string UserID { get; set; }
        public string ModuleName { get; set; }
        public string HeaderName { get; set; }
        public string ControllerName { get; set; }
        public string ICon { get; set; }
        public string IndexPage { get; set; }
        public int MMID { get; set; }
        public string IsHeader { get; set; }
        public bool iStatus { get; set; }
        public string Result { get; set; }
    }
    public class DepartmentMasterModel
    {
        public string DepartmentName { get; set; }
        public string DepartmentValue { get; set; }

    }
    public class SiteMasterModel
    {
        public string SiteName { get; set; }
        public string SiteValue { get; set; }

    }
    public class UserRights_Permission
    {
        public ICollection<UserRights> PermissionMaster { get; set; }
    }
    public class UserRights
    {
        public int URID { get; set; } = 0;
        public string UserID { get; set; } = string.Empty;
        public string ModuleName { get; set; } = string.Empty;
        public bool iStatus { get; set; } = false;
        public string RightsGivenBy { get; set; } = string.Empty;
        public DateTime RightsGivenOn { get; set; } = DateTime.UtcNow;
        public string Result { get; set; }

        public string SiteCode { get; set; }


    }
    public class PrintingDataMasterModel
    {
        public ICollection<PrintingData> ScannedList { get; set; }
    }
    public class PrintingData
    {
       
        public string SiteCode { get; set; }
        public string DispatchUser { get; set; }

        public string GradeName { get; set; }
        public string SerialNo { get; set; }
        public string Result { get; set; }

        public string Userid { get; set; }

        public string SpoolWeight { get; set; }
        public String MCWeightBox { get; set; }
        public String NETWT { get; set; }

        public String DrawnSizeName { get; set; }
       public string BaseSizeName { get; set; }
        public string ConditionName { get; set; }
    }
}