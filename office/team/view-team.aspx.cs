using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;

namespace backoffice.office.team
{
    public partial class view_team : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (!Page.IsPostBack)
            {
                Parameters.Clear();
                clsm.Fillcombo_Parameter(" select ttype,ttypeid from teamtype where status=1 order by  displayorder", Parameters, typeid);


                griddata();
                if (Request.QueryString.HasKeys() == true)
                {
                    if (Request.QueryString["edit"].ToString() == "edit")
                    {
                        trsuccess.Visible = true;
                        lblsuccess.Text = "Record Updated Successfully.";
                    }
                }

            }
        }
        protected void griddata()
        {
            string strq2 = string.Empty;
            DataSet ds = new DataSet();
            Parameters.Clear();
            strq2 = "select t.*,tt.ttype from ourteam t  inner join teamtype tt on t.ttypeid=tt.ttypeid where 1=1  ";
            if (Conversion.Val(typeid.SelectedValue) != 0)
            {
                Parameters.Add("@type", Conversion.Val(typeid.SelectedValue));
                strq2 += " and t.ttypeid=@type ";
            }
            if (!string.IsNullOrEmpty(TextBox4.Text))
            {
                Parameters.Add("@name", TextBox4.Text);
                strq2 += " and t.name like '%'+@name+'%'";
            }

            if (!string.IsNullOrEmpty(txtdesignation.Text))
            {
                Parameters.Add("@Designation", txtdesignation.Text);
                strq2 += " and t.Designation like '%'+@Designation+'%'";
            }


            strq2 += "  order by t.displayorder";

            ds = clsm.senddataset_Parameter(strq2, Parameters);

            if (ds.Tables[0].Rows.Count == 0)
            {
                trnotice.Visible = true;
                lblnotice.Text = "No data found";
                GridView1.Visible = false;
            }
            else
            {
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                GridView1.Visible = true;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "del")
            {

                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblimagesmall = (Label)row.FindControl("lblimagesmall");
                Label lbllargeimage = (Label)row.FindControl("lbllargeimage");
                FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + lblimagesmall.Text);
                if (F2.Exists)
                {
                    F2.Delete();
                }

                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + lbllargeimage.Text);
                if (F1.Exists)
                {
                    F1.Delete();
                }
                Parameters.Clear();
                Parameters.Add("@teamid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("delete from ourteam where teamid=@teamid", Parameters);
                griddata();
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Deleted Successfully.";

            }


            if (e.CommandName == "status")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtstatus = (TextBox)row.FindControl("txtstatus");

                if (txtstatus.Text == "False")
                {
                    Parameters.Clear();
                    Parameters.Add("@teamid", e.CommandArgument.ToString());
                    clsm.ExecuteQry_Parameter("update ourteam set status=1 where teamid=@teamid", Parameters);
                }
                else if (txtstatus.Text == "True")
                {
                    Parameters.Clear();
                    Parameters.Add("@teamid", e.CommandArgument.ToString());
                    clsm.ExecuteQry_Parameter("update ourteam set status=0 where teamid=@teamid", Parameters);
                }
                griddata();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status Changed Successfully !!!";
            }

            if (e.CommandName == "lnkshowonhome")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblshowonhome = (Label)row.FindControl("lblshowonhome");

                if (lblshowonhome.Text == "False")
                {

                    Parameters.Clear();
                    Parameters.Add("@teamid", Convert.ToInt32(e.CommandArgument));
                    string strsql = "update ourteam set showonhome=1 where teamid=@teamid";
                    clsm.ExecuteQry_Parameter(strsql, Parameters);

                }
                else if (lblshowonhome.Text == "True")
                {

                    Parameters.Clear();
                    Parameters.Add("@teamid", Convert.ToInt32(e.CommandArgument));
                    string strsql = "update ourteam set showonhome=0 where teamid=@teamid";
                    clsm.ExecuteQry_Parameter(strsql, Parameters);
                }
                griddata();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }

            if (e.CommandName == "edit")
            {
                Response.Redirect("our-team.aspx?teamid=" + Convert.ToString(e.CommandArgument));

            }


        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lnkshowonhome = (ImageButton)e.Row.FindControl("lnkshowonhome");
                Label lblshowonhome = (Label)e.Row.FindControl("lblshowonhome");


                ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
                HtmlImage imgimage = (HtmlImage)e.Row.FindControl("imgimage");
                TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");

                HtmlImage imgsmall = (HtmlImage)e.Row.FindControl("imgsmall");
                Label lblimagesmall = (Label)e.Row.FindControl("lblimagesmall");
                if (string.IsNullOrEmpty(lblimagesmall.Text))
                {
                    imgsmall.Visible = false;
                }
                else
                {
                    imgsmall.Src = "~/Uploads/SmallImages/" + lblimagesmall.Text;
                    imgsmall.Visible = true;
                }
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


                if (lblshowonhome.Text == "True")
                {
                    lnkshowonhome.ImageUrl = "~/office/assets/ico_unblock.png";
                    lnkshowonhome.ToolTip = "Yes";
                }
                else if (lblshowonhome.Text == "False")
                {
                    lnkshowonhome.ImageUrl = "~/office/assets/ico_block.png";
                    lnkshowonhome.ToolTip = "No";
                }



                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            }


        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                griddata();
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            griddata();
        }
    }
}