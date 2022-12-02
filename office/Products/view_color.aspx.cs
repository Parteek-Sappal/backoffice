using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace backoffice.office.Products
{
    public partial class view_color : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        Hashtable parameters = new Hashtable();
        public int appno;
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (!Page.IsPostBack)
            {

                gridshow();
                if (Request.QueryString["edit"] != null)
                {
                    if (Request.QueryString["edit"].ToString() == "edit")
                    {
                        trsuccess.Visible = true;
                        lblsuccess.Text = "Record updated successfully.";
                    }
                }
            }
        }
        private string Pad(Int32 numberOfSpaces)
        {
            string Spaces = "";
            for (int i = 0; i < numberOfSpaces; i++)
            {
                Spaces += "&nbsp;&nbsp;&raquo;&nbsp;";
            }
            return Server.HtmlDecode(Spaces);

        }

        public void gridshow()
        {
            string strsql = "";
            parameters.Clear();
            strsql = "select * from Color_master where 1=1";

            if (!string.IsNullOrEmpty(TextBox4.Text.Trim()))
            {
                parameters.Add("@ColorTitle", TextBox4.Text.Replace("'", ""));
                strsql += " and ColorTitle like '%'+@ColorTitle+'%'";
            }

            strsql = strsql + " order by ColorTitle";
            clsm.GridviewData_Parameter(GridView1, strsql, parameters);
            appno = GridView1.Rows.Count;

            if (GridView1.Rows.Count == 0)
            {
                trnotice.Visible = true;
                lblnotice.Text = "Record(s) not found.";
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

                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
                ImageButton lnkshowonhome = (ImageButton)e.Row.FindControl("lnkshowonhome");
                Label lblshowonhome = (Label)e.Row.FindControl("lblshowonhome");
                Image imgDown = (Image)e.Row.FindControl("imgDown");

                Label lblstatus = (Label)e.Row.FindControl("lblstatus");
                TextBox txtcolor = (TextBox)e.Row.FindControl("txtcolor");
                Label lblcolor = (Label)e.Row.FindControl("lblcolor");

                Label lblsmallimg = (Label)e.Row.FindControl("lblsmallimg");


                if (!string.IsNullOrEmpty(lblcolor.Text))
                {
                    txtcolor.Style.Add("background", "#" + lblcolor.Text);
                    txtcolor.Enabled = false;
                }
                else
                {
                    lblcolor.Visible = false;
                    txtcolor.Visible = false;

                }

                if (lblstatus.Text == "True")
                {
                    lnkstatus.ImageUrl = "~/office/assets/ico_unblock.png";
                    lnkstatus.ToolTip = "Yes";
                }
                else if (lblstatus.Text == "False")
                {
                    lnkstatus.ImageUrl = "~/office/assets/ico_block.png";
                    lnkstatus.ToolTip = "No";
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


                if (!string.IsNullOrEmpty(lblsmallimg.Text))

                {
                    imgDown.Visible = true;
                    imgDown.ImageUrl = "/uploads/smallimages/" + lblsmallimg.Text;
                }

                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Session["altColor"] + "'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");



                txtcolor.ReadOnly = true;

            }

        }

        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lbldown = (Label)row.FindControl("lbldown");

                Label lblsmallimg = (Label)row.FindControl("lblsmallimg");
                Label lbllargeimg = (Label)row.FindControl("lbllargeimg");

                FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + lblsmallimg.Text);
                if (F2.Exists)
                {
                    F2.Delete();
                }


                parameters.Clear();
                parameters.Add("@colorid", Convert.ToInt32((e.CommandArgument)));
                string strsql = "delete from Color_master where colorid=@colorid";
                clsm.ExecuteQry_Parameter(strsql, parameters);
                gridshow();
                trnotice.Visible = true;
                lblnotice.Text = "Record deleted successfully.";

            }
            if (e.CommandName == "status")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                Label lblstatus = (Label)row.FindControl("lblstatus");

                if (lblstatus.Text == "False")
                {
                    parameters.Clear();
                    parameters.Add("@colorid", Convert.ToInt32(e.CommandArgument));
                    string strsql = "update Color_master set status=1 where colorid=@colorid";
                    clsm.ExecuteQry_Parameter(strsql, parameters);

                }
                else if (lblstatus.Text == "True")
                {
                    parameters.Clear();
                    parameters.Add("@colorid", Convert.ToInt32(e.CommandArgument));
                    string strsql = "update Color_master set status=0 where colorid=@colorid";
                    clsm.ExecuteQry_Parameter(strsql, parameters);

                }
                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }
            if (e.CommandName == "lnkshowonhome")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblshowonhome = (Label)row.FindControl("lblshowonhome");

                if (lblshowonhome.Text == "False")
                {
                    parameters.Clear();
                    parameters.Add("@colorid", Convert.ToInt32(e.CommandArgument));
                    string strsql = "update Color_master set showonhome=1 where colorid=@colorid";
                    clsm.ExecuteQry_Parameter(strsql, parameters);

                }
                else if (lblshowonhome.Text == "True")
                {                
                    parameters.Clear();
                    parameters.Add("@colorid", Convert.ToInt32(e.CommandArgument));
                    string strsql = "update Color_master set showonhome=0 where colorid=@colorid";
                    clsm.ExecuteQry_Parameter(strsql, parameters);

                }
                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }

            if (e.CommandName == "edit")
            {
                Response.Redirect("color.aspx?colorid=" + Convert.ToInt32(e.CommandArgument));
            }

        }

        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            gridshow();
        }
        protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            //GridView1.DataBind();
            gridshow();
        }
    }
}