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
using Microsoft.VisualBasic;

namespace backoffice.office.Products
{
    public partial class viewproductcategory : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        public HttpCookie AUserSession = null;
        Hashtable Parameters = new Hashtable();
        string StrFileName;
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (Page.IsPostBack == false)
            {
                Parameters.Clear();
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
                string strsql = " select * from productcate where 1=1 ";
                Parameters.Clear();

                if (!string.IsNullOrEmpty(catname.Text))
                {
                    Parameters.Add("@category", catname.Text);
                    strsql += " and category like '%'+@category+'%'";
                }
                strsql += " order by displayorder";
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lnkstatus = e.Row.FindControl("lnkstatus") as ImageButton;
                TextBox txtstatus = e.Row.FindControl("txtstatus") as TextBox;
                ImageButton lnkshowonhome = e.Row.FindControl("lnkshowonhome") as ImageButton;
                TextBox txtshowonhome = e.Row.FindControl("txtshowonhome") as TextBox;
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

                if (lnkshowonhome == null == false)
                {
                    if (txtshowonhome.Text == "True")
                    {
                        lnkshowonhome.ImageUrl = "../assets/ico_unblock.png";
                        lnkshowonhome.ToolTip = "Yes";
                    }
                    else if (txtshowonhome.Text == "False")
                    {
                        lnkshowonhome.ImageUrl = "../assets/ico_block.png";
                        lnkshowonhome.ToolTip = "No";
                    }
                }

            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                Response.Redirect("productcategory.aspx?seriesid=" + e.CommandArgument);
            }
            if (e.CommandName == "status")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtstatus = row.FindControl("txtstatus") as TextBox;
                if (txtstatus.Text == "False")
                {
                    
                    Parameters.Clear();
                    Parameters.Add("@seriesid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update productcate set status=1 where seriesid=@seriesid", Parameters);
                }
                else if (txtstatus.Text == "True")
                {
                    
                    Parameters.Clear();
                    Parameters.Add("@seriesid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update productcate set status=0 where seriesid=@seriesid", Parameters);
                }
                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }


            if (e.CommandName == "showonhome")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtstatus = row.FindControl("txtshowonhome") as TextBox;
                if (txtstatus.Text == "False")
                {
                    
                    Parameters.Clear();
                    Parameters.Add("@seriesid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update productcate set showonhome=1 where seriesid=@seriesid", Parameters);
                }
                else if (txtstatus.Text == "True")
                {
                    
                    Parameters.Clear();
                    Parameters.Add("@seriesid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update productcate set showonhome=0 where seriesid=@seriesid", Parameters);
                }
                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }


            if (e.CommandName == "del")
            {
                Parameters.Clear();
                Parameters.Add("@seriesid", Convert.ToInt32(e.CommandArgument));
                if (clsm.Checking_Parameter("select * from products where seriesid=@seriesid", Parameters) == true)
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
                    Parameters.Add("@seriesid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("delete from productcate where seriesid=@seriesid", Parameters);
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + Server.HtmlDecode(lblimage.Text));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    gridshow();
                    trnotice.Visible = true;
                    lblnotice.Text = "Category deleted successfully.";
                }

            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                gridshow();
            }
            catch (Exception ex)
            {

            }

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            gridshow();
        }
    }
}