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
    public partial class country : System.Web.UI.Page
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
                Int32 p = 0;
                if (Int32.TryParse(Request.QueryString["cid"], out p) == true)
                {
                    Parameters.Clear();
                    Parameters.Add("@cid", Convert.ToInt32(Request.QueryString["cid"]));
                    string strsql1 = "Select * From country Where countryid=@cid";
                    clsm.MoveRecord_Parameter(this, countryid.Parent, strsql1, Parameters);
                    countryid.Text = HttpUtility.HtmlDecode(countryid.Text);
                    displayorder.Text = HttpUtility.HtmlDecode(displayorder.Text);
                    countryname.Text = HttpUtility.HtmlDecode(countryname.Text);
                    countrycode.Text = HttpUtility.HtmlDecode(countrycode.Text);
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
            clsm.GridviewData_Parameter(GridView1, "select * from country order by displayorder", Parameters);
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

                if (Convert.ToInt32(clsm.MasterSave(this, countryid.Parent, 5, mainclass.Mode.modeCheckDuplicate, "countrySP", Convert.ToString(Session["UserId"]))) > 0)
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "Duplicacy not allowed.";
                    return;
                }

                if (string.IsNullOrEmpty(countryid.Text))
                {
                    string var = clsm.MasterSave(this, countryid.Parent, 5, mainclass.Mode.modeAdd, "countrySP", Convert.ToString(Session["UserId"]));
                    clsm.ClearallPanel(this, countryid.Parent);
                    griddata();
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Added Successfully.";
                }
                else
                {
                    string var = clsm.MasterSave(this, countryid.Parent, 5, mainclass.Mode.modeModify, "countrySP", Convert.ToString(Session["UserId"]));
                    Response.Redirect("country.aspx?edit=edit");
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
            clsm.ClearallPanel(this, countryid.Parent);
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lnkstatus = e.Row.FindControl("lnkstatus") as ImageButton;
                if (e.Row.Cells[4].Text == "True")
                {
                    lnkstatus.ImageUrl = "~/Office/assets/ico_unblock.png";
                    lnkstatus.ToolTip = "Active";
                }
                else if (e.Row.Cells[4].Text == "False")
                {
                    lnkstatus.ImageUrl = "~/Office/assets/ico_block.png";
                    lnkstatus.ToolTip = "Inactive";
                }
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            }

            if (e.Row.RowType == DataControlRowType.DataRow | e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[4].Visible = false;
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnedit")
            {
                Response.Redirect("country.aspx?cid=" + e.CommandArgument);
            }

            if (e.CommandName == "lnkstatus")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string str = ((DataControlFieldCell)row.Cells[4]).Text;
                if (str == "False")
                {
                    Parameters.Clear();
                    Parameters.Add("@bid", Convert.ToInt32(e.CommandArgument.ToString()));
                    string strsql = "update country set status=1 where countryid=@bid";
                    clsm.ExecuteQry_Parameter(strsql, Parameters);
                }
                else if (str == "True")
                {
                    Parameters.Clear();
                    Parameters.Add("@bid", Convert.ToInt32(e.CommandArgument.ToString()));
                    string strsql = "update country set status=0 where countryid=@bid";
                    clsm.ExecuteQry_Parameter(strsql, Parameters);
                }
                griddata();
                trsuccess.Visible = true;
                lblsuccess.Text = "Country Changed Successfully.";
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