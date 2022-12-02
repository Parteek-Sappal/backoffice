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
using System.Web.UI.HtmlControls;

namespace backoffice.office.Testimonials
{
    public partial class addtestimonialstype : System.Web.UI.Page
    {
        mainclass Clsm = new mainclass();
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (!Page.IsPostBack)
            {
                if ((Conversion.Val(Request.QueryString["mid"]) > 0))
                {
                    Parameters.Clear();
                    Parameters.Add("@Tesid", double.Parse(Request.QueryString["mid"]));
                    Clsm.MoveRecord_Parameter(this, Tesid.Parent, "select * from Testimonials_Type where Tesid=@Tesid", Parameters);
                    Tesid.Text = HttpUtility.HtmlDecode(Tesid.Text);
                    Testimonialtype.Text = HttpUtility.HtmlDecode(Testimonialtype.Text);
                    banner.Text = HttpUtility.HtmlDecode(banner.Text);
                    displayorder.Text = HttpUtility.HtmlDecode(displayorder.Text);
                    if ((banner.Text != ""))
                    {
                        Image1.Visible = true;
                        Image1.ImageUrl = ("~/Uploads/banner/" + banner.Text);
                        LinkButton1.Visible = true;
                        LinkButton1.Text = "Remove Image";
                    }

                }

                gridshow();
                if ((HttpUtility.HtmlEncode(Request.QueryString["edit"]) == "edit"))
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record updated successfully.";
                }
            }
        }

        protected void gridshow()
        {
            try
            {

                Parameters.Clear();
                Clsm.GridviewData_Parameter(GridView1, "select * from Testimonials_Type order by displayorder", Parameters);
                if ((GridView1.Rows.Count == 0))
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "Record(s) not found.";
                }

            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
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

                default:
                    return false;

            }
        }

        protected void btnsubmit_Click(object sender, System.EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Tesid.Text = HttpUtility.HtmlEncode(Tesid.Text);
                    Testimonialtype.Text = HttpUtility.HtmlEncode(Testimonialtype.Text);
                    banner.Text = HttpUtility.HtmlEncode(banner.Text);
                    displayorder.Text = HttpUtility.HtmlEncode(displayorder.Text);
                    if (Convert.ToInt32(Clsm.MasterSave(this, Tesid.Parent, 5, mainclass.Mode.modeCheckDuplicate, "Testimonials_TypeSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])))) > 0)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "This testimonials type already exist.";
                        return;
                    }

                    if ((Conversion.Val(Tesid.Text) == 0))
                    {
                        if ((File1.PostedFile.FileName != ""))
                        {
                            if ((CheckImgType(File1.PostedFile.FileName) == false))
                            {
                                trnotice.Visible = true;
                                lblnotice.Visible = true;
                                lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png\'";
                                return;
                            }

                            banner.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        }

                        Status.Checked = true;
                        object var = Clsm.MasterSave(this, Tesid.Parent, 5, mainclass.Mode.modeAdd, "Testimonials_TypeSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])));
                        if ((File1.PostedFile.FileName != ""))
                        {                            
                            Parameters.Clear();
                            Parameters.Add("@Tesid", Conversion.Val(var));
                            string StrFileName = Convert.ToString(Clsm.SendValue_Parameter("Select banner from Testimonials_Type where Tesid=@Tesid", Parameters));
                            FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + StrFileName));
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }

                            File1.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\banner\\" + StrFileName));
                        }

                        Clsm.ClearallPanel(this, Tesid.Parent);
                        gridshow();
                        trsuccess.Visible = true;
                        lblsuccess.Text = "Record added successfully.";
                    }
                    else
                    {
                        if ((File1.PostedFile.FileName != ""))
                        {
                            if ((CheckImgType(File1.PostedFile.FileName) == false))
                            {
                                trnotice.Visible = true;
                                lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png\'";
                                return;
                            }

                        }

                        object var = Clsm.MasterSave(this, Tesid.Parent, 5, mainclass.Mode.modeModify, "Testimonials_TypeSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])));
                        if ((File1.PostedFile.FileName != ""))
                        {
                            FileInfo F2 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + Server.HtmlDecode(banner.Text)));
                            if (F2.Exists)
                            {
                                F2.Delete();
                            }

                            banner.Text = HttpUtility.HtmlEncode(Path.GetFileName((var + ("tom_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")))));
                            FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + Server.HtmlDecode(banner.Text)));
                            if (F1.Exists)
                            {
                                trnotice.Visible = true;
                                lblnotice.Text = "Image already exist, Please choose another image.";
                                return;
                            }

                            // ' update banner file
                            SqlConnection objcon = new SqlConnection(Clsm.strconnect);
                            objcon.Open();
                            SqlCommand objcmd = new SqlCommand(("update Testimonials_Type set banner=@banner where Tesid="
                                            + (Conversion.Val(var) + "")), objcon);
                            objcmd.Parameters.Add(new SqlParameter("@banner", banner.Text));
                            objcmd.ExecuteNonQuery();
                            objcon.Close();
                            File1.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\banner\\" + Server.HtmlDecode(banner.Text)));
                        }

                        Response.Redirect("addtestimonialstype.aspx?edit=edit");
                    }

                }
                catch (Exception ex)
                {
                    trerror.Visible = true;
                    lblerror.Text = ex.Message;
                }

            }

        }

        protected void btncancel_Click(object sender, System.EventArgs e)
        {
            Clsm.ClearallPanel(this, Tesid.Parent);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ((e.CommandName == "edit"))
            {
                Response.Redirect(("addtestimonialstype.aspx?mid=" + e.CommandArgument));
            }

            if ((e.CommandName == "status"))
            {
                GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
                TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
                if ((txtstatus.Text == "False"))
                {
                    Parameters.Clear();
                    Parameters.Add("@Tesid", Conversion.Val(e.CommandArgument));
                    Clsm.ExecuteQry_Parameter("update Testimonials_Type set status=1 where Tesid=@Tesid", Parameters);
                }
                else if ((txtstatus.Text == "True"))
                {
                    Parameters.Clear();
                    Parameters.Add("@Tesid", Conversion.Val(e.CommandArgument));
                    Clsm.ExecuteQry_Parameter("update Testimonials_Type set status=0 where Tesid=@Tesid", Parameters);
                }

                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }

            if ((e.CommandName == "del"))
            {
                Parameters.Clear();
                Parameters.Add("@Tesid", Conversion.Val(e.CommandArgument));
                if ((Clsm.Checking_Parameter("select * from Testimonials where Tesid=@Tesid", Parameters) == true))
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "Sorry, Data in use. Can not delete.";
                    return;
                }
                else
                {
                    GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
                    Label lblimage = (Label)row.FindControl("lblimage");
                    Parameters.Clear();
                    Parameters.Add("@Tesid", Conversion.Val(e.CommandArgument));
                    Clsm.ExecuteQry_Parameter("delete from Testimonials_Type where Tesid=@Tesid", Parameters);
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + Server.HtmlDecode(lblimage.Text)));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    gridshow();
                    trnotice.Visible = true;
                    lblnotice.Text = "Testimonials type deleted successfully.";
                }

            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
                HtmlImage imgimage = (HtmlImage)e.Row.FindControl("imgimage");
                Label lblimage = (Label)e.Row.FindControl("lblimage");
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



                if ((lblimage.Text == ""))
                {
                    imgimage.Visible = false;
                }
                else
                {
                    imgimage.Src = ("~/Uploads/banner/" + Server.HtmlDecode(lblimage.Text));
                    imgimage.Visible = true;
                }
            }
        }

        protected void LinkButton1_Click(object sender, System.EventArgs e)
        {
            if ((LinkButton1.Text != ""))
            {
                FileInfo F2 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + Server.HtmlDecode(banner.Text)));
                if (F2.Exists)
                {
                    F2.Delete();
                }

            }

            Parameters.Clear();
            Parameters.Add("@Tesid", double.Parse(banner.Text));
            Clsm.ExecuteQry_Parameter("update Testimonials_Type set banner=\'\' where Tesid=@Tesid", Parameters);
            banner.Text = "";
            LinkButton1.Text = "";
            Image1.Visible = false;
        }
    }
}