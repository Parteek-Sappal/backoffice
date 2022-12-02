using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace backoffice.office.Products
{
    public partial class orientationtype : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        string StrFileName;
        Hashtable parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trnotice.Visible = false;
            trsuccess.Visible = false;
            if (Page.IsPostBack == false)
            {
                gridshow();

                if (Request.QueryString["edit"] != "")
                {
                    // trsuccess.Visible = true;
                    lblsuccess.Text = "Record Updated Successfully";
                }
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            if ((Page.IsValid == true))
            {
                try
                {
                    if (Convert.ToInt32(clsm.MasterSave(this, modelid.Parent, 10, mainclass.Mode.modeCheckDuplicate, "orientation_masterSP", Session["Name"].ToString()).ToString()) > 0)
                    {
                        Label1.Visible = true;
                        Label1.Text = "This Record Already Exist";
                        return;
                    }

                    if ((modelid.Text != ""))
                    {

                        if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                        {
                            if ((CheckImgType(File2.PostedFile.FileName)) == false)
                            {
                                trnotice.Visible = true;
                                lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                                return;
                            }

                        }

                        object var = clsm.MasterSave(this, modelid.Parent, 10, mainclass.Mode.modeModify, "orientation_masterSP", Session["Name"].ToString());

                        if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                        {
                            banner.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "modelimg_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + banner.Text);
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }
                            //' update banner file
                            SqlConnection objcon = new SqlConnection(clsm.strconnect);
                            objcon.Open();
                            SqlCommand objcmd = new SqlCommand("update orientation_master set banner=@banner where modelid=" + var + "", objcon);
                            objcmd.Parameters.Add(new SqlParameter("@banner", banner.Text));
                            objcmd.ExecuteNonQuery();
                            objcon.Close();
                            File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\ProductsImage\\" + banner.Text);
                        }

                        clsm.ClearallPanel(this, modelid.Parent);
                        trsuccess.Visible = true;
                        lblsuccess.Text = "Record Updated Successfully.";
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                        {
                            if ((CheckImgType(File2.PostedFile.FileName)) == false)
                            {
                                trnotice.Visible = true;
                                lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                                return;
                            }

                        }

                        object var = clsm.MasterSave(this, modelid.Parent, 10, mainclass.Mode.modeAdd, "orientation_masterSP", Session["Name"].ToString());

                        if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                        {
                            parameters.Clear();
                            parameters.Add("@modelid", var);
                            StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select banner from orientation_master where modelid=@modelid", parameters));
                            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + StrFileName);
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }
                            File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\ProductsImage\\" + StrFileName);
                        }


                        clsm.ClearallPanel(this, modelid.Parent);
                        trsuccess.Visible = true;
                        lblsuccess.Text = "Record Added Successfully.";
                    }

                    gridshow();
                }
                catch (Exception eer)
                {
                    Label1.Visible = true;
                    Label1.Text = eer.Message;
                }

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
        protected void gridshow()
        {
            string strq2;
            parameters.Clear();
            strq2 = "SELECT * FROM orientation_master order by displayorder";
            clsm.GridviewData_Parameter(GridView1, strq2, parameters);
            if ((GridView1.Rows.Count == 0))
            {
                trnotice.Visible = true;
                lblnotice.Text = "No Record(s) Available";
                GridView1.Visible = false;
            }
            else
            {
                GridView1.Visible = true;
            }

            // Dim strquery As String
            // strquery = "SELECT * FROM brand order by displayorder"
            // clsm.GridDatashow(DataGrid1, strquery)
            // If DataGrid1.Items.Count > 0 Then
            //     DataGrid1.Visible = True
            // Else
            //     DataGrid1.Visible = False
            //     trnotice.Visible = True
            //     lblnotice.Text = "No Records"
            // End If
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                gridshow();
            }
            catch (Exception ex)
            {
                Label1.Visible = true;
                Label1.Text = ex.Message.ToString();
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ((e.CommandName == "btndel"))
            {
                GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));


                TextBox modelid = (TextBox)row.FindControl("modelid");
                //if ((clsm.Checking(("select Prodid from Product where brandid="
                //                + (double.Parse(sizeid.Text) + ""))) == true))
                //{
                //    Label1.Visible = true;
                //    Label1.Text = "This Size is map in product section";
                //    return;
                //}

                //else
                //{

                parameters.Clear();
                parameters.Add("@modelid", double.Parse(e.CommandArgument.ToString()));
                clsm.ExecuteQry_Parameter("delete from orientation_master where modelid=@modelid", parameters);
                //}

                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Deleted Successfully.";
            }

            if ((e.CommandName == "lnkstatus"))
            {
                GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
                TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
                if ((txtstatus.Text == "False"))
                {
                    parameters.Clear();
                    parameters.Add("@modelid", double.Parse(e.CommandArgument.ToString()));
                    string strsql = "update orientation_master set status=1 where modelid=@modelid";
                    clsm.ExecuteQry_Parameter(strsql, parameters);
                }
                else if ((txtstatus.Text == "True"))
                {
                    Hashtable parameters = new Hashtable();
                    parameters.Add("@modelid", double.Parse(e.CommandArgument.ToString()));
                    string strsql = "update orientation_master set status=0 where modelid=@modelid";
                    clsm.ExecuteQry_Parameter(strsql, parameters);
                }

                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status Changed Successfully !!!";
            }

            if ((e.CommandName == "btnedit"))
            {
                // Response.Redirect("addhomebanner.aspx?bid=" & Val(e.CommandArgument))
                clsm.MoveRecord(this, modelid.Parent, ("Select * from orientation_master where modelid = "
                                + (e.CommandArgument) + ""));

                if (!string.IsNullOrEmpty(banner.Text.Trim()))
                {
                    File2.Visible = true;
                    LinkButton1.Visible = true;
                    Image1.Visible = true;
                    Image1.ImageUrl = "../../Uploads/ProductsImage/" + banner.Text;
                }
                else
                {
                    LinkButton1.Visible = false;
                }
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
                TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");



                if ((txtstatus.Text == "True"))
                {
                    lnkstatus.ImageUrl = "~/Office/assets/ico_unblock.png";
                    lnkstatus.ToolTip = "Active";
                }
                else if ((txtstatus.Text == "False"))
                {
                    lnkstatus.ImageUrl = "~/Office/assets/ico_block.png";
                    lnkstatus.ToolTip = "Inactive";
                }

                e.Row.Attributes.Add("onmouseover", ("this.style.backgroundColor=\'"
                                + (Session["altColor"] + "\'")));
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#FFFFFF\'");
            }

        }


        protected void Button2_Click(object sender, System.EventArgs e)
        {
            clsm.ClearallPanel(this, Label1.Parent);
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(banner.Text))
            {
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + banner.Text);
                if (F1.Exists)
                {
                    F1.Delete();
                }
            }
            parameters.Clear();
            parameters.Add("@modelid", Convert.ToInt32(Request.QueryString["modelid"]));
            clsm.SendValue_Parameter("update orientation_master set banner='' where modelid=@modelid", parameters);
            banner.Text = "";
            Image1.Visible = false;
            trsuccess.Visible = true;
            LinkButton1.Visible = false;
            lblsuccess.Text = "File deleted successfully.";
        }
    }
}