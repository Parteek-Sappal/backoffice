using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using backoffice.layers.model;
using backoffice.layers.data;

namespace backoffice.layers.business
{
    public class BL_homebanner
    {
        DL_homebanner objDL_homebanner = new DL_homebanner();

        public bool BL_insupdhomebanner(ML_homebanner objML_homebanner)
        {
            return objDL_homebanner.BL_insupdhomebanner(objML_homebanner);
        }
    }
}