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


namespace backoffice.office.redirectionmanagement
{
    public partial class redirection : System.Web.UI.Page
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
                if (Convert.ToInt32(Request.QueryString["rewriteid"]) > 0)
                {
                    txtsearch.ReadOnly = true;
                    Parameters.Clear();
                    Parameters.Add("@rewriteid", Convert.ToInt32(Request.QueryString["rewriteid"]));
                    clsm.MoveRecord_Parameter(this, rewriteid.Parent, "select * from redirectmanagement where rewriteid=@rewriteid", Parameters);
                    rewriteid.Text = HttpUtility.HtmlDecode(rewriteid.Text);
                    txtsearch.ReadOnly = false;
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

                string strsql = "";
                Parameters.Clear();
                strsql = "select * from redirectmanagement where 1=1 ";


                if (txtsearch.Text != "")
                {
                    Parameters.Add("@redirectTo", txtsearch.Text.Replace("'", ""));
                    strsql += " and  redirectTo like '%'+@redirectTo+'%'  or   redirectFrom like '%'+@redirectTo+'%' ";
                }
             
                strsql += " order by trdate desc ";




                clsm.GridviewData_Parameter(GridView1, strsql, Parameters);
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
                redirectFrom.Text = redirectFrom.Text.Trim();
                redirectTo.Text = redirectTo.Text.Trim();


                txtsearch.ReadOnly = true;
                if (Convert.ToInt32(clsm.MasterSave(this, rewriteid.Parent, 5, mainclass.Mode.modeCheckDuplicate, "redirectmanagementSP", Convert.ToString(Session["UserId"]))) > 0)
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "This Old Url already Redirected.";
                    txtsearch.ReadOnly = false;
                    return;
                }


                if (string.IsNullOrEmpty(rewriteid.Text))
                {


                    Status.Checked = true;
                    string var = clsm.MasterSave(this, rewriteid.Parent, 5, mainclass.Mode.modeAdd, "redirectmanagementSP", Convert.ToString(Session["UserId"]));
                    txtsearch.ReadOnly = false;
                    clsm.ClearallPanel(this, rewriteid.Parent);

                    gridshow();
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record added successfully.";
                }
                else
                {

                    string var = clsm.MasterSave(this, rewriteid.Parent, 5, mainclass.Mode.modeModify, "redirectmanagementSP", Convert.ToString(Session["UserId"]));
                    txtsearch.ReadOnly = false;
                    Response.Redirect("redirection.aspx?edit=edit");
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
            clsm.ClearallPanel(this, rewriteid.Parent);
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
                Response.Redirect("redirection.aspx?rewriteid=" + e.CommandArgument);
            }
            if (e.CommandName == "status")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtstatus = row.FindControl("txtstatus") as TextBox;
                if (txtstatus.Text == "False")
                {

                    Parameters.Clear();
                    Parameters.Add("@rewriteid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update redirectmanagement set status=1 where rewriteid=@rewriteid", Parameters);
                }
                else if (txtstatus.Text == "True")
                {

                    Parameters.Clear();
                    Parameters.Add("@rewriteid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update redirectmanagement set status=0 where rewriteid=@rewriteid", Parameters);
                }
                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }
            if (e.CommandName == "del")
            {
                Parameters.Clear();
                Parameters.Add("@rewriteid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("delete from redirectmanagement where rewriteid=@rewriteid", Parameters);

                gridshow();
                trnotice.Visible = true;
                lblnotice.Text = "Redirection deleted successfully.";

            }


        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            gridshow();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            //GridView1.DataBind();
            gridshow();
        }
    }
}