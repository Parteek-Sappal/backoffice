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


namespace backoffice.office.investor
{
    public partial class addinvestor : System.Web.UI.Page
    {

        mainclass clsm = new mainclass();
        public HttpCookie AUserSession = null;
        Hashtable Parameters = new Hashtable();
        string Str;
        string Strrewriteid;
        string StrFileName;
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (Page.IsPostBack == false)
            {

                Int32 p = 0;
                disablecontrol();
                dropboxbind();
                if (Int32.TryParse(Request.QueryString["investorid"], out p) == true)
                {
                    linkpositionstatus.EnableViewState = false;
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    CKeditor3.ReadOnly = true;
                    CKeditor4.ReadOnly = true;
                    CKeditor5.ReadOnly = true;
                    Parameters.Clear();
                    Parameters.Add("@investorid", Convert.ToString(Request.QueryString["investorid"]));
                    string strsql = "select * from investor where investorid=@investorid ";


                    clsm.MoveRecord_Parameter(this, investorid.Parent, strsql, Parameters);
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    CKeditor3.ReadOnly = false;
                    CKeditor4.ReadOnly = false;
                    CKeditor5.ReadOnly = false;
                    parentid.Enabled = true;
                    CKeditor1.Text = Server.HtmlDecode(Pagedescription.Text);
                    CKeditor2.Text = Server.HtmlDecode(smalldesc.Text);
                    CKeditor3.Text = Server.HtmlDecode(megamenu.Text);

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
                        LinkButton1.Visible = true;                        
                    }
                    else
                    {
                        LinkButton1.Visible = false;
                    }
                    disablecontrol();

                }
            }
        }

        private void disablecontrol()
        {
            if (Convert.ToInt32(Session["Trid"]) == 2)
            {
                pageurl.Enabled = false;
                parentid.Enabled = false;

                pagename.Enabled = false;
                linkname.Enabled = false;
                rewriteurl.Enabled = false;
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
                default:
                    return false;
            }
        }
        protected void Populate(int pid)
        {
            Parameters.Clear();

            Parameters.Add("@investorid", Convert.ToInt32(pid));

            int l = Convert.ToInt32(clsm.SendValue_Parameter("select ParentId from investor where   investorid=@investorid ", Parameters));
            if (l >= 0)
            {
                Str += pid.ToString() + ",";

                if (l != 0)
                {
                    Populate(l);
                }
            }

        }

        private void dropboxbind()
        {

            DataTable tbl = GetData();
            DataSet ds = new DataSet();
            ds.Tables.Add(tbl);
            DataRelation rel = new DataRelation("ParentChild", tbl.Columns["investorid"], tbl.Columns["ParentId"], false);
            rel.Nested = true;
            ds.Relations.Add(rel);
            Repeater1.DataSource = Samples.OrderedHierarchy.GetOrderedTable(tbl, "ParentChild", "ParentId");
            Repeater1.DataBind();
            parentid.DataSource = Samples.OrderedHierarchy.GetOrderedTable(tbl, "ParentChild", "ParentId");
            parentid.DataTextField = "pagename";
            parentid.DataValueField = "investorid";
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
            tbl.Columns.Add(new DataColumn("investorid", typeof(Int32)));
            tbl.Columns.Add(new DataColumn("ParentId", typeof(Int32)));
            tbl.Columns.Add(new DataColumn("PageName", typeof(string)));
            tbl.Columns.Add(new DataColumn("linkposition", typeof(string)));
            tbl.Columns.Add(new DataColumn("PageTitle", typeof(string)));
            tbl.Columns.Add(new DataColumn("PageStatus", typeof(string)));
            // Add the data to the table
            Int32 idx = default(Int32);
            Parameters.Clear();

            DataSet ds1 = clsm.senddataset_Parameter("select * from investor   order by investorid", Parameters);
            for (idx = 0; idx <= ds1.Tables[0].Rows.Count - 1; idx++)
            {
                DataRow row = tbl.NewRow();
                row["investorid"] = ds1.Tables[0].Rows[idx]["pageid"].ToString();
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                Pagedescription.Text = Server.HtmlEncode(CKeditor1.Text);
                smalldesc.Text = Server.HtmlEncode(CKeditor2.Text);
                megamenu.Text = Server.HtmlEncode(CKeditor3.Text);
                PageDescription1.Text = Server.HtmlEncode(CKeditor4.Text);
                PageDescription2.Text = Server.HtmlEncode(CKeditor5.Text);
                int i = 0;
                linkposition.Text = "";
                for (i = 0; i <= linkpositionstatus.Items.Count - 1; i++)
                {
                    if (linkpositionstatus.Items[i].Selected == true)
                    {
                        linkposition.Text = linkposition.Text + (string.IsNullOrEmpty(linkposition.Text) ? "" : ",") + linkpositionstatus.Items[i].Value;
                    }
                }

                if (String.IsNullOrEmpty(investorid.Text))
                {
                    Pagestatus.Checked = true;
                    restricted.Checked = true;
                    linkpositionstatus.EnableViewState = false;
                    if (!string.IsNullOrEmpty(Path.GetFileName(File1.PostedFile.FileName)))
                    {
                        if ((CheckFileType(Path.GetFileName(File1.PostedFile.FileName))) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of Pdf, doc, docx,xls,xlsx, txt";
                            return;
                        }
                        UploadBanner.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName).Replace(" ", "").Replace("&", "")));
                    }
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    CKeditor3.ReadOnly = true;
                    CKeditor4.ReadOnly = true;
                    CKeditor5.ReadOnly = true;
                    
                    string var;
                    var = clsm.MasterSave(this, investorid.Parent, 29, mainclass.Mode.modeAdd, "investorSP", Session["UserId"].ToString());
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    CKeditor3.ReadOnly = false;
                    CKeditor4.ReadOnly = false;
                    CKeditor5.ReadOnly = false;
                    // '' for page url

                    //***************** for log history*********************

                    clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(pagename.Text), Convert.ToString(var), Convert.ToString("INVESTOR"), Convert.ToString(collageid.Text), Convert.ToString(lblcollage.Text));

                    //*********************** end for log history*******************************






                    if (!string.IsNullOrEmpty(Path.GetFileName(File1.PostedFile.FileName)))
                    {
                        Parameters.Clear();
                        Parameters.Add("@investorid", Convert.ToString(var));

                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select UploadBanner from investor where investorid=@investorid", Parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\pdf\\" + StrFileName);
                        if (F1.Exists)
                        {
                            Parameters.Clear();
                            Parameters.Add("@investorid", Convert.ToString(var));

                            clsm.ExecuteQry_Parameter("delete from investor where   investorid=@investorid", Parameters);
                            trnotice.Visible = true;
                            lblnotice.Text = "File already exist, Please choose another name.";
                            return;
                        }
                        else
                        {
                            File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\pdf\\" + StrFileName);
                        }
                    }
                    clsm.ClearallPanel(this, investorid.Parent);


                    collageid.Text = "0";



                    CKeditor1.Text = "";
                    CKeditor2.Text = "";
                    CKeditor3.Text = "";
                    CKeditor4.Text = "";
                    CKeditor5.Text = "";

                    trsuccess.Visible = true;
                    lblsuccess.Text = "Page added successfully.";

                    ///to delte after work 
                    ///
                    Parameters.Clear();
                    Parameters.Add("@investorid", var);


                }
                else
                {
                    linkpositionstatus.EnableViewState = false;
                    if (!string.IsNullOrEmpty(Path.GetFileName(File1.PostedFile.FileName)))
                    {
                        if ((CheckFileType(Path.GetFileName(File1.PostedFile.FileName))) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of Pdf, doc, docx,xls,xlsx, txt";
                            return;
                        }
                    }





                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    CKeditor3.ReadOnly = true;
                    CKeditor4.ReadOnly = true;
                    CKeditor5.ReadOnly = true;
                    string var = clsm.MasterSave(this, investorid.Parent, 29, mainclass.Mode.modeModify, "investorSP", Session["UserId"].ToString());
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    CKeditor3.ReadOnly = false;
                    CKeditor4.ReadOnly = false;
                    CKeditor5.ReadOnly = false;

                    //***************** for log history*********************

                    clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(pagename.Text), Convert.ToString(var), Convert.ToString("INVESTOR"), Convert.ToString(collageid.Text), Convert.ToString(lblcollage.Text));

                    //*********************** end for log history*******************************



                    if (!string.IsNullOrEmpty(Path.GetFileName(File1.PostedFile.FileName)))
                    {
                        UploadBanner.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "ib_" + Path.GetFileName(File1.PostedFile.FileName).Replace(" ", "").Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\pdf\\" + UploadBanner.Text);
                        if (F1.Exists)
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "File already exist, Please choose another name.";
                            return;
                        }
                        //' update banner file
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update investor set uploadbanner=@uploadbanner where   investorid=" + Convert.ToString(var) + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@uploadbanner", UploadBanner.Text));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();
                        //' end
                        
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\pdf\\" + UploadBanner.Text);
                    }
                    linkpositionstatus.EnableViewState = true;
                    string strcollageid = String.Empty;

                    Response.Redirect("viewinvestor.aspx?edit=edit");



                }
                dropboxbind();
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {

            string strcollageid = String.Empty;

            if (Convert.ToInt32(Request.QueryString["investorid"]) > 0)
            {
                Response.Redirect("viewinvestor.aspx");
            }
            CKeditor1.Text = "";
            CKeditor2.Text = "";
            CKeditor3.Text = "";
            clsm.ClearallPanel(this, investorid.Parent);


            collageid.Text = "0";



        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UploadBanner.Text))
            {
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\pdf\\" + UploadBanner.Text);
                if (F1.Exists)
                {
                    F1.Delete();
                }
            }
            Parameters.Clear();
            Parameters.Add("@investorid", Convert.ToInt32(Request.QueryString["investorid"]));

            clsm.ExecuteQry_Parameter("update investor set UploadBanner='' where   investorid=@investorid", Parameters);
            UploadBanner.Text = "";
            Image1.Visible = false;
            trsuccess.Visible = true;
            LinkButton1.Visible = false;
            lblsuccess.Text = "File deleted successfully.";
        }
    }
}