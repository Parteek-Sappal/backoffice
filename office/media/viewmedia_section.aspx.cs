using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace backoffice.office.media
{
    public partial class viewmedia_section : System.Web.UI.Page
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
                parameters.Clear();
                clsm.Fillcombo_Parameter(" select ntype,ntypeid from newstype where status=1   order by  displayorder", parameters, ntypeid);

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
        private DataTable GetData()
        {
            DataSet ds1 = new DataSet();
            DataTable tbl = new DataTable("data");
            ds1 = clsm.sendDataset("select * from project order by displayorder", false);
            tbl = ds1.Tables[0].Copy();
            ds1.Dispose();
            return tbl;
        }
        public void gridshow()
        {
            string strsql = "";
            parameters.Clear();
            strsql = "select a.*,b.ntype from Events a left join newstype b on a.ntypeid=b.ntypeid   where 1=1  ";

            if (TextBox4.Text != "")
            {
                parameters.Add("@EventsTitle", TextBox4.Text.Replace("'", ""));
                strsql += " and EventsTitle like '%'+@EventsTitle+'%'";
            }
            if (TextBox5.Text != "")
            {
                parameters.Add("@EventsDate", TextBox5.Text.Replace("'", ""));
                strsql += " and EventsDate >=@EventsDate";
            }
            if (TextBox6.Text != "")
            {
                DateTime dt = Convert.ToDateTime(TextBox6.Text);
                dt = dt.AddDays(0);
                strsql += " and EventsDate <='" + dt + "'";
            }
            if (ntypeid.SelectedIndex != 0)
            {

                parameters.Add("@ntypeid", Convert.ToInt32((ntypeid.SelectedValue)));
                strsql += " and a.ntypeid =@ntypeid";

            }
            strsql += " order by  EventsDate desc";            
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
                Label lbldown = (Label)e.Row.FindControl("lbldown");
                Label lblstatus = (Label)e.Row.FindControl("lblstatus");
                TextBox txtcolor = (TextBox)e.Row.FindControl("txtcolor");
                Label lblcolor = (Label)e.Row.FindControl("lblcolor");
                Panel pnl_gallery = (Panel)e.Row.FindControl("pnl_gallery");
                Literal lit_Eventsid = (Literal)e.Row.FindControl("lit_Eventsid");





                ImageButton lnkshowonschool = (ImageButton)e.Row.FindControl("lnkshowonschool");
                Label lblshowonschool = (Label)e.Row.FindControl("lblshowonschool");

                ImageButton lnkshowongroup = (ImageButton)e.Row.FindControl("lnkshowongroup");
                Label lblshowongroup = (Label)e.Row.FindControl("lblshowongroup");

                Panel pnl_faculty = (Panel)e.Row.FindControl("pnl_faculty");


               
                if (lit_Eventsid.Text == "7")
                {
                    pnl_faculty.Visible = true;

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



                if (lblshowonschool.Text == "True")
                {
                    lnkshowonschool.ImageUrl = "~/office/assets/ico_unblock.png";
                    lnkshowonschool.ToolTip = "Yes";
                }
                else if (lblshowonschool.Text == "False")
                {
                    lnkshowonschool.ImageUrl = "~/office/assets/ico_block.png";
                    lnkshowonschool.ToolTip = "No";
                }


                if (lblshowongroup.Text == "True")
                {
                    lnkshowongroup.ImageUrl = "~/office/assets/ico_unblock.png";
                    lnkshowongroup.ToolTip = "Yes";
                }
                else if (lblshowongroup.Text == "False")
                {
                    lnkshowongroup.ImageUrl = "~/office/assets/ico_block.png";
                    lnkshowongroup.ToolTip = "No";
                }


                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Session["altColor"] + "'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");

                if (lbldown.Text == string.Empty)
                {
                    imgDown.Visible = false;
                }
                else
                {
                    imgDown.Visible = true;
                }

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
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Files\\" + lbldown.Text);
                if (F1.Exists)
                {
                    F1.Delete();
                }
                FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + lblsmallimg.Text);
                if (F2.Exists)
                {
                    F2.Delete();
                }

                FileInfo F3 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + lbllargeimg.Text);
                if (F3.Exists)
                {
                    F3.Delete();
                }
                parameters.Clear();
                parameters.Add("@EventsId", Convert.ToInt32((e.CommandArgument)));
                string strsql = "delete from Events where EventsId=@EventsId";
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
                    parameters.Add("@EventsId", Convert.ToInt32(e.CommandArgument));
                    string strsql = "update Events set status=1 where Eventsid=@EventsId";
                    clsm.ExecuteQry_Parameter(strsql, parameters);

                }
                else if (lblstatus.Text == "True")
                {
                    parameters.Clear();
                    parameters.Add("@EventsId", Convert.ToInt32(e.CommandArgument));
                    string strsql = "update Events set status=0 where Eventsid=@EventsId";
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
                    parameters.Add("@EventsId", Convert.ToInt32(e.CommandArgument));
                    string strsql = "update Events set showonhome=1 where Eventsid=@EventsId";
                    clsm.ExecuteQry_Parameter(strsql, parameters);

                }
                else if (lblshowonhome.Text == "True")
                {                    
                    parameters.Clear();
                    parameters.Add("@EventsId", Convert.ToInt32(e.CommandArgument));
                    string strsql = "update Events set showonhome=0 where Eventsid=@EventsId";
                    clsm.ExecuteQry_Parameter(strsql, parameters);
                }
                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }


            if (e.CommandName == "lnkshowonschool")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                Label lblshowonschool = (Label)row.FindControl("lblshowonschool");

                if (lblshowonschool.Text == "False")
                {
                    parameters.Clear();
                    parameters.Add("@EventsId", Convert.ToInt32(e.CommandArgument));
                    string strsql = "update Events set showonschool=1 where Eventsid=@EventsId";
                    clsm.ExecuteQry_Parameter(strsql, parameters);

                }
                else if (lblshowonschool.Text == "True")
                {
                    parameters.Clear();
                    parameters.Add("@EventsId", Convert.ToInt32(e.CommandArgument));
                    string strsql = "update Events set showonschool=0 where Eventsid=@EventsId";
                    clsm.ExecuteQry_Parameter(strsql, parameters);

                }
                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }


            if (e.CommandName == "lnkshowongroup")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                Label lblshowongroup = (Label)row.FindControl("lblshowongroup");

                if (lblshowongroup.Text == "False")
                {
                    parameters.Clear();
                    parameters.Add("@EventsId", Convert.ToInt32(e.CommandArgument));
                    string strsql = "update Events set showongroup=1 where Eventsid=@EventsId";
                    clsm.ExecuteQry_Parameter(strsql, parameters);

                }
                else if (lblshowongroup.Text == "True")
                {
                    parameters.Clear();
                    parameters.Add("@EventsId", Convert.ToInt32(e.CommandArgument));
                    string strsql = "update Events set showongroup=0 where Eventsid=@EventsId";
                    clsm.ExecuteQry_Parameter(strsql, parameters);

                }
                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }



            if (e.CommandName == "downbtn")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lbldown = (Label)row.FindControl("lbldown");
                Response.Redirect("~/Office/DownloadFile.aspx?D=~/Uploads/Files/" + lbldown.Text);
            }
            if (e.CommandName == "edit")
            {
                Response.Redirect("media_section.aspx?nid=" + Convert.ToInt32(e.CommandArgument));
            }

        }

        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            gridshow();
        }
        protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;            
            gridshow();
        }
    }
}