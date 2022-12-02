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

namespace backoffice.office.media
{
    public partial class add_event_image : System.Web.UI.Page
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
            Parameters.Add("@eventcatid", Conversion.Val(Request.QueryString["eventcatid"]));
            DataSet ds = clsm.senddataset_Parameter("select eid,phototitle,uploadphoto  from Event_image where eventcatid=@eventcatid", Parameters);
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
                SqlCommand objcmd = new SqlCommand("Event_imageSP", objcon);
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.Parameters.AddWithValue("@eventcatid", Conversion.Val(Request.QueryString["eventcatid"]));
                objcmd.Parameters.AddWithValue("@phototitle", e.FileName.ToString());
                objcmd.Parameters.AddWithValue("@Uploadphoto", e.FileName.ToString().Replace(" ", "").Replace("&", ""));
                objcmd.Parameters.AddWithValue("@Status", "1");
                objcmd.Parameters.AddWithValue("@displayorder", 0);
                objcmd.Parameters.AddWithValue("@largeimage", "");
                objcmd.Parameters.AddWithValue("@Uname", Convert.ToString(Session["UserId"]));
                objcmd.Parameters.AddWithValue("@Mode", 1);
                objcmd.Parameters.Add("@eid", SqlDbType.Int, -1).Direction = ParameterDirection.Output;
                objcmd.ExecuteNonQuery();
                string cid = objcmd.Parameters["@eid"].Value.ToString();
                objcon.Close();
                objcmd.Dispose();

                //=== END CODE FOR SAVE IMAGE IN DATABASE ===// 
                //=== CODE FOR SAVE LARGE IMAGE ===//

                string uploadedfile = Path.GetFileName((cid + Convert.ToString("pb_")) + Path.GetFileName(e.FileName.ToString().Replace(" ", "")).Replace("&", ""));

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

                    Parameters.Add("@eid", lblphotoid.Text);
                    Parameters.Add("@phototitle", txtphototitle.Text.Trim());
                    clsm.ExecuteQry_Parameter("update Event_image set phototitle=@phototitle where eid=@eid", Parameters);

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
                    Label lbluploadphoto = item.FindControl("lbluploadphoto") as Label;
                    Parameters.Clear();
                    if (chk.Checked == true)
                    {
                        Parameters.Add("@eid", lblphotoid.Text);
                        clsm.ExecuteQry_Parameter("delete from Event_image where eid=@eid", Parameters);
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