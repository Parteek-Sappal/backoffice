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
    public partial class productsubcategory : System.Web.UI.Page
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
                Parameters.Clear();
                clsm.Fillcombo_Parameter(" select category,pcatid from productcate where status=1 order by  displayorder", Parameters, pcatid);

                if (Convert.ToInt32(Request.QueryString["psubcatid"]) > 0)
                {
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    Parameters.Clear();
                    Parameters.Add("@psubcatid", Convert.ToInt32(Request.QueryString["psubcatid"]));
                    clsm.MoveRecord_Parameter(this, psubcatid.Parent, "select * from productsubcate where psubcatid=@psubcatid", Parameters);
                    psubcatid.Text = HttpUtility.HtmlDecode(psubcatid.Text);
                    psubcatid.Text = HttpUtility.HtmlDecode(psubcatid.Text);
                    displayorder.Text = HttpUtility.HtmlDecode(displayorder.Text);
                    CKeditor1.ReadOnly = false;
                    CKeditor1.Text = Server.HtmlDecode(detail.Text);
                    CKeditor2.ReadOnly = false;
                    CKeditor2.Text = Server.HtmlDecode(shortdetail.Text);
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
                    if (!string.IsNullOrEmpty(UploadAImage.Text.Trim()))
                    {
                        File1.Visible = true;
                        LinkButton2.Visible = true;
                        Image2.Visible = true;
                        Image2.ImageUrl = "../../Uploads/ProductsImage/" + UploadAImage.Text;
                    }
                    else
                    {
                        LinkButton2.Visible = false;
                    }

                }

                if (Request.QueryString["edit"] == "edit")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record updated successfully.";
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
                if (Convert.ToInt32(clsm.MasterSave(this, psubcatid.Parent, 16, mainclass.Mode.modeCheckDuplicate, "productsubcateSP", Convert.ToString(Session["UserId"]))) > 0)
                {
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    trnotice.Visible = true;
                    lblnotice.Text = "This Category  already exist.";
                    return;
                }


                if (string.IsNullOrEmpty(psubcatid.Text))
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
                   

                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        if ((CheckImgType(File1.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                        UploadAImage.Text = Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                    }
                 
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    Status.Checked = true;
                    string var = clsm.MasterSave(this, psubcatid.Parent, 16, mainclass.Mode.modeAdd, "productsubcateSP", Convert.ToString(Session["UserId"]));
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        Parameters.Clear();
                        Parameters.Add("@psubcatid", var);
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select banner from productsubcate where psubcatid=@psubcatid", Parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\ProductsImage\\" + StrFileName);
                    }


                    clsm.ClearallPanel(this, pcatid.Parent);
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
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    string var = clsm.MasterSave(this, psubcatid.Parent, 16, mainclass.Mode.modeModify, "productsubcateSP", Convert.ToString(Session["UserId"]));
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
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
                        SqlCommand objcmd = new SqlCommand("update productsubcate set banner=@banner where psubcatid=" + var + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@banner", banner.Text));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();
                        File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\ProductsImage\\" + banner.Text);
                    }

                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {



                        UploadAImage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "pdctmimg_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + UploadAImage.Text);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        //' update banner file
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update productsubcate set UploadAImage=@UploadAImage where psubcatid=" + var + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@UploadAImage", UploadAImage.Text));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\ProductsImage\\" + UploadAImage.Text);
                    }


                    Response.Redirect("viewproductsubcategory.aspx?edit=edit");
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
            clsm.ClearallPanel(this, pcatid.Parent);
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
            Parameters.Add("@psubcatid", Convert.ToInt32(Request.QueryString["psubcatid"]));
            clsm.SendValue_Parameter("update productsubcate set banner='' where psubcatid=@psubcatid", Parameters);
            banner.Text = "";
            Image1.Visible = false;
            trsuccess.Visible = true;
            LinkButton1.Visible = false;
            lblsuccess.Text = "File deleted successfully.";
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UploadAImage.Text))
            {
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + UploadAImage.Text);
                if (F1.Exists)
                {
                    F1.Delete();
                }
            }
            
            Parameters.Clear();
            Parameters.Add("@psubcatid", Convert.ToInt32(Request.QueryString["psubcatid"]));
            clsm.SendValue_Parameter("update productsubcate set UploadAImage='' where psubcatid=@psubcatid", Parameters);
            UploadAImage.Text = "";
            Image2.Visible = false;
            trsuccess.Visible = true;
            LinkButton2.Visible = false;
            lblsuccess.Text = "File deleted successfully.";
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
                default:
                    return false;
            }
        }
    }
}