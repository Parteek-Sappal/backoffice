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
using backoffice.layers.model;
using backoffice.layers.business;

namespace backoffice.office.homebanner
{
    public partial class addhomebanner : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        public HttpCookie AUserSession = null;
        Hashtable Parameters = new Hashtable();
        string StrFileName = string.Empty;
        BL_homebanner objBL_homebanner = new BL_homebanner();
        ML_homebanner objML_homebanner = new ML_homebanner();
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            displayorder.Text = "0";


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
                        
                        Parameters.Clear();
                        Parameters.Add("@bid", newsidval);
                        string strsql = "Select * from homebanner where bid=@bid  ";
                        if (Conversion.Val(Request.QueryString["clid"]) > 0)
                        {
                            Parameters.Add("@collageid", Convert.ToString(Request.QueryString["clid"]));
                            strsql += " and collageid=@collageid ";
                        }
                        clsm.MoveRecord_Parameter(this, Label1.Parent, strsql, Parameters);


                        

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
                Label1.Visible = false;
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
                if (Conversion.Val(Request.QueryString["bid"]) > 0)
                {
                    objML_homebanner.bid = Convert.ToInt32(bid.Text);
                }
                objML_homebanner.collageid = Convert.ToInt32(Request.QueryString["prodid"]);
                objML_homebanner.btypeid = Convert.ToInt32(btypeid.SelectedValue);
                objML_homebanner.devicetype = devicetype.SelectedItem.Text;
                objML_homebanner.title = title.Text;
                objML_homebanner.tagline1 = tagline1.Text;
                objML_homebanner.tagline2 = tagline2.Text;
                objML_homebanner.bannerimage= bannerimage.Text;
                objML_homebanner.bannermobile = bannermobile.Text;
                objML_homebanner.blogo = blogo.Text;
                objML_homebanner.url= url.Text;
                objML_homebanner.displayorder = Convert.ToInt32(displayorder.Text);
                objML_homebanner.Status = 1;
                objML_homebanner.uname = Session["UserId"].ToString();
                if (Conversion.Val(Request.QueryString["bid"]) > 0)
                {
                    objML_homebanner.mode = 2;
                }
                else
                {
                    objML_homebanner.mode = 1;
                }
                bool x = objBL_homebanner.BL_insupdhomebanner(objML_homebanner);
                if (x == true)
                {
                    string bid = Convert.ToString(clsm.SendValue("select bid from homebanner where 2=2 order by bid desc"));
                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        Parameters.Clear();
                        Parameters.Add("@bid", bid);
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
                        Parameters.Add("@bid", bid);
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
                    if (Conversion.Val(Request.QueryString["bid"]) > 0)
                    {
                        Response.Redirect(("viewhomebanner.aspx?edit=edit" + strcollageid));
                    }
                    else
                    {
                        Response.Redirect(("addhomebanner.aspx?add=add" + strcollageid));
                    }
                        
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