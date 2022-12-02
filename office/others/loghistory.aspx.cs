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
    public partial class loghistory : System.Web.UI.Page
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
            string strsql = "select * from loghistory where 1=1 ";
            if (!string.IsNullOrEmpty(sdate.Text))
            {
                Parameters.Add("@trdate", sdate.Text);
                strsql += " and convert(varchar,addeditdate,101) > =Convert(datetime,@trdate,101)";
            }
            if (!string.IsNullOrEmpty(edate.Text))
            {
                DateTime dt = Convert.ToDateTime(edate.Text.Trim());
                dt = dt.AddDays(1);

                Parameters.Add("@trdateone", edate.Text);
                strsql += " and convert(varchar,addeditdate,101) <=Convert(datetime,@trdateone,101)";
            }
            strsql += " order by addeditdate desc";
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
            string strsql = "select ip, pagetitle [Page],pagetable[Module],addeditmode[Type],[userid], convert(varchar,addeditdate,107) [Date] from loghistory where ";
            Parameters.Clear();
            if (!string.IsNullOrEmpty(sdate.Text))
            {
                Parameters.Add("@trdate", sdate.Text);
                strsql += "  convert(varchar,addeditdate,101) > =Convert(datetime,@trdate,101)";
            }
            if (!string.IsNullOrEmpty(edate.Text))
            {

                Parameters.Add("@trdateone", edate.Text);
                strsql += " and convert(varchar,addeditdate,101) <=Convert(datetime,@trdateone,101)";
            }
            strsql = strsql + " order by addeditdate desc";
            DataSet ds = clsm.senddataset_Parameter(strsql, Parameters);
            Response.Clear();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=loghistory.xls");
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
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btndel")
            {
                Parameters.Clear();
                Parameters.Add("@historyid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("delete from loghistory where historyid=@historyid", Parameters);
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