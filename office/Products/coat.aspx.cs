using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace backoffice.office.Products
{
    public partial class coat : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        string StrFileName;
        Hashtable parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trnotice.Visible = false;
            trsuccess.Visible = false;
            if (Page.IsPostBack == false)
            {
                gridshow();

                if (Request.QueryString["edit"] != "")
                {                    
                    lblsuccess.Text = "Record Updated Successfully";
                }
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            if ((Page.IsValid == true))
            {
                try
                {
                    if (Convert.ToInt32(clsm.MasterSave(this, coatid.Parent, 11, mainclass.Mode.modeCheckDuplicate, "coat_masterSP", Session["Name"].ToString()).ToString()) > 0)
                    {
                        Label1.Visible = true;
                        Label1.Text = "This Record Already Exist";
                        return;
                    }

                    if ((coatid.Text != ""))
                    {

                        object var = clsm.MasterSave(this, coatid.Parent, 11, mainclass.Mode.modeModify, "coat_masterSP", Session["Name"].ToString());

                        clsm.ClearallPanel(this, coatid.Parent);
                        trsuccess.Visible = true;
                        lblsuccess.Text = "Record Updated Successfully.";
                    }
                    else
                    {

                        object var = clsm.MasterSave(this, coatid.Parent, 11, mainclass.Mode.modeAdd, "coat_masterSP", Session["Name"].ToString());

                        clsm.ClearallPanel(this, coatid.Parent);
                        trsuccess.Visible = true;
                        lblsuccess.Text = "Record Added Successfully.";
                    }

                    gridshow();
                }
                catch (Exception eer)
                {
                    Label1.Visible = true;
                    Label1.Text = eer.Message;
                }
            }
        }

        protected void gridshow()
        {
            string strq2;
            parameters.Clear();
            strq2 = "SELECT * FROM tblcoat order by displayorder";
            clsm.GridviewData_Parameter(GridView1, strq2, parameters);
            if ((GridView1.Rows.Count == 0))
            {
                trnotice.Visible = true;
                lblnotice.Text = "No Record(s) Available";
                GridView1.Visible = false;
            }
            else
            {
                GridView1.Visible = true;
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
                Label1.Visible = true;
                Label1.Text = ex.Message.ToString();
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ((e.CommandName == "btndel"))
            {
                GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));


                TextBox coatid = (TextBox)row.FindControl("coatid");
              
                parameters.Clear();
                parameters.Add("@coatid", double.Parse(e.CommandArgument.ToString()));
                clsm.ExecuteQry_Parameter("delete from tblcoat where coatid=@coatid", parameters);
                //}

                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Deleted Successfully.";
            }

            if ((e.CommandName == "lnkstatus"))
            {
                GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
                TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
                if ((txtstatus.Text == "False"))
                {
                    parameters.Clear();
                    parameters.Add("@coatid", double.Parse(e.CommandArgument.ToString()));
                    string strsql = "update tblcoat set status=1 where coatid=@coatid";
                    clsm.ExecuteQry_Parameter(strsql, parameters);
                }
                else if ((txtstatus.Text == "True"))
                {
                    Hashtable parameters = new Hashtable();
                    parameters.Add("@coatid", double.Parse(e.CommandArgument.ToString()));
                    string strsql = "update tblcoat set status=0 where coatid=@coatid";
                    clsm.ExecuteQry_Parameter(strsql, parameters);
                }

                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status Changed Successfully !!!";
            }

            if ((e.CommandName == "btnedit"))
            {                
                clsm.MoveRecord(this, coatid.Parent, ("Select * from tblcoat where coatid = "
                                + (e.CommandArgument) + ""));
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
                TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");



                if ((txtstatus.Text == "True"))
                {
                    lnkstatus.ImageUrl = "~/Office/assets/ico_unblock.png";
                    lnkstatus.ToolTip = "Active";
                }
                else if ((txtstatus.Text == "False"))
                {
                    lnkstatus.ImageUrl = "~/Office/assets/ico_block.png";
                    lnkstatus.ToolTip = "Inactive";
                }

                e.Row.Attributes.Add("onmouseover", ("this.style.backgroundColor=\'"
                                + (Session["altColor"] + "\'")));
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#FFFFFF\'");
            }

        }


        protected void Button2_Click(object sender, System.EventArgs e)
        {
            clsm.ClearallPanel(this, Label1.Parent);
        }
    }
}