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
    public partial class viewcity : System.Web.UI.Page
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
                griddata();
                if (Request.QueryString["edit"] == "edit")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Updated Successfully.";
                }
            }


        }
        protected void fillState()
        {
            sid.Items.Clear();
            Parameters.Clear();
            Parameters.Add("@countryid", countryid.SelectedValue);
            clsm.Fillcombo_Parameter("select statename, sid from states_master where status=1 and countryid=@countryid order by statename", Parameters, sid);
        }
        private void griddata()
        {
            Parameters.Clear();
            string strsql = "select co.countryname,c.*,s.statename from city_master c inner join states_master s on c.sid=s.sid inner join country co on co.countryid=c.countryid where 1=1  and  c.countryid=53  ";

            if (Convert.ToInt32(countryid.SelectedValue) > 0)
            {
                Parameters.Add("@countryid", countryid.SelectedValue);
                strsql += " and  c.countryid=@countryid";
            }
            if (Convert.ToInt32(sid.SelectedValue) > 0)
            {
                Parameters.Add("@sid", sid.SelectedValue);
                strsql += " and  c.sid=@sid";
            }
            if (!string.IsNullOrEmpty(cityname.Text.Trim()))
            {
                Parameters.Add("@cityname", cityname.Text);
                strsql += " and  c.cityname like '%' +@cityname+ '%'";
            }

            strsql += " order by co.countryname,s.statename,c.cityname";
            clsm.GridviewData_Parameter(GridView1, strsql, Parameters);
            if (GridView1.Rows.Count == 0)
            {
                trnotice.Visible = true;
                lblnotice.Text = "Record not found.";
            }
        }


        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {

                griddata();
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }

        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            clsm.ClearallPanel(this, sid.Parent);


        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lnkstatus = e.Row.FindControl("lnkstatus") as ImageButton;
                if (e.Row.Cells[5].Text == "True")
                {
                    lnkstatus.ImageUrl = "~/Office/assets/ico_unblock.png";
                    lnkstatus.ToolTip = "Active";
                }
                else if (e.Row.Cells[5].Text == "False")
                {
                    lnkstatus.ImageUrl = "~/Office/assets/ico_block.png";
                    lnkstatus.ToolTip = "Inactive";
                }
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            }

            if (e.Row.RowType == DataControlRowType.DataRow | e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[5].Visible = false;
            }


        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "btnedit")
            {
                Response.Redirect("city.aspx?cid=" + e.CommandArgument);
            }

            if (e.CommandName == "lnkstatus")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string str = ((DataControlFieldCell)row.Cells[5]).Text;
                if (str == "False")
                {
                    clsm.ExecuteQry("update city_master set status=1 where cityid=" + e.CommandArgument.ToString() + "");
                }
                else if (str == "True")
                {
                    clsm.ExecuteQry("update city_master set status=0 where cityid=" + e.CommandArgument.ToString() + "");
                }
                griddata();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status Changed Successfully.";
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                griddata();
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }

        }
        protected void countryid_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillState();
        }
    }
}