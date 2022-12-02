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
    public partial class mapallproduct : System.Web.UI.Page
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
                BindSubCategories();

                Bindproduct();
                Bindcolor();
                Bindsize();
                Bindorientation();
                Bindtype();
                Bindfeature();

                if (Conversion.Val(Request.QueryString["pmapid"]) > 0)
                {


                    Parameters.Clear();
                    Parameters.Add("@pmapid", Convert.ToInt32(Request.QueryString["pmapid"]));
                    clsm.MoveRecord_Parameter(this, pmapid.Parent, "select * from map_product where pmapid=@pmapid", Parameters);
                    BindSubCategories();

                    Bindproduct();

                    Parameters.Clear();
                    Parameters.Add("@pmapid", Convert.ToInt32(Request.QueryString["pmapid"]));
                    clsm.MoveRecord_Parameter(this, pmapid.Parent, "select * from map_product where pmapid=@pmapid", Parameters);

                    Bindproduct();

                    Parameters.Clear();
                    Parameters.Add("@pmapid", Convert.ToInt32(Request.QueryString["pmapid"]));
                    clsm.MoveRecord_Parameter(this, pmapid.Parent, "select * from map_product where pmapid=@pmapid", Parameters);                  

                    if (!string.IsNullOrEmpty(UploadAImage.Text.Trim()))
                    {
                        File1.Visible = true;
                        LinkButton1.Visible = true;
                        Image1.Visible = true;
                        Image1.ImageUrl = "../../Uploads/Mapproduct/" + UploadAImage.Text;
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
            clsm.Fillcombo_Parameter("select category,pcatid from productcate where status = 1 order by displayorder", Parameters, pcatid);
        }

        protected void BindSubCategories()
        {
            string sqlstr = "select category,psubcatid from productsubcate where 1=1 and status = 1";
            Parameters.Clear();
            //if (Conversion.Val(pcatid.SelectedValue) > 0)
            //{
            Parameters.Add("@pcatid", Conversion.Val(pcatid.SelectedValue));
            sqlstr += " and pcatid=@pcatid";
            //}
            sqlstr += " order by displayorder";
            clsm.Fillcombo_Parameter(sqlstr, Parameters, psubcatid);
        }


        protected void Bindproduct()
        {
            Parameters.Clear();
            string sqlstr = "select productname+'('+productcode+')' as productname ,productid from products where status = 1";
            //if (Conversion.Val(pcatid.SelectedValue) > 0)
            //{
            Parameters.Add("@pcatid", Conversion.Val(pcatid.SelectedValue));
            sqlstr += " and pcatid=@pcatid";
            // }
            //if (Conversion.Val(psubcatid.SelectedValue) > 0)
            //{
            Parameters.Add("@psubcatid", Conversion.Val(psubcatid.SelectedValue));
            sqlstr += " and psubcatid=@psubcatid";
            // }

            sqlstr += " order by displayorder";
            clsm.Fillcombo_Parameter(sqlstr, Parameters, productid);
        }
        protected void Bindcolor()
        {
            Parameters.Clear();

            clsm.Fillcombo_Parameter("select colortitle,colorid from Color_master where status = 1 order by displayorder", Parameters, colorid);
        }
        protected void Bindsize()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select sizetitle,sizeid from Size_master where status = 1 order by displayorder", Parameters, sizeid);
        }
        protected void Bindtype()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select typetitle,typeid from type_master where status = 1 order by displayorder", Parameters, typeid);
        }
        protected void Bindfeature()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select featuretitle,featureid from feature_master where status = 1 order by displayorder", Parameters, featureid);
        }
        protected void Bindorientation()
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select orientationtitle,orientationid from orientation_master where status = 1 order by displayorder", Parameters, orientationid);
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string StrFileName = null;

                if (Convert.ToInt32(clsm.MasterSave(this, pmapid.Parent, 15, mainclass.Mode.modeCheckDuplicate, "map_productSP", Convert.ToString(Session["UserId"]))) > 0)
                {

                    trnotice.Visible = true;
                    lblnotice.Text = "This Product already exist.";
                    return;
                }

                if (string.IsNullOrEmpty(pmapid.Text))
                {


                    status.Checked = true;


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

                    string var = clsm.MasterSave(this, pmapid.Parent, 15, mainclass.Mode.modeAdd, "map_productSP", Convert.ToString(Session["UserId"]));

                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        Parameters.Clear();
                        Parameters.Add("@productid", var);
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select UploadAImage from map_product where pmapid=@productid", Parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Mapproduct\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\Mapproduct\\" + StrFileName);
                    }


                    clsm.ClearallPanel(this, pmapid.Parent);
                    Response.Redirect("viewmapallproduct.aspx?edit=edit");
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record added successfully.";
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


                    string var = clsm.MasterSave(this, pmapid.Parent, 15, mainclass.Mode.modeModify, "map_productSP", Convert.ToString(Session["UserId"]));


                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        UploadAImage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "pmapimg_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));


                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Mapproduct\\" + UploadAImage.Text);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }

                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update map_product set UploadAImage=@uploadaimage where pmapid=" + var + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@uploadaimage", UploadAImage.Text));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\Mapproduct\\" + UploadAImage.Text);
                    }


                    Response.Redirect("viewmapallproduct.aspx?edit=edit");
                }
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UploadAImage.Text))
            {
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\mapproduct\\" + UploadAImage.Text);
                if (F1.Exists)
                {
                    F1.Delete();
                }
            }

            Parameters.Clear();
            Parameters.Add("@pmapid", Convert.ToInt32(Request.QueryString["pmapid"]));
            clsm.SendValue_Parameter("update map_product set UploadAImage='' where pmapid=@pmapid", Parameters);
            UploadAImage.Text = "";
            Image1.Visible = false;
            trsuccess.Visible = true;
            LinkButton1.Visible = false;
            lblsuccess.Text = "Image deleted successfully.";

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(pmapid.Text) == 0)
            {
                clsm.ClearallPanel(this, pmapid.Parent);
            }
            else
            {
                Response.Redirect("viewmapallproduct.aspx");
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
                case ".swf":
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

        protected void pcatid_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubCategories();
            Bindproduct();
        }

        protected void psubcatid_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bindproduct();
        }
        protected void Isnewlaunches_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void psubsubcatid_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bindproduct();
        }
    }
}