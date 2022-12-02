using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Web.UI.HtmlControls;

namespace backoffice.office.gallery
{
    public partial class viewvedio : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trnotice.Visible = false;
            trsuccess.Visible = false;
            if (!Page.IsPostBack)
            {
                griddata();
                if (Convert.ToString(Request.QueryString["edit"]) == "edit")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Updated Successfully !!!";
                }
            }
        }
        protected void griddata()
        {
            Label1.Visible = false;
            string strq2 = null;
            strq2 = "select v.*,at.typename from vedio v  left join Albumtype at on v.albumid=at.typeid  where 1=1";
            Parameters.Clear();
            if (!string.IsNullOrEmpty(TextBox4.Text))
            {

                Parameters.Add("@vediotitle", TextBox4.Text);
                strq2 += " and vediotitle like '%'+@vediotitle+'%'";
            }
            if (!string.IsNullOrEmpty(TextBox5.Text))
            {

                Parameters.Add("@trdate", TextBox5.Text);
                strq2 += " and trdate >=@trdate";
            }
            if (!string.IsNullOrEmpty(TextBox6.Text))
            {

                Parameters.Add("@trdateone", TextBox6.Text);
                strq2 += " and trdate <=@trdateone";
            }
            strq2 += " order by displayorder";

            clsm.GridviewData_Parameter(GridView1, strq2, Parameters);
            if (GridView1.Rows.Count == 0)
            {
                trnotice.Visible = true;
                lblnotice.Text = "NO Record Found";

            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            griddata();

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
                Label1.Visible = true;
                Label1.Text = ex.Message.ToString();
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btndel")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblthumb = (Label)row.FindControl("lblthumb");
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\vedio\\" + lblthumb.Text);
                if (F1.Exists)
                {
                    F1.Delete();
                }

                Parameters.Clear();
                Parameters.Add("@vedioid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("delete from vedio where vedioid=@vedioid", Parameters);
                griddata();
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Deleted Successfully.";

            }
            if (e.CommandName == "lnkstatus")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
                if (txtstatus.Text == "False")
                {

                    Parameters.Clear();
                    Parameters.Add("@vedioid", e.CommandArgument.ToString());
                    clsm.ExecuteQry_Parameter("update vedio set status=1 where vedioid=@vedioid", Parameters);
                }
                else if (txtstatus.Text == "True")
                {

                    Parameters.Clear();
                    Parameters.Add("@vedioid", e.CommandArgument.ToString());
                    clsm.ExecuteQry_Parameter("update vedio set status=0 where vedioid=@vedioid", Parameters);
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
                    Parameters.Add("@vedioid", e.CommandArgument);
                    clsm.ExecuteQry_Parameter("update vedio set showhome=1 where vedioid=@vedioid", Parameters);

                }
                else if (lblshowonhome.Text == "True")
                {
                    Parameters.Clear();
                    Parameters.Add("@vedioid", e.CommandArgument);
                    clsm.ExecuteQry_Parameter("update vedio set showhome=0 where vedioid=@vedioid", Parameters);
                }
                griddata();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }


            if (e.CommandName == "btnedit")
            {
                Response.Redirect("addvedio.aspx?vid=" + e.CommandArgument);
            }

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
                TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");

                HtmlImage imgimage = (HtmlImage)e.Row.FindControl("imgimage");
                Label lblthumb = (Label)e.Row.FindControl("lblthumb");


                if (string.IsNullOrEmpty(lblthumb.Text))
                {
                    imgimage.Visible = false;
                }
                else
                {
                    imgimage.Src = "~/Uploads/vedio/" + lblthumb.Text;
                    imgimage.Visible = true;
                }

                if (txtstatus.Text == "True")
                {
                    lnkstatus.ImageUrl = "~/office/assets/ico_unblock.png";
                    lnkstatus.ToolTip = "Active";
                }
                else if (txtstatus.Text == "False")
                {
                    lnkstatus.ImageUrl = "~/office/assets/ico_block.png";
                    lnkstatus.ToolTip = "Inactive";
                }

                ImageButton lnkshowonhome = (ImageButton)e.Row.FindControl("lnkshowonhome");
                Label lblshowonhome = (Label)e.Row.FindControl("lblshowonhome");
                if (lnkshowonhome == null == false)
                {
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
                }

                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");

            }



        }
    }
}