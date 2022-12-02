using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace backoffice.office.gallery
{
    public partial class addalbum : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        string StrFileName = null;
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            LinkButton1.Visible = false;
            if (!Page.IsPostBack)
            {
                Parameters.Clear();
                clsm.Fillcombo_Parameter(" select ntype,ntypeid from newstype where  ntypeid=4 order by  displayorder", Parameters, ntypeid);
                ntypeid.Items.RemoveAt(0);
                dropboxbind();
                dropboxload();
                bindalbumtype();
                galpageidbind();

                Int32 p = 0;
                if (Int32.TryParse(Request.QueryString["alid"], out p) == true)
                {
                    galpageidbind();
                    CKeditor1.ReadOnly = true;
                    Parameters.Clear();


                    Parameters.Clear();
                    Parameters.Add("@albumid", Convert.ToString(Request.QueryString["alid"]));
                    clsm.MoveRecord_Parameter(this, albumid.Parent, "select * from album where albumid=@albumid", Parameters);
                    CKeditor1.ReadOnly = false;


                    dropboxbind();
                    dropboxload();
                    CKeditor1.ReadOnly = true;
                    galpageidbind();
                    Parameters.Clear();
                    Parameters.Add("@albumid", Convert.ToString(Request.QueryString["alid"]));
                    clsm.MoveRecord_Parameter(this, albumid.Parent, "select * from album where albumid=@albumid", Parameters);

                    CKeditor1.ReadOnly = false;
                    CKeditor1.Text = Server.HtmlDecode(AlbumDesc.Text);

                    if (!string.IsNullOrEmpty(UploadAImage.Text))
                    {
                        Image1.Visible = true;
                        Image1.ImageUrl = "../../Uploads/LargeImages/" + UploadAImage.Text;
                    }
                    if (!string.IsNullOrEmpty(UploadAImage.Text))
                    {
                        LinkButton1.Visible = true;
                        LinkButton1.Text = "Remove Image";
                    }
                    else
                    {
                        LinkButton1.Text = "";
                    }


                    if (!string.IsNullOrEmpty(imagebanner.Text))
                    {
                        Imageban.Visible = true;
                        Imageban.ImageUrl = "../../Uploads/LargeImages/" + imagebanner.Text;
                    }
                    if (!string.IsNullOrEmpty(imagebanner.Text))
                    {
                        LinkButton2.Visible = true;
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
        private void galpageidbind()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select (e.pagename  +'-'+ b.pagename) as pagename,e.pageid from pagemaster e,pagemaster b where e.parentid = b.pageid and e.pagename like '%gallery%'", Parameters, galpageid);
        }
        private void bindalbumtype()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select typename,typeid from Albumtype where status=1", Parameters, typeid);

        }


        public DataTable GetData()
        {
            DataTable tbldata = new DataTable();
            Parameters.Clear();
            DataSet ds1 = clsm.senddataset_Parameter("select * from Album", Parameters);
            tbldata = ds1.Tables[0].Copy();
            ds1.Dispose();
            return tbldata;
        }
        private void dropboxbind()
        {
            DataTable tbl = new DataTable();
            tbl = (DataTable)GetData();
            DataSet ds = new DataSet();
            ds.Tables.Add(tbl);

            DataRelation rel = new DataRelation("ParentChild", tbl.Columns["Albumid"], tbl.Columns["ParentId"], false);
            rel.Nested = true;

            ds.Relations.Add(rel);

            Repeater1.DataSource = Samples.OrderedHierarchy.GetOrderedTable(tbl, "ParentChild", "ParentId");
            Repeater1.DataBind();

            Parentid.DataSource = Samples.OrderedHierarchy.GetOrderedTable(tbl, "ParentChild", "ParentId");
            Parentid.DataTextField = "Albumtitle";
            Parentid.DataValueField = "Albumid";
            Parentid.DataBind();
        }

        private void dropboxload()
        {
            DataTable tbl = new DataTable("ddldata");
            if (Parentid.Items.Count > 0)
            {
                int j = 0;
                for (j = 0; j <= Parentid.Items.Count - 1; j++)
                {
                    TextBox txt3 = (TextBox)Repeater1.Items[j].FindControl("txt3");
                    Parentid.Items[j].Text = Convert.ToString(Convert.ToString(txt3.Text)) + Parentid.Items[j].Text;
                }
            }
            Parentid.Items.Insert(0, "Main Category");
            Parentid.Items[0].Value = "0";
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
                case ".webp":
                    return true;
                case ".svg":
                    return true;
                default:
                    return false;
            }
        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    AlbumDesc.Text = Server.HtmlEncode(CKeditor1.Text);
                    CKeditor1.ReadOnly = true;
                    if (Convert.ToInt32(Convert.ToString(clsm.MasterSave(this, albumid.Parent, 22, mainclass.Mode.modeCheckDuplicate, "AlbumSP", Convert.ToString(Session["UserId"])))) > 0)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "This Album Already Exist.";
                        CKeditor1.ReadOnly = false;
                        return;
                    }

                    if (string.IsNullOrEmpty(albumid.Text))
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
                            UploadAImage.Text = Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
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
                            imagebanner.Text = Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                        }



                        CKeditor1.ReadOnly = true;
                        string var = clsm.MasterSave(this, albumid.Parent, 22, mainclass.Mode.modeAdd, "AlbumSP", Convert.ToString(Session["UserId"]));
                        CKeditor1.ReadOnly = false;
                        if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                        {
                            //StrFileName = clsm.SendValue("Select uploadaimage from Album where albumid=" & var)
                            Parameters.Clear();
                            Parameters.Add("@albumid", var);
                            StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select uploadaimage from Album where albumid=@albumid", Parameters));
                            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + StrFileName);
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }
                            File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\LargeImages\\" + StrFileName);
                        }
                        if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                        {
                            //StrFileName = clsm.SendValue("Select uploadaimage from Album where albumid=" & var)
                            Parameters.Clear();
                            Parameters.Add("@albumid", var);
                            StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select imagebanner from Album where albumid=@albumid", Parameters));
                            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + StrFileName);
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }
                            File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\LargeImages\\" + StrFileName);
                        }

                        Response.Redirect("addalbum.aspx?add=add");
                    }
                    else
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
                        }
                        CKeditor1.ReadOnly = true;
                        string var = clsm.MasterSave(this, albumid.Parent, 22, mainclass.Mode.modeModify, "AlbumSP", Convert.ToString(Session["UserId"]));
                        CKeditor1.ReadOnly = false;
                        if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                        {
                            UploadAImage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "al_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + UploadAImage.Text);
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }
                            //' update banner file
                            SqlConnection objcon = new SqlConnection(clsm.strconnect);
                            objcon.Open();
                            SqlCommand objcmd = new SqlCommand("update Album set uploadaimage=@uploadaimage where albumid=" + var + "", objcon);
                            objcmd.Parameters.Add(new SqlParameter("@uploadaimage", UploadAImage.Text));
                            objcmd.ExecuteNonQuery();
                            objcon.Close();

                            File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\LargeImages\\" + UploadAImage.Text);
                        }


                        if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                        {
                            imagebanner.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "iban_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + imagebanner.Text);
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }
                            //' update banner file
                            SqlConnection objcon = new SqlConnection(clsm.strconnect);
                            objcon.Open();
                            SqlCommand objcmd = new SqlCommand("update Album set imagebanner=@imagebanner where albumid=" + var + "", objcon);
                            objcmd.Parameters.Add(new SqlParameter("@imagebanner", imagebanner.Text));
                            objcmd.ExecuteNonQuery();
                            objcon.Close();

                            File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\LargeImages\\" + imagebanner.Text);
                        }
                        Response.Redirect("viewalbum.aspx?edit=edit");
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

            if (string.IsNullOrEmpty(albumid.Text))
            {
                clsm.ClearallPanel(this, albumid.Parent);
            }
            else
            {
                Response.Redirect("viewalbum.aspx");
            }

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UploadAImage.Text))
            {
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + UploadAImage.Text);
                if (F1.Exists)
                {
                    F1.Delete();
                }

            }
            //clsm.ExecuteQry("update album set UploadAImage='' WHERE albumid=" & Val(Request.QueryString("alid")) & "")
            Parameters.Clear();
            Parameters.Add("@albumid", Convert.ToString(Request.QueryString["alid"]));
            clsm.ExecuteQry_Parameter("update album set UploadAImage='' WHERE albumid=@albumid", Parameters);
            UploadAImage.Text = "";
            Image1.Visible = false;
            LinkButton1.Text = "";


        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(imagebanner.Text))
            {
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + imagebanner.Text);
                if (F1.Exists)
                {
                    F1.Delete();
                }

            }
            //clsm.ExecuteQry("update album set UploadAImage='' WHERE albumid=" & Val(Request.QueryString("alid")) & "")
            Parameters.Clear();
            Parameters.Add("@albumid", Convert.ToString(Request.QueryString["alid"]));
            clsm.ExecuteQry_Parameter("update album set imagebanner='' WHERE albumid=@albumid", Parameters);
            imagebanner.Text = "";
            Imageban.Visible = false;
            LinkButton2.Text = "";


        }
    }
}