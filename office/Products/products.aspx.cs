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
using Microsoft.VisualBasic;

namespace backoffice.office.Products
{
    public partial class products : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        public HttpCookie AUserSession = null;
        Hashtable Parameters = new Hashtable();
        string StrFileName;
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (Page.IsPostBack == false)
            {
                BindCategories();
                // BindSubCategories();
                BindLook();
                Bindcoat();
                Bindsize();
                BindModel();
                Bindtype();
                Bindcolor();
                BindUOM();
                BindEPPD();
                if (Conversion.Val(Request.QueryString["pid"]) > 0)
                {

                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;

                    Parameters.Clear();
                    Parameters.Add("@productid", Convert.ToInt32(Request.QueryString["pid"]));
                    clsm.MoveRecord_Parameter(this, productid.Parent, "select * from Products where productid=@productid", Parameters);
                    //BindSubCategories();


                    //Parameters.Clear();
                    //Parameters.Add("@productid", Convert.ToInt32(Request.QueryString["pid"]));
                    //clsm.MoveRecord_Parameter(this, productid.Parent, "select * from Products where productid=@productid", Parameters);

                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    CKeditor2.Text = Server.HtmlDecode(productdetail.Text);
                    CKeditor1.Text = Server.HtmlDecode(shortdetail.Text);

                    if (!string.IsNullOrEmpty(UploadAImage.Text.Trim()))
                    {
                        File2.Visible = true;
                        LinkButton1.Visible = true;
                        Image1.Visible = true;
                        Image1.ImageUrl = "../../Uploads/ProductsImage/" + UploadAImage.Text;
                    }
                    else
                    {
                        LinkButton1.Visible = false;
                    }

                }

            }

        }

        protected void BindCategories()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select category,seriesid from productcate where status = 1 order by displayorder", Parameters, seriesid);
        }
        protected void BindLook()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select featuretitle,lookid from feature_master where status=1 order by displayorder", Parameters, lookid);
        }
        protected void Bindsize()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select Sizetitle,sizeid from Size_master where status=1 order by displayorder", Parameters, sizeid);
        }
        protected void Bindcoat()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select titlename,coatid from tblcoat where status=1 order by displayorder", Parameters, coatid);
        }
        protected void BindModel()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select orientationtitle,modelid from orientation_master where status=1 order by displayorder", Parameters, modelid);
        }
        protected void Bindtype()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select typetitle,typeid from Type_master where status=1 order by displayorder", Parameters, typeid);
        }
        protected void Bindcolor()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select colortitle,colorid from Color_master where status=1 order by displayorder", Parameters, colorid);
        }
        protected void BindUOM()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select uomtitle,uomid from uom where status=1 order by displayorder", Parameters, uomid);
        }
        protected void BindEPPD()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select eppdtitle,eppdid from eppd where status=1 order by displayorder", Parameters, eppdid);
        }

        //protected void BindSubCategories()
        //{
        //    string sqlstr = "select category,psubcatid from productsubcate where 1=1 and status = 1";
        //    Parameters.Clear();
        //    if (Conversion.Val(pcatid.SelectedValue) > 0)
        //    {
        //        Parameters.Add("@pcatid", Conversion.Val(pcatid.SelectedValue));
        //        sqlstr += " and pcatid=@pcatid";
        //    }
        //    sqlstr += " order by displayorder";
        //    clsm.Fillcombo_Parameter(sqlstr, Parameters, psubcatid);
        //}

        //protected void BindSubSubCategories()
        //{
        //    Parameters.Clear();
        //    string sqlstr = "select category,psubsubcatid from productsubsubcate where status = 1";
        //    if (Conversion.Val(pcatid.SelectedValue) > 0)
        //    {
        //        Parameters.Add("@pcatid", Conversion.Val(pcatid.SelectedValue));
        //        sqlstr += " and pcatid=@pcatid";
        //    }
        //    if (Conversion.Val(psubcatid.SelectedValue) > 0)
        //    {
        //        Parameters.Add("@psubcatid", Conversion.Val(psubcatid.SelectedValue));
        //        sqlstr += " and psubcatid=@psubcatid";
        //    }
        //    sqlstr += " order by displayorder";

        //    clsm.Fillcombo_Parameter(sqlstr, Parameters, psubsubcatid);
        //}

        //protected void BindsubsubsubCategories()
        //{
        //    Parameters.Clear();
        //    clsm.Fillcombo_Parameter("select category,psubsubsubcatid from productsubsubsubcate where status = 1 order by displayorder", Parameters, psubsubsubcatid);
        //}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string StrFileName = "";
                productdetail.Text = Server.HtmlEncode(CKeditor2.Text);
                shortdetail.Text = Server.HtmlEncode(CKeditor1.Text);

                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                if (Convert.ToInt32(clsm.MasterSave(this, productid.Parent, 41, mainclass.Mode.modeCheckDuplicate2, "ProductsSP", Convert.ToString(Session["UserId"]))) > 0)
                {
                    CKeditor1.ReadOnly = false;
                    trnotice.Visible = true;
                    lblnotice.Text = "This Product Code already exist.";
                    return;
                }

                if (string.IsNullOrEmpty(productid.Text))
                {
                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        if ((CheckFileType(File1.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either pdf, doc,docx,txt";
                            return;
                        }
                        prospectus.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
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
                        UploadAImage.Text = Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                    }
                    else
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                        return;

                    }
                    status.Checked = true;
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    string var = clsm.MasterSave(this, productid.Parent, 41, mainclass.Mode.modeAdd, "ProductsSP", Convert.ToString(Session["UserId"]));
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        Parameters.Clear();
                        Parameters.Add("@productid", Convert.ToInt32(var));
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select prospectus from Products where productid=@productid", Parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\prospectus\\" + StrFileName);
                    }
                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        Parameters.Clear();
                        Parameters.Add("@productid", var);
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select UploadAImage from Products where productid=@productid", Parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\ProductsImage\\" + StrFileName);
                    }
                    clsm.ClearallPanel(this, productid.Parent);
                    CKeditor1.Text = "";
                    CKeditor2.Text = "";
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record added successfully.";
                }
                else
                {
                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        if ((CheckFileType(File1.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either pdf, doc,docx,txt";
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
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    string var = clsm.MasterSave(this, productid.Parent, 41, mainclass.Mode.modeModify, "ProductsSP", Convert.ToString(Session["UserId"]));
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + prospectus.Text);
                        if (F2.Exists)
                        {
                            F2.Delete();
                        }

                        prospectus.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + prospectus.Text);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update Products set prospectus=@prospectus where productid=" + Convert.ToInt32(var) + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@prospectus", prospectus.Text));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\prospectus\\" + prospectus.Text);
                    }

                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {

                        UploadAImage.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + UploadAImage.Text);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        //' update banner file
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update Products set uploadaimage=@uploadaimage where productid=" + var + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@uploadaimage", UploadAImage.Text));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();
                        File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\ProductsImage\\" + UploadAImage.Text);
                    }
                    Response.Redirect("viewproducts.aspx?edit=edit");
                }
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Conversion.Val(productid.Text) == 0)
            {
                clsm.ClearallPanel(this, productid.Parent);
            }
            else
            {
                Response.Redirect("viewproducts.aspx");
            }

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(prospectus.Text))
            {
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + UploadAImage.Text);
                if (F1.Exists)
                {
                    F1.Delete();
                }
            }
            //clsm.ExecuteQry("update Products set prospectus='' where productid=" & Val(Request.QueryString("pid")))
            Parameters.Clear();
            Parameters.Add("@productid", Convert.ToInt32(Request.QueryString["pid"]));
            clsm.SendValue_Parameter("update Products set UploadAImage='' where productid=@productid", Parameters);
            prospectus.Text = "";
            Image1.Visible = false;
            trsuccess.Visible = true;
            LinkButton1.Visible = false;
            lblsuccess.Text = "File deleted successfully.";

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
                case ".swf":
                    return true;
                case ".webp":
                    return true;
                default:
                    return false;
            }
        }
        public bool CheckFileType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".doc":
                    return true;
                case ".pdf":
                    return true;
                case ".docx":
                    return true;
                case ".txt":

                    return true;
                default:
                    return false;
            }
        }
     
        protected void Isnewlaunches_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}