using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualBasic;

namespace backoffice.office.masters
{
    public partial class addcoursetype : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        public HttpCookie AUserSession = null;
        Random random = new Random();
        Hashtable Parameters = new Hashtable();
        Enc_Decyption enc = new Enc_Decyption();
        protected void Page_Load(object sender, EventArgs e)
        {

            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;


            if ((Page.IsPostBack == false))
            {
                if ((Conversion.Val(Request.QueryString["ctid"]) != 0))
                {
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    Parameters.Clear();
                    Parameters.Add("@ctid", Conversion.Val(Request.QueryString["ctid"]));
                    clsm.MoveRecord_Parameter(this, ctid.Parent, "select * from coursetype where ctid=@ctid", Parameters);
                    CKeditor1.ReadOnly = false;
                    CKeditor1.Text = Server.HtmlDecode(details.Text);

                    CKeditor2.ReadOnly = false;
                    CKeditor2.Text = Server.HtmlDecode(pdetails.Text);

                    if ((uploadbanner.Text != ""))
                    {
                        Image1.ImageUrl = ("~/Uploads/SmallImages/" + uploadbanner.Text);
                        Image1.Visible = true;
                        lnkremove.Visible = true;
                    }

                }

            }

        }
        protected void btnsubmit_Click(object sender, System.EventArgs e)
        {
            try
            {
                string StrFileName;
                details.Text = Server.HtmlEncode(CKeditor1.Text);
                pdetails.Text = Server.HtmlEncode(CKeditor2.Text);
                if ((Page.IsValid == true))
                {

                    if ((Conversion.Val(ctid.Text) == 0))
                    {

                        if ((File1.PostedFile.FileName != ""))
                        {
                            if ((CheckImgType(Path.GetFileName(File1.PostedFile.FileName)) == false))
                            {
                                trnotice.Visible = true;
                                lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png\'";
                                return;
                            }

                            uploadbanner.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        }

                        status.Checked = true;
                        CKeditor1.ReadOnly = true;
                        CKeditor2.ReadOnly = true;
                        object var = clsm.MasterSave(this, ctid.Parent, 18, mainclass.Mode.modeAdd, "coursetypeSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])));
                        CKeditor1.ReadOnly = false;
                        CKeditor2.ReadOnly = false;
                        if ((File1.PostedFile.FileName != ""))
                        {
                            Parameters.Clear();
                            Parameters.Add("@ctid ", Conversion.Val(var));
                            StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select uploadbanner from coursetype where ctid=@ctid ", Parameters));
                            FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + StrFileName));

                            if (F1.Exists)
                            {
                                F1.Delete();
                            }

                            File1.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + ("\\uploads\\SmallImages\\" + StrFileName)));
                        }

                        clsm.ClearallPanel(this, ctid.Parent);
                        trsuccess.Visible = true;
                        lblsuccess.Text = "Record added successfully.";
                    }
                    else
                    {                        
                        CKeditor1.ReadOnly = true;
                        CKeditor2.ReadOnly = true;
                        object var = clsm.MasterSave(this, ctid.Parent, 18, mainclass.Mode.modeModify, "coursetypeSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])));
                        CKeditor1.ReadOnly = false;
                        CKeditor2.ReadOnly = false;
                        if ((File1.PostedFile.FileName != ""))
                        {
                            FileInfo F5 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + Server.HtmlDecode(uploadbanner.Text))));
                            if (F5.Exists)
                            {
                                F5.Delete();
                            }

                            uploadbanner.Text = HttpUtility.HtmlEncode(Path.GetFileName((var + ("ct_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")))));
                            FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + Server.HtmlDecode(uploadbanner.Text)));
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }

                            // ' update banner file
                            SqlConnection objcon = new SqlConnection(clsm.strconnect);
                            objcon.Open();
                            SqlCommand objcmd = new SqlCommand(("update coursetype set uploadbanner=@uploadbanner where ctid="
                                            + (Conversion.Val(var) + "")), objcon);
                            objcmd.Parameters.Add(new SqlParameter("@uploadbanner", Server.HtmlDecode(uploadbanner.Text)));
                            objcmd.ExecuteNonQuery();
                            objcon.Close();
                            File1.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\SmallImages\\" + Server.HtmlDecode(uploadbanner.Text)));
                        }

                        clsm.ClearallPanel(this, ctid.Parent);
                        Response.Redirect("viewcoursetype.aspx?edit=edit");
                    }

                }

            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
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
    }
}