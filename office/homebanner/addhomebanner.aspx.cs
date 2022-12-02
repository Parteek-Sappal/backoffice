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
    public partial class addhomebanner : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        public HttpCookie AUserSession = null;
        Hashtable Parameters = new Hashtable();
        string StrFileName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;


            if (Page.IsPostBack == false)
            {
                Parameters.Clear();
                clsm.Fillcombo_Parameter(" select btype,btypeid from homebannertype where 1=1 and collageid=" + Conversion.Val(Request.QueryString["clid"]) + "  order by  displayorder", Parameters, btypeid);

                if (Conversion.Val(Request.QueryString["prodid"]) > 0)
                {
                    collageid.Text = Convert.ToString(Conversion.Val(Request.QueryString["prodid"]));
                    tr1.Visible = true;
                    Parameters.Clear();
                    Parameters.Add("@prodid", Convert.ToString(Conversion.Val(Request.QueryString["prodid"])));
                    lblcollage.Text = Convert.ToString(clsm.SendValue_Parameter("SELECT productname FROM products WHERE productid=@prodid", Parameters));
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
                        CKeditor2.ReadOnly = true;
                        Parameters.Clear();
                        Parameters.Add("@bid", newsidval);
                        string strsql = "Select * from homebanner where bid=@bid  ";
                        if (Conversion.Val(Request.QueryString["clid"]) > 0)
                        {
                            Parameters.Add("@collageid", Convert.ToString(Request.QueryString["clid"]));
                            strsql += " and collageid=@collageid ";
                        }
                        clsm.MoveRecord_Parameter(this, Label1.Parent, strsql, Parameters);


                        CKeditor1.ReadOnly = false;
                        CKeditor2.ReadOnly = false;
                        CKeditor1.Text = Server.HtmlDecode(tagline1.Text);
                        CKeditor2.Text = Server.HtmlDecode(tagline2.Text);

                        if (!string.IsNullOrEmpty(bannerimage.Text))
                        {
                            if (Convert.ToString(btypeid.SelectedItem.Text) == "Video")
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
                        if (!string.IsNullOrEmpty(blogo.Text))
                        {
                            Image3.ImageUrl = "~/Uploads/banner/" + Server.HtmlDecode(blogo.Text);
                            Image3.Visible = true;

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
        #region <<BUTTON EVENT>>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                tagline1.Text = Server.HtmlEncode(CKeditor1.Text);
                tagline2.Text = Server.HtmlEncode(CKeditor2.Text);

                Label1.Visible = false;
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
              
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

               
                    if (!string.IsNullOrEmpty(File3.PostedFile.FileName))
                    {
                        if ((CheckImgType(Path.GetFileName(File3.PostedFile.FileName))) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                            return;
                        }
                        blogo.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File3.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    }

                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    string var = clsm.MasterSave(this, Label1.Parent, 13, mainclass.Mode.modeAdd, "homebannerSP", Session["UserId"].ToString()).ToString();
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {                        
                        Parameters.Clear();
                        Parameters.Add("@bid", var);
                        StrFileName = clsm.SendValue_Parameter("Select bannerimage from homebanner where bid=@bid", Parameters).ToString();
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }

                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"].ToString() + "\\uploads\\banner\\" + StrFileName);

                    }

                     if (!string.IsNullOrEmpty(File3.PostedFile.FileName))
                    {
                        Parameters.Clear();
                        Parameters.Add("@bid", var);
                        StrFileName = clsm.SendValue_Parameter("Select blogo from homebanner where bid=@bid", Parameters).ToString();
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }

                        File3.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"].ToString() + "\\uploads\\banner\\" + StrFileName);

                    }

                    string strcollageid = String.Empty;
                    if ((Conversion.Val(collageid.Text) > 0))
                    {
                        strcollageid = ("&prodid=" + double.Parse(collageid.Text));
                    }

                    Response.Redirect(("addhomebanner.aspx?add=add" + strcollageid));

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
                  
                    if ((File3.PostedFile.FileName != ""))
                    {
                        if ((CheckImgType(File3.PostedFile.FileName) == false))
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                            return;
                        }

                    }



                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    string var = clsm.MasterSave(this, Label1.Parent, 13, mainclass.Mode.modeModify, "homebannerSP", Session["UserId"].ToString()).ToString();
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;




                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        FileInfo F5 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + Server.HtmlDecode(bannerimage.Text));
                        if (F5.Exists)
                        {
                            F5.Delete();
                        }
                        bannerimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "hbanner_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + Server.HtmlDecode(bannerimage.Text));
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        //' update banner file
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update homebanner set bannerimage=@bannerimage where bid=" + var.ToString() + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@bannerimage", Server.HtmlDecode(bannerimage.Text)));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();

                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"].ToString() + "\\uploads\\banner\\" + bannerimage.Text);
                    }                   

                    if (!string.IsNullOrEmpty(File3.PostedFile.FileName))
                    {
                        FileInfo F6 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + Server.HtmlDecode(blogo.Text));
                        if (F6.Exists)
                        {
                            F6.Delete();
                        }
                        blogo.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "hlbanner_" + Path.GetFileName(File3.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + Server.HtmlDecode(blogo.Text));
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        //' update banner file
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update homebanner set blogo=@blogo where bid=" + var.ToString() + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@blogo", Server.HtmlDecode(blogo.Text)));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();

                        File3.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"].ToString() + "\\uploads\\banner\\" + blogo.Text);
                    }


                    string strcollageid = String.Empty;
                    if (Conversion.Val(collageid.Text) > 0)
                    {
                        strcollageid = ("&prodid=" + double.Parse(collageid.Text));
                    }

                    Response.Redirect(("viewhomebanner.aspx?edit=edit" + strcollageid));
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
                Response.Redirect("viewhomebanner.aspx");
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