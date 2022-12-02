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

namespace backoffice.office.others
{
    public partial class subscriber : System.Web.UI.Page
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
                gridbind();
            }

        }
        protected void gridbind()
        {
            string strsql = "select subid,subemail,mobile,status,trdate from Subscribers where 1=1 ";
            if (!string.IsNullOrEmpty(txtemail.Text))
            {
                Parameters.Clear();
                Parameters.Add("@subemail", txtemail.Text);
                strsql += " and subemail like '%'+@subemail+'%'";
            }
            if (!string.IsNullOrEmpty(sdate.Text))
            {
                Parameters.Add("@trdate", sdate.Text);
                strsql += " and convert(varchar,trdate,101) > =Convert(datetime,@trdate,101)";
            }
            if (!string.IsNullOrEmpty(edate.Text))
            {
                DateTime dt = Convert.ToDateTime(edate.Text.Trim());
                dt = dt.AddDays(1);

                Parameters.Add("@trdateone", edate.Text);
                strsql += " and convert(varchar,trdate,101) <=Convert(datetime,@trdateone,101)";
            }
            strsql += " order by trdate desc";            
            clsm.GridviewData_Parameter(this.GridView1, strsql, Parameters);
            if (this.GridView1.Rows.Count == 0)
            {
                trnotice.Visible = true;
                btnExport.Visible = false;
                lblnotice.Text = "Record(s) not found.";
            }
            else
            {
                trnotice.Visible = false;
                btnExport.Visible = true;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gridbind();
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            string email = txtemail.Text;
            string strsql = "select subemail [Email],convert(varchar,trdate,107) [Subscriber Date] from Subscribers where status=1";
            Parameters.Clear();
            if (!string.IsNullOrEmpty(txtemail.Text))
            {
                Parameters.Clear();
                Parameters.Add("@subemail", txtemail.Text);
                strsql += " and subemail like '%'+@subemail+'%'";
            }
            if (!string.IsNullOrEmpty(sdate.Text))
            {
                Parameters.Add("@trdate", sdate.Text);
                strsql += " and convert(varchar,trdate,101) > =Convert(datetime,@trdate,101)";
            }
            if (!string.IsNullOrEmpty(edate.Text))
            {

                Parameters.Add("@trdateone", edate.Text);
                strsql += " and convert(varchar,trdate,101) <=Convert(datetime,@trdateone,101)";
            }

            strsql = strsql + " order by trdate desc";            
            DataSet ds = clsm.senddataset_Parameter(strsql, Parameters);
            Response.Clear();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=subscriber.xls");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            DataSetToExcel.Convert(ds, Response);
            Response.Write(stringWrite.ToString());
            Response.Buffer = true;
            Response.End();

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbldate = e.Row.FindControl("lbldate") as Label;
                lbldate.Text = Convert.ToDateTime(lbldate.Text).ToString("dd/MM/yyyy");
                if (lbldate.Text == "01/01/1900")
                {
                    lbldate.Text = "";
                }
                ImageButton lnkstatus = e.Row.FindControl("lnkstatus") as ImageButton;
                TextBox txtstatus = e.Row.FindControl("txtstatus") as TextBox;
                if (txtstatus.Text == "True")
                {
                    lnkstatus.ImageUrl = "~/Office/assets/ico_unblock.png";
                    lnkstatus.ToolTip = "Active";
                }
                else if (txtstatus.Text == "False")
                {
                    lnkstatus.ImageUrl = "~/Office/assets/ico_block.png";
                    lnkstatus.ToolTip = "Inactive";
                }
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            }

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkstatus")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtstatus = row.FindControl("txtstatus") as TextBox;
                if (txtstatus.Text == "False")
                {

                    Parameters.Clear();
                    Parameters.Add("@subid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update Subscribers set status=1 where subid=@subid", Parameters);
                }
                else if (txtstatus.Text == "True")
                {
                    Parameters.Clear();
                    Parameters.Add("@subid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update Subscribers set status=0 where subid=@subid", Parameters);
                }
                gridbind();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }

            if (e.CommandName == "btndel")
            {                
                Parameters.Clear();
                Parameters.Add("@subid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("delete from Subscribers where subid=@subid", Parameters);
                gridbind();
                trsuccess.Visible = true;
                lblsuccess.Text = "Record deleted successfully.";
            }


        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                gridbind();
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }
        }
    }
}