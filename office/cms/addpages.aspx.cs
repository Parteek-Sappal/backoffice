using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;
using backoffice.layers.model;
using backoffice.layers.business;


namespace backoffice.office.cms
{
    public partial class addpages : System.Web.UI.Page
    {
        BL_cms objBL_cms = new BL_cms();
        ML_cms objML_cms = new ML_cms();

        mainclass clsm = new mainclass();
        public HttpCookie AUserSession = null;
        Hashtable Parameters = new Hashtable();
        string Str;
        string Strrewriteid;
        string StrFileName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                displayorder.Text = "0";
                dropboxbind();

                if (Conversion.Val(Request.QueryString["pgid"]) > 0)
                {
                    linkpositionstatus.EnableViewState = false;
                    Parameters.Clear();
                    Parameters.Add("@pageid", Convert.ToString(Request.QueryString["pgid"]));
                    string strsql = "select * from pagemaster where pageid=@pageid ";
                    if (Conversion.Val(Request.QueryString["clid"]) > 0)
                    {
                        Parameters.Add("@collageid", Convert.ToString(Request.QueryString["clid"]));
                        strsql += " and collageid=@collageid ";
                    }

                    clsm.MoveRecord_Parameter(this, Pageid.Parent, strsql, Parameters);

                    parentid.Enabled = true;


                    linkpositionstatus.EnableViewState = true;
                    int i = 0;
                    int j = 0;
                    ArrayList arrayposition = new ArrayList();
                    if (!string.IsNullOrEmpty(linkposition.Text))
                    {
                        arrayposition.AddRange(linkposition.Text.Split(','));
                        for (i = 0; i <= arrayposition.Count - 1; i++)
                        {
                            for (j = 0; j <= linkpositionstatus.Items.Count - 1; j++)
                            {
                                if (arrayposition[i].ToString() == linkpositionstatus.Items[j].Value)
                                {
                                    linkpositionstatus.Items[j].Selected = true;
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(UploadBanner.Text.Trim()))
                    {
                        File1.Visible = true;
                        Image1.ImageUrl = "~/Uploads/banner/" + UploadBanner.Text;
                        LinkButton1.Visible = true;
                        Image1.Visible = true;
                    }
                    else
                    {
                        LinkButton1.Visible = false;
                    }

                }
            }
        }
        protected void submit(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Path.GetFileName(File1.PostedFile.FileName)))
                {
                    if ((CheckImgType(Path.GetFileName(File1.PostedFile.FileName))) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                        return;
                    }
                    UploadBanner.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName).Replace(" ", "").Replace("&", "")));
                }
                if (Conversion.Val(Request.QueryString["pgid"]) > 0)
                {
                    objML_cms.pageid = Request.QueryString["pgid"];
                }

                objML_cms.parentid = Convert.ToString(parentid.SelectedValue);
                objML_cms.pagetitle = pagename.Text;
                objML_cms.tagline = tagline.Text;
                objML_cms.linkname = linkname.Text;
                objML_cms.linkposition = linkpositionstatus.SelectedValue;
                objML_cms.megamenu = megamenu.Text;
                objML_cms.smalldesc = smalldesc.Text;
                objML_cms.pagedescription = Pagedescription.Text;
                objML_cms.pagedescription1 = PageDescription1.Text;
                objML_cms.pagedescription2 = PageDescription2.Text;
                objML_cms.uploadbanner = UploadBanner.Text;
                objML_cms.displayorder = Convert.ToInt32(displayorder.Text);
                objML_cms.pagename = pagename.Text;
                objML_cms.pagemeta = pagemeta.Text;
                objML_cms.pagemetadesc = pagemetadesc.Text;
                objML_cms.canonical = canonical.Text;
                objML_cms.no_indexfollow = 0;
                objML_cms.target = target.Text;
                objML_cms.rewriteid = rewriteid.Text;
                objML_cms.rewriteurl = rewriteurl.Text;                
                objML_cms.quicklink = 0;                
                objML_cms.restricted = 1;
                objML_cms.collageid = 0;
                objML_cms.other_scheme = other_schema.Text;
                objML_cms.dynamicurlvalue = dynamicurlvalue.Text;
                objML_cms.dynamicurlrewrite = dynamicurlrewrte.Text;
                objML_cms.pageurl = "";
                objML_cms.uname = Session["UserId"].ToString();
                if (Conversion.Val(Request.QueryString["pgid"]) > 0)
                {
                    objML_cms.mode = 2;
                }
                else { objML_cms.mode = 1; }

                if (Pagestatus.Checked == true)
                {
                    objML_cms.pagestatus = 1;
                }
                bool x = objBL_cms.BL_insupdpages(objML_cms);
                if (x == true)
                {
                    string pageid = Convert.ToString(clsm.SendValue("select pageid from pagemaster where 2=2 order by pageid desc"));

                    //***************** for log history*********************

                    clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(pagename.Text), Convert.ToString(pageid), Convert.ToString("CMS"), Convert.ToString(collageid.Text), Convert.ToString(lblcollage.Text));

                    //*********************** end for log history*******************************
                    Str = "";
                    string purl = "";
                    if (Convert.ToInt16(parentid.SelectedValue) == 0)
                    {
                        purl = "cpage.aspx?mpgid=" + Convert.ToInt16(pageid) + "&pgidtrail=" + Convert.ToInt16(pageid);
                        Strrewriteid = Convert.ToString(pageid);
                    }
                    else
                    {
                        Populate(Convert.ToInt16(parentid.SelectedValue));
                        Str = Str.TrimEnd(',');
                        ArrayList ar = new ArrayList(Str.Split(','));
                        ar.Reverse();
                        //*************************
                        int n = 0;
                        if (ar.Count > 0)
                        {
                            Strrewriteid += ar[0] + ",";
                            for (n = 1; n <= ar.Count - 1; n++)
                            {
                                Strrewriteid += ar[n] + ",";
                            }
                        }
                        //**************************
                        int m = 0;
                        if (ar.Count > 0)
                        {
                            purl = "cpage.aspx?mpgid=" + ar[0];
                            for (m = 1; m <= ar.Count - 1; m++)
                            {
                                purl += "&pgid" + m + "=" + ar[m];
                            }
                            purl += "&pgidtrail=" + Convert.ToString(pageid);
                        }

                    }
                    clsm.ExecuteQry("update pagemaster set pageurl='" + purl + "' where pageid=" + Convert.ToString(pageid) + "");
                    // '' end page url
                    if (Strrewriteid.Contains(",") == true)
                    {
                        Strrewriteid = Strrewriteid.TrimEnd(',');
                        Strrewriteid = Strrewriteid.Replace(',', '/');
                    }
                    if (!string.IsNullOrEmpty(Path.GetFileName(File1.PostedFile.FileName)))
                    {
                        Parameters.Clear();
                        Parameters.Add("@pageid", Convert.ToString(pageid));
                        Parameters.Add("@collageid", Conversion.Val(collageid.Text));
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select UploadBanner from pagemaster where collageid=@collageid and  pageid=@pageid", Parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + StrFileName);
                        if (F1.Exists)
                        {
                            Parameters.Clear();
                            Parameters.Add("@pageid", Convert.ToString(pageid));
                            Parameters.Add("@collageid", Conversion.Val(collageid.Text));
                            clsm.ExecuteQry_Parameter("delete from pagemaster where collageid=@collageid and  pageid=@pageid", Parameters);
                            trnotice.Visible = true;
                            lblnotice.Text = "File already exist, Please choose another name.";
                            return;
                        }
                        else
                        {
                            File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\banner\\" + StrFileName);
                        }
                    }
                    if (Conversion.Val(Request.QueryString["pgid"]) > 0)
                    {
                        Response.Redirect("viewpages.aspx?edit=edit");
                    }
                    else
                    {
                        trsuccess.Visible = true;
                        lblsuccess.Text = "Page added successfully.";
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
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
        private void dropboxbind()
        {

            DataTable tbl = GetData();
            DataSet ds = new DataSet();
            ds.Tables.Add(tbl);
            DataRelation rel = new DataRelation("ParentChild", tbl.Columns["pageid"], tbl.Columns["ParentId"], false);
            rel.Nested = true;
            ds.Relations.Add(rel);
            Repeater1.DataSource = Samples.OrderedHierarchy.GetOrderedTable(tbl, "ParentChild", "ParentId");
            Repeater1.DataBind();
            parentid.DataSource = Samples.OrderedHierarchy.GetOrderedTable(tbl, "ParentChild", "ParentId");
            parentid.DataTextField = "pagename";
            parentid.DataValueField = "pageid";
            parentid.DataBind();
            if (parentid.Items.Count > 0)
            {
                int j = 0;
                for (j = 0; j <= parentid.Items.Count - 1; j++)
                {
                    TextBox txt3 = Repeater1.Items[j].FindControl("txt3") as TextBox;
                    parentid.Items[j].Text = Pad(Convert.ToInt32(txt3.Text)) + parentid.Items[j].Text;
                }
            }
            parentid.Items.Insert(0, "Main Page");
            parentid.Items[0].Value = "0";
        }

        public DataTable GetData()
        {
            DataTable tbl = new DataTable();

            // Add columns to the table
            tbl.Columns.Add(new DataColumn("PageId", typeof(Int32)));
            tbl.Columns.Add(new DataColumn("ParentId", typeof(Int32)));
            tbl.Columns.Add(new DataColumn("PageName", typeof(string)));
            tbl.Columns.Add(new DataColumn("linkposition", typeof(string)));
            tbl.Columns.Add(new DataColumn("PageTitle", typeof(string)));
            tbl.Columns.Add(new DataColumn("PageStatus", typeof(string)));
            // Add the data to the table
            Int32 idx = default(Int32);
            Parameters.Clear();
            Parameters.Add("@collageid", Conversion.Val(collageid.Text));
            DataSet ds1 = clsm.senddataset_Parameter("select * from Pagemaster  where collageid=@collageid order by pageid", Parameters);
            for (idx = 0; idx <= ds1.Tables[0].Rows.Count - 1; idx++)
            {
                DataRow row = tbl.NewRow();
                row["PageId"] = ds1.Tables[0].Rows[idx]["pageid"].ToString();
                row["ParentId"] = ds1.Tables[0].Rows[idx]["ParentId"].ToString();
                row["PageName"] = ds1.Tables[0].Rows[idx]["PageName"].ToString();
                row["linkposition"] = ds1.Tables[0].Rows[idx]["linkposition"].ToString();
                row["PageTitle"] = ds1.Tables[0].Rows[idx]["PageTitle"].ToString();
                row["PageStatus"] = ds1.Tables[0].Rows[idx]["PageStatus"].ToString();
                tbl.Rows.Add(row);
            }

            return tbl;
        }
        private string Pad(Int32 numberOfSpaces)
        {
            string Spaces = string.Empty;

            for (Int32 items = 1; items <= numberOfSpaces; items++)
            {
                Spaces += "&nbsp;&nbsp;&raquo;&nbsp;";
            }
            return Server.HtmlDecode(Spaces);
        }
        protected void Populate(int pid)
        {
            Parameters.Clear();

            Parameters.Add("@PageId", Convert.ToInt32(pid));
            Parameters.Add("@collageid", Convert.ToInt32(Convert.ToString(Request.QueryString["clid"])));
            int l = Convert.ToInt32(clsm.SendValue_Parameter("select ParentId from PageMaster where  collageid=@collageid and PageId=@PageId ", Parameters));
            if (l >= 0)
            {
                Str += pid.ToString() + ",";

                if (l != 0)
                {
                    Populate(l);
                }
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UploadBanner.Text))
            {
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + UploadBanner.Text);
                if (F1.Exists)
                {
                    F1.Delete();
                }
            }
            Parameters.Clear();
            Parameters.Add("@pageid", Convert.ToInt32(Request.QueryString["pgid"]));
            Parameters.Add("@collageid", Conversion.Val(collageid.Text));
            clsm.ExecuteQry_Parameter("update pagemaster set UploadBanner='' where  collageid=@collageid and  pageid=@pageid", Parameters);
            UploadBanner.Text = "";
            Image1.Visible = false;
            trsuccess.Visible = true;
            LinkButton1.Visible = false;
            lblsuccess.Text = "File deleted successfully.";
        }


    }
}