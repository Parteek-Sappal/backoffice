using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using backoffice.layers.model;
using backoffice.layers.data;

namespace backoffice.layers.business
{
    public class BL_cms
    {
        DL_cms objDL_cms=new DL_cms();
        public bool BL_insupdpages(ML_cms objML_cms)
        {
            return objDL_cms.BL_insupdpages(objML_cms);
        }
    }
}