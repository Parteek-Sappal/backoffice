using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Net.Mail;

namespace backoffice.office.masters
{
    public partial class city : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        public HttpCookie AUserSession = null;
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (Page.IsPostBack == false)
            {
                Parameters.Clear();
                clsm.Fillcombo_Parameter("select countryname, countryid from country where status=1 and countryid=53 order by countryname", Parameters, countryid);
                fillState();
                Int32 p = 0;
                if (Int32.TryParse(Request.QueryString["cid"], out p) == true)
                {
                    Parameters.Clear();
                    Parameters.Add("@cid", Convert.ToInt32(Request.QueryString["cid"]));
                    string strsql1 = "Select * From city_master Where cityid=@cid";
                    clsm.MoveRecord_Parameter(this, cityid.Parent, strsql1, Parameters);
                    fillState();
                    Parameters.Clear();
                    Parameters.Add("@cid", Convert.ToInt32(Request.QueryString["cid"]));
                    string strsql = "Select * From city_master Where cityid=@cid";
                    clsm.MoveRecord_Parameter(this, cityid.Parent, strsql, Parameters);
                }

                if (Request.QueryString["add"] == "add")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Added Successfully.";
                }
            }


        }
        protected void fillState()
        {
            Parameters.Clear();
            Parameters.Add("@countryid", countryid.SelectedValue);
            string strsql = "select statename, sid from states_master where status=1 and countryid=@countryid order by statename";            

            clsm.Fillcombo_Parameter(strsql, Parameters, sid);
        }

        protected void countryid_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillState();
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(cityid.Text))
                {
                    string var = clsm.MasterSave(this, cityid.Parent, 6, mainclass.Mode.modeAdd, "citySP", Convert.ToString(Session["UserId"]));

                    Response.Redirect("city.aspx?add=add");

                }
                else
                {
                    string var = clsm.MasterSave(this, cityid.Parent, 6, mainclass.Mode.modeModify, "citySP", Convert.ToString(Session["UserId"]));
                    Response.Redirect("viewcity.aspx?edit=edit");
                }
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }


        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(sid.Text) == 0)
            {
                clsm.ClearallPanel(this, sid.Parent);
            }
            else
            {
                Response.Redirect("viewcity.aspx");
            }

        }
    }
}