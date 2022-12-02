using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualBasic;


namespace backoffice.office.Products
{
    public partial class index : System.Web.UI.Page
    {
        HttpCookie AUserSession;
        mainclass clsm = new mainclass();
        Hashtable Parameters = new Hashtable();


        protected void Page_Load(object sender, System.EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (Request.Cookies["AUserSession"] == null)
            {
                AUserSession = new HttpCookie("AUserSession");
            }
            else
            {
                AUserSession = Request.Cookies["AUserSession"];
            }

            if ((Page.IsPostBack == false))
            {
                collageid.Text = Convert.ToString(Conversion.Val(Request.QueryString["prodid"]));

                Parameters.Clear();
                Parameters.Add("@prodid", double.Parse(Request.QueryString["prodid"]));
                lblcollage.Text = Convert.ToString(clsm.SendValue_Parameter("SELECT productname FROM Products  WHERE productid=@prodid", Parameters));

            }

        }
    }
}