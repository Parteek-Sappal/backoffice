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

namespace backoffice.office.Testimonials
{
    public partial class addtestimonials : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        string StrFileName;
        Hashtable Parameters = new Hashtable();

        protected void Page_Load(object sender, System.EventArgs e)
        {
            trerror.Visible = false;
            trnotice.Visible = false;
            trsuccess.Visible = false;
            LinkButton1.Visible = false;

            if ((Page.IsPostBack == false))
            {
                Parameters.Clear();
                clsm.Fillcombo_Parameter("Select Testimonialtype,Tesid,displayorder from Testimonials_Type where Status=1 order by displayorder" +
                    "", Parameters, Tesid);                
                if ((Conversion.Val(Request.QueryString["tid"]) != 0))
                {
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    Parameters.Clear();
                    Parameters.Add("@testimonialid", double.Parse(Request.QueryString["tid"]));
                    clsm.MoveRecord_Parameter(this, testimonialid.Parent, "Select * From Testimonials where testimonialid=@testimonialid", Parameters);
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    CKeditor1.Text = Server.HtmlDecode(testimonialdesc.Text);
                    CKeditor2.Text = Server.HtmlDecode(detaildesc.Text);
                    testimonialid.Text = HttpUtility.HtmlDecode(testimonialid.Text);
                    Testimonialname.Text = HttpUtility.HtmlDecode(Testimonialname.Text);
                    Tesid.Text = HttpUtility.HtmlDecode(Tesid.Text);
                    Uploadphoto.Text = HttpUtility.HtmlDecode(Uploadphoto.Text);
                    uploadvedio.Text = HttpUtility.HtmlDecode(uploadvedio.Text);
                    displayorder.Text = HttpUtility.HtmlDecode(displayorder.Text);
                    if ((Uploadphoto.Text != ""))
                    {
                        LinkButton1.Visible = true;
                        LinkButton1.Text = "Remove Image";
                        Image1.ImageUrl = ("~/Uploads/TestimonialImage/" + Uploadphoto.Text);
                        Image1.Visible = true;
                    }

                    if ((texttype.SelectedValue == "Video"))
                    {
                        uploadvedio.Visible = true;
                    }
                    else
                    {
                        uploadvedio.Visible = false;
                    }

                }

                if ((Request.QueryString["add"] == "add"))
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record added successfully.";
                }

            }

        }

        protected void btnsubmit_Click(object sender, System.EventArgs e)
        {
            try
            {
                testimonialdesc.Text = Server.HtmlEncode(CKeditor1.Text);
                detaildesc.Text = Server.HtmlEncode(CKeditor2.Text);
                testimonialid.Text = HttpUtility.HtmlEncode(testimonialid.Text);
                Testimonialname.Text = HttpUtility.HtmlEncode(Testimonialname.Text);
                Tesid.Text = HttpUtility.HtmlEncode(Tesid.Text);
                Uploadphoto.Text = HttpUtility.HtmlEncode(Uploadphoto.Text);
                uploadvedio.Text = HttpUtility.HtmlEncode(uploadvedio.Text);
                displayorder.Text = HttpUtility.HtmlEncode(displayorder.Text);
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;

                if ((Convert.ToUInt32(clsm.MasterSave(this, testimonialid.Parent, 25, mainclass.Mode.modeCheckDuplicate, "TestimonialsSP", Convert.ToString(Session["UserId"]))) > 0))
                {
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    trnotice.Visible = true;
                    lblnotice.Text = "This testimonials already exist.";
                    return;
                }

                if ((Conversion.Val(testimonialid.Text) == 0))
                {
                    if ((File1.PostedFile.FileName != ""))
                    {
                        if ((CheckImgType(File1.PostedFile.FileName) == false))
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png\'";
                            return;
                        }

                        Uploadphoto.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    }

                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    object var = clsm.MasterSave(this, testimonialid.Parent, 25, mainclass.Mode.modeAdd, "TestimonialsSP", Convert.ToString(Session["UserId"]));
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    if ((File1.PostedFile.FileName != ""))
                    {                        
                        Parameters.Clear();
                        Parameters.Add("@testimonialid", Conversion.Val(var));
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select Uploadphoto from Testimonials where testimonialid=@testimonialid", Parameters));
                        FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\TestimonialImage\\" + StrFileName));
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }

                        File1.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\TestimonialImage\\" + StrFileName));
                    }

                    Response.Redirect("addtestimonials.aspx?add=add");
                }
                else
                {
                    if ((File1.PostedFile.FileName != ""))
                    {
                        if ((CheckImgType(File1.PostedFile.FileName) == false))
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png\'";
                            return;
                        }

                    }

                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    object var = clsm.MasterSave(this, testimonialid.Parent, 25, mainclass.Mode.modeModify, "TestimonialsSP", Convert.ToString(Session["UserId"]));
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    if ((File1.PostedFile.FileName != ""))
                    {
                        FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\TestimonialImage\\" + Uploadphoto.Text));
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }

                        Uploadphoto.Text = HttpUtility.HtmlEncode(Path.GetFileName((var + ("testi_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")))));
                        FileInfo F2 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\TestimonialImage\\" + Server.HtmlDecode(Uploadphoto.Text)));
                        if (F2.Exists)
                        {
                            F2.Delete();
                        }

                        // ' update banner file
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand(("update Testimonials set uploadphoto=@uploadphoto where testimonialid="
                                        + (Conversion.Val(var) + "")), objcon);
                        objcmd.Parameters.Add(new SqlParameter("@uploadphoto", Server.HtmlDecode(Uploadphoto.Text)));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();
                        File1.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\TestimonialImage\\" + Server.HtmlDecode(Uploadphoto.Text)));
                    }

                    Response.Redirect("viewtestimonials.aspx?edit=edit");
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

        protected void btncancel_Click(object sender, System.EventArgs e)
        {
            if ((double.Parse(testimonialid.Text) == 0))
            {
                Response.Redirect("addtestimonials.aspx");
            }
            else
            {
                Response.Redirect("viewtestimonials.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, System.EventArgs e)
        {
            if ((LinkButton1.Text != ""))
            {
                FileInfo F2 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\TestimonialImage\\" + Server.HtmlDecode(Uploadphoto.Text)));
                if (F2.Exists)
                {
                    F2.Delete();
                }

            }           
            Parameters.Clear();
            Parameters.Add("@testimonialid", Conversion.Val(Request.QueryString["tid"]));
            clsm.ExecuteQry_Parameter("update Testimonials set uploadphoto=\'\' where testimonialid=@testimonialid", Parameters);
            Uploadphoto.Text = "";
            LinkButton1.Text = "";
            Image1.Visible = false;
        }


        protected void texttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((texttype.SelectedValue == "Video"))
            {

                uploadvedio.Visible = true;
            }
            else
            {
                uploadvedio.Visible = false;
            }

        }
    }
}