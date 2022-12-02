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

namespace backoffice.office.Imagepath
{
    public partial class imagefilepath : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        public HttpCookie AUserSession = null;
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (Page.IsPostBack == false)
            {
                griddata();
            }
        }

        protected void griddata()
        {
            Label1.Visible = false;
            string strq2 = null;
            Parameters.Clear();
            strq2 = "select * from Imagefileupload  where 1=1";
            strq2 += " order by trdate desc";
            clsm.GridviewData_Parameter(GridView1, strq2, Parameters);
            if (GridView1.Rows.Count == 0)
            {
                trnotice.Visible = true;
                lblnotice.Text = "Record(s) not found.";
            }
        }
        public bool CheckFileType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".pdf":
                    return true;
                case ".doc":
                    return true;
                case ".docx":
                    return true;
                case ".xls":
                    return true;
                case ".xlsx":
                    return true;
                case ".txt":
                    return true;
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                string StrFileName = null;
                Label1.Visible = true;
                if (string.IsNullOrEmpty(Fileid.Text))
                {
                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        if ((CheckFileType(Path.GetFileName(File1.PostedFile.FileName))) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of gif,png,jpg,jpeg,Pdf,bmp,doc, docx,xls,xlsx, txt";
                            return;
                        }
                        UploadFile.Text = HttpUtility.HtmlEncode(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
                    }
                    else
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of gif,png,jpg,jpeg,Pdf,bmp,doc, docx,xls,xlsx, txt";
                        return;

                    }
                    //*************************************
                    string var = clsm.MasterSave(this, Label1.Parent, 5, mainclass.Mode.modeAdd, "ImagefileuploadSP", Session["UserId"].ToString());

                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        Parameters.Clear();
                        Parameters.Add("@fileid", Convert.ToInt32(var));
                        StrFileName = clsm.SendValue_Parameter("Select UploadFile from Imagefileupload where fileid=@fileid", Parameters).ToString();
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Image\\" + StrFileName);
                        if (F1.Exists)
                        {
                            Parameters.Clear();
                            Parameters.Add("@fileid", Convert.ToInt32(var));
                            clsm.ExecuteQry_Parameter("delete from Imagefileupload where fileid=@fileid", Parameters);
                            trnotice.Visible = true;
                            lblnotice.Text = "File already exist, Please choose another name.";
                            return;
                        }
                        else
                        {
                            File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\Image\\" + StrFileName);
                        }
                    }
                    FileTitle.Text = "/Uploads/image/" + StrFileName;
                    Parameters.Clear();
                    Parameters.Add("@fileid", Convert.ToInt32(var));
                    Parameters.Add("@filetitle", "/Uploads/image/" + StrFileName);
                    clsm.ExecuteQry_Parameter("update Imagefileupload set filetitle=@filetitle where fileid=@fileid", Parameters);
                    Label2.Text = "/Uploads/image/" + StrFileName;
                    Label2.Visible = true;

                    trsuccess.Visible = true;
                    lblsuccess.Text = "File/Image Added Successfully.";
                    griddata();
                  
                }
                else
                {

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
            if (Convert.ToInt32(Fileid.Text) == 0)
            {
                clsm.ClearallPanel(this, Label1.Parent);
            }


        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");


                Label lbldown = e.Row.FindControl("lbldown") as Label;

            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "downbtn")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lbldown = row.FindControl("lbldown") as Label;
                Response.Redirect("~/Office/DownloadFile.aspx?D=~/Uploads/Image/" + lbldown.Text);
            }

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                griddata();
            }
            catch (Exception ex)
            {
                Label1.Visible = true;
                Label1.Text = ex.Message.ToString();
            }

        }
    }
}