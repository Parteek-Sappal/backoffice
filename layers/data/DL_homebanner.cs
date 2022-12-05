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
    public class DL_homebanner
    {
        public static Enc_Decyption objEncrypt = new Enc_Decyption();

        SqlConnection con = new SqlConnection(objEncrypt.AES_Decrypt(ConfigurationManager.AppSettings["dsn_SQL"], "!@12345AaxzZ$#9870"));

        public bool BL_insupdhomebanner(ML_homebanner objML_homebanner)
        {
            SqlParameter[] par = { new SqlParameter("@bid", objML_homebanner.bid),                
                new SqlParameter("@btypeid", objML_homebanner.btypeid),
                   new SqlParameter("@title", objML_homebanner.title),
                   new SqlParameter("@tagline1", objML_homebanner.tagline1),
                new SqlParameter("@tagline2", objML_homebanner.tagline2),
                new SqlParameter("@bannerimage", objML_homebanner.bannerimage),
                new SqlParameter("@bannermobile", objML_homebanner.bannermobile),
                    new SqlParameter("@displayorder", objML_homebanner.displayorder),
                 new SqlParameter("@Status", objML_homebanner.Status),
                 new SqlParameter("@url", objML_homebanner.url),
                new SqlParameter("@collageid", objML_homebanner.collageid),
                new SqlParameter("@blogo", objML_homebanner.blogo),
                new SqlParameter("@devicetype", objML_homebanner.devicetype),
                        new SqlParameter("@uname", objML_homebanner.uname),
                        new SqlParameter("@mode", objML_homebanner.mode)

            };
            return Convert.ToBoolean(SqlHelper.ExecuteNonQuery(con, "homebannerSP", par));
        }
    }
}