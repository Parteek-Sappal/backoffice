using System;
using System.Data;
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
using System.Collections.ObjectModel;

namespace backoffice.office
{
    
    public partial class dataupdate : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, System.EventArgs e)
        {
            string strsql = null;
            strsql = TextBox1.Text.Trim();
            clsm.GridDatashow(DataGrid2, strsql, false);
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string strsql = null;
            strsql = TextBox1.Text;
            clsm.ExecuteQry(strsql);
            clsm.ShowMessage(this, "data updated");
            return;
        }
        private void uploadProc()
        {
            //Open a file for reading
            string FILENAME = Server.MapPath("Proc.sql");
            //Get a StreamReader class that can be used to read the file
            StreamReader objStreamReader = default(StreamReader);
            objStreamReader = File.OpenText(FILENAME);
            //Now, read the entire file into a string
            string strsql = objStreamReader.ReadToEnd();
            try
            {
                TextBox1.Text = strsql;
                objStreamReader.Close();
            }
            catch (Exception err)
            {
                objStreamReader.Close();
                throw (err);
            }
        }
    }
}