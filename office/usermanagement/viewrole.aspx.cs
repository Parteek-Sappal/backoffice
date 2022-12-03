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
    public partial class viewrole : System.Web.UI.Page
    {
        mainclass Clsm = new mainclass();
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["edit"] == "edit")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Role updated successfully.";
                }
            }            
        }
        protected void gridshow()
        {
            Parameters.Clear();
            string Strqry = "select * from RoleMaster where roleid <> 1 order by rolename";
            Clsm.GridviewData_Parameter(GridView1, Strqry, Parameters);
            if (GridView1.Rows.Count == 0)
            {
                trnotice.Visible = true;
                lblnotice.Text = "Roles not found.";
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "btnedit")
            {
                Response.Redirect("addrole.aspx?roleid=" + Conversion.Val(e.CommandArgument) + "");
            }
            if (e.CommandName == "lnkstatus")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string str = ((DataControlFieldCell)row.Cells[2]).Text;

                Parameters.Add("@roleid", Conversion.Val(e.CommandArgument));
                if (str == "False")
                {
                    Clsm.ExecuteQry_Parameter("update RoleMaster set rolestatus=1 where roleid=@roleid", Parameters);
                }
                else if (str == "False")
                {

                    Clsm.ExecuteQry_Parameter("update RoleMaster set rolestatus=0 where roleid=@roleid", Parameters);
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
                if (e.Row.Cells[2].Text == "True")
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
                if(e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.Cells[2].Visible = false;
                }
            }
        }
    }
}