using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace backoffice.office.gallery
{
    public partial class addphotogallery : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        string StrFileName = null;
        string StrFileName2 = null;
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            LinkButton1.Visible = false;
            if (!Page.IsPostBack)
            {
                dropboxbind();
                dropboxload();
                Int32 p = 0;
                if (Int32.TryParse(Request.QueryString["phid"], out p) == true)
                {
                    
                    Parameters.Clear();
                    Parameters.Add("@photoid", Convert.ToString(Request.QueryString["phid"]));
                    clsm.MoveRecord_Parameter(this, photoid.Parent, "select * from albumphoto where photoid=@photoid", Parameters);
                    dropboxbind();
                    dropboxload();
                    
                    Parameters.Clear();
                    Parameters.Add("@photoid", Convert.ToString(Request.QueryString["phid"]));
                    clsm.MoveRecord_Parameter(this, photoid.Parent, "select * from albumphoto where photoid=@photoid", Parameters);

                    if (!string.IsNullOrEmpty(Uploadphoto.Text))
                    {
                        Image1.Visible = true;
                        Image1.ImageUrl = "~/Uploads/LargeImages/" + Uploadphoto.Text;
                    }
                    if (!string.IsNullOrEmpty(Uploadphoto.Text))
                    {
                        LinkButton1.Visible = false;
                        LinkButton1.Text = "Remove Image";
                    }
                    else
                    {
                        LinkButton1.Text = "";
                    }

                    if (!string.IsNullOrEmpty(largeimage.Text))
                    {
                        Image2.Visible = true;
                        Image2.ImageUrl = "~/Uploads/LargeImages/" + largeimage.Text;
                    }
                    if (!string.IsNullOrEmpty(largeimage.Text))
                    {
                        LinkButton2.Visible = false;
                        LinkButton2.Text = "Remove Image";
                    }
                    else
                    {
                        LinkButton2.Text = "";
                    }

                }
                if (Convert.ToString(Request.QueryString["add"]) == "add")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Added Successfully.";
                }
            }
        }
        #region << all methods>>

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
                case ".webp":
                    return true;
                case ".svg":
                    return true;
                default:
                    return false;
            }
        }


        private string Pad(Int32 numberOfSpaces)
        {
            string Spaces = null;

            for (Int32 items = 1; items <= numberOfSpaces; items++)
            {
                Spaces += "&nbsp;&nbsp;&raquo;&nbsp;&nbsp;";
            }
            return Server.HtmlDecode(Spaces);
        }

        public DataTable GetData()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("Id", typeof(Int32)));
            tbl.Columns.Add(new DataColumn("ParentId", typeof(Int32)));
            tbl.Columns.Add(new DataColumn("Name", typeof(string)));

            Parameters.Clear();
            DataSet ds1 = clsm.senddataset_Parameter("select * from Album", Parameters);
            Int32 i = default(Int32);
            for (i = 0; i <= ds1.Tables[0].Rows.Count - 1; i++)
            {
                DataRow row = tbl.NewRow();
                row["Id"] = ds1.Tables[0].Rows[i]["Albumid"];
                row["ParentId"] = ds1.Tables[0].Rows[i]["Parentid"];
                row["Name"] = ds1.Tables[0].Rows[i]["Albumtitle"];
                tbl.Rows.Add(row);
            }

            ds1.Dispose();
            return tbl;
        }

        private void dropboxbind()
        {
            DataTable tbl = GetData();
            DataSet ds = new DataSet();
            ds.Tables.Add(tbl);

            DataRelation rel = new DataRelation("ParentChild", tbl.Columns["Id"], tbl.Columns["ParentId"], false);
            rel.Nested = true;
            ds.Relations.Add(rel);
            Repeater1.DataSource = Samples.OrderedHierarchy.GetOrderedTable(tbl, "ParentChild", "ParentId");
            Repeater1.DataBind();

            albumid.DataSource = Samples.OrderedHierarchy.GetOrderedTable(tbl, "ParentChild", "ParentId");
            albumid.DataTextField = "Name";
            albumid.DataValueField = "Id";
            albumid.DataBind();
        }

        private void dropboxload()
        {
            DataTable tbl = new DataTable();
            if (albumid.Items.Count > 0)
            {
                int j = 0;
                for (j = 0; j <= albumid.Items.Count - 1; j++)
                {
                    TextBox txt3 = (TextBox)Repeater1.Items[j].FindControl("txt3");
                    albumid.Items[j].Text = Pad(Convert.ToInt32(txt3.Text)) + albumid.Items[j].Text;
                }
            }
            albumid.Items.Insert(0, "Select");
            albumid.Items[0].Value = "0";
        }

        public bool CheckFileType(string fileName)
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


        #endregion


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (string.IsNullOrEmpty(photoid.Text))
                    {
                        if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                        {
                            if ((CheckImgType(File1.PostedFile.FileName)) == false)
                            {
                                trnotice.Visible = true;
                                lblnotice.Visible = true;
                                lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                                return;
                            }
                            Uploadphoto.Text = Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                        }
                        else
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;

                        }

                        if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                        {
                            if ((CheckImgType(File2.PostedFile.FileName)) == false)
                            {
                                trnotice.Visible = true;
                                lblnotice.Visible = true;
                                lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                                return;
                            }
                            largeimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        }
                     
                        string var = clsm.MasterSave(this, photoid.Parent, 7, mainclass.Mode.modeAdd, "albumphotosp", HttpUtility.HtmlEncode(Path.GetFileName(Convert.ToString(Session["UserId"]))));

                        if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                        {
                            Parameters.Clear();
                            Parameters.Add("@photoid", var);
                            StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select Uploadphoto from albumphoto where photoid=@photoid", Parameters));
                            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + StrFileName);
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }
                            File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\LargeImages\\" + StrFileName);
                        }

                        if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                        {
                            Parameters.Clear();
                            Parameters.Add("@photoid", var);
                            StrFileName2 = Convert.ToString(clsm.SendValue_Parameter("Select largeimage from albumphoto where photoid=@photoid", Parameters));
                            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + StrFileName2);
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }
                            File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\LargeImages\\" + StrFileName2);
                        }
                        Response.Redirect("addphotogallery.aspx?add=add");
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                        {
                            if ((CheckImgType(File1.PostedFile.FileName)) == false)
                            {
                                trnotice.Visible = true;
                                lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                        {
                            if ((CheckImgType(File2.PostedFile.FileName)) == false)
                            {
                                trnotice.Visible = true;
                                lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                                return;
                            }
                        }
                        string var = clsm.MasterSave(this, photoid.Parent, 7, mainclass.Mode.modeModify, "albumphotosp", Convert.ToString(Session["UserId"]));

                        if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                        {
                            Uploadphoto.Text = Path.GetFileName(var + "pg_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + Uploadphoto.Text);
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }
                            //' update banner file
                            SqlConnection objcon = new SqlConnection(clsm.strconnect);
                            objcon.Open();
                            SqlCommand objcmd = new SqlCommand("update Albumphoto set uploadphoto=@uploadphoto where photoid=" + var + "", objcon);
                            objcmd.Parameters.Add(new SqlParameter("@uploadphoto", Uploadphoto.Text));
                            objcmd.ExecuteNonQuery();
                            objcon.Close();

                            File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\LargeImages\\" + Uploadphoto.Text);
                        }
                        if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                        {
                            largeimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "pgl_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + largeimage.Text);
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }
                            SqlConnection objcon2 = new SqlConnection(clsm.strconnect);
                            objcon2.Open();
                            SqlCommand objcmd2 = new SqlCommand("update Albumphoto set largeimage=@largeimage where photoid=" + var + "", objcon2);
                            objcmd2.Parameters.Add(new SqlParameter("@largeimage", HttpUtility.HtmlEncode(Path.GetFileName(largeimage.Text))));
                            objcmd2.ExecuteNonQuery();
                            objcon2.Close();

                            File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\LargeImages\\" + largeimage.Text);
                        }
                        Response.Redirect("viewphotogallery.aspx?edit=edit");
                    }
                }
                catch (Exception ex)
                {
                    trerror.Visible = true;
                    lblerror.Text = ex.Message;
                }
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Convert.ToString(photoid.Text)))
            {
                clsm.ClearallPanel(this, photoid.Parent);
            }
            else
            {
                Response.Redirect("viewphotogallery.aspx");
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(LinkButton1.Text))
            {
                FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + Uploadphoto.Text);
                if (F2.Exists)
                {
                    F2.Delete();
                }
            }

            Parameters.Clear();
            Parameters.Add("@photoid", Convert.ToInt32(Request.QueryString["phid"]));
            clsm.ExecuteQry_Parameter("update albumphoto set uploadphoto='' where photoid=@photoid", Parameters);
            Uploadphoto.Text = "";
            LinkButton1.Text = "";
            Image1.Visible = false;

        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(LinkButton2.Text))
            {
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + Uploadphoto.Text);
                if (F1.Exists)
                {
                    F1.Delete();
                }

            }

            Parameters.Clear();
            Parameters.Add("@photoid", Convert.ToInt32(Request.QueryString["phid"]));
            clsm.ExecuteQry_Parameter("update albumphoto set largeimage='' where photoid=@photoid", Parameters);
            largeimage.Text = "";
            LinkButton2.Text = "";
            Image2.Visible = false;

        }
    }
}