using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Collections;
using System.Web.UI.HtmlControls;

namespace backoffice.office.masters
{
    public partial class courselevelseo : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        Hashtable parameters = new Hashtable();
        public int appno;
        string StrFileName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (!IsPostBack)
            {
                levelid.Text = Convert.ToInt32(Request.QueryString["levelid"]).ToString();

                parameters.Clear();
                clsm.Fillcombo_Parameter("select collagename,collageid from collage_master where status=1 order by displayorder ", parameters, collageid);

                Int32 p = 0;
                if (Int32.TryParse(Request.QueryString["id"], out p) == true)
                {

                    parameters.Clear();
                    parameters.Add("@id", Convert.ToInt32(Request.QueryString["id"]));
                    clsm.MoveRecord_Parameter(this, id.Parent, "Select * From CourseLevel_Master_Seo Where id=@id", parameters);


                }
                griddata();
                if (Request.QueryString["edit"] == "edit")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Updated Successfully.";
                }


            }

        }
        protected void griddata()
        {
            parameters.Clear();
            string strq2 = string.Empty;
            DataSet ds = new DataSet();
            strq2 = "select ms.*,cm.collagename from CourseLevel_Master_Seo ms inner join collage_master cm on ms.collageid=cm.collageid  where 1=1 and  cm.status=1 ";
            if (Conversion.Val(Request.QueryString["ntypeid"]) > 0)
            {
                parameters.Add("@levelid", Conversion.Val(Request.QueryString["levelid"]));
                strq2 += " and ms.levelid=@levelid";
            }
            ds = clsm.senddataset_Parameter(strq2, parameters);
            if (ds.Tables[0].Rows.Count == 0)
            {
                trnotice.Visible = true;
                lblnotice.Text = "No Data";
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
                parameters.Clear();
                parameters.Add("@id", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("delete from CourseLevel_Master_Seo where id=@id", parameters);
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
                    parameters.Clear();
                    parameters.Add("@id", e.CommandArgument.ToString());
                    clsm.ExecuteQry_Parameter("update CourseLevel_Master_Seo set status=1 where id=@id", parameters);
                }
                else if (txtstatus.Text == "True")
                {
                    parameters.Clear();
                    parameters.Add("@id", e.CommandArgument.ToString());
                    clsm.ExecuteQry_Parameter("update CourseLevel_Master_Seo set status=0 where id=@id", parameters);
                }
                griddata();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status Changed Successfully !!!";
            }
            if (e.CommandName == "btnedit")
            {
                Response.Redirect("courselevelseo.aspx?levelid=" + Request.QueryString["levelid"] + "&id=" + e.CommandArgument);
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");

                TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");

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
                //Label1.Visible = true;
                //Label1.Text = ex.Message.ToString();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {

                if (string.IsNullOrEmpty(id.Text))
                {
                    if (Convert.ToInt32(clsm.MasterSave(this, id.Parent, 11, mainclass.Mode.modeCheckDuplicate, "CourseLevel_Master_Seosp", Session["UserId"].ToString())) > 0)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Duplicacy not allowed.";
                        return;
                    }


                    string var = clsm.MasterSave(this, id.Parent, 11, mainclass.Mode.modeAdd, "CourseLevel_Master_Seosp", Convert.ToString(Session["UserId"]));


                    clsm.ClearallPanel(this, id.Parent);

                    levelid.Text = Convert.ToInt32(Request.QueryString["levelid"]).ToString();
                    griddata();
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Added Successfully.";
                }
                else
                {

                    string var = clsm.MasterSave(this, id.Parent, 11, mainclass.Mode.modeModify, "CourseLevel_Master_Seosp", Convert.ToString(Session["UserId"]));

                    Response.Redirect("courselevelseo.aspx?levelid=" + Request.QueryString["levelid"] + "&edit=edit");

                }
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }
        }
    }
}