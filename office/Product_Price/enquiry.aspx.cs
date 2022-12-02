using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Web.UI.HtmlControls;

namespace backoffice.office.Product_Price
{
    public partial class enquiry : System.Web.UI.Page
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
                clsm.Fillcombo_Parameter("Select username as name,userid from userregistration where status=1 order by username", parameters, drpuserid);

                parameters.Clear();
                clsm.Fillcombo_Parameter("Select orderno,convert(varchar(50) ,orderno)as orderno from order_history order by trdate desc ", parameters, drporderno);

                FillData();
                if (Request.QueryString["edit"] == "edit")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record(s) updated successfully.";
                }
            }
        }
        void FillData()
        {
            string strquery1 = "";
            parameters.Clear();            
            strquery1 = @"select distinct oh.*,u.username FROM order_history oh inner join userregistration u ON oh.userid = u.userid  where 1=1 ";
            if (double.Parse(drpuserid.SelectedValue) != 0)
            {
                strquery1 = (strquery1 + "and oh.userid ='" + (drpuserid.SelectedValue + "'"));
            }
            if (drporderno.SelectedIndex > 0)
            {
                strquery1 = (strquery1 + " and oh.orderno ='" + (drporderno.SelectedValue + "'"));
            }
            if ((sdate.Text != ""))
            {
                strquery1 = strquery1 + " and oh.trdate >='" + (sdate.Text + "'");
            }

            if ((edate.Text != ""))
            {
                DateTime dt = Convert.ToDateTime(edate.Text);
                dt = dt.AddDays(1);
                strquery1 = strquery1 + " and oh.trdate <='" + (dt + "'");
            }

            strquery1 += "order by oh.trdate desc";
            clsm.GridviewData_Parameter(GridView1, strquery1, parameters);
            Session["qry"] = strquery1;
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
            appno = GridView1.Rows.Count;
        }
        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                FillData();
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }
        }
        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            //Label1.Visible = false;
            //if ((e.CommandName == "lnkstatus"))
            //{
            //   GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
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

            //    FillData();
            //    trsuccess.Visible = true;
            //    lblsuccess.Text = "Status changed successfully !!!";
            //}

            //if ((e.CommandName == "btnedit"))
            //{
            //    Response.Redirect(("product.aspx?pid="
            //                    + (e.CommandArgument) + ""), false);
            //}

            if ((e.CommandName == "btndel"))
            {
                GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
                parameters.Clear();
                parameters.Add("@orderno", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("delete from order_history where orderno=@orderno", parameters);


                parameters.Clear();
                parameters.Add("@orderno", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("delete from order_details where orderno=@orderno", parameters);


                FillData();
                trsuccess.Visible = true;
                lblsuccess.Text = "Record(s) deleted successfully.";
            }

        }

        protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            //if ((e.Row.RowType == DataControlRowType.DataRow))
            //{
            //    ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
            //    TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");
            //    HtmlGenericControl divtext = (HtmlGenericControl)e.Row.FindControl("divtext");
            //    if ((txtstatus.Text == "True"))
            //    {
            //        lnkstatus.ImageUrl = "~/BackOffice/assets/ico_unblock.png";
            //        lnkstatus.ToolTip = "Active";
            //    }
            //    else if ((txtstatus.Text == "False"))
            //    {
            //        lnkstatus.ImageUrl = "~/BackOffice/assets/ico_block.png";
            //        lnkstatus.ToolTip = "Inactive";
            //    }

            //    e.Row.Attributes.Add("onmouseover", ("this.style.backgroundColor=\'"
            //                    + (Session["altColor"] + "\'")));
            //    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#FFFFFF\'");
            //    if (((double.Parse(Cat_id.SelectedValue) == 1)
            //                || (double.Parse(Cat_id.SelectedValue) == 2)))
            //    {
            //        divtext.Visible = true;
            //    }
            //    else
            //    {
            //        divtext.Visible = false;
            //    }

            //}

        }

        protected void btnsearch_Click(object sender, System.EventArgs e)
        {
            FillData();
        }

        protected void drpuserid_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            FillData();
        }

        protected void drporderno_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            FillData();
        }
    }
}