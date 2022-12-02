using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backoffice.layers.model
{
    public class ML_cms
    {
        public string pageid { get; set; }
        public string pagetitle { get; set; }
        public string linkname { get; set; }
        public string linkposition { get; set; }
        public string pagename { get; set; }
        public string pagemeta { get; set; }
        public string pagemetadesc { get; set; }
        public string pagedescription { get; set; }
        public string smalldesc { get; set; }
        public Int32 pagestatus { get; set; }
        public Int32 quicklink { get; set; }
        public string parentid{ get; set; }
        public string pageurl { get; set; }
        public string rewriteid { get; set; }
        public string rewriteurl { get; set; }
        public string target { get; set; }
        public string tagline { get; set; }
        public string uploadbanner { get; set; }
        public decimal displayorder { get; set; }
        public string megamenu { get; set; }
        public Int32 collageid { get; set; }
        public string canonical { get; set; }
        public Int32 no_indexfollow { get; set; }
        public string other_scheme { get; set; }
        public string dynamicurlvalue { get; set; }

        public string dynamicurlrewrite { get; set; }
        public string pagedescription1 { get; set; }
        public string pagedescription2 { get; set; }
        public Int32 restricted { get; set; }
        public string uname { get; set; }
        public Int32 mode { get; set; }


    }
}