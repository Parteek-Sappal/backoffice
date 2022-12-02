using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;

namespace backoffice.office.team
{
    public partial class teamsubtype : System.Web.UI.Page
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
                if ((Conversion.Val(Request.QueryString["tsubtypeid"]) > 0))
                {
                    Parameters.Clear();
                    Parameters.Add("@tsubtypeid", Conversion.Val(Request.QueryString["tsubtypeid"]));
                    clsm.MoveRecord_Parameter(this, tsubtypeid.Parent, "select * from teamsubtype where tsubtypeid=@tsubtypeid", Parameters);
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

                    if (Convert.ToInt32(clsm.MasterSave(this, tsubtypeid.Parent, 4, mainclass.Mode.modeCheckDuplicate, "teamsubtypeSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])))) > 0)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "This Team Sub Type already exist.";
                        return;
                    }
                    if (Conversion.Val(tsubtypeid.Text) == 0)
                    {
                        Status.Checked = true;
                        clsm.MasterSave(this, tsubtypeid.Parent, 4, mainclass.Mode.modeAdd, "teamsubtypeSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])));
                        clsm.ClearallPanel(this, tsubtypeid.Parent);
                        gridshow();
                        trsuccess.Visible = true;
                        lblsuccess.Text = "Record added successfully.";
                    }
                    else
                    {
                        clsm.MasterSave(this, tsubtypeid.Parent, 4, mainclass.Mode.modeModify, "teamsubtypeSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])));
                        clsm.ClearallPanel(this, tsubtypeid.Parent);
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
                clsm.GridviewData_Parameter(GridView1, "select * from teamsubtype order by displayorder", Parameters);
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
                Response.Redirect(("teamsubtype.aspx?tsubtypeid=" + e.CommandArgument));
            }

            if (e.CommandName == "status")
            {
                GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
                TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
                if (txtstatus.Text == "False")
                {
                    Parameters.Clear();
                    Parameters.Add("@tsubtypeid", Conversion.Val(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update teamsubtype set status=1 where tsubtypeid=@tsubtypeid", Parameters);
                }
                else if (txtstatus.Text == "True")
                {
                    Parameters.Clear();
                    Parameters.Add("@tsubtypeid", Conversion.Val(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update teamsubtype set status=0 where tsubtypeid=@tsubtypeid", Parameters);
                }

                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }

            if (e.CommandName == "del")
            {
                Parameters.Clear();
                Parameters.Add("@tsubtypeid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("delete from teamsubtype where tsubtypeid=@tsubtypeid", Parameters);
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
            Response.Redirect("teamsubtype.aspx");
        }
    }
}