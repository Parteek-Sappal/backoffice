using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;

namespace backoffice.office.gallery
{
    public partial class viewphotogallery : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (!Page.IsPostBack)
            {
                dropboxbind();
                dropboxload();
                if (DropDownList1.SelectedValue != "0")
                {                    
                    griddata();
                }
                else
                {                 
                    griddata();
                }
                if (Convert.ToString(Request.QueryString["edit"]) == "edit")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Updated Successfully !!!";
                }
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

            // Add columns to the table
            tbl.Columns.Add(new DataColumn("Id", typeof(Int32)));
            tbl.Columns.Add(new DataColumn("ParentId", typeof(Int32)));
            tbl.Columns.Add(new DataColumn("Name", typeof(string)));

            // Add the data to the table

            Int32 i = default(Int32);            
            Parameters.Clear();
            DataSet ds1 = clsm.senddataset_Parameter("select * from Album where status=1  order by displayorder", Parameters);
            for (i = 0; i <= ds1.Tables[0].Rows.Count - 1; i++)
            {
                DataRow row = tbl.NewRow();
                row["Id"] = ds1.Tables[0].Rows[i]["Albumid"].ToString();
                row["ParentId"] = ds1.Tables[0].Rows[i]["Parentid"].ToString();
                row["Name"] = ds1.Tables[0].Rows[i]["Albumtitle"].ToString();
                tbl.Rows.Add(row);
            }

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

            DropDownList1.DataSource = Samples.OrderedHierarchy.GetOrderedTable(tbl, "ParentChild", "ParentId");
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "Id";
            DropDownList1.DataBind();

        }

        private void dropboxload()
        {
            DataTable tbl = new DataTable();
            if (DropDownList1.Items.Count > 0)
            {
                int j = 0;
                for (j = 0; j <= DropDownList1.Items.Count - 1; j++)
                {
                    TextBox txt3 = (TextBox)Repeater1.Items[j].FindControl("txt3");
                    DropDownList1.Items[j].Text = Pad(Convert.ToInt32(txt3.Text)) + DropDownList1.Items[j].Text;
                }
            }
            DropDownList1.Items.Insert(0, "Select");
            DropDownList1.Items[0].Value = "0";
        }
        protected void griddata()
        {
            string strq2 = null;
            strq2 = "select a.*,b.Albumtitle,b.displayorder from AlbumPhoto a left outer join Album b on a.albumid=b.albumid where 1=1";
            Parameters.Clear();
            if (DropDownList1.SelectedValue != "0")
            {
                Parameters.Add("@albumid", DropDownList1.SelectedValue);
                strq2 += " and a.albumid =@albumid";
            }
            strq2 += " order by b.displayorder,a.displayorder ";
            clsm.GridviewData_Parameter(GridView1, strq2, Parameters);
            if (GridView1.Rows.Count == 0)
            {
                trnotice.Visible = true;
                lblnotice.Text = "No Photo found.";
                GridView1.Visible = false;
            }
            else
            {
                GridView1.Visible = true;
            }
        }


        protected void btn_Click(object sender, EventArgs e)
        {
            griddata();
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
                
            }

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btndel")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblimage = (Label)row.FindControl("lblimage");
                Label lblimagesmall = (Label)row.FindControl("lblimagesmall");
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + lblimage.Text);
                if (F1.Exists)
                {
                    F1.Delete();
                }
                FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + lblimagesmall.Text);
                if (F2.Exists)
                {
                    F2.Delete();
                }                
                Parameters.Clear();
                Parameters.Add("@photoid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("delete from AlbumPhoto where photoid=@photoid", Parameters);
                griddata();
                trsuccess.Visible = true;
                lblsuccess.Text = "Photo Deleted Successfully.";

            }
            if (e.CommandName == "lnkstatus")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
                if (txtstatus.Text == "False")
                {                    
                    Parameters.Clear();
                    Parameters.Add("@photoid", e.CommandArgument.ToString());
                    clsm.ExecuteQry_Parameter("update AlbumPhoto set status=1 where photoid=@photoid", Parameters);
                }
                else if (txtstatus.Text == "True")
                {                    
                    Parameters.Clear();
                    Parameters.Add("@photoid", e.CommandArgument.ToString());
                    clsm.ExecuteQry_Parameter("update AlbumPhoto set status=0 where photoid=@photoid", Parameters);
                }
                griddata();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status Changed Successfully.";
            }

            if (e.CommandName == "btnedit")
            {
                Response.Redirect("addphotogallery.aspx?phid=" + e.CommandArgument);
            }


        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
                HtmlImage imgimage = (HtmlImage)e.Row.FindControl("imgimage");
                Label lblimage = (Label)e.Row.FindControl("lblimage");

                HtmlImage imgsmall = (HtmlImage)e.Row.FindControl("imgsmall");
                Label lblimagesmall = (Label)e.Row.FindControl("lblimagesmall");
                TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");

                if (string.IsNullOrEmpty(lblimagesmall.Text))
                {
                    imgsmall.Visible = false;
                }
                else
                {
                    imgsmall.Src = "~/Uploads/LargeImages/" + lblimagesmall.Text;
                    imgsmall.Visible = true;
                }



                if (string.IsNullOrEmpty(lblimage.Text))
                {
                    imgimage.Visible = false;
                }
                else
                {
                    imgimage.Src = "~/Uploads/LargeImages/" + lblimage.Text;
                    imgimage.Visible = true;
                }
                if (txtstatus.Text == "True")
                {
                    lnkstatus.ImageUrl = "~/Office/assets/ico_unblock.png";
                    lnkstatus.ToolTip = "Active";
                }
                else if (txtstatus.Text == "False")
                {
                    lnkstatus.ImageUrl = "~/Office/assets/ico_block.png";
                    lnkstatus.ToolTip = "Inactive";
                }
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");


            }


        }
    }
}