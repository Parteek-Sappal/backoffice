using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;


namespace backoffice.office.others
{
    public partial class view_enquiry_details : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        Hashtable Parameters = new Hashtable();
        string sqrqry = null;
        DataSet ds = default(DataSet);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                Parameters.Clear();
                Bindenquirydetail();
            }
        }

        private void Bindenquirydetail()
        {
            if (Convert.ToInt32(Request.QueryString["eid"]) != 0)
            {
                Parameters.Clear();
                Parameters.Add("@eid", Convert.ToInt32(Request.QueryString["eid"]));
                sqrqry += @"select Fname[Name] ,Emailid,Mobile, FMessage[Message] from enquiry where eid =@eid ";
            }
            ds = clsm.senddataset_Parameter(sqrqry, Parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblname.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                dtlview.DataSource = ds.Tables[0];
                dtlview.DataBind();

            }
        }
    }
}