using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Collections;

namespace backoffice.office.media
{
    public partial class media_coverage : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        Hashtable Parameters = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {

            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (!IsPostBack)
            {
                Parameters.Clear();
                clsm.Fillcombo_Parameter("select ntype,ntypeid from newstype where status=1 and ntypeid=5 order by  displayorder", Parameters, ntypeid);
                ntypeid.SelectedValue = "5";
                FillImage();
            }

        }

        private void FillImage()
        {
            string strsql = "";
            Parameters.Clear();
            strsql = "select eventsid,eventstitle,uploadevents,displayorder,Eventsdate  from Events where 1=1";
            Parameters.Add("@ntypeid", "5");
            strsql += " and ntypeid=@ntypeid";
            if (TextBox4.Text != "")
            {
                Parameters.Add("@EventsTitle", TextBox4.Text.Replace("'", ""));
                strsql += " and EventsTitle like '%'+@EventsTitle+'%'";
            }
            if (TextBox5.Text != "")
            {
                Parameters.Add("@EventsDate", TextBox5.Text.Replace("'", ""));
                strsql += " and EventsDate >=@EventsDate";
            }
            if (TextBox6.Text != "")
            {
                DateTime dt = Convert.ToDateTime(TextBox6.Text);
                dt = dt.AddDays(0);
                strsql += " and EventsDate <='" + dt + "'";
            }
            strsql += " order by  displayorder ";
            DataSet ds = clsm.senddataset_Parameter(strsql, Parameters);


            if (ds.Tables[0].Rows.Count > 0)
            {
                dtlview.DataSource = ds.Tables[0];
                dtlview.DataBind();
            }
        }

        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {

            try
            {

                //=== CODE FOR SAVE IMAGE IN DATA BASE ===//
                SqlConnection objcon = new SqlConnection(clsm.strconnect);
                objcon.Open();
                SqlCommand objcmd = new SqlCommand("MediaCoverageSP", objcon);
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.Parameters.AddWithValue("@ntypeid", "5");
                objcmd.Parameters.AddWithValue("@eventstitle", e.FileName.ToString());
                objcmd.Parameters.AddWithValue("@UploadEvents", e.FileName.ToString().Replace(" ", "").Replace("&", ""));
                objcmd.Parameters.AddWithValue("@Status", "1");
                objcmd.Parameters.AddWithValue("@displayorder", 0);
                objcmd.Parameters.AddWithValue("@uploadfile", "");
                objcmd.Parameters.AddWithValue("@largeimage", "");

                objcmd.Parameters.AddWithValue("@archive", 0);
                objcmd.Parameters.AddWithValue("@no_indexfollow", 0);
                objcmd.Parameters.AddWithValue("@showonschool", 0);
                objcmd.Parameters.AddWithValue("@showongroup", 0);
                objcmd.Parameters.AddWithValue("@Eventsdate", "01/01/1900");
                objcmd.Parameters.AddWithValue("@eventedate", "01/01/1900");
                objcmd.Parameters.AddWithValue("@types", "");





                objcmd.Parameters.AddWithValue("@Uname", Convert.ToString(Session["UserId"]));
                objcmd.Parameters.AddWithValue("@Mode", 1);
                objcmd.Parameters.Add("@eventsid", SqlDbType.Int, -1).Direction = ParameterDirection.Output;
                objcmd.ExecuteNonQuery();
                string eventsid = objcmd.Parameters["@eventsid"].Value.ToString();
                objcon.Close();
                objcmd.Dispose();

                //=== END CODE FOR SAVE IMAGE IN DATABASE ===// 
                //=== CODE FOR SAVE LARGE IMAGE ===//

                string uploadedfile = Path.GetFileName((eventsid + Convert.ToString("mc_")) + Path.GetFileName(e.FileName.ToString().Replace(" ", "")).Replace("&", ""));

                //=== CODE FOR SAVE SMALL IMAGE ===//

                FileInfo F2 = new FileInfo(Convert.ToString(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\") + uploadedfile);
                if (F2.Exists)
                {
                    F2.Delete();
                }
                string fileNameWithPathL = Server.MapPath("~/uploads/SmallImages/") + uploadedfile;
                AjaxFileUpload1.SaveAs(fileNameWithPathL);





            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }



        }

        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            FillImage();
        }

        protected void btnpublish_Click(object sender, EventArgs e)
        {
            FillImage();
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {

            try
            {
                int i = 0;
                foreach (DataListItem item in dtlview.Items)
                {

                    Parameters.Clear();
                    Label lbleventsid = item.FindControl("lbleventsid") as Label;
                    TextBox txteventstitle = item.FindControl("txteventstitle") as TextBox;
                    CheckBox chk = item.FindControl("chk") as CheckBox;
                    TextBox txtdisplayorder = item.FindControl("txtdisplayorder") as TextBox;
                    TextBox txtdate = item.FindControl("txtdate") as TextBox;

                    if (chk.Checked == true)
                    {
                        Parameters.Add("@eventsid", lbleventsid.Text);
                        Parameters.Add("@eventstitle", txteventstitle.Text.Trim());
                        Parameters.Add("@displayorder", txtdisplayorder.Text.Trim());

                        if (!string.IsNullOrEmpty(txtdate.Text))
                        {
                            Parameters.Add("@eventsdate", txtdate.Text.Trim());
                            clsm.ExecuteQry_Parameter("update Events set eventstitle=@eventstitle,displayorder=@displayorder,Eventsdate=@eventsdate where eventsid=@eventsid", Parameters);

                        }
                        else
                        {

                            clsm.ExecuteQry_Parameter("update Events set eventstitle=@eventstitle,displayorder=@displayorder,Eventsdate=null where eventsid=@eventsid", Parameters);

                        }

                        i += 1;
                    }

                }
                if (i == 0)
                {
                    trnotice.Visible = true;
                    lblnotice.Visible = true;
                    lblnotice.Text = "Please Select altest one data'";
                }

                FillImage();
                lblmsg.Text = "Record updated successfully";

            }
            catch (Exception err)
            {
                lblmsg.Text = err.Message;

            }

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                int i = 0;
                foreach (DataListItem item in dtlview.Items)
                {



                    Label lbleventsid = item.FindControl("lbleventsid") as Label;
                    TextBox txteventstitle = item.FindControl("txteventstitle") as TextBox;
                    TextBox txtdisplayorder = item.FindControl("txtdisplayorder") as TextBox;
                    CheckBox chk = item.FindControl("chk") as CheckBox;
                    Label lbluploadphoto = item.FindControl("lbluploadphoto") as Label;

                    Parameters.Clear();
                    if (chk.Checked == true)
                    {
                        Parameters.Add("@eventsid", lbleventsid.Text);
                        clsm.ExecuteQry_Parameter("delete from Events where eventsid=@eventsid", Parameters);
                        FileInfo F2 = new FileInfo(Convert.ToString(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\") + lbluploadphoto.Text);
                        if (F2.Exists)
                        {
                            F2.Delete();
                        }
                        FileInfo F3 = new FileInfo(Convert.ToString(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\") + lbluploadphoto.Text);
                        if (F3.Exists)
                        {
                            F3.Delete();
                        }
                        i += 1;

                    }



                }
                if (i == 0)
                {
                    trnotice.Visible = true;
                    lblnotice.Visible = true;
                    lblnotice.Text = "Please Select altest one data'";
                }
                FillImage();

                
            }
            catch (Exception er)
            {

                lblmsg.Text = er.Message;
            }

        }

        protected void dtlview_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                
            }
        }
    }
}