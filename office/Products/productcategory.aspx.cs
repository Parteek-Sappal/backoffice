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

namespace backoffice.office.Products
{
    public partial class productcategory : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        public HttpCookie AUserSession = null;
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (!Page.IsPostBack)
            {
                if (Convert.ToInt32(Request.QueryString["seriesid"]) > 0)
                {
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    CKeditor3.ReadOnly = true;
                    Parameters.Clear();
                    Parameters.Add("@seriesid", Convert.ToInt32(Request.QueryString["seriesid"]));
                    clsm.MoveRecord_Parameter(this, seriesid.Parent, "select * from productcate where seriesid=@seriesid", Parameters);


                    CKeditor1.ReadOnly = false;
                    CKeditor1.Text = Server.HtmlDecode(detail.Text);
                    CKeditor2.ReadOnly = false;
                    CKeditor2.Text = Server.HtmlDecode(shortdetail.Text);

                    CKeditor3.ReadOnly = false;
                    CKeditor3.Text = Server.HtmlDecode(longdetails.Text);

                    if (!string.IsNullOrEmpty(banner.Text.Trim()))
                    {
                        File2.Visible = true;
                        LinkButton1.Visible = true;
                        Image1.Visible = true;
                        Image1.ImageUrl = "../../Uploads/ProductsImage/" + banner.Text;
                    }
                    else
                    {
                        LinkButton1.Visible = false;
                    }
                    if (!string.IsNullOrEmpty(mobilebanner.Text.Trim()))
                    {
                        File3.Visible = true;
                        LinkButton3.Visible = true;
                        Image2.Visible = true;
                        Image2.ImageUrl = "../../Uploads/ProductsImage/" + mobilebanner.Text;
                    }
                    else
                    {
                        LinkButton3.Visible = false;
                    }
                    if (!string.IsNullOrEmpty(mobileicon.Text.Trim()))
                    {
                        File4.Visible = true;
                        LinkButton4.Visible = true;
                        Image3.Visible = true;
                        Image3.ImageUrl = "../../Uploads/ProductsImage/" + mobileicon.Text;
                    }
                    else
                    {
                        LinkButton4.Visible = false;
                    }

                    if (!string.IsNullOrEmpty(UploadAPDF.Text.Trim()))
                    {
                        File1.Visible = true;
                        LinkButton2.Visible = true;
                        imgbanner.Visible = true;
                        imgbanner.ImageUrl = "../../Uploads/ProductsImage/" + UploadAPDF.Text;
                    }
                    else
                    {
                        LinkButton2.Visible = false;
                    }
                }


                if (Request.QueryString["add"] == "add")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record added successfully.";
                }

            }
        }



        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string StrFileName = null;
            try
            {
                detail.Text = Server.HtmlEncode(CKeditor1.Text);
                CKeditor1.ReadOnly = true;
                shortdetail.Text = Server.HtmlEncode(CKeditor2.Text);
                CKeditor2.ReadOnly = true;

                longdetails.Text = Server.HtmlEncode(CKeditor3.Text);
                CKeditor3.ReadOnly = true;

                if (Convert.ToInt32(clsm.MasterSave(this, seriesid.Parent, 19, mainclass.Mode.modeCheckDuplicate, "productcateSP", Convert.ToString(Session["UserId"]))) > 0)
                {
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    CKeditor3.ReadOnly = false;
                    trnotice.Visible = true;
                    lblnotice.Text = "This Category  already exist.";
                    return;
                }
                if (string.IsNullOrEmpty(seriesid.Text))
                {

                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        if ((CheckImgType(File2.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                        banner.Text = Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                    }


                    if (!string.IsNullOrEmpty(File3.PostedFile.FileName))
                    {
                        if ((CheckImgType(File3.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                        mobilebanner.Text = Path.GetFileName(Path.GetFileName(File3.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                    }



                    if (!string.IsNullOrEmpty(File4.PostedFile.FileName))
                    {
                        if ((CheckImgType(File4.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                        mobileicon.Text = Path.GetFileName(Path.GetFileName(File4.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                    }


                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        if ((CheckImgType(File1.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                        UploadAPDF.Text = Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                    }



                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    CKeditor3.ReadOnly = true;
                    Status.Checked = true;
                    string var = clsm.MasterSave(this, seriesid.Parent, 19, mainclass.Mode.modeAdd, "productcateSP", Convert.ToString(Session["UserId"]));
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    CKeditor3.ReadOnly = false;
                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        Parameters.Clear();
                        Parameters.Add("@seriesid", var);
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select banner from productcate where seriesid=@seriesid", Parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\ProductsImage\\" + StrFileName);
                    }

                    if (!string.IsNullOrEmpty(File3.PostedFile.FileName))
                    {
                        Parameters.Clear();
                        Parameters.Add("@seriesid", var);
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select mobilebanner from productcate where seriesid=@seriesid", Parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File3.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\ProductsImage\\" + StrFileName);
                    }

                    if (!string.IsNullOrEmpty(File4.PostedFile.FileName))
                    {
                        Parameters.Clear();
                        Parameters.Add("@seriesid", var);
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select mobileicon from productcate where seriesid=@seriesid", Parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File4.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\ProductsImage\\" + StrFileName);
                    }

                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        Parameters.Clear();
                        Parameters.Add("@seriesid", var);
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select UploadAPDF from productcate where seriesid=@seriesid", Parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\ProductsImage\\" + StrFileName);
                    }


                    clsm.ClearallPanel(this, seriesid.Parent);
                    Status.Checked = true;
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record added successfully.";
                }
                else
                {
                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        if ((CheckImgType(File2.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }

                    }
                    if (!string.IsNullOrEmpty(File3.PostedFile.FileName))
                    {
                        if ((CheckImgType(File3.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }

                    }
                    if (!string.IsNullOrEmpty(File4.PostedFile.FileName))
                    {
                        if ((CheckImgType(File4.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }

                    }
                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        if ((CheckImgType(File1.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                    }
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    CKeditor3.ReadOnly = true;
                    string var = clsm.MasterSave(this, seriesid.Parent, 19, mainclass.Mode.modeModify, "productcateSP", Convert.ToString(Session["UserId"]));
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    CKeditor3.ReadOnly = false;


                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        UploadAPDF.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "pdctfile_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));

                        //FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + UploadAPDF.Text);
                        //if (F2.Exists)
                        //{
                        //    F2.Delete();
                        //}
                        // UploadAPDF.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + UploadAPDF.Text);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update productcate set UploadAPDF=@UploadAPDF where seriesid=" + Convert.ToInt32(var) + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@UploadAPDF", UploadAPDF.Text));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\ProductsImage\\" + UploadAPDF.Text);
                    }





                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        banner.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "pdctimg_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + banner.Text);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        //' update banner file
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update productcate set banner=@banner where seriesid=" + var + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@banner", banner.Text));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();
                        File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\ProductsImage\\" + banner.Text);
                    }

                    if (!string.IsNullOrEmpty(File3.PostedFile.FileName))
                    {
                        mobilebanner.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "pdctmimg_" + Path.GetFileName(File3.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + mobilebanner.Text);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        //' update banner file
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update productcate set mobilebanner=@mobilebanner where seriesid=" + var + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@mobilebanner", mobilebanner.Text));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();
                        File3.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\ProductsImage\\" + mobilebanner.Text);
                    }

                    if (!string.IsNullOrEmpty(File4.PostedFile.FileName))
                    {
                        mobileicon.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "pdctmiconimg_" + Path.GetFileName(File4.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + mobileicon.Text);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        //' update banner file
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update productcate set mobileicon=@mobileicon where seriesid=" + var + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@mobileicon", mobileicon.Text));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();
                        File4.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\ProductsImage\\" + mobileicon.Text);
                    }

                    Response.Redirect("viewproductcategory.aspx?edit=edit");
                }
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message;
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            clsm.ClearallPanel(this, seriesid.Parent);
        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(banner.Text))
            {
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + banner.Text);
                if (F1.Exists)
                {
                    F1.Delete();
                }
            }
            
            Parameters.Clear();
            Parameters.Add("@seriesid", Convert.ToInt32(Request.QueryString["seriesid"]));
            clsm.SendValue_Parameter("update productcate set banner='' where seriesid=@seriesid", Parameters);
            banner.Text = "";
            Image1.Visible = false;
            trsuccess.Visible = true;
            LinkButton1.Visible = false;
            lblsuccess.Text = "File deleted successfully.";
        }


        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UploadAPDF.Text))
            {
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + UploadAPDF.Text);
                if (F1.Exists)
                {
                    F1.Delete();
                }
            }
            
            Parameters.Clear();
            Parameters.Add("@seriesid", Convert.ToInt32(Request.QueryString["seriesid"]));
            clsm.SendValue_Parameter("update productcate set UploadAPDF='' where seriesid=@seriesid", Parameters);
            UploadAPDF.Text = "";
            imgbanner.Visible = false;
            trsuccess.Visible = true;
            LinkButton2.Visible = false;
            lblsuccess.Text = "Image deleted successfully.";
        }

        public bool CheckImgType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                case ".bmp":
                    return true;
                case ".swf":
                    return true;
                case ".webp":
                    return true;
                case ".svg":
                    return true;
                default:
                    return false;
            }
        }

        public bool CheckFileType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".doc":
                    return true;
                case ".pdf":
                    return true;
                case ".docx":
                    return true;
                case ".txt":

                    return true;
                default:
                    return false;
            }
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mobilebanner.Text))
            {
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + mobilebanner.Text);
                if (F1.Exists)
                {
                    F1.Delete();
                }
            }
            
            Parameters.Clear();
            Parameters.Add("@seriesid", Convert.ToInt32(Request.QueryString["seriesid"]));
            clsm.SendValue_Parameter("update productcate set mobilebanner='' where seriesid=@seriesid", Parameters);
            mobilebanner.Text = "";
            Image2.Visible = false;
            trsuccess.Visible = true;
            LinkButton3.Visible = false;
            lblsuccess.Text = "File deleted successfully.";
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mobileicon.Text))
            {
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + mobileicon.Text);
                if (F1.Exists)
                {
                    F1.Delete();
                }
            }
            
            Parameters.Clear();
            Parameters.Add("@seriesid", Convert.ToInt32(Request.QueryString["seriesid"]));
            clsm.SendValue_Parameter("update productcate set mobileicon='' where seriesid=@seriesid", Parameters);
            mobileicon.Text = "";
            Image3.Visible = false;
            trsuccess.Visible = true;
            LinkButton4.Visible = false;
            lblsuccess.Text = "File deleted successfully.";
        }
    }
}