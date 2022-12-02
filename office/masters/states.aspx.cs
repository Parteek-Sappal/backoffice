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
    public partial class states : System.Web.UI.Page
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
                clsm.Fillcombo_Parameter("select countryname,countryid from country where status=1 and countryid=53 order by countryname", Parameters, countryid);
                Int32 p = 0;
                if (Int32.TryParse(Request.QueryString["sid"], out p) == true)
                {
                    Parameters.Clear();
                    Parameters.Add("@sid", Convert.ToInt32(Request.QueryString["sid"]));
                    clsm.MoveRecord_Parameter(this, sid.Parent, "Select * From states_master Where sid=@sid", Parameters);

                }
                griddata();
                if (Request.QueryString["edit"] == "edit")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Updated Successfully.";
                }
            }
        }
        private void griddata()
        {
            Parameters.Clear();
            clsm.GridviewData_Parameter(GridView1, "select c.countryname, s.* from states_master s inner join country c on c.countryid=s.countryid where c.countryid=53 order by s.statename", Parameters);
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


                if (string.IsNullOrEmpty(sid.Text))
                {
                    string var = clsm.MasterSave(this, sid.Parent, 6, mainclass.Mode.modeAdd, "stateSP", Convert.ToString(Session["UserId"]));
                    clsm.ClearallPanel(this, sid.Parent);
                    griddata();
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Added Successfully.";
                }
                else
                {
                    string var = clsm.MasterSave(this, sid.Parent, 6, mainclass.Mode.modeModify, "stateSP", Convert.ToString(Session["UserId"]));
                    Response.Redirect("states.aspx?edit=edit");
                }
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }


        }


        protected void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                Parameters.Clear();
                string strsql = "select co.*,s.* from country co inner join states_master s on co.countryid=s.countryid";

                if (Convert.ToInt32(countryid.SelectedValue) > 0)
                {
                    Parameters.Add("@countryid", countryid.SelectedValue);
                    strsql += " and  co.countryid=@countryid";
                }
                if (!string.IsNullOrEmpty(statename.Text.Trim()))
                {
                    Parameters.Add("@statename", statename.Text);
                    strsql += " and  s.statename like '%' +@statename+ '%'";
                }
                strsql += " order by co.countryname,s.statename";
                clsm.GridviewData_Parameter(GridView1, strsql, Parameters);
                if (GridView1.Rows.Count == 0)
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "Record not found.";
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
            // clsm.Clearall(sid.Parent)
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
                Response.Redirect("states.aspx?sid=" + e.CommandArgument);
            }

            if (e.CommandName == "lnkstatus")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string str = ((DataControlFieldCell)row.Cells[5]).Text;
                if (str == "False")
                {
                    clsm.ExecuteQry("update states_master set status=1 where sid=" + e.CommandArgument.ToString() + "");
                }
                else if (str == "True")
                {
                    clsm.ExecuteQry("update states_master set status=0 where sid=" + e.CommandArgument.ToString() + "");
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
    }
}