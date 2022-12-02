using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;

namespace backoffice.office.homebanner
{
    public partial class addhomebannertype : System.Web.UI.Page
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
                if (Conversion.Val(Request.QueryString["prodid"]) > 0)
                {
                    collageid.Text = Convert.ToString(Conversion.Val(Request.QueryString["prodid"]));
                    tr1.Visible = true;
                    Parameters.Clear();
                    Parameters.Add("@prodid", Convert.ToString(Conversion.Val(Request.QueryString["prodid"])));
                    lblcollage.Text = Convert.ToString(clsm.SendValue_Parameter("SELECT productname FROM products WHERE productid=@prodid", Parameters));
                }
                else
                {
                    collageid.Text = "0";
                }

                if ((Conversion.Val(Request.QueryString["btypeid"]) > 0))
                {
                    Parameters.Clear();
                    Parameters.Add("@btypeid", Conversion.Val(Request.QueryString["btypeid"]));
                    string strsql = "select * from homebannertype where btypeid=@btypeid  ";
                    if (Conversion.Val(Request.QueryString["clid"]) > 0)
                    {
                        Parameters.Add("@collageid", Convert.ToString(Request.QueryString["clid"]));
                        strsql += " and collageid=@collageid ";
                    }
                    clsm.MoveRecord_Parameter(this, btypeid.Parent, strsql, Parameters);
                }
                if (Convert.ToString(Request.QueryString["add"]) == "add")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Added Successfully.";
                }
                if (Convert.ToString(Request.QueryString["edit"]) == "edit")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record updated Successfully.";
                }
                gridshow();
            }
        }
        protected void btnsubmit_Click(object sender, System.EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {

                    if (Convert.ToInt32(clsm.MasterSave(this, btypeid.Parent, 6, mainclass.Mode.modeCheckDuplicate, "homebannertypeSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])))) > 0)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "This Banner Type already exist.";
                        return;
                    }
                    if (Conversion.Val(btypeid.Text) == 0)
                    {

                        clsm.MasterSave(this, btypeid.Parent, 6, mainclass.Mode.modeAdd, "homebannertypeSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])));                       

                        string strcollageid = String.Empty;
                        if (Conversion.Val(collageid.Text) > 0)
                        {
                            strcollageid = "&prodid=" + Conversion.Val(collageid.Text);
                        }
                        Response.Redirect("addhomebannertype.aspx?add=add" + strcollageid);
                        
                        gridshow();
                        trsuccess.Visible = true;
                        lblsuccess.Text = "Record added successfully.";
                    }
                    else
                    {
                        clsm.MasterSave(this, btypeid.Parent, 6, mainclass.Mode.modeModify, "homebannertypeSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])));                                             

                        string strcollageid = String.Empty;
                        if (Conversion.Val(collageid.Text) > 0)
                        {
                            strcollageid = "&prodid=" + Conversion.Val(collageid.Text);
                        }
                        Response.Redirect("addhomebannertype.aspx?edit=edit" + strcollageid);


                        
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

        }



        protected void gridshow()
        {
            try
            {
                Parameters.Clear();
                string strsql = "select * from homebannertype where 1=1 ";                
                
                Parameters.Add("@collageid", Conversion.Val(Request.QueryString["prodid"]));
                strsql += " and collageid=@collageid";
                
                strsql += " order by displayorder";


                clsm.GridviewData_Parameter(GridView1, strsql, Parameters);
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
                string strcollageid = String.Empty;
                if ((double.Parse(collageid.Text) > 0))
                {
                    strcollageid = ("&prodid=" + double.Parse(collageid.Text));
                }
                Response.Redirect("addhomebannertype.aspx?btypeid=" + Convert.ToString(e.CommandArgument) + strcollageid);
            }

            if (e.CommandName == "status")
            {
                GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
                TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
                if (txtstatus.Text == "False")
                {
                    Parameters.Clear();
                    Parameters.Add("@btypeid", Conversion.Val(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update homebannertype set status=1 where btypeid=@btypeid and collageid=" + Conversion.Val(Request.QueryString["clid"]) + "", Parameters);


                    Parameters.Clear();
                    Parameters.Add("@btypeid", Conversion.Val(e.CommandArgument));

                    clsm.ExecuteQry_Parameter("update homebannertype set status=0 where btypeid!=@btypeid and collageid=" + Conversion.Val(Request.QueryString["clid"]) + "", Parameters);
                }
                else if (txtstatus.Text == "True")
                {
                    Parameters.Clear();
                    Parameters.Add("@btypeid", Conversion.Val(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update homebannertype set status=0 where btypeid=@btypeid and collageid=" + Conversion.Val(Request.QueryString["clid"]) + "", Parameters);
                }

                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }


            if (e.CommandName == "mobilestatus")
            {
                GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
                TextBox mobiletxtstatus = (TextBox)row.FindControl("mobiletxtstatus");
                if (mobiletxtstatus.Text == "False")
                {
                    Parameters.Clear();
                    Parameters.Add("@btypeid", Conversion.Val(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update homebannertype set mobilestatus=1 where btypeid=@btypeid and collageid=" + Conversion.Val(Request.QueryString["clid"]) + "", Parameters);

                    Parameters.Clear();
                    Parameters.Add("@btypeid", Conversion.Val(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update homebannertype set mobilestatus=0 where btypeid!=@btypeid and collageid=" + Conversion.Val(Request.QueryString["clid"]) + "", Parameters);
                }
                else if (mobiletxtstatus.Text == "True")
                {
                    Parameters.Clear();
                    Parameters.Add("@btypeid", Conversion.Val(e.CommandArgument));
                    clsm.ExecuteQry_Parameter("update homebannertype set mobilestatus=0 where btypeid=@btypeid and collageid=" + Conversion.Val(Request.QueryString["clid"]) + "", Parameters);
                }

                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Status changed successfully.";
            }

            if (e.CommandName == "del")
            {
                Parameters.Clear();
                Parameters.Add("@btypeid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("delete from homebannertype where btypeid=@btypeid", Parameters);
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

                ImageButton mobilelnkstatus = (ImageButton)e.Row.FindControl("mobilelnkstatus");
                TextBox mobiletxtstatus = (TextBox)e.Row.FindControl("mobiletxtstatus");


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

                if (mobiletxtstatus.Text == "True")
                {
                    mobilelnkstatus.ImageUrl = "../assets/ico_unblock.png";
                    mobilelnkstatus.ToolTip = "Yes";
                }
                else if (mobiletxtstatus.Text == "False")
                {
                    mobilelnkstatus.ImageUrl = "../assets/ico_block.png";
                    mobilelnkstatus.ToolTip = "No";
                }
            }

        }

        protected void btncancel_Click(object sender, System.EventArgs e)
        {
            string strcollageid = String.Empty;
            if (Conversion.Val(collageid.Text) > 0)
            {
                strcollageid = "&prodid=" + Conversion.Val(collageid.Text);
            }
            Response.Redirect("addhomebannertype.aspx" + strcollageid);
            
        }
    }
}