using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace backoffice.office.usermanagement
{
    public partial class adduser : System.Web.UI.Page
    {
        mainclass Clsm = new mainclass();
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Parameters.Clear();
                Clsm.Fillcombo_Parameter("select rolename,roleid from rolemaster where rolestatus=1 and  roleid<>1 order by rolename", Parameters, Roleid);
                gridshow();
            }
        }
        protected void gridshow()
        {
            Parameters.Clear();
            string Strqry = "select B.*, r.rolename from bousermaster b inner join rolemaster r on r.roleid=b.roleid where b.trid<>1 order by b.userid";
            Clsm.GridviewData_Parameter(GridView1, Strqry, Parameters);
            if (GridView1.Rows.Count == 0)
            {
                trnotice.Visible = true;
                lblnotice.Text = "Users not found.";
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Clsm.ClearallPanel(this, TrId.Parent);
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnedit")
            {
                Parameters.Clear();
                Clsm.MoveRecord_Parameter(this, TrId.Parent, "select * from bousermaster where trid=" + Conversion.Val(e.CommandArgument) + "", Parameters);
                Clsm.MoveRecord_Parameter(this, TrId.Parent, "select * from bousermaster where trid=" + Conversion.Val(e.CommandArgument) + "", Parameters);
            }
            if (e.CommandName == "lnkstatus")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string str = ((DataControlFieldCell)row.Cells[2]).Text;

                Parameters.Add("@trid", Conversion.Val(e.CommandArgument));
                if (str == "False")
                {
                    Clsm.ExecuteQry_Parameter("update bousermaster set status=1 where trid=@trid", Parameters);
                }
                else if (str == "False")
                {

                    Clsm.ExecuteQry_Parameter("update bousermaster set status=0 where trid=@trid", Parameters);
                }

                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
                gridshow();
            }



        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
                if (e.Row.Cells[4].Text == "True")
                {
                    lnkstatus.ImageUrl = "~/Office/assets/ico_unblock.png";
                    lnkstatus.ToolTip = "Active";
                }
                else
                {
                    lnkstatus.ImageUrl = "~/Office/assets/ico_block.png";
                    lnkstatus.ToolTip = "Inactive";

                }
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Session["altColor"] + "'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
                if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.Cells[4].Visible = false;
                }
            }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if(Page.IsValid == true)
                {
                    if (Convert.ToBoolean(Clsm.MasterSave(this, TrId.Parent, 11, mainclass.Mode.modeCheckDuplicate, "bousermasterSP", Session["UserId"].ToString())) == true)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Duplicacy not allowed.";
                        gridshow();
                    }
                    if(Conversion.Val(TrId.Text) == 0)
                    {
                        Status.Checked = true;
                        Name.Text = Roleid.SelectedItem.Text;
                        themeid.Text = "1";
                        Clsm.MasterSave(this, TrId.Parent, 11, mainclass.Mode.modeAdd, "bousermasterSP", Session["UserId"].ToString());
                        Clsm.ClearallPanel(this, TrId.Parent);
                        trsuccess.Visible = true;
                        lblsuccess.Text = "User added successfully.";
                    }
                    else
                    {
                        Clsm.MasterSave(this, TrId.Parent, 11, mainclass.Mode.modeModify, "bousermasterSP", Session["UserId"].ToString());

                        trsuccess.Visible = true;
                        lblsuccess.Text = "User updated successfully.";
                        Clsm.ClearallPanel(this, TrId.Parent);
                    }
                    gridshow();
                }
            }
            catch(Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }
        }
    }
}