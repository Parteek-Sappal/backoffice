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
using Microsoft.VisualBasic;

namespace backoffice.office.homebanner
{
    public partial class addpopupbanner : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        public HttpCookie AUserSession = null;
        Hashtable Parameters = new Hashtable();
        string StrFileName = string.Empty;
        #region <<PAGE LOAD EVENT >>

        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;


            if (Page.IsPostBack == false)
            {

                if (Conversion.Val(Request.QueryString["clid"]) > 0)
                {
                    collageid.Text = Convert.ToString(Conversion.Val(Request.QueryString["clid"]));
                    tr1.Visible = true;
                    Parameters.Clear();
                    Parameters.Add("@COLLAGEID", Convert.ToString(Conversion.Val(Request.QueryString["clid"])));
                    lblcollage.Text = Convert.ToString(clsm.SendValue_Parameter("SELECT COLLAGENAME FROM COLLAGE_MASTER WHERE COLLAGEID=@COLLAGEID", Parameters));
                }
                else
                {
                    collageid.Text = "0";
                }



                Label1.Visible = false;
                if (Request.QueryString.HasKeys() == true)
                {
                    Int32 p = 0;
                    if (Int32.TryParse(Request.QueryString["bid"], out p) == true)
                    {
                        string newsidval = Convert.ToString(Request.QueryString["bid"]);
                        CKeditor1.ReadOnly = true;
                        Parameters.Clear();
                        Parameters.Add("@bid", newsidval);
                        string strsql = "Select * from popbanner where bid=@bid  ";
                        if (Conversion.Val(Request.QueryString["clid"]) > 0)
                        {
                            Parameters.Add("@collageid", Convert.ToString(Request.QueryString["clid"]));
                            strsql += " and collageid=@collageid ";
                        }
                        clsm.MoveRecord_Parameter(this, Label1.Parent, strsql, Parameters);


                        CKeditor1.ReadOnly = false;
                        CKeditor1.Text = Server.HtmlDecode(tagline1.Text);

                        if (!string.IsNullOrEmpty(bannerimage.Text))
                        {
                            if (Convert.ToString(btype.Text) == "Video")
                            {

                                pvideo.Visible = true;
                                Image1.Visible = false;
                                showvideo.Attributes.Add("src", "/Uploads/banner/" + bannerimage.Text);
                            }
                            else
                            {
                                pvideo.Visible = false;
                                Image1.ImageUrl = "~/Uploads/banner/" + Server.HtmlDecode(bannerimage.Text);
                                Image1.Visible = true;
                            }
                        }
                        if (!string.IsNullOrEmpty(bannermobile.Text))
                        {
                            Image2.ImageUrl = "~/Uploads/banner/" + Server.HtmlDecode(bannermobile.Text);
                            Image2.Visible = true;

                        }
                        displayorder.Enabled = true;
                    }

                    if (Convert.ToString(Request.QueryString["add"]) == "add")
                    {
                        trsuccess.Visible = true;
                        lblsuccess.Text = "Record Added Successfully.";
                    }
                }
            }

        }

        #endregion

        #region <<BUTTON EVENT>>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                tagline1.Text = Server.HtmlEncode(CKeditor1.Text);
                Label1.Visible = false;
                CKeditor1.ReadOnly = true;
                
                if (string.IsNullOrEmpty(bid.Text))
                {
                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        if ((CheckImgType(Path.GetFileName(File1.PostedFile.FileName))) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                            return;
                        }
                        bannerimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    }
                    else
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                        return;
                    }

                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        if ((CheckImgType(Path.GetFileName(File2.PostedFile.FileName))) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                            return;
                        }
                        bannermobile.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    }              

                    CKeditor1.ReadOnly = true;
                    string var = clsm.MasterSave(this, Label1.Parent, 11, mainclass.Mode.modeAdd, "popbannerSP", Session["UserId"].ToString()).ToString();
                    CKeditor1.ReadOnly = false;
                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {                        
                        Parameters.Clear();
                        Parameters.Add("@bid", var);
                        StrFileName = clsm.SendValue_Parameter("Select bannerimage from popbanner where bid=@bid", Parameters).ToString();
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + StrFileName);
                        if (F1.Exists)
                        {                            
                            Parameters.Clear();
                            Parameters.Add("@bid", var);
                            clsm.ExecuteQry_Parameter("delete from popbanner where bid=@bid", Parameters);
                            trnotice.Visible = true;
                            lblnotice.Text = "Banner already exist, Please choose another name.";
                            return;
                        }
                        else
                        {
                            File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"].ToString() + "\\uploads\\banner\\" + StrFileName);
                        }
                    }

                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        Parameters.Clear();
                        Parameters.Add("@bid", var);
                        StrFileName = clsm.SendValue_Parameter("Select bannermobile from popbanner where bid=@bid", Parameters).ToString();
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + StrFileName);
                        if (F1.Exists)
                        {
                            Parameters.Clear();
                            Parameters.Add("@bid", var);
                            clsm.ExecuteQry_Parameter("delete from popbanner where bid=@bid", Parameters);
                            trnotice.Visible = true;
                            lblnotice.Text = "Mobile Banner already exist, Please choose another name.";
                            return;
                        }
                        else
                        {
                            File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"].ToString() + "\\uploads\\banner\\" + StrFileName);
                        }
                    }

                    string strcollageid = String.Empty;
                    if ((Conversion.Val(collageid.Text) > 0))
                    {
                        strcollageid = ("&clid=" + double.Parse(collageid.Text));
                    }

                    Response.Redirect(("addpopupbanner.aspx?add=add" + strcollageid));

                }
                else
                {

                    if ((File1.PostedFile.FileName != ""))
                    {
                        if ((CheckImgType(File1.PostedFile.FileName) == false))
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                            return;
                        }

                    }
                    if ((File2.PostedFile.FileName != ""))
                    {
                        if ((CheckImgType(File2.PostedFile.FileName) == false))
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                            return;
                        }

                    }



                    CKeditor1.ReadOnly = true;
                    string var = clsm.MasterSave(this, Label1.Parent, 11, mainclass.Mode.modeModify, "popbannerSP", Session["UserId"].ToString()).ToString();
                    CKeditor1.ReadOnly = false;




                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        FileInfo F5 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + Server.HtmlDecode(bannerimage.Text));
                        if (F5.Exists)
                        {
                            F5.Delete();
                        }
                        bannerimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "pbanner_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + Server.HtmlDecode(bannerimage.Text));
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        //' update banner file
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update popbanner set bannerimage=@bannerimage where bid=" + var.ToString() + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@bannerimage", Server.HtmlDecode(bannerimage.Text)));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();

                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"].ToString() + "\\uploads\\banner\\" + bannerimage.Text);
                    }

                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        FileInfo F6 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + Server.HtmlDecode(bannermobile.Text));
                        if (F6.Exists)
                        {
                            F6.Delete();
                        }
                        bannermobile.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "pmbanner_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + Server.HtmlDecode(bannermobile.Text));
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        //' update banner file
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update popbanner set bannermobile=@bannermobile where bid=" + var.ToString() + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@bannermobile", Server.HtmlDecode(bannermobile.Text)));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();

                        File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"].ToString() + "\\uploads\\banner\\" + bannermobile.Text);
                    }


                    string strcollageid = String.Empty;
                    if (Conversion.Val(collageid.Text) > 0)
                    {
                        strcollageid = ("&clid=" + double.Parse(collageid.Text));
                    }

                    Response.Redirect(("viewpopupnbanner.aspx?edit=edit" + strcollageid));
                }

            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message;
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Label1.Visible = false;
            if (string.IsNullOrEmpty(bid.Text))
            {
                clsm.ClearallPanel(this, Label1.Parent);
            }
            else
            {
                Response.Redirect("viewpopupnbanner.aspx");
                clsm.ClearallPanel(this, Label1.Parent);
            }


        }
        #endregion

        #region << methods >>
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
                case ".mp4":
                    return true;
                case ".webp":
                    return true;
                case ".svg":
                    return true;
                default:
                    return false;
            }
        }
        #endregion
    }
}