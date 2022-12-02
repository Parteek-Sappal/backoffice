using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using backoffice.layers.business;
using backoffice.layers.model;
using System.Configuration;

namespace backoffice.layers.data
{  
    public class DL_login
    {
        ML_login objML_login = new ML_login();
        public static Enc_Decyption objEncrypt = new Enc_Decyption();      

        SqlConnection con = new SqlConnection(objEncrypt.AES_Decrypt(ConfigurationManager.AppSettings["dsn_SQL"], "!@12345AaxzZ$#9870"));
        public bool BL_login(ML_login objML_login)
        {
            SqlParameter[] par = { new SqlParameter("@Userid", objML_login.usercode),
                new SqlParameter("@UserPasword", objML_login.Password)

            };
            return Convert.ToBoolean(SqlHelper.ExecuteNonQuery(con, "select_userlogin", par));
        }
        public DataTable BL_getlogin(ML_login objML_login)
        {
            SqlParameter[] par = { new SqlParameter("@Userid", objML_login.usercode),
                new SqlParameter("@UserPasword", objML_login.Password)

            };
            return SqlHelper.ExecuteDataset(con, "select_userlogin", par).Tables[0];
        }
    }
}