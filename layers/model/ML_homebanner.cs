using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backoffice.layers.model
{
    public class ML_homebanner
    {        
        public Int32 bid { get; set; }
        public Int32 collageid { get; set; }
        public Int32 btypeid { get; set; }
        public string devicetype { get; set; }
        public string title { get; set; }
        public string tagline1 { get; set; }
        public string tagline2 { get; set;}
        public string bannerimage { get; set; }
        public string bannermobile { get; set; }
        public string blogo { get; set; }
        public string url { get; set; }
        
        public Int32 displayorder { get; set; }
        public Int32 Status { get; set; }
        public string uname { get; set; }
        public Int32 mode { get; set; }

    }
}