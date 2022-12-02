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

namespace backoffice.office.masters
{
    public partial class departments : System.Web.UI.Page
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
                Int32 p = 0;
                if (Int32.TryParse(Request.QueryString["id"], out p) == true)

                {
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;                    
                    Parameters.Clear();
                    Parameters.Add("@deptid", Convert.ToInt32(Request.QueryString["id"]));
                    clsm.MoveRecord_Parameter(this, deptid.Parent, "select * from Department_Master where deptid=@deptid", Parameters);
                    CKeditor1.ReadOnly = false;
                    CKeditor1.Text = Server.HtmlDecode(departmentdetail.Text);
                    CKeditor2.ReadOnly = false;
                    CKeditor2.Text = Server.HtmlDecode(smalldesc.Text);

                    if (!string.IsNullOrEmpty(banner.Text))
                    {
                        Image1.ImageUrl = "~/Uploads/banner/" + banner.Text;
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

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string StrFileName = null;
                departmentdetail.Text = Server.HtmlEncode(CKeditor1.Text);
                smalldesc.Text = Server.HtmlEncode(CKeditor2.Text);

                if (Page.IsValid == true)
                {
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    if (Convert.ToInt32(clsm.MasterSave(this, deptid.Parent, 12, mainclass.Mode.modeCheckDuplicate, "Department_MasterSP", Convert.ToString((Session["UserId"])))) > 0)
                    {
                        CKeditor1.ReadOnly = false;
                        CKeditor2.ReadOnly = false;
                        trnotice.Visible = true;
                        lblnotice.Text = "Duplicacy not allowed.";

                        return;
                    }
                    if (string.IsNullOrEmpty(deptid.Text))
                    {
                        if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                        {
                            if ((CheckImgType(Path.GetFileName(File1.PostedFile.FileName))) == false)
                            {
                                trnotice.Visible = true;
                                lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                                return;
                            }
                            banner.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));

                        }

                        status.Checked = true;
                        CKeditor1.ReadOnly = true;
                        CKeditor2.ReadOnly = true;

                        string var = clsm.MasterSave(this, deptid.Parent, 12, mainclass.Mode.modeAdd, "Department_MasterSP", Convert.ToString(Session["UserId"]));
                        CKeditor1.ReadOnly = false;
                        CKeditor2.ReadOnly = false;
                        if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                        {
                            
                            Parameters.Clear();
                            Parameters.Add("@deptid", Convert.ToInt32(var));
                            StrFileName = clsm.SendValue_Parameter("Select banner from Department_Master where deptid=@deptid", Parameters).ToString();
                            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + StrFileName);
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }
                            File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\banner\\" + StrFileName);
                        }
                        clsm.ClearallPanel(this, deptid.Parent);
                        trsuccess.Visible = true;
                        lblsuccess.Text = "Record added successfully.";
                    }
                    else
                    {
                        status.Checked = true;
                        CKeditor1.ReadOnly = true;
                        CKeditor2.ReadOnly = true;
                        
                        string var = clsm.MasterSave(this, deptid.Parent, 12, mainclass.Mode.modeModify, "Department_MasterSP", Convert.ToString(Session["UserId"]));
                        CKeditor1.ReadOnly = false;
                        CKeditor2.ReadOnly = false;
                        if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                        {
                            FileInfo F5 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + banner.Text);
                            if (F5.Exists)
                            {
                                F5.Delete();
                            }
                            banner.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "deptbanner_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + banner.Text);
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }
                            //' update banner file
                            SqlConnection objcon = new SqlConnection(clsm.strconnect);
                            objcon.Open();
                            SqlCommand objcmd = new SqlCommand("update Department_Master set banner=@banner where deptid=" + Convert.ToInt32(var) + "", objcon);
                            objcmd.Parameters.Add(new SqlParameter("@banner", Server.HtmlDecode(banner.Text)));
                            objcmd.ExecuteNonQuery();
                            objcon.Close();

                            File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\banner\\" + Server.HtmlDecode(banner.Text));
                        }


                        clsm.ClearallPanel(this, deptid.Parent);
                        Response.Redirect("viewdepartment.aspx?edit=edit");
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
            if (Convert.ToInt32(deptid.Text) != 0)
            {
                Response.Redirect("viewdepartment.aspx");
            }
            else
            {
                clsm.ClearallPanel(this, deptname.Parent);
                CKeditor1.Text = "";
                CKeditor2.Text = "";
            }

        }
    }
}