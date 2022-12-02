using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace backoffice.office.Registration
{
    public partial class viewregistration : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            trerror.Visible = false;
            trnotice.Visible = false;
            trsuccess.Visible = false;
            if (!IsPostBack)
            {
                showrecord();
                if ((Request.QueryString["edit"] == "edit"))
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record updated successfully.";
                }
            }
        }
        protected void showrecord()
        {
            string strcust;
            strcust = "Select * from userregistration where 1=1 ";
            if ((username.Text.Trim() != ""))
            {
                strcust += " and username like '%'+@username+'%'";
            }

            if ((emailid.Text.Trim() != ""))
            {
                strcust += " and emailid like '%'+@email+'%'";
            }
            strcust += " order by  trdate desc";
            SqlConnection objcon = new SqlConnection(clsm.strconnect);
            objcon.Open();
            SqlCommand objcmd = new SqlCommand(strcust, objcon);
            objcmd.Parameters.AddWithValue("@username", username.Text.Trim());
            objcmd.Parameters.AddWithValue("@email", emailid.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(objcmd);
            DataSet dsdata = new DataSet();
            da.Fill(dsdata);
            objcon.Close();
            GridView1.DataSource = dsdata;
            GridView1.DataBind();
            if ((GridView1.Rows.Count == 0))
            {
                trnotice.Visible = true;
                lblnotice.Text = "Record(s) not found.";
                btnexport.Visible = false;
            }
            else
            {
                trnotice.Visible = false;
                btnexport.Visible = true;
            }
        }
        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                showrecord();
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }
        }
        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if ((e.CommandName == "btndel"))
            {
                GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
                clsm.ExecuteQry(("delete from userregistration where userid="
                                + (e.CommandArgument + "")));
                showrecord();
                trnotice.Visible = true;
                lblnotice.Text = "Record deleted successfully.";
            }
            if ((e.CommandName == "lnkstatus"))
            {
                GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
                TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
                if ((txtstatus.Text == "False"))
                {
                    clsm.ExecuteQry(("update userregistration set status=1 where userid="
                                    + (e.CommandArgument + "")));
                }
                else if ((txtstatus.Text == "True"))
                {
                    clsm.ExecuteQry(("update userregistration set status=0 where userid="
                                    + (e.CommandArgument + "")));
                }
                showrecord();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }            
        }
        protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
                TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");
                if ((lnkstatus == null == false))
                {
                    if ((txtstatus.Text == "True"))
                    {
                        lnkstatus.ImageUrl = "~/office/assets/ico_unblock.png";
                        lnkstatus.ToolTip = "Yes";
                    }
                    else if ((txtstatus.Text == "False"))
                    {
                        lnkstatus.ImageUrl = "~/office/assets/ico_block.png";
                        lnkstatus.ToolTip = "No";
                    }
                }

                e.Row.Attributes.Add("onmouseover", ("this.style.backgroundColor='" + (Session["altColor"] + "'")));
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            }
        }

        protected void btnsearch_Click(object sender, System.EventArgs e)
        {
            showrecord();
        }

        protected void lnkdetail_Click(object sender, EventArgs e)
        {
            Label3.Visible = false;
            LinkButton lb = (LinkButton)sender;            
            string regid = lb.CommandArgument;
            DataSet ds = clsm.sendDataset(("select * from userregistration  where userid=" + double.Parse(regid)), false);
            if ((ds.Tables[0].Rows.Count > 0))
            {
                lblusername.Text = ds.Tables[0].Rows[0]["username"].ToString();
                lblphone.Text = ds.Tables[0].Rows[0]["mobileno"].ToString();
                lblemail.Text = ds.Tables[0].Rows[0]["emailid"].ToString();
                lblpassword.Text = ds.Tables[0].Rows[0]["password"].ToString();                
                lblcountry.Text = ds.Tables[0].Rows[0]["country"].ToString();
                lbldate.Text = ds.Tables[0].Rows[0]["trdate"].ToString();
            }

            ModalPopupExtender1.Show();
        }

        protected void btnexport_Click(object sender, System.EventArgs e)
        {
            string strcust;
            strcust = "Select username [Name],password [Password],emailid [Email],mobileno[Phone]from userregistration where 1=1 ";
            if ((username.Text.Trim() != ""))
            {
                strcust += " and username like '%'+@username+'%'";
            }
            if ((emailid.Text.Trim() != ""))
            {
                strcust += " and emailid like '%'+@email+'%'";
            }
            strcust += " order by  trdate desc";
            SqlConnection objcon = new SqlConnection(clsm.strconnect);
            objcon.Open();
            SqlCommand objcmd = new SqlCommand(strcust, objcon);
            objcmd.Parameters.AddWithValue("@username", username.Text.Trim());
            objcmd.Parameters.AddWithValue("@email", emailid.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(objcmd);
            DataSet dsdata = new DataSet();
            da.Fill(dsdata);
            objcon.Close();
            Response.Clear();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=User.xls");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            DataSetToExcel.Convert(dsdata, Response);
            Response.Write(stringWrite.ToString());
            Response.Buffer = true;
            Response.End();
        }
    }
}