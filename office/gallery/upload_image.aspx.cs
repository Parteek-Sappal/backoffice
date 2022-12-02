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


namespace backoffice.office.gallery
{
    public partial class upload_image : System.Web.UI.Page
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
            Parameters.Add("@Albumid", Conversion.Val(Request.QueryString["Albumid"]));
            DataSet ds = clsm.senddataset_Parameter("select photoid,phototitle,uploadphoto,phototitle,displayorder  from AlbumPhoto where Albumid=@Albumid", Parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dtlview.DataSource = ds.Tables[0];
                dtlview.DataBind();
            }
        }

        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {

            try
            {
                //=== CODE FOR SAVE IMAGE IN DATA BASE ===//
                SqlConnection objcon = new SqlConnection(clsm.strconnect);
                objcon.Open();
                SqlCommand objcmd = new SqlCommand("AlbumPhotosp", objcon);
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.Parameters.AddWithValue("@AlbumId", Conversion.Val(Request.QueryString["AlbumId"]));
                objcmd.Parameters.AddWithValue("@phototitle", e.FileName.ToString());
                objcmd.Parameters.AddWithValue("@Uploadphoto", e.FileName.ToString().Replace(" ", "").Replace("&", ""));
                objcmd.Parameters.AddWithValue("@Status", "1");
                objcmd.Parameters.AddWithValue("@displayorder", 0);
                objcmd.Parameters.AddWithValue("@largeimage", "");
                objcmd.Parameters.AddWithValue("@Uname", Convert.ToString(Session["UserId"]));
                objcmd.Parameters.AddWithValue("@Mode", 1);
                objcmd.Parameters.Add("@photoid", SqlDbType.Int, -1).Direction = ParameterDirection.Output;
                objcmd.ExecuteNonQuery();
                string photoid = objcmd.Parameters["@photoid"].Value.ToString();
                objcon.Close();
                objcmd.Dispose();

                //=== END CODE FOR SAVE IMAGE IN DATABASE ===// 
                //=== CODE FOR SAVE LARGE IMAGE ===//

                string uploadedfile = Path.GetFileName((photoid + Convert.ToString("pg_")) + Path.GetFileName(e.FileName.ToString().Replace(" ", "")).Replace("&", ""));

                //=== CODE FOR SAVE SMALL IMAGE ===//

                FileInfo F2 = new FileInfo(Convert.ToString(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\") + uploadedfile);
                if (F2.Exists)
                {
                    F2.Delete();
                }
                string fileNameWithPathL = Server.MapPath("~/uploads/LargeImages/") + uploadedfile;
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
                    CheckBox chk = item.FindControl("chk") as CheckBox;

                    TextBox txtdisplayorder = item.FindControl("txtdisplayorder") as TextBox;

                    Parameters.Add("@photoid", lblphotoid.Text);
                    Parameters.Add("@phototitle", txtphototitle.Text.Trim());
                    Parameters.Add("@displayorder", txtdisplayorder.Text.Trim());
                    clsm.ExecuteQry_Parameter("update AlbumPhoto set phototitle=@phototitle,displayorder=@displayorder where photoid=@photoid", Parameters);

                }
                FillImage();
                lblmsg.Text = "Record updated successfully";

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
                    TextBox txtdisplayorder = item.FindControl("txtdisplayorder") as TextBox;
                    CheckBox chk = item.FindControl("chk") as CheckBox;
                    Label lbluploadphoto = item.FindControl("lbluploadphoto") as Label;
                    Parameters.Clear();
                    if (chk.Checked == true)
                    {
                        Parameters.Add("@photoid", lblphotoid.Text);
                        clsm.ExecuteQry_Parameter("delete from AlbumPhoto where photoid=@photoid", Parameters);
                        FileInfo F2 = new FileInfo(Convert.ToString(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\") + lbluploadphoto.Text);
                        if (F2.Exists)
                        {
                            F2.Delete();
                        }
                        FileInfo F3 = new FileInfo(Convert.ToString(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\") + lbluploadphoto.Text);
                        if (F3.Exists)
                        {
                            F3.Delete();
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
    }
}