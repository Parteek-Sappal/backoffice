using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualBasic;

namespace backoffice.office.Products
{
    public partial class color : System.Web.UI.Page
    {
        HttpCookie AUserSession;
        mainclass clsm = new mainclass();
        Hashtable parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (!Page.IsPostBack)
            {

                Int32 p = 0;
                if (Int32.TryParse(Request.QueryString["colorid"], out p) == true)
                {

                    parameters.Clear();
                    parameters.Add("@colorid", p);
                    string strsql = "Select * from Color_master where colorid=@colorid";
                    clsm.MoveRecord_Parameter(this, colorid.Parent, strsql, parameters);


                    if (UploadImage.Text != "")
                    {
                        lnkremove.Visible = true;
                        Image1.ImageUrl = "../../Uploads/SmallImages/" + UploadImage.Text;
                        Image1.Visible = true;
                    }



                }
                if (Request.QueryString["add"] != null)
                {
                    if (Request.QueryString["add"].ToString() == "add")
                    {
                        trsuccess.Visible = true;
                        lblsuccess.Text = "Record added successfully.";
                    }
                }
            }
        }
        private string Pad(Int32 numberOfSpaces)
        {
            string Spaces = "";
            for (int i = 0; i < numberOfSpaces; i++)
            {
                Spaces += "&nbsp;&nbsp;&raquo;&nbsp;";
            }
            return Server.HtmlDecode(Spaces);
        }

        protected void lnkremove_Click(object sender, EventArgs e)
        {
            parameters.Clear();
            parameters.Add("@colorid", Convert.ToInt32((colorid.Text)));
            string strsql = "update Color_master set UploadImage='' where colorid=@colorid";
            clsm.ExecuteQry_Parameter(strsql, parameters);
            parameters.Clear();
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + Convert.ToString(UploadImage.Text));
            
            UploadImage.Text = "";
            if (F1.Exists)
            {
                F1.Delete();
            }
            lnkremove.Visible = false;
            trsuccess.Visible = true;
            Image1.Visible = false;
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
                default:
                    return false;
            }

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (colorid.Text == "")
                {
                    if (File1.PostedFile.FileName != "")
                    {
                        if ((CheckImgType(File1.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                        UploadImage.Text = HttpUtility.HtmlEncode(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
                    }



                    string var = clsm.MasterSave(this, colorid.Parent, 15, mainclass.Mode.modeAdd, "Color_masterSP", Session["UserId"].ToString());

                    if (File1.PostedFile.FileName != "")
                    {
                        string strhomeimg = clsm.SendValue("Select UploadImage from Color_master where colorid=" + Convert.ToInt32(var)).ToString();
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + strhomeimg);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + strhomeimg);
                    }

                    Response.Redirect("color.aspx?add=add");

                }
                else
                {
                    if (File1.PostedFile.FileName != "")
                    {
                        if ((CheckImgType(File1.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                    }

                    string var = clsm.MasterSave(this, colorid.Parent, 15, mainclass.Mode.modeModify, "Color_masterSP", Session["UserId"].ToString());

                    if (File1.PostedFile.FileName != "")
                    {

                        FileInfo F5 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + UploadImage.Text);


                        if (F5.Exists)
                        {
                            F5.Delete();
                        }

                        UploadImage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "akm-" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));


                        FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + Convert.ToString(UploadImage.Text));
                        if (F2.Exists)
                        {
                            F2.Delete();
                        }

                        SqlConnection objcon2 = new SqlConnection(clsm.strconnect);
                        
                        objcon2.Open();
                        SqlCommand objcmd2 = new SqlCommand("update Color_master set UploadImage=@UploadImage where colorid=" + var + "", objcon2);
                        objcmd2.Parameters.Add(new SqlParameter("@UploadImage", UploadImage.Text));
                        objcmd2.ExecuteNonQuery();
                        objcon2.Close();
                      
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\SmallImages\\" + Convert.ToString(UploadImage.Text));
                    }



                    Response.Redirect("view_color.aspx?edit=edit");
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
            if (Conversion.Val(colorid.Text) == 0)
            {
                clsm.ClearallPanel(this, colorid.Parent);

            }
            else
            {
                Response.Redirect("view_color.aspx");
            }
        }
    }
}