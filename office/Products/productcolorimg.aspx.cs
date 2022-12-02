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

namespace backoffice.office.Products
{
    public partial class productcolorimg : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        Hashtable Parameters = new Hashtable();
        public int appno;
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (!IsPostBack)
            {
                FillImage();
            }
        }
        private void FillImage()
        {
            Parameters.Clear();
            Parameters.Add("@productid", Conversion.Val(Request.QueryString["productid"]));
            DataSet ds = clsm.senddataset_Parameter("select *  from Productcolorimages where productid=@productid", Parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dtlview.DataSource = ds.Tables[0];
                dtlview.DataBind();
                appno = ds.Tables[0].Rows.Count;
            }
        }

        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            
            try
            {
                //=== CODE FOR SAVE IMAGE IN DATA BASE ===//
                SqlConnection objcon = new SqlConnection(clsm.strconnect);
                objcon.Open();
                SqlCommand objcmd = new SqlCommand("ProductcolorimagesSP", objcon);
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.Parameters.AddWithValue("@productid", Conversion.Val(Request.QueryString["productid"]));
                objcmd.Parameters.AddWithValue("@imagetitle", e.FileName.ToString());
                objcmd.Parameters.AddWithValue("@colorimage", e.FileName.ToString().Replace(" ", "").Replace("&", ""));
                
                objcmd.Parameters.AddWithValue("@Status", "1");
                objcmd.Parameters.AddWithValue("@displayorder", 0);
                objcmd.Parameters.AddWithValue("@Uname", Convert.ToString(Session["UserId"]));
                objcmd.Parameters.AddWithValue("@Mode", 1);
                objcmd.Parameters.Add("@colorimageid", SqlDbType.Int, -1).Direction = ParameterDirection.Output;
                objcmd.ExecuteNonQuery();
                string photoid = objcmd.Parameters["@colorimageid"].Value.ToString();
                objcon.Close();
                objcmd.Dispose();
                //=== END CODE FOR SAVE IMAGE IN DATABASE ===// 
                //=== CODE FOR SAVE LARGE IMAGE ===//

                string uploadedfile = Path.GetFileName(photoid + Convert.ToString("pdctclrimg_")) + Path.GetFileName(e.FileName.ToString().Replace(" ", "")).Replace("&", "");
               
                //=== CODE FOR SAVE SMALL IMAGE ===//
                FileInfo F2 = new FileInfo(Convert.ToString(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\") + uploadedfile);
                if (F2.Exists)
                {
                    F2.Delete();
                }
                string fileNameWithPathL = Server.MapPath("~/uploads/ProductsImage/") + uploadedfile;
                AjaxFileUpload1.SaveAs(fileNameWithPathL);
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }
        }
        protected void btnpublish_Click(object sender, EventArgs e)
        {
            FillImage();
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataListItem item in dtlview.Items)
                {

                    Parameters.Clear();
                    Label lblphotoid = item.FindControl("lblphotoid") as Label;
                    TextBox txtphototitle = item.FindControl("txtphototitle") as TextBox;

                    DropDownList drpcolor = item.FindControl("drpcolor") as DropDownList;
                    CheckBox chk = item.FindControl("chk") as CheckBox;
                    TextBox txtprice = item.FindControl("txtprice") as TextBox;
                    Parameters.Add("@colorimageid", Conversion.Val(lblphotoid.Text));
                    Parameters.Add("@imagetitle", txtphototitle.Text.Trim());
                    Parameters.Add("@price", txtprice.Text.Trim());
                    clsm.ExecuteQry_Parameter("update Productcolorimages set imagetitle=@imagetitle,colorname=" + Conversion.Val(drpcolor.SelectedValue) + " , price=@price where colorimageid=@colorimageid", Parameters);

                }
                FillImage();
                lblmsg.Text = "Title updated successfully";

            }
            catch (Exception err)
            {
                lblmsg.Text = err.Message;

            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataListItem item in dtlview.Items)
                {
                    Label lblphotoid = item.FindControl("lblphotoid") as Label;
                    TextBox txtphototitle = item.FindControl("txtphototitle") as TextBox;
                    CheckBox chk = item.FindControl("chk") as CheckBox;
                    Label lblcolorimage = item.FindControl("lblcolorimage") as Label;
                    Parameters.Clear();
                    if (chk.Checked == true)
                    {
                        Parameters.Add("@colorimageid", lblphotoid.Text);
                        clsm.ExecuteQry_Parameter("delete from Productcolorimages where colorimageid=@colorimageid", Parameters);
                     
                    }
                }

                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
            }
            catch (Exception er)
            {
                lblmsg.Text = er.Message;
            }

        }

        protected void dtlview_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblcolorname = e.Item.FindControl("lblcolorname") as Label;
                DropDownList drpcolor = e.Item.FindControl("drpcolor") as DropDownList;
                Parameters.Clear();
                clsm.Fillcombo_Parameter("select ColorTitle,colorid from Color_master where status=1 order by ColorTitle", Parameters, drpcolor);
                drpcolor.Items[0].Text = "Select Color";

                drpcolor.SelectedValue = Convert.ToString(Conversion.Val(lblcolorname.Text));

            }
        }
    }
}