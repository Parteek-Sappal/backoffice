using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualBasic;

namespace backoffice.office.team
{
    public partial class teamtype : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        public int appno;
        Hashtable Parameters = new Hashtable();

        protected void Page_Load(object sender, System.EventArgs e)
        {
            trerror.Visible = false;
            trnotice.Visible = false;
            trsuccess.Visible = false;
            if ((Page.IsPostBack == false))
            {
                if ((Conversion.Val(Request.QueryString["ttypeid"]) > 0))
                {
                    CKeditor1.ReadOnly = true;
                    Parameters.Clear();
                    Parameters.Add("@ttypeid", double.Parse(Request.QueryString["ttypeid"]));
                    clsm.MoveRecord_Parameter(this, ttypeid.Parent, "select * from teamtype where ttypeid=@ttypeid", Parameters);
                    CKeditor1.ReadOnly = false;
                    CKeditor1.Text = shortdesc.Text;
                }
                if (Convert.ToString(Request.QueryString["add"]) == "add")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Added Successfully.";
                }
                if (Convert.ToString(Request.QueryString["edit"]) == "edit")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record updated Successfully.";
                }
                gridshow();
            }
        }
        protected void btnsubmit_Click(object sender, System.EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {

                    shortdesc.Text = Server.HtmlEncode(CKeditor1.Text);
                    CKeditor1.ReadOnly = true;
                    if (Convert.ToInt32(clsm.MasterSave(this, ttypeid.Parent, 5, mainclass.Mode.modeCheckDuplicate, "teamtypeSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])))) > 0)
                    {
                        CKeditor1.ReadOnly = false;
                        trnotice.Visible = true;
                        lblnotice.Text = "This Team Type already exist.";
                        return;
                    }
                    if (Conversion.Val(ttypeid.Text) == 0)
                    {

                        Status.Checked = true;
                        CKeditor1.ReadOnly = true;
                        clsm.MasterSave(this, ttypeid.Parent, 5, mainclass.Mode.modeAdd, "teamtypeSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])));
                        CKeditor1.ReadOnly = false;
                        Response.Redirect("teamtype.aspx?add=add");                        
                        gridshow();
                        trsuccess.Visible = true;
                        lblsuccess.Text = "Record added successfully.";
                    }
                    else
                    {
                        CKeditor1.ReadOnly = true;
                        clsm.MasterSave(this, ttypeid.Parent, 5, mainclass.Mode.modeModify, "teamtypeSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])));
                        CKeditor1.ReadOnly = false;
                        Response.Redirect("teamtype.aspx?edit=edit");                        
                        gridshow();
                        trsuccess.Visible = true;
                        lblsuccess.Text = "Record updated successfully.";
                    }

                }
                catch (Exception ex)
                {
                    trerror.Visible = true;
                    lblerror.Text = ex.Message;
                }

            }
        }
        protected void gridshow()
        {
            try
            {
                Parameters.Clear();
                clsm.GridviewData_Parameter(GridView1, "select * from teamtype order by displayorder", Parameters);
                appno = GridView1.Rows.Count;
                if ((GridView1.Rows.Count == 0))
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "No Record found.";
                }

            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                Response.Redirect(("teamtype.aspx?ttypeid=" + e.CommandArgument));
            }

            if (e.CommandName == "status")
            {
                GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
                TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
                if (txtstatus.Text == "False")
                {
                    Parameters.Clear();
                    Parameters.Add("@ttypeid", Conversion.Val(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update teamtype set status=1 where ttypeid=@ttypeid", Parameters);
                }
                else if (txtstatus.Text == "True")
                {
                    Parameters.Clear();
                    Parameters.Add("@ttypeid", Conversion.Val(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update teamtype set status=0 where ttypeid=@ttypeid", Parameters);
                }

                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }

            if (e.CommandName == "del")
            {
                Parameters.Clear();
                Parameters.Add("@ttypeid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("delete from teamtype where ttypeid=@ttypeid", Parameters);
                gridshow();
                trnotice.Visible = true;
                lblnotice.Text = "Record deleted successfully.";
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
                TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");


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

        protected void btncancel_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("teamtype.aspx");
        }
    }
}