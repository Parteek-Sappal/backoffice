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
    public partial class viewdepartment : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        public HttpCookie AUserSession = null;
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {

            trsuccess.Visible = false;
            trnotice.Visible = false;
            trerror.Visible = false;
            if (Page.IsPostBack == false)
            {
                gridshow();
            }
            if (Request.QueryString["edit"] == "edit")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record updated successfully..";
            }

        }
        protected void gridshow()
        {
            
            Parameters.Clear();
            clsm.GridviewData_Parameter(GridView1, "select * from Department_Master order by displayorder", Parameters);
            if (GridView1.Rows.Count == 0)
            {
                trnotice.Visible = true;
                lblnotice.Text = "Departments not found.";
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lnkstatus = e.Row.FindControl("lnkstatus") as ImageButton;
                TextBox txtstatus = e.Row.FindControl("txtstatus") as TextBox;
                if (txtstatus.Text == "True")
                {
                    lnkstatus.ImageUrl = "../assets/ico_unblock.png";
                    lnkstatus.ToolTip = "Active";
                }
                else if (txtstatus.Text == "False")
                {
                    lnkstatus.ImageUrl = "../assets/ico_block.png";
                    lnkstatus.ToolTip = "Inactive";
                }
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            }

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "redit")
            {
                Response.Redirect("departments.aspx?id=" + Convert.ToInt32(e.CommandArgument));
                
            }
            if (e.CommandName == "lnkstatus")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtstatus = row.FindControl("txtstatus") as TextBox;
                if (txtstatus.Text == "False")
                {
                    
                    Parameters.Clear();
                    Parameters.Add("@deptid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update Department_Master set status=1 where deptid=@deptid", Parameters);
                }
                else if (txtstatus.Text == "True")
                {
                    
                    Parameters.Clear();
                    Parameters.Add("@deptid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update Department_Master set status=0 where deptid=@deptid", Parameters);
                }
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
                gridshow();
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
    }
}