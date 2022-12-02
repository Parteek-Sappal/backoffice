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
using Microsoft.VisualBasic;


namespace backoffice.office.cms
{
    public partial class viewpages : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        public HttpCookie AUserSession = null;
        Hashtable Parameters = new Hashtable();
        public string str = string.Empty;
        public string strmainid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Visible = false;
                dropboxbind();


                if (Request.QueryString["edit"] == "edit")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record(s) updated successfully.";
                }
            }
        }
        private void dropboxbind()
        {

            DataTable tbl = GetData();
            DataSet ds = new DataSet();
            ds.Tables.Add(tbl);

            DataRelation rel = new DataRelation("ParentChild", tbl.Columns["pageId"], tbl.Columns["ParentId"], false);
            rel.Nested = true;

            ds.Relations.Add(rel);

            GridView1.DataSource = Samples.OrderedHierarchy.GetOrderedTable(tbl, "ParentChild", "ParentId");
            GridView1.DataBind();

            int j = 0;
            for (j = 0; j <= GridView1.Rows.Count - 1; j++)
            {                
                TextBox txtd = GridView1.Rows[j].FindControl("txtd") as TextBox;
                Label lblpagename = GridView1.Rows[j].FindControl("lblpagename") as Label;
                GridView1.Rows[j].Cells[1].Text = Pad(Convert.ToInt32(txtd.Text)) + lblpagename.Text;
            }


        }

        public DataTable GetData()
        {
            DataTable tbl = new DataTable();

            // Add columns to the table
            tbl.Columns.Add(new DataColumn("PageId", typeof(Int32)));
            tbl.Columns.Add(new DataColumn("ParentId", typeof(Int32)));
            tbl.Columns.Add(new DataColumn("PageName", typeof(string)));
            tbl.Columns.Add(new DataColumn("LinkName", typeof(string)));
            tbl.Columns.Add(new DataColumn("PageStatus", typeof(string)));
            tbl.Columns.Add(new DataColumn("restricted", typeof(string)));
            tbl.Columns.Add(new DataColumn("displayorder", typeof(string)));
            tbl.Columns.Add(new DataColumn("dynamicurlvalue", typeof(string)));
            // Add the data to the table
            Int32 idx = default(Int32);
            Parameters.Clear();
            Parameters.Add("@collageid", Conversion.Val(collageid.Text));
            DataSet ds1 = clsm.senddataset_Parameter("select * from Pagemaster  where collageid=@collageid  order by displayorder", Parameters);
            //Dim ds1 As Data.DataSet = clsm.sendDataset("select * from Pagemaster order by pageid")

            for (idx = 0; idx <= ds1.Tables[0].Rows.Count - 1; idx++)
            {
                DataRow row = tbl.NewRow();
                row["PageId"] = ds1.Tables[0].Rows[idx]["PageId"];
                row["ParentId"] = ds1.Tables[0].Rows[idx]["ParentId"];
                row["PageName"] = ds1.Tables[0].Rows[idx]["PageName"];
                row["LinkName"] = ds1.Tables[0].Rows[idx]["LinkName"];
                row["PageStatus"] = ds1.Tables[0].Rows[idx]["PageStatus"];
                row["restricted"] = ds1.Tables[0].Rows[idx]["restricted"];
                row["displayorder"] = ds1.Tables[0].Rows[idx]["displayorder"];
                row["dynamicurlvalue"] = ds1.Tables[0].Rows[idx]["dynamicurlvalue"];
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

            var parameters = new Hashtable();
            parameters.Add("@pid", Conversion.Val(pid));
            int i = Convert.ToInt16(Conversion.Val(clsm.SendValue_Parameter("select ParentId from PageMaster where  PageId=@pid", parameters)));
            parameters.Clear();
            if (i >= 0)
            {
                str += pid.ToString() + ",";
                strmainid = pid.ToString() + ",";
                if (i != 0)
                {
                    Populate(i);
                }
            }
        }
        protected string ArrangeStr()
        {
            str = str.TrimEnd(',');
            Array arr = str.Split(',');
            string ids = string.Empty;
            for (int x = arr.Length - 1; x >= 0; x += -1)
            {
                ids += arr.GetValue(x) + ",";
            }
            ids = ids.TrimEnd(',');
            //ArrangeStr= ids;
            str = "";
            return ids;
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lnkstatus = e.Row.FindControl("lnkstatus") as ImageButton;
                Label lblstatus = e.Row.FindControl("lblstatus") as Label;
                Label lblrestricted = e.Row.FindControl("lblrestricted") as Label;

                ImageButton btndel = e.Row.FindControl("btndel") as ImageButton;
                HtmlImage imgdel = e.Row.FindControl("imgdel") as HtmlImage;

                ImageButton btnrest = e.Row.FindControl("btnrest") as ImageButton;
                HtmlImage imgdelres = e.Row.FindControl("imgdelres") as HtmlImage;


                Literal litrewriteurl = e.Row.FindControl("litrewriteurl") as Literal;
                Literal litpageid = e.Row.FindControl("litpageid") as Literal;
                Literal litparentid = e.Row.FindControl("litparentid") as Literal;

                if (lblstatus.Text == "True")
                {
                    lnkstatus.ImageUrl = "~/Office/assets/ico_unblock.png";
                    lnkstatus.ToolTip = "Active";
                }
                else if (lblstatus.Text == "False")
                {
                    lnkstatus.ImageUrl = "~/Office/assets/ico_block.png";
                    lnkstatus.ToolTip = "Inactive";
                }

                //HtmlAnchor divanchslide = e.Row.FindControl("divanchslide") as HtmlAnchor;





                if (lblrestricted.Text == "True")
                {
                    // btnrest.ImageUrl = "~/backoffice/assets/Cancel_24x24.png";
                    //btndel.ToolTip = "Restricted"
                    btnrest.Visible = false;
                }
                else if (lblrestricted.Text == "False")
                {
                    imgdelres.Visible = false;
                    btnrest.ImageUrl = "~/Office/assets/Remove_24x24.png";
                    btnrest.ToolTip = "Not Restricted";
                }


                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Session["altColor"] + "'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");


                //************ for display dynamic show re write url****************

                //if (litpageid.Text=="7")
                //{

                if (!string.IsNullOrEmpty(litrewriteurl.Text))
                {
                    Populate(Convert.ToInt16(litpageid.Text));
                    string pageids = ArrangeStr();
                    Response.Write(pageids);
                    string strbcc = pageids;
                    strbcc = strbcc.TrimEnd(',');
                    var addrsn = strbcc.Split(',');
                    string strrewriteid;
                    strrewriteid = "/";
                    foreach (string addrn in addrsn)
                        strrewriteid += addrn + "/";
                    // if (Conversion.Val(strmainid) == 2 || Conversion.Val(strmainid) == 141 || Conversion.Val(strmainid) == 27 || Conversion.Val(strmainid) == 37 || Conversion.Val(strmainid) == 57 || Conversion.Val(strmainid) == 64 || Conversion.Val(strmainid) == 76)
                    if (Conversion.Val(strmainid) >= 2)
                    {
                        string strpagename = Convert.ToString(clsm.SendValue("select pagename from pagemaster where pageid=" + Conversion.Val(strmainid) + ""));
                        strpagename = strpagename.Trim();
                        strpagename = strpagename.Replace(" ", "-").Replace("&", "").Replace("@", "").Replace("--", "-").ToLower().ToString();
                        litrewriteurl.Text = litrewriteurl.Text.ToLower().ToString();
                        if (Conversion.Val(litparentid.Text) == 0)
                        {
                            litparentid.Text = Convert.ToString(Conversion.Val(litpageid.Text));
                            strrewriteid = strrewriteid + Convert.ToString(Conversion.Val(litpageid.Text));
                        }

                        litrewriteurl.Text = "/" + strpagename + "/" + litrewriteurl.Text + strrewriteid;
                        Parameters.Clear();
                        Parameters.Add("@synamicurlrewrite", litrewriteurl.Text);
                        clsm.ExecuteQry_Parameter("update pagemaster set dynamicurlrewrte=@synamicurlrewrite where pageid=" + Conversion.Val(litpageid.Text) + "", Parameters);
                        strmainid = "";
                    }
                    else
                    {
                        litrewriteurl.Text = litrewriteurl.Text.ToLower().ToString();
                        if (Conversion.Val(litparentid.Text) == 0)
                        {
                            litparentid.Text = Convert.ToString(Conversion.Val(litpageid.Text));
                            strrewriteid = strrewriteid + Convert.ToString(Conversion.Val(litpageid.Text));
                        }
                        litrewriteurl.Text = "/page/" + litrewriteurl.Text + strrewriteid;
                        Parameters.Clear();
                        Parameters.Add("@synamicurlrewrite", litrewriteurl.Text);
                        clsm.ExecuteQry_Parameter("update pagemaster set dynamicurlrewrte=@synamicurlrewrite where pageid=" + Conversion.Val(litpageid.Text) + "", Parameters);
                    }

                    strrewriteid = "";
                }
                else
                {
                    Parameters.Clear();
                    clsm.ExecuteQry_Parameter("update pagemaster set dynamicurlrewrte='' where pageid=" + Conversion.Val(litpageid.Text) + "", Parameters);
                }
                // }
            }





            if (e.Row.RowType == DataControlRowType.DataRow | e.Row.RowType == DataControlRowType.Header)
            {
                //  e.Row.Cells[3].Visible = false;
                // e.Row.Cells[4].Visible = false;
                // e.Row.Cells[8].Visible = false;
            }



        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            Label1.Visible = false;
            if (e.CommandName == "lnkstatus")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                Label lblstatus = (Label)row.FindControl("lblstatus");
                if (lblstatus.Text == "False")
                {
                    //clsm.ExecuteQry("update pagemaster set pagestatus=1 where pageid=" & e.CommandArgument.ToString() & "")
                    Parameters.Clear();
                    Parameters.Add("@pageid", Convert.ToInt32(e.CommandArgument.ToString()));
                    clsm.ExecuteQry_Parameter("update pagemaster set pagestatus=1 where pageid=@pageid", Parameters);
                }
                else if (lblstatus.Text == "True")
                {
                    //clsm.ExecuteQry("update pagemaster set pagestatus=0 where pageid=" & e.CommandArgument.ToString() & "")
                    Parameters.Clear();
                    Parameters.Add("@pageid", Convert.ToInt32(e.CommandArgument.ToString()));
                    clsm.ExecuteQry_Parameter("update pagemaster set pagestatus=0 where pageid=@pageid", Parameters);
                }
                //clsm.GridviewDatashow(GridView1, "select * from pagemaster order by pagename")
                dropboxbind();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully !!!";

            }
            if (e.CommandName == "btnedit")
            {
                string strcollageid = String.Empty;
                if ((Conversion.Val(collageid.Text) > 0))
                {
                    strcollageid = ("&clid=" + double.Parse(collageid.Text));
                }

                Response.Redirect("addpages.aspx?pgid=" + e.CommandArgument + strcollageid);
            }

            if (e.CommandName == "btnrest")
            {
                Parameters.Clear();
                Parameters.Add("@pageid", Convert.ToInt32(e.CommandArgument));
                string str = clsm.SendValue_Parameter("select UploadBanner from pagemaster where pageid=@pageid", Parameters).ToString();
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + str);
                if (F1.Exists)
                {
                    F1.Delete();
                }

                Parameters.Clear();
                Parameters.Add("@pageid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("delete from pagemaster where pageid=@pageid", Parameters);

                dropboxbind();
                trsuccess.Visible = true;
                lblsuccess.Text = "Record(s) deleted successfully.";
            }




            if (e.CommandName == "btndel")
            {
                //clsm.ExecuteQry("delete from pagemaster where pageid=" & e.CommandArgument & "")
                Parameters.Clear();
                Parameters.Add("@pageid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("delete from pagemaster where pageid=@pageid", Parameters);
                //Dim str = clsm.SendValue("select UploadBanner from pagemaster where pageid=" & e.CommandArgument & "")
                Parameters.Clear();
                Parameters.Add("@pageid", Convert.ToInt32(e.CommandArgument));
                string str = clsm.SendValue_Parameter("select UploadBanner from pagemaster where pageid=@pageid", Parameters).ToString();
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + str);
                if (F1.Exists)
                {
                    F1.Delete();
                }
                dropboxbind();
                trsuccess.Visible = true;
                lblsuccess.Text = "Record(s) deleted successfully.";
            }




        }
    }
}