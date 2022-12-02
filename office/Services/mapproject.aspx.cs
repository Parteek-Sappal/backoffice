using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections;

namespace backoffice.office.Services
{
    public partial class mapproject : System.Web.UI.Page
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
                Filltestimonials();
                Fill_alldata();
            }
        }
        private void Filltestimonials()
        {
            Parameters.Clear();
            string stralbum = "select * from project WHERE status=1 order by DisplayOrder   ";
            DataSet ds = clsm.senddataset_Parameter(stralbum, Parameters);
            projectlist.DataSource = ds.Tables[0];
            projectlist.DataBind();
            if (projectlist.Items.Count > 0)
            {
                Button1.Visible = true;
            }
            else
            {
                Button1.Visible = false;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (DataListItem item in projectlist.Items)
            {
                Parameters.Clear();
                Label lblprojectid = item.FindControl("lblprojectid") as Label;
                TextBox lblprojectname = item.FindControl("lblprojectname") as TextBox;
                CheckBox checkfeature = item.FindControl("checkfeature") as CheckBox;
                if (checkfeature.Checked == true)
                {
                    if (clsm.Checking("select * from map_project_services  where serviceid='" + Conversion.Val(Request.QueryString["serviceid"]) + "' and projectid= '" + Conversion.Val(lblprojectid.Text) + "' ") == false)
                    {
                        if (clsm.Checking("select mapid from map_project_services where projectid='"
                                        + (Conversion.Val(lblprojectid.Text) + "' and serviceid='"
                                        + (Conversion.Val(Request.QueryString["serviceid"])) + "'")) == false)
                        {
                            clsm.ExecuteQry("insert into map_project_services (serviceid,projectid)values("
                                          + (Request.QueryString["serviceid"]) + ","
                                          + (Conversion.Val(lblprojectid.Text) + ")"));
                        }
                    }
                }
                else
                {
                    clsm.ExecuteQry("delete from map_project_services where projectid="
                                    + (Conversion.Val(lblprojectid.Text) + " and serviceid="
                                    + (Conversion.Val(Request.QueryString["serviceid"]) + "  ")));
                }
                trsuccess.Visible = true;
                lblsuccess.Text = "Service Map Successfully.";
            }
            Filltestimonials();
            Fill_alldata();
        }
        private void Fill_alldata()
        {
            Parameters.Clear();
            Parameters.Add("@serviceid", Conversion.Val(Request.QueryString["serviceid"]));
            string strquery = "select * from map_project_services where serviceid=@serviceid";
            DataSet ds = clsm.senddataset_Parameter(strquery, Parameters);
            if ((ds.Tables[0].Rows.Count > 0))
            {
                foreach (DataListItem li in projectlist.Items)
                {
                    CheckBox checkfeature = (CheckBox)li.FindControl("checkfeature");
                    Label lblprojectname = (Label)li.FindControl("lblprojectname");
                    Label lblprojectid = (Label)li.FindControl("lblprojectid");
                    for (int index = 0; index <= ds.Tables[0].Rows.Count - 1; index++)
                    {
                        if (Conversion.Val(ds.Tables[0].Rows[index]["projectid"]) == Conversion.Val(lblprojectid.Text))
                        {
                            checkfeature.Checked = true;
                            lblprojectname.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                }
            }
        }
    }
}