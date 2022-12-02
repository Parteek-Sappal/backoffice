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

namespace backoffice.office.Services
{
    public partial class servicetype : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        public HttpCookie AUserSession = null;
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (!Page.IsPostBack)
            {
                if (Convert.ToInt32(Request.QueryString["stypeid"]) > 0)
                {

                    Parameters.Clear();
                    Parameters.Add("@stypeid", Convert.ToInt32(Request.QueryString["stypeid"]));
                    clsm.MoveRecord_Parameter(this, stypeid.Parent, "select * from servicetype where stypeid=@stypeid", Parameters);
                    stypeid.Text = HttpUtility.HtmlDecode(stypeid.Text);
                    stype.Text = HttpUtility.HtmlDecode(stype.Text);
                    displayorder.Text = HttpUtility.HtmlDecode(displayorder.Text);


                }
                gridshow();

                if (Request.QueryString["edit"] == "edit")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record updated successfully.";
                }

            }

        }
        protected void gridshow()
        {
            try
            {

                Parameters.Clear();
                clsm.GridviewData_Parameter(GridView1, "select * from servicetype order by displayorder", Parameters);
                if (GridView1.Rows.Count == 0)
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "Record(s) not found.";
                }
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }
        }


        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Write("aaaaaaaaaa");

                if (Convert.ToInt32(clsm.MasterSave(this, stypeid.Parent, 4, mainclass.Mode.modeCheckDuplicate, "servicetypeSP", Convert.ToString(Session["UserId"]))) > 0)
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "This Service type  already exist.";
                    return;
                }


                if (string.IsNullOrEmpty(stypeid.Text))
                {


                    Status.Checked = true;
                    string var = clsm.MasterSave(this, stypeid.Parent, 4, mainclass.Mode.modeAdd, "servicetypeSP", Convert.ToString(Session["UserId"]));

                    clsm.ClearallPanel(this, stypeid.Parent);
                    gridshow();
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record added successfully.";
                }
                else
                {

                    string var = clsm.MasterSave(this, stypeid.Parent, 4, mainclass.Mode.modeModify, "servicetypeSP", Convert.ToString(Session["UserId"]));

                    Response.Redirect("servicetype.aspx?edit=edit");
                }
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message;
            }

        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            clsm.ClearallPanel(this, stypeid.Parent);
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lnkstatus = e.Row.FindControl("lnkstatus") as ImageButton;
                TextBox txtstatus = e.Row.FindControl("txtstatus") as TextBox;
                if (lnkstatus == null == false)
                {
                    if (txtstatus.Text == "True")
                    {
                        lnkstatus.ImageUrl = "../assets/ico_unblock.png";
                        lnkstatus.ToolTip = "Yes";
                    }
                    else if (txtstatus.Text == "False")
                    {
                        lnkstatus.ImageUrl = "../assets/ico_block.png";
                        lnkstatus.ToolTip = "No";
                    }
                }

            }


        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                Response.Redirect("servicetype.aspx?stypeid=" + e.CommandArgument);
            }
            if (e.CommandName == "status")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtstatus = row.FindControl("txtstatus") as TextBox;
                if (txtstatus.Text == "False")
                {
                    Parameters.Clear();
                    Parameters.Add("@stypeid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update servicetype set status=1 where stypeid=@stypeid", Parameters);
                }
                else if (txtstatus.Text == "True")
                {                    
                    Parameters.Clear();
                    Parameters.Add("@stypeid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update servicetype set status=0 where stypeid=@stypeid", Parameters);
                }
                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }
            if (e.CommandName == "del")
            {
                Parameters.Clear();
                Parameters.Add("@stypeid", Convert.ToInt32(e.CommandArgument));
                if (clsm.Checking_Parameter("select * from servicetype where stypeid=@stypeid", Parameters) == true)
                {

                    trnotice.Visible = true;
                    lblnotice.Text = "Sorry, Data in use. Can not delete.";
                    return;
                }
                else
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    Label lblimage = row.FindControl("lblimage") as Label;

                    Parameters.Clear();
                    Parameters.Add("@stypeid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("delete from servicetype where stypeid=@stypeid", Parameters);
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + Server.HtmlDecode(lblimage.Text));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    gridshow();
                    trnotice.Visible = true;
                    lblnotice.Text = "Service  type deleted successfully.";
                }

            }


        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}