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

namespace backoffice.office.media
{
    public partial class mediaseo : System.Web.UI.Page
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
                ntypeid.Text = Convert.ToInt32(Request.QueryString["ntypeid"]).ToString();

                parameters.Clear();
                clsm.Fillcombo_Parameter("select collagename,collageid from collage_master where status=1 order by displayorder ", parameters, collageid);

                Int32 p = 0;
                if (Int32.TryParse(Request.QueryString["nid"], out p) == true)
                {

                    parameters.Clear();
                    parameters.Add("@nid", Convert.ToInt32(Request.QueryString["nid"]));
                    clsm.MoveRecord_Parameter(this, nid.Parent, "Select * From mediaseo Where nid=@nid", parameters);


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
            strq2 = "select ms.*,cm.collagename from mediaseo ms inner join collage_master cm on ms.collageid=cm.collageid  where 1=1 and  cm.status=1 ";
            if (Conversion.Val(Request.QueryString["ntypeid"]) > 0)
            {
                parameters.Add("@ntypeid", Conversion.Val(Request.QueryString["ntypeid"]));
                strq2 += " and ms.ntypeid=@ntypeid";
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
                parameters.Add("@nid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("delete from mediaseo where nid=@nid", parameters);
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
                    parameters.Add("@nid", e.CommandArgument.ToString());
                    clsm.ExecuteQry_Parameter("update mediaseo set status=1 where nid=@nid", parameters);
                }
                else if (txtstatus.Text == "True")
                {
                    parameters.Clear();
                    parameters.Add("@nid", e.CommandArgument.ToString());
                    clsm.ExecuteQry_Parameter("update mediaseo set status=0 where nid=@nid", parameters);
                }
                griddata();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status Changed Successfully !!!";
            }
            if (e.CommandName == "btnedit")
            {
                Response.Redirect("mediaseo.aspx?ntypeid=" + Request.QueryString["ntypeid"] + "&nid=" + e.CommandArgument);
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
               
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {

                if (string.IsNullOrEmpty(nid.Text))
                {
                    if (Convert.ToInt32(clsm.MasterSave(this, nid.Parent, 11, mainclass.Mode.modeCheckDuplicate, "mediaseosp", Session["UserId"].ToString())) > 0)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Duplicacy not allowed.";
                        return;
                    }


                    string var = clsm.MasterSave(this, nid.Parent, 11, mainclass.Mode.modeAdd, "mediaseosp", Convert.ToString(Session["UserId"]));


                    clsm.ClearallPanel(this, nid.Parent);

                    ntypeid.Text = Convert.ToInt32(Request.QueryString["ntypeid"]).ToString();
                    griddata();
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Added Successfully.";
                }
                else
                {

                    string var = clsm.MasterSave(this, nid.Parent, 11, mainclass.Mode.modeModify, "mediaseosp", Convert.ToString(Session["UserId"]));

                    Response.Redirect("mediaseo.aspx?ntypeid=" + Request.QueryString["ntypeid"] + "&edit=edit");

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