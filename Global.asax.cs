using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace backoffice
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
           // RouteConfig.RegisterRoutes(RouteTable.Routes);
           // BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_BeginRequest(object sender, System.EventArgs e)
        {
          //  string strrawredirecturl = string.Empty;
          //  strrawredirecturl = Request.RawUrl;

            //if (!string.IsNullOrEmpty(strrawredirecturl))
            //{
            //    strrawredirecturl = strrawredirecturl.TrimStart('/');
            //    if (!string.IsNullOrEmpty(strrawredirecturl))
            //    {
            //        Hashtable parameters = new Hashtable();
            //        mainclass clsm = new mainclass();
            //        parameters.Add("@redirectFrom", strrawredirecturl);
            //        string strdbvalue = Convert.ToString(clsm.SendValue_Parameter("select redirectTo from  redirectmanagement where status=1 and redirectFrom=@redirectFrom", parameters));

            //        if (!string.IsNullOrEmpty(strdbvalue))
            //        {
            //            if (strdbvalue.Contains("http") == true || strdbvalue.Contains("https") == true)
            //            {
            //                string newUrl = strdbvalue;
            //                Response.Status = "301 Moved Permanently";
            //                Response.AddHeader("Location", newUrl);
            //            }
            //            else
            //            {
            //                //Response.Write(strdbvalue);
            //                string newUrl = "/" + strdbvalue;
            //                Response.Status = "301 Moved Permanently";
            //                Response.AddHeader("Location", newUrl);
            //            }

            //        }
            //    }
            //}
        }
    }
}