using DTPLLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WorkOrderAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);           
            DTPLLogs.DTPLLogsWrite objLogs1 = new DTPLLogs.DTPLLogsWrite();   
            objLogs1.sLogName = "DTLPL";
            objLogs1.sLogFilePath = AppDomain.CurrentDomain.BaseDirectory;
            objLogs1.iLogDays = 20;
            Common.objLogs = objLogs1;
        }
    }
}
