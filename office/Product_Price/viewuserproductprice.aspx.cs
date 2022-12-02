using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;


namespace backoffice.office.Product_Price
{
    public partial class viewuserproductprice : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        Hashtable parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (!Page.IsPostBack)
            {
                parameters.Clear();
                clsm.Fillcombo_Parameter("Select username as name,userid from userregistration where status=1 order by username", parameters, userid);
                if (Request.QueryString["edit"] == "edit")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record(s) updated successfully.";
                }
                //ShowData();
            }
        }
        public void ShowData()
        {
            string strquery1 = "";
            parameters.Clear();
            //strquery1 = @"select distinct oh.*,u.username FROM order_history oh inner join userregistration u ON oh.userid = u.userid  where 1=1  and oh.enquirystatus='Pending'";
            strquery1 = @"select distinct oh.*,u.username as Name,p.Prodname FROM user_product_price oh inner join userregistration u ON oh.userid = u.userid inner join Product p on oh.Prodid=p.Prodid  where 1=1 ";
            if (Conversion.Val(userid.SelectedValue) != 0)
            {
                //parameters.Add("@userid", Conversion.Val(userid.SelectedValue));
                strquery1 += " and oh.userid =" + Conversion.Val(userid.SelectedValue) + "";
            }


            strquery1 += "order by oh.trdate desc";
            clsm.GridviewData_Parameter(GridView1, strquery1, parameters);
            // Session["qry"] = strquery1;
            if ((GridView1.Rows.Count > 0))
            {
                GridView1.Visible = true;
            }
            else
            {
                GridView1.Visible = false;
                trnotice.Visible = true;
                lblnotice.Text = "No Record(s) found to display";

            }
        }

        protected void btnsearch_Click(object sender, System.EventArgs e)
        {
            ShowData();
        }

        protected void userid_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ShowData();
        }

        protected void drporderno_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ShowData();
        }

        //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex;
        //    ShowData();
        //}

        //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    GridView1.EditIndex = e.NewEditIndex;
        //    ShowData();
        //}
        //protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    GridView1.EditIndex = -1;
        //    ShowData();
        //}
        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    Label lblProdid = GridView1.Rows[e.RowIndex].FindControl("lblProdid") as Label;
        //    Label lblquatity = GridView1.Rows[e.RowIndex].FindControl("lblquatity") as Label;
        //    TextBox txtid = GridView1.Rows[e.RowIndex].FindControl("txt_Name") as TextBox;
        //    TextBox txtuserid = GridView1.Rows[e.RowIndex].FindControl("txtuserid") as TextBox;
        //    TextBox txtprice = GridView1.Rows[e.RowIndex].FindControl("txtprice") as TextBox;
        //    //TextBox lblquatity = GridView1.Rows[e.RowIndex].FindControl("lblquatity") as TextBox;

        //    parameters.Clear();
        //    parameters.Add("@Prodid", lblProdid.Text);
        //    parameters.Add("@price", txtprice.Text);
        //    parameters.Add("@userid", txtuserid.Text);
        //    parameters.Add("@quantity", lblquatity.Text);
        //    clsm.ExecuteQry_Parameter("update user_product_price set price=@price where  Prodid=@Prodid and userid=@userid and quantity=@quantity", parameters);
        //    Response.Write(userid.Text);
        //    //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        //    GridView1.EditIndex = -1;
        //    //Call ShowData method for displaying updated data  
        //    ShowData();
        //}

        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                ShowData();
            }
            catch (Exception ex)
            {
                Label1.Visible = true;
                Label1.Text = ex.Message.ToString();
            }

        }

        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            Label1.Visible = false;
            //if ((e.CommandName == "lnkstatus"))
            //{
            //    GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            //    TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
            //    if ((txtstatus.Text == "False"))
            //    {
            //        parameters.Clear();
            //        parameters.Add("@Prodid", e.CommandArgument.ToString());
            //        clsm.ExecuteQry_Parameter("update Product set status=1 where Prodid=@Prodid", parameters);
            //    }
            //    else if ((txtstatus.Text == "True"))
            //    {
            //        parameters.Clear();
            //        parameters.Add("@Prodid", e.CommandArgument.ToString());
            //        clsm.ExecuteQry_Parameter("update Product set status=0 where Prodid=@Prodid", parameters);
            //    }

            //    ShowData();
            //    trsuccess.Visible = true;
            //    lblsuccess.Text = "Status changed successfully !!!";
            //}

            if ((e.CommandName == "btnedit"))
            {
                Response.Redirect("adduserproductprice.aspx?id=" + e.CommandArgument);
            }

            if ((e.CommandName == "btndel"))
            {
                GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));


                parameters.Clear();
                parameters.Add("@id", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("delete from user_product_price where id=@id", parameters);
                ShowData();
                trsuccess.Visible = true;
                lblsuccess.Text = "Record(s) deleted successfully.";
            }

        }

        protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                //ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
                //TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");
                //HtmlGenericControl divtext = (HtmlGenericControl)e.Row.FindControl("divtext");
                //if ((txtstatus.Text == "True"))
                //{
                //    lnkstatus.ImageUrl = "~/BackOffice/assets/ico_unblock.png";
                //    lnkstatus.ToolTip = "Active";
                //}
                //else if ((txtstatus.Text == "False"))
                //{
                //    lnkstatus.ImageUrl = "~/BackOffice/assets/ico_block.png";
                //    lnkstatus.ToolTip = "Inactive";
                //}

                //e.Row.Attributes.Add("onmouseover", ("this.style.backgroundColor=\'"
                //                + (Session["altColor"] + "\'")));
                //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#FFFFFF\'");
                //if (((double.Parse(Cat_id.SelectedValue) == 1)
                //            || (double.Parse(Cat_id.SelectedValue) == 2)))
                //{
                //    divtext.Visible = true;
                //}
                //else
                //{
                //    divtext.Visible = false;
                //}

            }

        }
    }
}