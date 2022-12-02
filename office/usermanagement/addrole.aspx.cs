using Microsoft.AspNet.FriendlyUrls;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace backoffice.office.usermanagement
{
    public partial class addrole : System.Web.UI.Page
    {
        mainclass Clsm = new mainclass();
        int rid;
        string qstring;
        SqlConnection consql = new SqlConnection();
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            trsuccess.Visible = false;
            trerror.Visible = false;
            trnotice.Visible = false;
            if (Page.IsPostBack == false)
            {
                try
                {
                    Parameters.Clear();
                    Clsm.datalistDatashow_Parameter(DlAccess, "select * from ModuleMaster where status=1 order by displayorder", Parameters);

                    tr_per.Visible = false;

                    if (Conversion.Val(Request.QueryString["roleid"]) != 0)
                    {
                        DlAccess.Visible = true;
                        qstring = Microsoft.VisualBasic.Strings.Replace(Request.QueryString["roleid"], "'", "''");
                        Parameters.Clear();
                        Parameters.Add("@roleid", Conversion.Val(qstring));
                        Clsm.MoveRecord_Parameter(this, roleid.Parent, "Select * from RoleMaster where roleid =@roleid", Parameters);
                        DataSet dscheck = new DataSet();
                        Parameters.Clear();
                        Parameters.Add("@roleid", Conversion.Val(qstring));
                        dscheck = Clsm.senddataset_Parameter("select * from Role_details where roleid=@roleid", Parameters);

                        foreach (DataListItem item in DlAccess.Items)
                        {
                            TextBox txtmid = (TextBox)item.FindControl("txtmid");
                            GridView GridView2 = (GridView)item.FindControl("GridView2");

                            foreach (int d in GridView2.Rows)
                            {
                                CheckBox chkbx2 = (CheckBox)item.FindControl("chkselect");

                                foreach (int m in dscheck.Tables[0].Rows)
                                {
                                    if (GridView2.Rows[d].Cells[0].Text == dscheck.Tables[0].Rows[m]["formid"])
                                    {
                                        if (dscheck.Tables[0].Rows[m]["viwform"] == "true")
                                        {
                                            chkbx2.Checked = true;
                                        }
                                    }
                                }
                            }
                        }

                    }

                }
                catch (Exception ex)
                {
                    trerror.Visible = true;
                    lblerror.Text = ex.Message.ToString();
                }

            }
        }
        protected void showList()
        {
            DlAccess.Visible = true;
            tr_per.Visible = true;
            int i, r;
            foreach (DataListItem item in DlAccess.Items)
            {
                GridView GridView2 = (GridView)item.FindControl("GridView2");
                var loopTo = GridView2.Rows.Count - 1;
                for (i = 0; i <= loopTo; i++)
                {
                    CheckBox chkbx2 = (CheckBox)GridView2.Rows[i].FindControl("chkselect");
                    chkbx2.Checked = false;
                }
            }
        }

        protected void DlAccess_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            GridView GridView2 = (GridView)e.Item.FindControl("GridView2");
            GridView gridSubDepartment = (GridView)e.Item.FindControl("gridSubDepartment");
            GridView gridcampus = (GridView)e.Item.FindControl("gridcampus");

            ImageButton btnhide = (ImageButton)e.Item.FindControl("btnhide");
            ImageButton btnshow = (ImageButton)e.Item.FindControl("btnshow");
            TextBox txtmid = (TextBox)e.Item.FindControl("txtmid");

            Parameters.Clear();
            Parameters.Add("@Moduleid", Conversion.Val(txtmid.Text));
            Clsm.GridviewData_Parameter(GridView2, "SELECT distinct fmas.FormCaption, fmas.Formid FROM  FormMaster fmas INNER JOIN ModuleMaster mmas ON fmas.Moduleid = mmas.Moduleid where mmas.status=1 and fmas.status=1 and mmas.Moduleid=@Moduleid", Parameters);
            GridView2.Visible = false;
            if (Conversion.Val(txtmid.Text) == 19)
            {
                Parameters.Clear();
                Clsm.GridviewData_Parameter(gridSubDepartment, "select collageid,collagename from collage_master  where status=1  order by displayorder", Parameters);
                gridSubDepartment.Visible = false;
            }
            if (Conversion.Val(txtmid.Text) == 41)
            {
                Parameters.Clear();
                Clsm.GridviewData_Parameter(gridcampus, "select campusid,campus_name from campus  where status=1  order by displayorder", Parameters);
                gridcampus.Visible = false;
            }
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Visible = false;
            }
            
        }

        protected void gridSubDepartment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                DataSet dsdepartment = new DataSet();
                Parameters.Clear();
                string qstring = Request.QueryString["roleid"];
                Parameters.Add("@roleid", Conversion.Val(qstring));
                dsdepartment = Clsm.senddataset_Parameter("select * from collage_Management where roleid=@roleid", Parameters);
                Label lbldeptid = (Label)e.Row.FindControl("lbldeptid");
                CheckBox chkselect = (CheckBox)e.Row.FindControl("chkselect");
                foreach(int j in dsdepartment.Tables[0].Rows)
                {
                    if(lbldeptid.Text == dsdepartment.Tables[0].Rows[j]["collageid"])
                    {
                        chkselect.Checked = true;
                    }
                }
            }
        }

        protected void gridcampus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataSet dsdepartment = new DataSet();
                Parameters.Clear();
                string qstring = Request.QueryString["roleid"];
                Parameters.Add("@roleid", Conversion.Val(qstring));
                dsdepartment = Clsm.senddataset_Parameter("select * from campusrole_Management where roleid=@roleid", Parameters);
                Label lblcampusid = (Label)e.Row.FindControl("lblcampusid");
                CheckBox chkselect = (CheckBox)e.Row.FindControl("chkselect");
                foreach (int j in dsdepartment.Tables[0].Rows)
                {
                    if (lblcampusid.Text == dsdepartment.Tables[0].Rows[j]["lblcampusid"])
                    {
                        chkselect.Checked = true;
                    }
                }
            }
        }
        protected void SaveCampusDetails(int RId)
        {
            roleid.Text = RId.ToString();
            int i = 0;
            foreach (DataListItem dl in DlAccess.Items)
            {
                TextBox txtmid = (TextBox)dl.FindControl("txtmid");
                if (Conversion.Val(txtmid.Text) == 41)
                {
                    Parameters.Clear();
                    Parameters.Add("@rid", Conversion.Val(RId));
                    Clsm.ExecuteQry_Parameter("delete from campusrole_Management where roleid=@rid", Parameters);

                    GridView gridcampus = (GridView)dl.FindControl("gridcampus");
                    foreach(int k in gridcampus.Rows)
                    {
                        Label lblcampusid = (Label)gridcampus.Rows[k].FindControl("lblcampusid");
                        CheckBox chkselect = (CheckBox)gridcampus.Rows[k].FindControl("chkselect");
                        if (chkselect.Checked == true)
                        {
                            SqlCommand objcmd = new SqlCommand("campusrole_ManagementSP", consql);
                            objcmd.CommandType = CommandType.StoredProcedure;
                            objcmd.Parameters.AddWithValue("@campusid", Conversion.Val(lblcampusid.Text));
                            objcmd.Parameters.AddWithValue("@roleid", RId);
                            objcmd.Parameters.AddWithValue("@status", 1);
                            objcmd.Parameters.AddWithValue("@Uname", "sadmin");
                            objcmd.Parameters.AddWithValue("@mode", 1);
                            objcmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        protected void SaveDepartmentDetails(int RId)
        {
            roleid.Text = RId.ToString();
            int i = 0;
            foreach (DataListItem dl in DlAccess.Items)
            {
                TextBox txtmid = (TextBox)dl.FindControl("txtmid");
                if (Conversion.Val(txtmid.Text) == 41)
                {
                    Parameters.Clear();
                    Parameters.Add("@rid", Conversion.Val(RId));
                    Clsm.ExecuteQry_Parameter("delete from collage_Management where roleid=@rid", Parameters);

                    GridView gridcampus = (GridView)dl.FindControl("gridSubDepartment");
                    foreach (int k in gridcampus.Rows)
                    {
                        Label lblcampusid = (Label)gridcampus.Rows[k].FindControl("lbldeptid");
                        CheckBox chkselect = (CheckBox)gridcampus.Rows[k].FindControl("chkselect");
                        if (chkselect.Checked == true)
                        {
                            SqlCommand objcmd = new SqlCommand("collage_managementSP", consql);
                            objcmd.CommandType = CommandType.StoredProcedure;
                            objcmd.Parameters.AddWithValue("@collageid", Conversion.Val(lblcampusid.Text));
                            objcmd.Parameters.AddWithValue("@roleid", RId);
                            objcmd.Parameters.AddWithValue("@status", 1);
                            objcmd.Parameters.AddWithValue("@Uname", "sadmin");
                            objcmd.Parameters.AddWithValue("@mode", 1);
                            objcmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        protected void selectall_CheckedChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            checkedall();
        }
        protected void checkedall()
        {
            int i = 0;
            foreach(DataListItem item in DlAccess.Items)
            {
                GridView GridView2 = (GridView)item.FindControl("GridView2");

                foreach (int d in GridView2.Rows)
                {
                    CheckBox chkbx2 = (CheckBox)GridView2.Rows[d].FindControl("chkselect");
                    CheckBox selectall = (CheckBox)GridView2.Rows[d].FindControl("selectall");

                    if (selectall.Checked == true)
                    {
                        chkbx2.Checked = true;
                    }
                    else
                    {
                        chkbx2.Checked = false;
                    }                   
                }

            }
        }
        protected void datalistgrdeachitem(int var)
        {
            try
            {
                int i, ctr;
                Parameters.Clear();
                Parameters.Add("@rid", Conversion.Val(rid));
                Clsm.ExecuteQry_Parameter("delete fro Role_details where roleid=@rid", Parameters);
                consql.ConnectionString = Clsm.strconnect;
                consql.Open();
                foreach (DataListItem item in DlAccess.Items)
                {
                    GridView GridView2 = (GridView)item.FindControl("GridView2");
                    Label lblMName = (Label)item.FindControl("lblMName");
                    TextBox txtmid = (TextBox)item.FindControl("txtmid");

                    foreach(int l in GridView2.Rows)
                    {
                        CheckBox chkbx2 = (CheckBox)GridView2.Rows[l].FindControl("chkselect");
                        string fmid = GridView2.Rows[l].Cells[0].Text.ToString();

                        if (chkbx2.Checked == true)
                        {
                            SqlCommand objcmd3 = new SqlCommand("Role_detailsSP", consql);
                            objcmd3.CommandType = CommandType.StoredProcedure;
                            objcmd3.Parameters.AddWithValue("@roleid", rid);
                            objcmd3.Parameters.AddWithValue("@formid", fmid);
                            objcmd3.Parameters.AddWithValue("@viewform", 1);
                            objcmd3.Parameters.AddWithValue("@mode", 1);
                            objcmd3.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand objcmd3 = new SqlCommand("Role_detailsSP", consql);
                            objcmd3.CommandType = CommandType.StoredProcedure;
                            objcmd3.Parameters.AddWithValue("@roleid", rid);
                            objcmd3.Parameters.AddWithValue("@formid", fmid);
                            objcmd3.Parameters.AddWithValue("@viewform", 0);
                            objcmd3.Parameters.AddWithValue("@mode", 1);
                            objcmd3.ExecuteNonQuery();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if(Page.IsValid)
                {
                    if (Conversion.Val(Clsm.MasterSave(this, roleid.Parent, 3, mainclass.Mode.modeCheckDuplicate, "RoleMasterSP", Session["UserId"].ToString())) > 0)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "This Role is already exist.";
                        return;
                    }
                    if (Conversion.Val(roleid.Text) == 0)
                    {
                        rolestatus.Checked = true;
                        rid = Convert.ToInt32(Clsm.MasterSave(this, roleid.Parent, 3, mainclass.Mode.modeAdd, "RoleMasterSP", Session["UserId"].ToString()));
                        datalistgrdeachitem(Convert.ToInt32(rid));
                        SaveDepartmentDetails(Convert.ToInt32(rid));
                        SaveCampusDetails(Convert.ToInt32(rid));                        
                        trsuccess.Visible = true;
                        lblsuccess.Text = "Role added successfully.";
                    }
                    else
                    {
                        rolestatus.Checked = true;
                        rid = Convert.ToInt32(Clsm.MasterSave(this, roleid.Parent, 3, mainclass.Mode.modeModify, "RoleMasterSP", Session["UserId"].ToString()));
                        datalistgrdeachitem(Convert.ToInt32(rid));
                        SaveDepartmentDetails(Convert.ToInt32(rid));
                        SaveCampusDetails(Convert.ToInt32(rid));
                        trsuccess.Visible = true;
                        Response.Redirect("viewrole.aspx?edit=edit");
                    }
                }
            }
            catch(Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Conversion.Val(roleid.Text) != 0)
            {
                Response.Redirect("viewrole.aspx");
            }
            rolestatus.Checked = true;
        }
    }
}