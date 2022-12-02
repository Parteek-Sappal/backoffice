using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Net.Mail;
using Microsoft.VisualBasic;

namespace backoffice.office.Products
{
    public partial class viewmapallproduct : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        public HttpCookie AUserSession = null;
        Hashtable Parameters = new Hashtable();
        string StrFileName;
        public int appno;
        protected void Page_Load(object sender, EventArgs e)
        {


            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (Page.IsPostBack == false)
            {
                Parameters.Clear();
                categoryname();
                subcategoryname();

                gridshow();

                if (Request.QueryString["edit"] == "edit")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record updated successfully.";
                }
            }
        }
        private void categoryname()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select category,pcatid from productcate where status = 1 order by displayorder", Parameters, pcatid);
            pcatid.Items[0].Text = "Search By Category";
        }

        private void subcategoryname()
        {
            // psubcatid.Items.Clear();
            Parameters.Clear();
            Parameters.Add("@pcatid", pcatid.SelectedValue);
            clsm.Fillcombo_Parameter("select category,psubcatid from productsubcate where status = 1 and pcatid=@pcatid order by displayorder", Parameters, psubcatid);
            //psubcatid.Items[0].Text = "Search By Sub Category";
        }
        protected void pcatid_SelectedIndexChanged(object sender, EventArgs e)
        {
            subcategoryname();
        }




        protected void psubcatid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gridshow()
        {
            string strsql = null;
            strsql = "select mp.pmapid,mp.status,mp.stock,mp.erpcode,p.productname,p.productcode,b.category as category,c.category as subcategory,cm.ColorTitle,tm.typetitle,om.orientationtitle,mp.price,mp.pmapid,mp.UploadAImage,sz.sizetitle,fm.featuretitle from Products p inner  join  productcate b on p.pcatid=b.pcatid inner join productsubcate c on p.psubcatid=c.psubcatid  inner join map_product mp on mp.productid=p.productid left join Color_master cm on mp.colorid=cm.colorid  left join type_master tm on mp.typeid=tm.typeid left join orientation_master om on mp.orientationid=om.orientationid left join Size_master sz on mp.sizeid=sz.sizeid left join feature_master fm on mp.featureid=fm.featureid  where 1=1  ";

            Parameters.Clear();
            if (Conversion.Val(pcatid.SelectedValue) > 0)
            {
                Parameters.Add("@pcatid", Conversion.Val(pcatid.SelectedValue));
                //strsql += " and p.pcatid=@pcatid";
                strsql += " and p.pcatid=" + Conversion.Val(pcatid.SelectedValue) + "";
            }

            if (Conversion.Val(psubcatid.SelectedValue) > 0)
            {
                Parameters.Add("@psubcatid", Conversion.Val(psubcatid.SelectedValue));
                //strsql += " and p.psubcatid =@psubcatid";
                strsql += " and p.psubcatid =" + Conversion.Val(psubcatid.SelectedValue) + "";
            }
            if (Conversion.Val(psubsubcatid.SelectedValue) > 0)
            {
                Parameters.Add("@psubsubcatid", Conversion.Val(psubsubcatid.SelectedValue));
                //strsql += " and p.psubsubcatid =@psubsubcatid";

                strsql += " and p.psubsubcatid =" + Conversion.Val(psubsubcatid.SelectedValue) + "";
            }
            if (!string.IsNullOrEmpty(productname.Text))
            {
                Parameters.Add("@productname", productname.Text);
                strsql += " and p.productname like '%'+@productname+'%'";
            }

            strsql += " order by  mp.pmapid";

            // Response.Write(strsql);
            clsm.GridviewData_Parameter(GridView1, strsql, Parameters);
            if (GridView1.Rows.Count == 0)
            {
                trnotice.Visible = true;
                lblnotice.Text = "Record(s) not found.";
                // btnexport.Visible = False
            }
            else
            {
                //btnexport.Visible = True
            }
            appno = GridView1.Rows.Count;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lnkstatus = e.Row.FindControl("lnkstatus") as ImageButton;

                TextBox txtstatus = e.Row.FindControl("txtstatus") as TextBox;



                Image imgDown = (Image)e.Row.FindControl("imgDown");
                Label lblsmallimg = (Label)e.Row.FindControl("lblsmallimg");

                if (txtstatus.Text == "True")
                {
                    lnkstatus.ImageUrl = "~/office/assets/ico_unblock.png";
                    lnkstatus.ToolTip = "Yes";
                }
                else if (txtstatus.Text == "False")
                {
                    lnkstatus.ImageUrl = "~/office/assets/ico_block.png";
                    lnkstatus.ToolTip = "No";
                }


                if (!string.IsNullOrEmpty(lblsmallimg.Text))
                {
                    imgDown.Visible = true;
                    imgDown.ImageUrl = "/uploads/mapproduct/" + lblsmallimg.Text;
                }







                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkstatus")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtstatus = row.FindControl("txtstatus") as TextBox;
                if (txtstatus.Text == "False")
                {
                    Parameters.Clear();
                    Parameters.Add("@pmapid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update map_product set status=1 where pmapid=@pmapid", Parameters);
                }
                else if (txtstatus.Text == "True")
                {
                    Parameters.Clear();
                    Parameters.Add("@pmapid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update map_product set status=0 where pmapid=@pmapid", Parameters);
                }
                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }







            if (e.CommandName == "btnedit")
            {
                Response.Redirect("mapallproduct.aspx?pmapid=" + Convert.ToInt32(e.CommandArgument) + "");
            }
            if (e.CommandName == "btndel")
            {
                Parameters.Clear();
                Parameters.Add("@pmapid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("delete from map_product where pmapid=@pmapid", Parameters);

                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Record deleted successfully.";
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

            }

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gridshow();
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {

            Parameters.Clear();
            string strsql = null;
            strsql = @"select p.productcode, p.productname as [ProductName],cm.ColorTitle as Finish ,om.orientationtitle as Varient,tm.typetitle as Type,mp.UploadAImage as Image,mp.price as Price,mp.stock as Stock,mp.erpcode as [ERPcode] from Products p inner  join  productcate b on p.pcatid=b.pcatid inner join productsubcate c on p.psubcatid=c.psubcatid inner join   productsubsubcate d on p.psubsubcatid=d.psubsubcatid  inner join map_product mp on mp.productid=p.productid inner join Color_master cm on cm.colorid=mp.colorid  inner join type_master tm on tm.typeid=mp.typeid inner join orientation_master om on om.orientationid=mp.orientationid  where 1=1 ";

            Parameters.Clear();
            if (Conversion.Val(pcatid.SelectedValue) > 0)
            {
                Parameters.Add("@pcatid", Conversion.Val(pcatid.SelectedValue));
                //strsql += " and p.pcatid=@pcatid";
                strsql += " and p.pcatid=" + Conversion.Val(pcatid.SelectedValue) + "";
            }
            if (!string.IsNullOrEmpty(productname.Text))
            {
                Parameters.Add("@productname", productname.Text);
                strsql += " and p.productname like '%'+@productname+'%'";
            }
            if (Conversion.Val(psubcatid.SelectedValue) > 0)
            {
                Parameters.Add("@psubcatid", Conversion.Val(psubcatid.SelectedValue));
                //strsql += " and p.psubcatid =@psubcatid";
                strsql += " and p.psubcatid =" + Conversion.Val(psubcatid.SelectedValue) + "";
            }
            if (Conversion.Val(psubsubcatid.SelectedValue) > 0)
            {
                Parameters.Add("@psubsubcatid", Conversion.Val(psubsubcatid.SelectedValue));
                //strsql += " and p.psubsubcatid =@psubsubcatid";

                strsql += " and p.psubsubcatid =" + Conversion.Val(psubsubcatid.SelectedValue) + "";
            }

            strsql += " order by  p.displayorder";
            DataSet ds = clsm.senddataset_Parameter(strsql, Parameters);
            //Dim ds As DataSet = clsm.sendDataset(strsql)

            Response.Clear();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=mapproduct.xls");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            DataSetToExcel.Convert(ds, Response);

            //DgExp.RenderControl(htmlWrite)
            Response.Write(stringWrite.ToString());
            Response.Buffer = true;
            Response.End();

        }
    }
}