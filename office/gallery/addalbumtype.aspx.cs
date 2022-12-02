using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualBasic;

namespace backoffice.office.gallery
{
    public partial class addalbumtype : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        public int appno;
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trnotice.Visible = false;
            trsuccess.Visible = false;
            if ((Page.IsPostBack == false))
            {               

                if ((Conversion.Val(Request.QueryString["typeid"]) > 0))
                {
                    Parameters.Clear();
                    Parameters.Add("@typeid", double.Parse(Request.QueryString["typeid"]));
                    clsm.MoveRecord_Parameter(this, typeid.Parent, "select * from Albumtype where typeid=@typeid", Parameters);
                    if (!string.IsNullOrEmpty(albumimage.Text))
                    {
                        Image1.Visible = true;
                        Image1.ImageUrl = "../../Uploads/vedio/" + albumimage.Text;
                        LinkButton2.Visible = true;
                    }
                }
                gridshow();
            }
        }
        protected void btnsubmit_Click(object sender, System.EventArgs e)
        {


            try
            {
                string StrFileName1 = null;


                if (Convert.ToInt32(clsm.MasterSave(this, typeid.Parent, 14, mainclass.Mode.modeCheckDuplicate, "AlbumtypeSP", Convert.ToString(Session["UserId"]))) > 0)
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "This Type already exist.";
                    return;
                }

                if (Conversion.Val(typeid.Text) == 0)
                {
                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        if ((CheckthumbnailType(File1.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a thumbnail with a thumbnail format extension of Either bmp,gif,jpeg or jpg";
                            return;
                        }
                        albumimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    }
                    else
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a thumbnail with a thumbnail format extension of Either bmp,gif,jpeg or jpg";
                        return;
                    }

                    status.Checked = true;
                    string var = clsm.MasterSave(this, typeid.Parent, 14, mainclass.Mode.modeAdd, "AlbumtypeSP", Convert.ToString(Session["UserId"]));

                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {

                        Parameters.Clear();
                        Parameters.Add("@typeid", var);
                        StrFileName1 = Convert.ToString(clsm.SendValue_Parameter("Select albumimage from Albumtype where typeid=@typeid", Parameters));
                        FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\vedio\\" + StrFileName1);
                        if (F2.Exists)
                        {
                            F2.Delete();
                        }
                        else
                        {
                            File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\vedio\\" + StrFileName1);
                        }
                    }


                    clsm.ClearallPanel(this, typeid.Parent);
                    gridshow();
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record added successfully.";
                }
                else
                {

                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        if ((CheckthumbnailType(File1.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a thumbnail with a thumbnail format extension of Either jpeg,bmp,gif,png or jpg ";
                            return;
                        }
                    }


                    string var = clsm.MasterSave(this, typeid.Parent, 14, mainclass.Mode.modeModify, "AlbumtypeSP", (Convert.ToString(Session["UserId"])));

                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        albumimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "altype_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\vedio\\" + albumimage.Text);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        //' update banner file
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update Albumtype set albumimage=@albumimage where typeid=" + var + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@albumimage", albumimage.Text));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();

                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\vedio\\" + albumimage.Text);
                    }



                    clsm.ClearallPanel(this, typeid.Parent);
                    gridshow();
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record updated successfully.";
                }

            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message;
            }



        }
        public bool CheckthumbnailType(string fileName)
        {
            string ext1 = Path.GetExtension(fileName);
            switch (ext1.ToLower())
            {
                case ".jpeg":
                    return true;
                case ".jpg":
                    return true;
                case ".bmp":
                    return true;
                case ".gif":
                    return true;
                case ".png":
                    return true;
                default:
                    return false;
            }
        }

        protected void gridshow()
        {
            try
            {
                Parameters.Clear();
                clsm.GridviewData_Parameter(GridView1, "select * from Albumtype order by displayorder", Parameters);
                appno = GridView1.Rows.Count;
                if ((GridView1.Rows.Count == 0))
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "No Record found.";
                }

            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                Response.Redirect(("addalbumtype.aspx?typeid=" + e.CommandArgument));
            }

            if (e.CommandName == "status")
            {
                GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
                TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
                if (txtstatus.Text == "False")
                {
                    Parameters.Clear();
                    Parameters.Add("@typeid", Conversion.Val(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update Albumtype set status=1 where typeid=@typeid", Parameters);
                }
                else if (txtstatus.Text == "True")
                {
                    Parameters.Clear();
                    Parameters.Add("@typeid", Conversion.Val(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update Albumtype set status=0 where typeid=@typeid", Parameters);
                }

                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }

            if (e.CommandName == "del")
            {
                Parameters.Clear();
                Parameters.Add("@typeid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("delete from Albumtype where typeid=@typeid", Parameters);
                gridshow();
                trnotice.Visible = true;
                lblnotice.Text = "Record deleted successfully.";
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
                TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");


                if (txtstatus.Text == "True")
                {
                    lnkstatus.ImageUrl = "../assets/ico_unblock.png";
                    lnkstatus.ToolTip = "Yes";
                }
                else if (txtstatus.Text == "False")
                {
                    lnkstatus.ImageUrl = "../assets/ico_block.png";
                    lnkstatus.ToolTip = "No";
                }
            }

        }

        protected void btncancel_Click(object sender, System.EventArgs e)
        {            
            if (string.IsNullOrEmpty(typeid.Text))
            {
                clsm.ClearallPanel(this, typeid.Parent);
            }
            else
            {
                Response.Redirect("addalbumtype.aspx");
            }
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(albumimage.Text))
            {
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\vedio\\" + albumimage.Text);
                if (F1.Exists)
                {
                    F1.Delete();
                }

            }

            Parameters.Clear();
            Parameters.Add("@typeid", typeid.Text);
            clsm.ExecuteQry_Parameter("update Albumtype set albumimage='' WHERE typeid=@typeid", Parameters);
            albumimage.Text = "";
            Image1.Visible = false;
            LinkButton2.Visible = false;


        }
    }
}