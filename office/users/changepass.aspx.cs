using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace backoffice.office.user
{
    public partial class changepass : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        public HttpCookie AUserSession = null;
        Hashtable parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label2.Text = Session["UserId"].ToString();
            }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            try
            {
                Label1.Visible = false;
                oldpassword.Text = oldpassword.Text.Replace("'", "");
                oldpassword.Text = oldpassword.Text.Replace(";", "");
                oldpassword.Text = oldpassword.Text.Replace("=", "");
                oldpassword.Text = oldpassword.Text.Replace("drop", "");

                Newpass.Text = Newpass.Text.Replace("'", "");
                Newpass.Text = Newpass.Text.Replace(";", "");
                Newpass.Text = Newpass.Text.Replace("=", "");
                Newpass.Text = Newpass.Text.Replace("drop", "");

                if (Page.IsValid)
                {

                    string Upwd = null;
                    parameters.Clear();
                    parameters.Add("Userid", Session["UserId"]);
                    Upwd = clsm.SendValue_SP("select_userpassword", parameters).ToString();
                    if (Upwd == oldpassword.Text.Trim())
                    {
                        clsm.ExecuteQry("Update BOUserMaster set Userpassword='" + Newpass.Text + "' where Userid='" + Session["UserId"] + "'");
                        Label1.Visible = true;
                        Label1.Text = "Password Changed Successfully.";
                    }
                    else
                    {
                        Label1.Visible = true;
                        Label1.Text = "Invalid Old Password.";
                        return;
                    }
                }
            }
            catch (Exception er)
            {
                Label1.Visible = true;
                Label1.Text = er.Message.ToString();
            }


        }
    }
}