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
    public class DL_cms
    {
        public static Enc_Decyption objEncrypt = new Enc_Decyption();

        SqlConnection con = new SqlConnection(objEncrypt.AES_Decrypt(ConfigurationManager.AppSettings["dsn_SQL"], "!@12345AaxzZ$#9870"));

        public bool BL_insupdpages(ML_cms objML_cms)
        {
            SqlParameter[] par = { new SqlParameter("@pageid", objML_cms.pageid),
                new SqlParameter("@pagename", objML_cms.pagename),
                new SqlParameter("@linkposition", objML_cms.linkposition),
                new SqlParameter("@linkname", objML_cms.linkname),
                new SqlParameter("@pagetitle", objML_cms.pagetitle),
                   new SqlParameter("@pagemeta", objML_cms.pagemeta),
                new SqlParameter("@pagemetadesc", objML_cms.pagemetadesc),
                new SqlParameter("@megamenu", objML_cms.megamenu),
                new SqlParameter("@pagestatus", objML_cms.pagestatus),
                new SqlParameter("@parentid", objML_cms.parentid),
                new SqlParameter("@pageurl", objML_cms.pageurl),
                   new SqlParameter("@rewriteid", objML_cms.rewriteid),
                 new SqlParameter("@rewriteurl", objML_cms.rewriteurl),
                 new SqlParameter("@uploadbanner", objML_cms.uploadbanner),
                 new SqlParameter("@displayorder", objML_cms.displayorder),
                 new SqlParameter("@quicklink", objML_cms.quicklink),
                 new SqlParameter("@smalldesc", objML_cms.smalldesc),
                     new SqlParameter("@restricted", objML_cms.restricted),
                     new SqlParameter("@target", objML_cms.target),
                new SqlParameter("@tagline", objML_cms.tagline),
                   new SqlParameter("@collageid", objML_cms.collageid),
                     new SqlParameter("@canonical", objML_cms.canonical),
                new SqlParameter("@no_indexfollow", objML_cms.no_indexfollow),
                     new SqlParameter("@other_scheme", objML_cms.other_scheme),
                      new SqlParameter("@dynamicurlvalue", objML_cms.dynamicurlvalue),
                       new SqlParameter("@dynamicurlrewrite", objML_cms.dynamicurlrewrite),
                new SqlParameter("@pagedescription1", objML_cms.pagedescription1),
                new SqlParameter("@pagedescription2", objML_cms.pagedescription2),
                new SqlParameter("@pagedescription", objML_cms.pagedescription),
                        new SqlParameter("@uname", objML_cms.uname),
                        new SqlParameter("@mode", objML_cms.mode)

            };
            return Convert.ToBoolean(SqlHelper.ExecuteNonQuery(con, "pagemastersp", par));
        }
    }
}