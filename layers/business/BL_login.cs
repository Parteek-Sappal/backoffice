using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using backoffice.layers.data;
using backoffice.layers.model;
using System.Data;

namespace backoffice.layers.business
{
    public class BL_login
    {
        ML_login objML_login=new ML_login();
        DL_login objDL_login=new DL_login();

        public DataTable BL_getlogin(ML_login objML_login)
        {
            return objDL_login.BL_getlogin(objML_login);
        }
        public bool BL_logindetail(ML_login objML_login)
        {
            return objDL_login.BL_login(objML_login);
        }
    }
}