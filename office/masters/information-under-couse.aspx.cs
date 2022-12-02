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

namespace backoffice.office.masters
{
    public partial class information_under_couse : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        public int appno;
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            trerror.Visible = false;
            trnotice.Visible = false;
            trsuccess.Visible = false;
            if (Page.IsPostBack == false)
            {
                gridshow();
            }
        }
        protected void btnsubmit_Click(object sender, System.EventArgs e)
        {
            try
            {
                details.Text = Server.HtmlEncode(CKeditor1.Text);
                CKeditor1.ReadOnly = true;
                string var = clsm.MasterSave(this, id.Parent, 4, mainclass.Mode.modeModify, "lastupdatelogSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])));
                CKeditor1.ReadOnly = false;
                gridshow();
                trsuccess.Visible = true;
                lblsuccess.Text = "Record updated successfully.";
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message;
            }

        }

        protected void gridshow()
        {
            try
            {

                CKeditor1.ReadOnly = true;
                Parameters.Clear();
                clsm.MoveRecord_Parameter(this, id.Parent, "select top 1 * from lastupdatelog where id=1", Parameters);
                CKeditor1.ReadOnly = false;

                CKeditor1.Text = Server.HtmlDecode(details.Text);

            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }

        }

    }
}