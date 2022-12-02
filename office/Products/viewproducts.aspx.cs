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
    public partial class viewproducts : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        public HttpCookie AUserSession = null;
        Hashtable Parameters = new Hashtable();
        string StrFileName;
        public int appno;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Int32 p = 0;
            //  if (Int32.TryParse(Request.QueryString["cid"], out p) == true)

            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (Page.IsPostBack == false)
            {
                Parameters.Clear();
                categoryname();
                BindLook();
                BindCoat();
                BindModel();
                Bindcolor();
                BindSize();
                BindType();
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
            clsm.Fillcombo_Parameter("select category,seriesid from productcate where status = 1 order by displayorder", Parameters, seriesid);
            seriesid.Items[0].Text = "Search By Series";
        }
        protected void BindLook()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select featuretitle,lookid from feature_master where status=1 order by displayorder", Parameters, lookid);
        }
        protected void BindCoat()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select titlename,coatid from tblcoat where status=1 order by displayorder", Parameters, coatid);
        }
        protected void BindModel()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select orientationtitle,modelid from orientation_master where status=1 order by displayorder", Parameters, modelid);
        }

        protected void Bindcolor()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select colortitle,colorid from Color_master where status=1 order by displayorder", Parameters, colorid);
        }
        protected void BindSize()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select sizetitle,sizeid from size_master where status=1 order by displayorder", Parameters, sizeid);
        }
        protected void BindType()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select typetitle,typeid from type_master where status=1 order by displayorder", Parameters, typeid);
        }

        //private void subcategoryname()
        //{
        //   // psubcatid.Items.Clear();
        //    Parameters.Clear();
        //    Parameters.Add("@pcatid", pcatid.SelectedValue);
        //    clsm.Fillcombo_Parameter("select category,psubcatid from productsubcate where status = 1 and pcatid=@pcatid order by displayorder", Parameters, psubcatid);
        //    //psubcatid.Items[0].Text = "Search By Sub Category";
        //}


        //private void subsubcategoryname()
        //{
        //    Parameters.Clear();
        //    Parameters.Add("@pcatid", pcatid.SelectedValue);
        //    Parameters.Add("@psubcatid", psubcatid.SelectedValue);
        //    clsm.Fillcombo_Parameter("select category,psubsubcatid from productsubsubcate where status = 1 and pcatid=@pcatid and psubcatid=@psubcatid  order by displayorder", Parameters, psubsubcatid);
        //  // psubsubcatid.Items[0].Text = "Search By Sub Sub Category";
        //}

        //protected void psubcatid_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    subsubcategoryname();
        //}

        protected void gridshow()
        {
            string strsql = null;
            strsql = "select p.*,t.typetitle,c.colortitle,m.orientationtitle as modelname,l.featuretitle as lookname,size.sizetitle as sizename,coat.titlename as coatname from Products p left  join  Color_master c on p.colorid=c.colorid left join type_master t on t.typeid=p.typeid left join orientation_master m on m.modelid=p.modelid left join feature_master l on l.lookid=p.lookid left join Size_master size on size.sizeid=p.sizeid left join tblcoat coat on coat.coatid=p.coatid   where 1=1 ";

            Parameters.Clear();
            if (Conversion.Val(seriesid.SelectedValue) > 0)
            {
                Parameters.Add("@seriesid", Conversion.Val(seriesid.SelectedValue));
                //strsql += " and p.pcatid=@pcatid";
                strsql += " and p.seriesid=" + Conversion.Val(seriesid.SelectedValue) + "";
            }
            if (Conversion.Val(modelid.SelectedValue) > 0)
            {
                Parameters.Add("@modelid", Conversion.Val(modelid.SelectedValue));
                strsql += " and m.modelid=" + Conversion.Val(modelid.SelectedValue) + "";
            }
            if (Conversion.Val(colorid.SelectedValue) > 0)
            {
                Parameters.Add("@colorid", Conversion.Val(colorid.SelectedValue));
                strsql += " and c.colorid=" + Conversion.Val(colorid.SelectedValue) + "";
            }
            if (Conversion.Val(lookid.SelectedValue) > 0)
            {
                Parameters.Add("@lookid", Conversion.Val(lookid.SelectedValue));
                strsql += " and l.lookid=" + Conversion.Val(lookid.SelectedValue) + "";
            }
            if (Conversion.Val(coatid.SelectedValue) > 0)
            {
                Parameters.Add("@coatid", Conversion.Val(coatid.SelectedValue));
                strsql += " and coat.coatid=" + Conversion.Val(coatid.SelectedValue) + "";
            }
            if (Conversion.Val(sizeid.SelectedValue) > 0)
            {
                Parameters.Add("@sizeid", Conversion.Val(sizeid.SelectedValue));
                strsql += " and size.sizeid=" + Conversion.Val(sizeid.SelectedValue) + "";
            }
            if (Conversion.Val(typeid.SelectedValue) > 0)
            {
                Parameters.Add("@typeid", Conversion.Val(typeid.SelectedValue));
                strsql += " and t.typeid=" + Conversion.Val(typeid.SelectedValue) + "";
            }
            if (!string.IsNullOrEmpty(productname.Text))
            {
                Parameters.Add("@productname", productname.Text);
                strsql += " and p.productname like '%'+@productname+'%'";
            }
            if (!string.IsNullOrEmpty(productcode.Text))
            {
                Parameters.Add("@productcode", productcode.Text);
                strsql += " and p.productcode =@productcode";
            }

            //if (Conversion.Val(psubcatid.SelectedValue) > 0)
            //{
            //    Parameters.Add("@psubcatid", Conversion.Val(psubcatid.SelectedValue));
            //               strsql += " and p.psubcatid =" + Conversion.Val(psubcatid.SelectedValue)  + "";
            //}
            //if (Conversion.Val(psubsubcatid.SelectedValue) > 0)
            //{
            //    Parameters.Add("@psubsubcatid", Conversion.Val(psubsubcatid.SelectedValue));

            //    strsql += " and p.psubsubcatid =" + Conversion.Val(psubsubcatid.SelectedValue)  + "";
            //}
            //if (Conversion.Val(ddlmobile.SelectedValue)==1)
            //{
            //    Parameters.Add("@mobileshow", Conversion.Val(1));

            //    strsql += " and p.mobileshow =@mobileshow  ";
            //}
            //if (Conversion.Val(ddlmobile.SelectedValue)==2)
            //{
            //    Parameters.Add("@websiteshow", Conversion.Val(1));

            //    strsql += " and p.websiteshow =@websiteshow ";
            //}

            strsql += " order by  p.displayorder";

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
                Label lbldown = e.Row.FindControl("lbldown") as Label;
                LinkButton downbtn = e.Row.FindControl("downbtn") as LinkButton;
                TextBox txtstatus = e.Row.FindControl("txtstatus") as TextBox;


                ImageButton lnkIsfamilyproduct = e.Row.FindControl("lnkIsfamilyproduct") as ImageButton;
                TextBox txtIsfamilyproduct = e.Row.FindControl("txtIsfamilyproduct") as TextBox;

                ImageButton lnkmobileshow = e.Row.FindControl("lnkmobileshow") as ImageButton;
                TextBox txtmobileshow = e.Row.FindControl("txtmobileshow") as TextBox;


                ImageButton lnkwebsiteshow = e.Row.FindControl("lnkwebsiteshow") as ImageButton;
                TextBox txtwebsiteshow = e.Row.FindControl("txtwebsiteshow") as TextBox;



                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + lbldown.Text);
                if (F1.Exists)
                {
                    if (!string.IsNullOrEmpty(lbldown.Text))
                    {
                        downbtn.Visible = true;
                    }
                }
                else
                {
                    downbtn.Visible = false;
                    if (string.IsNullOrEmpty(lbldown.Text))
                    {
                        downbtn.Visible = false;
                    }
                }


                if (lnkstatus == null == false)
                {
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
                }


                //if (e.Row.RowType == DataControlRowType.DataRow | e.Row.RowType == DataControlRowType.Header)
                //{
                //    e.Row.Cells[7].Visible = false;
                //}

                if (lnkIsfamilyproduct == null == false)
                {
                    if (txtIsfamilyproduct.Text == "True")
                    {
                        lnkIsfamilyproduct.ImageUrl = "~/office/assets/ico_unblock.png";
                        lnkIsfamilyproduct.ToolTip = "Yes";
                    }
                    else if (txtIsfamilyproduct.Text == "False")
                    {
                        lnkIsfamilyproduct.ImageUrl = "~/office/assets/ico_block.png";
                        lnkIsfamilyproduct.ToolTip = "No";
                    }
                }

                if (lnkmobileshow == null == false)
                {
                    if (txtmobileshow.Text == "True")
                    {
                        lnkmobileshow.ImageUrl = "~/office/assets/ico_unblock.png";
                        lnkmobileshow.ToolTip = "Yes";
                    }
                    else if (txtmobileshow.Text == "False")
                    {
                        lnkmobileshow.ImageUrl = "~/office/assets/ico_block.png";
                        lnkmobileshow.ToolTip = "No";
                    }
                }

                if (lnkwebsiteshow == null == false)
                {
                    if (txtwebsiteshow.Text == "True")
                    {
                        lnkwebsiteshow.ImageUrl = "~/office/assets/ico_unblock.png";
                        lnkwebsiteshow.ToolTip = "Yes";
                    }
                    else if (txtwebsiteshow.Text == "False")
                    {
                        lnkwebsiteshow.ImageUrl = "~/office/assets/ico_block.png";
                        lnkwebsiteshow.ToolTip = "No";
                    }
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
                    Parameters.Add("@productid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update Products set status=1 where productid=@productid", Parameters);
                }
                else if (txtstatus.Text == "True")
                {
                    Parameters.Clear();
                    Parameters.Add("@productid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update Products set status=0 where productid=@productid", Parameters);
                }
                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }

            if (e.CommandName == "lnkIsfamilyproduct")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtIsfamilyproduct = row.FindControl("txtIsfamilyproduct") as TextBox;
                if (txtIsfamilyproduct.Text == "False")
                {
                    Parameters.Clear();
                    Parameters.Add("@productid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update Products set featureproduct=1 where productid=@productid", Parameters);
                }
                else if (txtIsfamilyproduct.Text == "True")
                {
                    Parameters.Clear();
                    Parameters.Add("@productid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update Products set featureproduct=0 where productid=@productid", Parameters);
                }
                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }

            if (e.CommandName == "lnkmobileshow")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtmobileshow = row.FindControl("txtmobileshow") as TextBox;
                if (txtmobileshow.Text == "False")
                {
                    Parameters.Clear();
                    Parameters.Add("@productid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update Products set mobileshow=1 where productid=@productid", Parameters);
                }
                else if (txtmobileshow.Text == "True")
                {
                    Parameters.Clear();
                    Parameters.Add("@productid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update Products set mobileshow=0 where productid=@productid", Parameters);
                }
                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }

            if (e.CommandName == "lnkwebsiteshow")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtwebsiteshow = row.FindControl("txtwebsiteshow") as TextBox;
                if (txtwebsiteshow.Text == "False")
                {
                    Parameters.Clear();
                    Parameters.Add("@productid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update Products set websiteshow=1 where productid=@productid", Parameters);
                }
                else if (txtwebsiteshow.Text == "True")
                {
                    Parameters.Clear();
                    Parameters.Add("@productid", Convert.ToInt32(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update Products set websiteshow=0 where productid=@productid", Parameters);
                }
                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }





            if (e.CommandName == "btnedit")
            {
                Response.Redirect("products.aspx?pid=" + Convert.ToInt32(e.CommandArgument) + "");
            }
            if (e.CommandName == "btndel")
            {
                Parameters.Clear();
                Parameters.Add("@productid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("delete from Products where productid=@productid", Parameters);
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lbldown = row.FindControl("lbldown") as Label;
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + lbldown.Text);
                if (F1.Exists)
                {
                    F1.Delete();
                }
                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Record deleted successfully.";
            }
            if (e.CommandName == "downbtn")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lbldown = row.FindControl("lbldown") as Label;
                Response.Redirect("~/Office/DownloadFile.aspx?D=~/Uploads/prospectus/" + lbldown.Text);
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
            strsql = @"select p.productid as [ID], p.productname as [Product Name],p.productcode as [Prodcuct Code],p.mainprice as [Main Price],p.youtubeurl as YoutubeUrl, '' as PDFFile from Products p left  join  productcate b on p.seriesid=b.seriesid   where 1=1 ";

            Parameters.Clear();
            if (Conversion.Val(seriesid.SelectedValue) > 0)
            {
                Parameters.Add("@seriesid", Conversion.Val(seriesid.SelectedValue));
                //strsql += " and p.pcatid=@pcatid";
                strsql += " and p.seriesid=" + Conversion.Val(seriesid.SelectedValue) + "";
            }
            if (!string.IsNullOrEmpty(productname.Text))
            {
                Parameters.Add("@productname", productname.Text);
                strsql += " and p.productname like '%'+@productname+'%'";
            }
          
            if (Conversion.Val(psubsubcatid.SelectedValue) > 0)
            {
                Parameters.Add("@psubsubcatid", Conversion.Val(psubsubcatid.SelectedValue));
                //strsql += " and p.psubsubcatid =@psubsubcatid";

                strsql += " and p.psubsubcatid =" + Conversion.Val(psubsubcatid.SelectedValue) + "";
            }

            strsql += " order by  p.displayorder";
            DataSet ds = clsm.senddataset_Parameter(strsql, Parameters);
            

            Response.Clear();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=DorsetProductList.xls");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            DataSetToExcel.Convert(ds, Response);

            
            Response.Write(stringWrite.ToString());
            Response.Buffer = true;
            Response.End();

        }
    }
}