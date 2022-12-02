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

namespace backoffice.office.Services
{
    public partial class service : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        public HttpCookie AUserSession = null;
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            //edit
            if (Page.IsPostBack == false)
            {
                Parameters.Clear();
                clsm.Fillcombo_Parameter(" select stype,stypeid from servicetype where status=1 order by  displayorder", Parameters, stypeid);

                Int32 p = 0;
                if (Int32.TryParse(Request.QueryString["id"], out p) == true)
                {
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    CKeditor3.ReadOnly = true;
                    Parameters.Clear();
                    Parameters.Add("@serviceid", Convert.ToInt32(Request.QueryString["id"]));
                    clsm.MoveRecord_Parameter(this, serviceid.Parent, "select * from cservices where serviceid=@serviceid", Parameters);
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    CKeditor3.ReadOnly = false;
                    CKeditor1.Text = Server.HtmlDecode(smalldesc.Text);
                    CKeditor2.Text = Server.HtmlDecode(details.Text);
                    CKeditor3.Text = Server.HtmlDecode(details1.Text);
                    if (!string.IsNullOrEmpty(smallimage.Text))
                    {
                        Image1.ImageUrl = "~/Uploads/SmallImages/" + Server.HtmlDecode(smallimage.Text);
                        Image1.Visible = true;
                        LinkButton1.Visible = true;
                    }
                    if (!string.IsNullOrEmpty(homebanner.Text))
                    {
                        Image2.ImageUrl = "~/Uploads/SmallImages/" + Server.HtmlDecode(homebanner.Text);
                        Image2.Visible = true;
                        LinkButton2.Visible = true;

                    }

                }
                if (Convert.ToString(Request.QueryString["add"]) == "add")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Added Successfully.";
                }

            }


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
                default:
                    return false;
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string StrFileName = null;

                smalldesc.Text = Server.HtmlDecode(CKeditor1.Text);
                details.Text = Server.HtmlDecode(CKeditor2.Text);
                details1.Text = Server.HtmlDecode(CKeditor3.Text);

                if (Page.IsValid == true)
                {
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    CKeditor3.ReadOnly = true;
                    
                    if (string.IsNullOrEmpty(serviceid.Text))
                    {


                        if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                        {
                            if ((CheckImgType(Path.GetFileName(File1.PostedFile.FileName))) == false)
                            {
                                trnotice.Visible = true;
                                lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                                return;
                            }
                            smallimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        }
                        if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                        {
                            if ((CheckImgType(Path.GetFileName(File2.PostedFile.FileName))) == false)
                            {
                                trnotice.Visible = true;
                                lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                                return;
                            }
                            homebanner.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        }
                        status.Checked = true;

                        CKeditor1.ReadOnly = true;
                        CKeditor2.ReadOnly = true;
                        CKeditor3.ReadOnly = true;


                        string var = clsm.MasterSave(this, serviceid.Parent, 17, mainclass.Mode.modeAdd, "cservicesSP", Convert.ToString(Session["UserId"]));


                        CKeditor1.ReadOnly = false;
                        CKeditor2.ReadOnly = false;
                        CKeditor3.ReadOnly = false;

                        if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                        {
                            smallimage.Text = HttpUtility.HtmlEncode(var + "simg_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
                            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\SmallImages\\" + smallimage.Text.ToString());
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }
                            File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\SmallImages\\" + smallimage.Text.ToString());
                        }
                        if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                        {
                            homebanner.Text = HttpUtility.HtmlEncode(var + "sh_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
                            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\SmallImages\\" + homebanner.Text.ToString());
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }
                            File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\SmallImages\\" + homebanner.Text.ToString());
                        }

                        Response.Redirect("service.aspx?add=add");
                                                
                        trsuccess.Visible = true;
                        lblsuccess.Text = "Record added successfully.";
                    }
                    else
                    {

                        if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                        {
                            if ((CheckImgType(Path.GetFileName(File1.PostedFile.FileName))) == false)
                            {
                                trnotice.Visible = true;
                                lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                                return;
                            }
                            smallimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        }
                        if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                        {
                            if ((CheckImgType(Path.GetFileName(File2.PostedFile.FileName))) == false)
                            {
                                trnotice.Visible = true;
                                lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                                return;
                            }
                            homebanner.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        }
                        status.Checked = true;
                        CKeditor1.ReadOnly = true;
                        CKeditor2.ReadOnly = true;
                        CKeditor3.ReadOnly = true;

                        string var = clsm.MasterSave(this, serviceid.Parent, 17, mainclass.Mode.modeModify, "cservicesSP", Convert.ToString(Session["UserId"]));

                        CKeditor1.ReadOnly = false;
                        CKeditor2.ReadOnly = false;
                        CKeditor3.ReadOnly = false;

                        if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                        {
                            smallimage.Text = HttpUtility.HtmlEncode(var + "simg_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
                            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\SmallImages\\" + smallimage.Text.ToString());
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }
                            SqlConnection objcon = new SqlConnection(clsm.strconnect);
                            objcon.Open();
                            SqlCommand objcmd = new SqlCommand("update cservices set smallimage=@smallimage where serviceid=" + var.ToString() + "", objcon);
                            objcmd.Parameters.Add(new SqlParameter("@smallimage", Server.HtmlDecode(smallimage.Text)));
                            objcmd.ExecuteNonQuery();
                            objcon.Close();
                            File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\SmallImages\\" + smallimage.Text.ToString());
                        }

                        if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                        {
                            homebanner.Text = HttpUtility.HtmlEncode(var + "sh_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
                            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\SmallImages\\" + homebanner.Text.ToString());
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }
                            SqlConnection objcon = new SqlConnection(clsm.strconnect);
                            objcon.Open();
                            SqlCommand objcmd = new SqlCommand("update cservices set homebanner=@homebanner where serviceid=" + var.ToString() + "", objcon);
                            objcmd.Parameters.Add(new SqlParameter("@homebanner", Server.HtmlDecode(homebanner.Text)));
                            objcmd.ExecuteNonQuery();
                            objcon.Close();
                            File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\SmallImages\\" + homebanner.Text.ToString());
                        }                        
                        Response.Redirect("viewservice.aspx?edit=edit");
                    }

                }
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }


        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(serviceid.Text) != 0)
            {
                Response.Redirect("viewservice.aspx");
            }
            else
            {
                clsm.ClearallPanel(this, serviceid.Parent);
                CKeditor1.Text = "";

            }

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + Convert.ToString(smallimage.Text));
            if (F1.Exists)
            {
                F1.Delete();
            }
            Parameters.Clear();
            Parameters.Add("@serviceid", Convert.ToInt32(serviceid.Text));
            clsm.ExecuteQry_Parameter("update cservices set smallimage='' where serviceid=@serviceid", Parameters);
            LinkButton1.Visible = false;
            Image1.Visible = false;
            trsuccess.Visible = true;
            lblsuccess.Text = "Image deleted successfully.";
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {

            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + Convert.ToString(homebanner.Text));
            if (F1.Exists)
            {
                F1.Delete();
            }
            Parameters.Clear();
            Parameters.Add("@serviceid", Convert.ToInt32(serviceid.Text));
            clsm.ExecuteQry_Parameter("update cservices set homebanner='' where serviceid=@serviceid", Parameters);
            LinkButton2.Visible = false;
            Image2.Visible = false;
            trsuccess.Visible = true;

            lblsuccess.Text = "Image deleted successfully.";
        }
    }
}