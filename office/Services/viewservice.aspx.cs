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

namespace backoffice.office.Services
{
    public partial class viewservice : System.Web.UI.Page
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
                Parameters.Clear();
                clsm.Fillcombo_Parameter(" select stype,stypeid from servicetype where status=1 order by  displayorder", Parameters, stypeid);

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
            string strsql = "";
            strsql = "select s.*,st.stype from cservices s inner join servicetype st on s.stypeid=st.stypeid  where 1=1  ";
            if (TextBox4.Text != "")
            {
                Parameters.Add("@servicename", TextBox4.Text.Replace("'", ""));
                strsql += " and s.servicename like '%'+@servicename+'%'";
            }
            if (stypeid.SelectedValue != "0")
            {
                Parameters.Add("@stypeid", stypeid.SelectedValue);
                strsql += " and s.stypeid=@stypeid";
            }
            strsql += " order by s.displayorder";

            clsm.GridviewData_Parameter(GridView1, strsql, Parameters);
            if (GridView1.Rows.Count == 0)
            {
                trnotice.Visible = true;
                lblnotice.Text = "Service not found.";
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
                ImageButton lnkshowonhome = e.Row.FindControl("lnkshowonhome") as ImageButton;
                TextBox txtshowonhome = e.Row.FindControl("txtshowonhome") as TextBox;
                if (txtshowonhome.Text == "True")
                {
                    lnkshowonhome.ImageUrl = "../assets/ico_unblock.png";
                    lnkshowonhome.ToolTip = "Active";
                }
                else if (txtshowonhome.Text == "False")
                {
                    lnkshowonhome.ImageUrl = "../assets/ico_block.png";
                    lnkshowonhome.ToolTip = "Inactive";
                }

                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            }

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "redit")
            {
                Response.Redirect("service.aspx?id=" + Convert.ToInt32(e.CommandArgument));

            }
            if (e.CommandName == "lnkstatus")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtstatus = row.FindControl("txtstatus") as TextBox;
                if (txtstatus.Text == "False")
                {

                    Parameters.Clear();
                    Parameters.Add("@serviceid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update cservices set status=1 where serviceid=@serviceid", Parameters);
                }
                else if (txtstatus.Text == "True")
                {

                    Parameters.Clear();
                    Parameters.Add("@serviceid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update cservices set status=0 where serviceid=@serviceid", Parameters);
                }
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
                gridshow();
            }
            if (e.CommandName == "lnkshowonhome")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtshowonhome = row.FindControl("txtshowonhome") as TextBox;
                if (txtshowonhome.Text == "False")
                {

                    Parameters.Clear();
                    Parameters.Add("@serviceid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update cservices set showonhome=1 where serviceid=@serviceid", Parameters);
                }
                else if (txtshowonhome.Text == "True")
                {
                    Parameters.Clear();
                    Parameters.Add("@serviceid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update cservices set showonhome=0 where serviceid=@serviceid", Parameters);
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
        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            gridshow();
        }
    }
}