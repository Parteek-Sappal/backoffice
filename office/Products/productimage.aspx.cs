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
    public partial class productimage : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        Hashtable Parameters = new Hashtable();
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
            DataSet ds = clsm.senddataset_Parameter("select *  from Product_images where productid=@productid", Parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dtlview.DataSource = ds.Tables[0];
                dtlview.DataBind();
            }
        }

        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            Response.Write("Fired");
            try
            {
                //=== CODE FOR SAVE IMAGE IN DATA BASE ===//
                SqlConnection objcon = new SqlConnection(clsm.strconnect);
                objcon.Open();
                SqlCommand objcmd = new SqlCommand("Product_imagesSP", objcon);
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.Parameters.AddWithValue("@productid", Conversion.Val(Request.QueryString["productid"]));
                objcmd.Parameters.AddWithValue("@imagetitle", e.FileName.ToString());
                objcmd.Parameters.AddWithValue("@productimage", e.FileName.ToString().Replace(" ", "").Replace("&", ""));
                objcmd.Parameters.AddWithValue("@colorimage", e.FileName.ToString().Replace(" ", "").Replace("&", ""));
                objcmd.Parameters.AddWithValue("@Iscolorimage", 0);
                objcmd.Parameters.AddWithValue("@Status", "1");
                objcmd.Parameters.AddWithValue("@displayorder", 0);
                objcmd.Parameters.AddWithValue("@largeimage", "");
                objcmd.Parameters.AddWithValue("@Uname", Convert.ToString(Session["UserId"]));
                objcmd.Parameters.AddWithValue("@Mode", 1);
                objcmd.Parameters.Add("@imageid", SqlDbType.Int, -1).Direction = ParameterDirection.Output;
                objcmd.ExecuteNonQuery();
                string photoid = objcmd.Parameters["@imageid"].Value.ToString();
                objcon.Close();
                objcmd.Dispose();

                //=== END CODE FOR SAVE IMAGE IN DATABASE ===// 
                //=== CODE FOR SAVE LARGE IMAGE ===//

                string uploadedfile = Path.GetFileName((photoid + Convert.ToString("pdctimg_")) + Path.GetFileName(e.FileName.ToString().Replace(" ", "")).Replace("&", ""));

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
                    TextBox txtorder = item.FindControl("txtorder") as TextBox;
                    CheckBox chk = item.FindControl("chk") as CheckBox;

                    Parameters.Add("@imageid", lblphotoid.Text);
                    Parameters.Add("@imagetitle", txtphototitle.Text.Trim());
                    Parameters.Add("@displayorder", Conversion.Val(txtorder.Text));
                    clsm.ExecuteQry_Parameter("update Product_images set imagetitle=@imagetitle,displayorder=@displayorder where imageid=@imageid", Parameters);
                }
                FillImage();
                trsuccess.Visible = true;
                lblsuccess.Text = "Record(s) updated successfully";
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
                    Label lbluploadphoto = item.FindControl("lbluploadphoto") as Label;
                    Label lblcolorimage = item.FindControl("lblcolorimage") as Label;
                    Label lbllargeimg = item.FindControl("lbllargeimg") as Label;

                    Parameters.Clear();
                    if (chk.Checked == true)
                    {
                        Parameters.Add("@imageid", lblphotoid.Text);
                        clsm.ExecuteQry_Parameter("delete from Product_images where imageid=@imageid", Parameters);
                        FileInfo F2 = new FileInfo(Convert.ToString(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\") + lbluploadphoto.Text);
                        if (F2.Exists)
                        {
                            F2.Delete();
                        }
                        FileInfo F3 = new FileInfo(Convert.ToString(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\") + lbllargeimg.Text);
                        if (F3.Exists)
                        {
                            F3.Delete();
                        }

                        FileInfo F4 = new FileInfo(Convert.ToString(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\") + lblcolorimage.Text);
                        if (F4.Exists)
                        {
                            F4.Delete();
                        }

                    }
                }

                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
            }
            catch (Exception er)
            {

                lblmsg.Text = er.Message;
            }

        }
        protected void btncolorimg_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataListItem item in dtlview.Items)
                {
                    Label lblphotoid = item.FindControl("lblphotoid") as Label;
                    TextBox txtphototitle = item.FindControl("txtphototitle") as TextBox;
                    CheckBox chk = item.FindControl("chk") as CheckBox;
                    Label lbluploadphoto = item.FindControl("lbluploadphoto") as Label;
                    Label lblcolorimage = item.FindControl("lblcolorimage") as Label;
                    Label lbllargeimg = item.FindControl("lbllargeimg") as Label;

                    Parameters.Clear();
                    if (chk.Checked == true)
                    {
                        Parameters.Add("@imageid", lblphotoid.Text);
                        clsm.ExecuteQry_Parameter("update Product_images set Iscolorimage=1 where imageid=@imageid", Parameters);
                    }
                    else
                    {
                        Parameters.Add("@imageid", lblphotoid.Text);
                        clsm.ExecuteQry_Parameter("update Product_images set Iscolorimage=0 where imageid=@imageid", Parameters);
                    }
                }
            }
            catch (Exception er)
            {

                lblmsg.Text = er.Message;
            }
        }
    }
}