using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Data.SqlClient;

namespace backoffice.office.gallery
{
    public partial class addvedio : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trnotice.Visible = false;
            trsuccess.Visible = false;
            if (!Page.IsPostBack)
            {
                Bindalbum();
                galpageidbind();
                Int32 p = 0;
                if (Int32.TryParse(Request.QueryString["vid"], out p) == true)
                {
                    galpageidbind();
                   
                    Parameters.Clear();
                    Parameters.Add("@vedioid", Request.QueryString["vid"]);
                    clsm.MoveRecord_Parameter(this, vedioid.Parent, "Select * From vedio where vedioid=@vedioid", Parameters);
                    galpageidbind();
                    Parameters.Clear();
                    Parameters.Add("@vedioid", Request.QueryString["vid"]);
                    clsm.MoveRecord_Parameter(this, vedioid.Parent, "Select * From vedio where vedioid=@vedioid", Parameters);
                  

                    if (!string.IsNullOrEmpty(thumbnailimage.Text))
                    {
                        Image2.Visible = true;
                        Image2.ImageUrl = "../../Uploads/vedio/" + thumbnailimage.Text;
                        LinkButton2.Visible = false;
                    }
                }
                if (Convert.ToString(Request.QueryString["add"]) == "add")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record added successfully.";
                }
            }
        }
        private void Bindalbum()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select albumtitle,albumid from Album  where Status=1 and typeid=2 ", Parameters, Albumid);

        }
        private void galpageidbind()
        {

            Parameters.Clear();
            clsm.Fillcombo_Parameter("select (e.pagename  +'-'+ b.pagename) as pagename,e.pageid from pagemaster e,pagemaster b where e.parentid = b.pageid and e.pagename like '%gallery%'", Parameters, galpageid);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string StrFileName1 = null;                   
                    if (string.IsNullOrEmpty(vedioid.Text))
                    {
                        if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                        {
                            if ((CheckthumbnailType(File2.PostedFile.FileName)) == false)
                            {
                                trnotice.Visible = true;
                                lblnotice.Visible = true;
                                lblnotice.Text = "Please select a thumbnail with a thumbnail format extension of Either bmp,gif,jpeg or jpg";
                                return;
                            }
                            thumbnailimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        }
                        else
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a thumbnail with a thumbnail format extension of Either bmp,gif,jpeg or jpg";
                            return;
                        }

                        string var = clsm.MasterSave(this, vedioid.Parent, 11, mainclass.Mode.modeAdd, "vedioSP", Convert.ToString(Session["UserId"]));

                        if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                        {

                            Parameters.Clear();
                            Parameters.Add("@vedioid", var);
                            StrFileName1 = Convert.ToString(clsm.SendValue_Parameter("Select thumbnailimage from vedio where vedioid=@vedioid", Parameters));
                            FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\vedio\\" + StrFileName1);
                            if (F2.Exists)
                            {

                                Parameters.Clear();
                                Parameters.Add("@vedioid", var);
                                clsm.ExecuteQry_Parameter("delete from vedio where vedioid=@vedioid", Parameters);
                                trnotice.Visible = true;
                                lblnotice.Text = "File already exist, Please choose another name.";
                                return;
                            }
                            else
                            {
                                File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\vedio\\" + StrFileName1);
                            }
                        }
                        Response.Redirect("addvedio.aspx?add=add");
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                        {
                            if ((CheckthumbnailType(File2.PostedFile.FileName)) == false)
                            {
                                trnotice.Visible = true;
                                lblnotice.Text = "Please select a thumbnail with a thumbnail format extension of Either jpeg,bmp,gif,png or jpg ";
                                return;
                            }
                        }

                        string var = clsm.MasterSave(this, vedioid.Parent, 11, mainclass.Mode.modeModify, "vedioSP", Convert.ToString(Session["UserId"]));

                        if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                        {
                            thumbnailimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "vfile_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                            FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\vedio\\" + Convert.ToString(thumbnailimage.Text));
                            if (F2.Exists)
                            {
                                F2.Delete();
                            }

                            SqlConnection objcon = new SqlConnection(clsm.strconnect);
                            objcon.Open();
                            SqlCommand objcmd = new SqlCommand("update vedio set thumbnailimage=@thumbnailimage where vedioid=" + var + "", objcon);
                            objcmd.Parameters.Add(new SqlParameter("@thumbnailimage", thumbnailimage.Text));
                            objcmd.ExecuteNonQuery();
                            objcon.Close();

                            File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\vedio\\" + thumbnailimage.Text);
                        }
                        Response.Redirect("viewvedio.aspx?edit=edit");
                    }
                }
                catch (Exception ex)
                {
                    trerror.Visible = true;
                    lblerror.Text = ex.Message.ToString();
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["vid"]))
            {
                Response.Redirect("viewvedio.aspx");
            }
            else
            {
                clsm.ClearallPanel(this, vedioid.Parent);
                Response.Redirect("addvedio.aspx");
            }
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\vedio\\" + thumbnailimage.Text);
            if (F2.Exists)
            {
                F2.Delete();
            }

            Parameters.Clear();
            Parameters.Add("@vedioid", vedioid.Text);
            clsm.ExecuteQry_Parameter("update vedio set thumbnailimage='' where vedioid=@vedioid", Parameters);
            thumbnailimage.Text = "";
            LinkButton2.Visible = false;
            Image2.Visible = false;
        }
        public bool CheckthumbnailType(string fileName)
        {
            string ext1 = Path.GetExtension(fileName);
            switch (ext1.ToLower())
            {
                case ".jpeg":
                    return true;
                case ".jpg":
                    return true;
                case ".bmp":
                    return true;
                case ".gif":
                    return true;
                case ".png":
                    return true;
                default:
                    return false;
            }
        }
    }
}