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
using System.Net.Mail;
using System.Net;

namespace backoffice.office.usercontrols
{
    public partial class uc_backmenu : System.Web.UI.UserControl
    {
        public HttpCookie AUserSession = null;
        string masterscat, checkscat;
        mainclass clsm = new mainclass();
        Hashtable Parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["AUserSession"] == null)
            {
                AUserSession = new HttpCookie("AUserSession");
            }
            else
            {
                AUserSession = Request.Cookies["AUserSession"];
            }
            if (!IsPostBack)
            {

                if (Conversion.Val(AUserSession["Roleid"]) == 1)
                {
                    Parameters.Clear();
                    clsm.repeaterDatashow_Parameter(repmain, " select distinct moduleid, modulename,displayorder from modulemaster where status=1  order by displayorder", Parameters);
                }
                else
                {                   
                    Parameters.Clear();
                    Parameters.Add("@roleid", Conversion.Val(AUserSession["Roleid"]));
                    clsm.repeaterDatashow_Parameter(repmain, "select distinct m.moduleid, m.modulename,m.displayorder from modulemaster m inner join  formmaster fm on  m.moduleid=fm.moduleid inner join role_details r on fm.formid=r.formid where r.roleid=@roleid and fm.status=1 and m.status=1 and fm.status=1 and r.viewform=1  order by m.displayorder", Parameters);
                }

            }
        }
        protected void repinner_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "show")
            {
                string strurl = "../" + e.CommandArgument;
                Response.Redirect(strurl);
            }
        }
        protected void repmain_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                TextBox moduleid = (TextBox)e.Item.FindControl("moduleid");
                Repeater repinner = (Repeater)e.Item.FindControl("repinner");

                if (Conversion.Val(AUserSession["Roleid"]) == 1)
                {
                    Parameters.Clear();
                    Parameters.Add("@moduleid", Conversion.Val(moduleid.Text));
                    clsm.repeaterDatashow_Parameter(repinner, "select distinct fm.* from  formmaster fm  left join role_details r on fm.formid=r.formid where fm.moduleid=@moduleid and fm.status=1 order by fm.displayorder", Parameters);
                }
                else
                {
                    Parameters.Clear();
                    Parameters.Add("@roleid", Conversion.Val(AUserSession["Roleid"]));
                    Parameters.Add("@moduleid", Conversion.Val(moduleid.Text));
                    clsm.repeaterDatashow_Parameter(repinner, "select distinct fm.* from  formmaster fm  inner join role_details r on fm.formid=r.formid where r.roleid=@roleid and fm.moduleid=@moduleid and fm.status=1 and r.viewform=1 order by fm.displayorder", Parameters);
                }
            }
        }
    }
}