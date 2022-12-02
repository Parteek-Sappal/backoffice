using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;


namespace backoffice.office.Products
{
    public partial class category_map_product : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        public HttpCookie AUserSession = null;
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trnotice.Visible = false;
            trsuccess.Visible = false;
            if (Page.IsPostBack == false)
            {
                Bindcat();
                bindproducts();               
            }
        }

        public void bindproducts()
        {

            string strsql = "Select (productname + ' ('+productcode+') ' ) as Prodname,productid From Products where 1=1 ";
            if (Conversion.Val(CatId.SelectedValue) > 0)
            {                
                strsql += " and seriesid=" + Conversion.Val(CatId.SelectedValue) + "";
            }
            strsql += " order by productname";
            clsm.Fillcombo(strsql, pid);
        }

        public void Bindcat()
        {
            string strsql = "Select category,seriesid From productcate where 1=1 and Status=1 order by category";
            clsm.Fillcombo(strsql, CatId);

        }
              
        private void ProductGridBind()
        {
            string strsql1;
            strsql1 = " select Distinct  p.* from Products p where  p.status=1  ";
            if (pid.SelectedIndex > 0)
            {
                strsql1 += " and p.productid <> " + Conversion.Val(pid.SelectedValue) + "";
            }

            if (CatId.SelectedIndex > 0)
            {
                strsql1 += " and p.seriesid = " + Conversion.Val(CatId.SelectedValue) + "";
            }

            if ((exactsku.Text).Trim() != "")
            {
                strsql1 += " and (p.productname like '%" + exactsku.Text.Replace("'", "") + "%' or p.productcode like '%" + exactsku.Text.Replace("'", "") + "%')";
            }

            strsql1 += " order by p.productname";

            clsm.GridviewDatashow(GridView1, strsql1);
            if (GridView1.Rows.Count > 0)
            {

                lblProductMsg.Visible = false;
                btnSubmit.Visible = true;
                btnCancel.Visible = true;
                SearchPanel.Visible = true;
            }
            else
            {
                btnSubmit.Visible = false;
                btnCancel.Visible = false;
                lblProductMsg.Visible = true;
                lblProductMsg.Text = "Record(s) not found.";
            }

            int i, j;
            DataSet dsmapped = clsm.sendDataset("select pid, mappid from Map_Cat_Product where pid=" + Conversion.Val(pid.SelectedValue) + "", false);
            if (dsmapped.Tables[0].Rows.Count > 0)

                for (i = 0; i <= GridView1.Rows.Count - 1; i++)
                {
                    for (j = 0; j <= dsmapped.Tables[0].Rows.Count - 1; j++)
                    {
                        if (GridView1.Rows[i].Cells[2].Text == Convert.ToString(dsmapped.Tables[0].Rows[j]["mappid"]))
                        {
                            CheckBox chkselect = GridView1.Rows[i].FindControl("chkselect") as CheckBox;
                            chkselect.Checked = true;
                        }
                    }
                }

        }

        protected void btnSubmit_Click(object sender, System.EventArgs e)
        {
            try
            {
                addeddate.Text = Convert.ToString(DateTime.Now);
                if (mapcpid.Text == "")
                {
                    addedby.Text = Session["UserId"].ToString();
                    addeddate.Text = Convert.ToString(DateTime.Now);
                    mappid.Text = "";
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        CheckBox chkselect = row.FindControl("chkselect") as CheckBox;
                        TextBox GrdmapPTitle = row.FindControl("GrdmapPTitle") as TextBox;
                        mappid.Text = GrdmapPTitle.Text;
                        if (chkselect.Checked == true)
                        {

                            addeddate.Text = Convert.ToString(DateTime.Now);
                            if (clsm.Checking("select * from Map_Cat_Product where  mappid=" + mappid.Text + " and pid=" + pid.SelectedValue + " ") == true)
                            { }

                            else
                            {

                                clsm.ExecuteQry("exec Map_Cat_ProductSP ''," + pid.SelectedValue + "," + mappid.Text + ",1");
                            }

                        }
                        else
                        {
                            string delstr = "Delete from Map_Cat_Product where  pid=" + pid.SelectedValue + "";
                            delstr += " and mappid = " + mappid.Text + "";
                            clsm.ExecuteQry(delstr);
                        }
                    }
                    if (mappid.Text.Trim() == "")
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "There are no Map product selected, Please select them. ";
                    }
                    else
                    {
                        trsuccess.Visible = true;
                        lblsuccess.Text = "Record added successfully.";

                    }
                    SearchPanel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                exactsku.EnableViewState = true;
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }
        }

        protected void btnCancel_Click(object sender, System.EventArgs e)
        {
            clsm.ClearallPanel(this, Label1.Parent);
        }

        protected void Search_Click(object sender, System.EventArgs e)
        {
            if (exactsku.Text != "")
            {
                string strsql = " select top 1 p.* from Products p  where p.status=1 and  p.productcode<>'" + (exactsku.Text).Trim() + "' order by p.Prodid";
                clsm.Fillcombo("Select productname,productid From Products where productcode<>'" + (exactsku.Text.Replace("'", "")).Trim() + "' order by productname", pid);
                DataSet dsnew = clsm.sendDataset(strsql, false);
                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    pid.SelectedValue = dsnew.Tables[0].Rows[0]["productid"].ToString();
                }
                else
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "Record(s) not found.";
                    return;
                }
            }

            SearchPanel.Visible = true;
            ProductGridBind();
        }
        protected void pid_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        }
        protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Session["altColor"] + "'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            }

            if (e.Row.RowType == DataControlRowType.DataRow | e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Visible = false;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                ProductGridBind();
            }
            catch (Exception ex)
            {
                Label1.Visible = true;
                Label1.Text = ex.Message.ToString();
            }
        }

        private void dropboxbind()
        {
            Parameters.Clear();
            string strsql = "select * from Product where  status=1";
            clsm.GridviewData_Parameter(GridView1, strsql, Parameters);


        }
        public string Pad(Int32 numberOfSpaces)
        {
            string Spaces = "";
            for (Int32 items = 1; items <= numberOfSpaces; items++)
            {
                Spaces += "&nbsp;&nbsp;&raquo;&nbsp;&nbsp;";
            }

            return Server.HtmlDecode(Spaces);
        }

        protected void newsubptypeid_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ProductGridBind();
        }
        protected void CatId_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindproducts();
            ProductGridBind();
        }
        protected void subcatId_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductGridBind();
        }

        protected void pid_SelectedIndexChanged1(object sender, EventArgs e)
        {
            ProductGridBind();
        }

        protected void exactsku_Click(object sender, System.EventArgs e)
        {
            ProductGridBind();
        }
    }
}