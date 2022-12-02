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
    public partial class add_stream : System.Web.UI.Page
    {
        mainclass Clsm = new mainclass();
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if ((Page.IsPostBack == false))
            {

                Parameters.Clear();
                Clsm.Fillcombo_Parameter("select levelname,levelid from CourseLevel_Master  where status=1 order by displayorder", Parameters, levelid);



                if ((Conversion.Val(Request.QueryString["streamid"]) != 0))
                {
                    CKeditor1.ReadOnly = true;
                    Parameters.Clear();
                    Parameters.Add("@streamid", Conversion.Val(Request.QueryString["streamid"]));
                    Clsm.MoveRecord_Parameter(this, streamid.Parent, "select * from stream_Master where streamid=@streamid", Parameters);
                    CKeditor1.ReadOnly = false;
                    CKeditor1.Text = Server.HtmlDecode(stream_tdetail.Text);
                    if ((uploadimage.Text != ""))
                    {
                        Image1.ImageUrl = ("~/Uploads/SmallImages/" + uploadimage.Text);
                        Image1.Visible = true;
                        lnkremove.Visible = true;
                    }

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

        protected void btnsubmit_Click(object sender, System.EventArgs e)
        {
            try
            {
                string StrFileName;
                stream_tdetail.Text = Server.HtmlEncode(CKeditor1.Text);
                if ((Page.IsValid == true))
                {
                    CKeditor1.ReadOnly = true;
                    if (Convert.ToInt32(Clsm.MasterSave(this, streamid.Parent, 15, mainclass.Mode.modeCheckDuplicate, "stream_MasterSP", Convert.ToString((Session["UserId"])))) > 0)
                    {
                        CKeditor1.ReadOnly = false;
                        trnotice.Visible = true;
                        lblnotice.Text = "Duplicacy not allowed.";
                        return;
                    }

                    if ((Conversion.Val(streamid.Text) == 0))
                    {
                        if ((File1.PostedFile.FileName != ""))
                        {
                            if ((CheckImgType(Path.GetFileName(File1.PostedFile.FileName)) == false))
                            {
                                trnotice.Visible = true;
                                lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png\'";
                                return;
                            }

                            uploadimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        }

                        status.Checked = true;
                        CKeditor1.ReadOnly = true;
                        var var = Clsm.MasterSave(this, streamid.Parent, 15, mainclass.Mode.modeAdd, "stream_MasterSP", Convert.ToString(Session["UserId"]));
                        CKeditor1.ReadOnly = false;
                        if ((File1.PostedFile.FileName != ""))
                        {
                            Parameters.Clear();
                            Parameters.Add("@streamid", Conversion.Val(var));
                            StrFileName = Convert.ToString(Clsm.SendValue_Parameter("Select uploadimage from stream_Master where streamid=@streamid", Parameters));
                            FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + StrFileName)));
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }

                            File1.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + ("\\uploads\\SmallImages\\" + StrFileName)));
                        }

                        Clsm.ClearallPanel(this, streamid.Parent);
                        trsuccess.Visible = true;
                        lblsuccess.Text = "Record added successfully.";
                    }
                    else
                    {
                        CKeditor1.ReadOnly = true;
                        var var = Clsm.MasterSave(this, streamid.Parent, 15, mainclass.Mode.modeModify, "stream_MasterSP", Convert.ToString(Session["UserId"]));
                        CKeditor1.ReadOnly = false;
                        if ((File1.PostedFile.FileName != ""))
                        {
                            FileInfo F5 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + Server.HtmlDecode(uploadimage.Text))));
                            if (F5.Exists)
                            {
                                F5.Delete();
                            }

                            uploadimage.Text = HttpUtility.HtmlEncode(Path.GetFileName((var + ("ste_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")))));
                            FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + Server.HtmlDecode(uploadimage.Text))));
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }

                            // ' update banner file
                            SqlConnection objcon = new SqlConnection(Clsm.strconnect);
                            objcon.Open();
                            SqlCommand objcmd = new SqlCommand(("update stream_Master set uploadimage=@uploadimage where streamid="
                                            + (Conversion.Val(var) + "")), objcon);
                            objcmd.Parameters.Add(new SqlParameter("@uploadimage", Server.HtmlDecode(uploadimage.Text)));
                            objcmd.ExecuteNonQuery();
                            objcon.Close();
                            File1.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + ("\\uploads\\SmallImages\\" + Server.HtmlDecode(uploadimage.Text))));
                        }

                        Clsm.ClearallPanel(this, streamid.Parent);
                        Response.Redirect("view-stream.aspx?edit=edit");
                    }

                }

            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }

        }

        protected void btncancel_Click(object sender, System.EventArgs e)
        {
            if ((Conversion.Val(streamid.Text) != 0))
            {
                Response.Redirect("view-stream.aspx");
            }
            else
            {
                Clsm.ClearallPanel(this, streamid.Parent);
                CKeditor1.Text = "";
            }

        }
        protected void lnkremove_Click(object sender, System.EventArgs e)
        {
            if ((uploadimage.Text != ""))
            {
                FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + Server.HtmlDecode(uploadimage.Text))));
                if (F1.Exists)
                {
                    F1.Delete();
                }
            }
            Parameters.Clear();
            Parameters.Add("@streamid", double.Parse(Request.QueryString["streamid"]));
            Clsm.ExecuteQry_Parameter("update stream_Master set uploadimage='' where streamid=@streamid", Parameters);
            Image1.Visible = false;
            trsuccess.Visible = true;
            lnkremove.Visible = false;
            lblsuccess.Text = "File deleted successfully.";
        }
    }

}