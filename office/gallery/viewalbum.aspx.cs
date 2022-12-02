using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;

namespace backoffice.office.gallery
{
    public partial class viewalbum : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        Hashtable Parameters = new Hashtable();
        public int appno;
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (!Page.IsPostBack)
            {
                Label1.Visible = false;
                Parameters.Clear();
                clsm.Fillcombo_Parameter(" select typename,typeid from Albumtype ", Parameters, ddlAlbum);
                ddlAlbum.Items[0].Text = "Select Album Type";
                bindata();
                if (Convert.ToString(Request.QueryString["edit"]) == "edit")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Updated Successfully.";
                }
            }
        }
        public void bindata()
        {

            Parameters.Clear();
            string strqry = "";
            strqry = "select a.*,at.typename from Album a left join Albumtype at on a.typeid=at.typeid  where 1=1  ";
            if (ddlAlbum.SelectedValue != "0")
            {
                Parameters.Add("@typeid", ddlAlbum.SelectedValue);
                strqry += " and a.typeid=@typeid ";
            }
            if (title.Text != "")
            {
                Parameters.Add("@Albumtitle", title.Text.Replace("'", ""));
                strqry += " and a.Albumtitle like '%'+@Albumtitle+'%'";
            }

            strqry += " order by a.displayorder ";

            clsm.GridviewData_Parameter(GridView1, strqry, Parameters);
            if (GridView1.Rows.Count == 0)
            {
                trnotice.Visible = true;
                lblnotice.Text = "NO Record Found";

            }


        }
        protected void btn_Click(object sender, EventArgs e)
        {
            bindata();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            Label1.Visible = false;
            if (e.CommandName == "lnkstatus")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
                if (txtstatus.Text == "False")
                {
                    Parameters.Clear();
                    Parameters.Add("@Albumid", e.CommandArgument.ToString());
                    clsm.ExecuteQry_Parameter("update Album set status=1 where Albumid=@Albumid", Parameters);
                }
                else if (txtstatus.Text == "True")
                {
                    Parameters.Clear();
                    Parameters.Add("@Albumid", e.CommandArgument.ToString());
                    clsm.ExecuteQry_Parameter("update Album set status=0 where Albumid=@Albumid", Parameters);
                }
                bindata();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status Changed Successfully !!!";

            }

            if (e.CommandName == "lnkstatus1")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtshowonmainsite = (TextBox)row.FindControl("txtshowonmainsite");

                if (txtshowonmainsite.Text == "False")
                {
                    Parameters.Clear();
                    Parameters.Add("@Albumid", e.CommandArgument.ToString());
                    clsm.ExecuteQry_Parameter("update Album set showonmainsite=1 where Albumid=@Albumid", Parameters);
                }
                else if (txtshowonmainsite.Text == "True")
                {
                    Parameters.Clear();
                    Parameters.Add("@Albumid", e.CommandArgument.ToString());
                    clsm.ExecuteQry_Parameter("update Album set showonmainsite=0 where Albumid=@Albumid", Parameters);
                }
                bindata();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status Changed Successfully !!!";
            }

            if (e.CommandName == "lnkstatus2")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtshowonmicrosite = (TextBox)row.FindControl("txtshowonmicrosite");

                if (txtshowonmicrosite.Text == "False")
                {
                    Parameters.Clear();
                    Parameters.Add("@Albumid", e.CommandArgument.ToString());
                    clsm.ExecuteQry_Parameter("update Album set showonmicrosite=1 where Albumid=@Albumid", Parameters);
                }
                else if (txtshowonmicrosite.Text == "True")
                {
                    Parameters.Clear();
                    Parameters.Add("@Albumid", e.CommandArgument.ToString());
                    clsm.ExecuteQry_Parameter("update Album set showonmicrosite=0 where Albumid=@Albumid", Parameters);
                }
                bindata();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status Changed Successfully !!!";
            }

            if (e.CommandName == "btnedit")
            {
                Response.Redirect("addalbum.aspx?alid=" + e.CommandArgument);
            }
            if (e.CommandName == "del")
            {
                Parameters.Clear();
                Parameters.Add("@Parentid", Convert.ToString(e.CommandArgument));
                if (clsm.Checking_Parameter("select * from album where Parentid=@Parentid", Parameters) == true)
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "Album not deleted use in another.";
                    bindata();
                    return;
                }
                Parameters.Clear();
                Parameters.Add("@albumid", Convert.ToString(e.CommandArgument));
                if (clsm.Checking_Parameter("select * from AlbumPhoto where albumid=@albumid", Parameters) == true)
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "Album not deleted use in photo gallery.";
                    bindata();
                    return;
                }

                Parameters.Clear();
                Parameters.Add("@Albumid", Convert.ToString(e.CommandArgument));
                clsm.ExecuteQry_Parameter("delete from Album where Albumid=@Albumid", Parameters);
                Parameters.Clear();
                Parameters.Add("@Albumid", Convert.ToString(e.CommandArgument));
                string str = Convert.ToString(clsm.SendValue_Parameter("select UploadAImage from Album where Albumid=@Albumid", Parameters));
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + str);
                if (F1.Exists)
                {
                    F1.Delete();
                }
                //**************

                Parameters.Clear();
                Parameters.Add("@Albumid", Convert.ToString(e.CommandArgument));
                clsm.ExecuteQry_Parameter("delete from Album where Albumid=@Albumid", Parameters);
                Parameters.Clear();
                Parameters.Add("@Albumid", Convert.ToString(e.CommandArgument));
                string strbann = Convert.ToString(clsm.SendValue_Parameter("select imagebanner from Album where Albumid=@Albumid", Parameters));
                FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + strbann);
                if (F2.Exists)
                {
                    F2.Delete();
                }

                //************
                bindata();
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Deleted Successfully.";
            }


        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");

                HtmlImage imgimage = (HtmlImage)e.Row.FindControl("imgimage");
                Label lblimage = (Label)e.Row.FindControl("lblimage");
                TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");
                TextBox txtshowonmainsite = (TextBox)e.Row.FindControl("txtshowonmainsite");
                ImageButton lnkstatus1 = (ImageButton)e.Row.FindControl("lnkstatus1");
                TextBox txtshowonmicrosite = (TextBox)e.Row.FindControl("txtshowonmicrosite");
                ImageButton lnkstatus2 = (ImageButton)e.Row.FindControl("lnkstatus2");
                Literal lbltype = (Literal)e.Row.FindControl("lbltype");
                HtmlGenericControl divanch = e.Row.FindControl("divanch") as HtmlGenericControl;
                HtmlGenericControl divevents = e.Row.FindControl("divevents") as HtmlGenericControl;

                if (lbltype.Text == "Photo")
                {
                    divanch.Visible = true;
                    divevents.Visible = true;
                }
                if (string.IsNullOrEmpty(lblimage.Text))
                {
                    imgimage.Visible = false;
                }
                else
                {
                    imgimage.Src = "../../Uploads/LargeImages/" + lblimage.Text;
                    imgimage.Visible = true;
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
                if (txtshowonmainsite.Text == "True")
                {
                    lnkstatus1.ImageUrl = "~/Office/assets/ico_unblock.png";
                    lnkstatus1.ToolTip = "Active";
                }
                else if (txtshowonmainsite.Text == "False")
                {
                    lnkstatus1.ImageUrl = "~/Office/assets/ico_block.png";
                    lnkstatus1.ToolTip = "Inactive";
                }


                if (txtshowonmicrosite.Text == "True")
                {
                    lnkstatus2.ImageUrl = "~/Office/assets/ico_unblock.png";
                    lnkstatus2.ToolTip = "Active";
                }
                else if (txtshowonmicrosite.Text == "False")
                {
                    lnkstatus2.ImageUrl = "~/Office/assets/ico_block.png";
                    lnkstatus2.ToolTip = "Inactive";
                }



                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");

            }

        }
    }
}