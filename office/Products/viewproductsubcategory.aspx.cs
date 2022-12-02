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
    public partial class viewproductsubcategory : System.Web.UI.Page
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
                categoryname();
                gridshow();

                if (Request.QueryString["edit"] == "edit")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record updated successfully.";
                }
            }
        }
        private void categoryname()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select category,pcatid from productcate where status = 1 order by displayorder", Parameters, pcatid);
            pcatid.Items[0].Text = "Search By Category";
        }
        protected void gridshow()
        {
            try
            {
                string strsql = "select sc.*,pc.category as subcategory from productsubcate sc left join productcate pc on sc.pcatid=pc.pcatid where 1=1  ";
                Parameters.Clear();

                if (Conversion.Val(pcatid.SelectedValue) > 0)
                {

                    Parameters.Add("@pcatid", Conversion.Val(pcatid.SelectedValue));
                    strsql += " and sc.pcatid=@pcatid";
                }
                if (!string.IsNullOrEmpty(catname.Text))
                {
                    Parameters.Add("@category", catname.Text);
                    strsql += " and sc.category like '%'+@category+'%'";
                }

                strsql += " order by sc.displayorder";
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
                Response.Redirect("productsubcategory.aspx?psubcatid=" + e.CommandArgument);
            }
            if (e.CommandName == "status")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtstatus = row.FindControl("txtstatus") as TextBox;
                if (txtstatus.Text == "False")
                {                    
                    Parameters.Clear();
                    Parameters.Add("@psubcatid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update productsubcate set status=1 where psubcatid=@psubcatid", Parameters);
                }
                else if (txtstatus.Text == "True")
                {
                    Parameters.Clear();
                    Parameters.Add("@psubcatid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update productsubcate set status=0 where psubcatid=@psubcatid", Parameters);
                }
                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }
            if (e.CommandName == "del")
            {
                Parameters.Clear();
                Parameters.Add("@psubcatid", Convert.ToInt32(e.CommandArgument));
                if (clsm.Checking_Parameter("select * from products where psubcatid=@psubcatid", Parameters) == true)
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
                    Parameters.Add("@psubcatid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("delete from productsubcate where psubcatid=@psubcatid", Parameters);
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + Server.HtmlDecode(lblimage.Text));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    gridshow();
                    trnotice.Visible = true;
                    lblnotice.Text = "Sub Category deleted successfully.";
                }

            }


        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            gridshow();
        }
    }
}