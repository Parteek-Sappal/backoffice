using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace backoffice.office
{
    public partial class logout : System.Web.UI.Page
    {
        HttpCookie AUserSession = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["AUserSession"] == null)
            {
                AUserSession = new HttpCookie("AUserSession");
            }
            else
            {
                AUserSession = Request.Cookies["AUserSession"];
            }

            Response.Cookies["AUserSession"].Expires = DateTime.Now.AddDays(-1);
            AUserSession["Userid"] = "";
            AUserSession["Name"] = "";
            AUserSession["Roleid"] = "";
            Response.Cookies.Add(AUserSession);
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("~/office/index.aspx");
        }
    }
}