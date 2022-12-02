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
            
        }
    }
}