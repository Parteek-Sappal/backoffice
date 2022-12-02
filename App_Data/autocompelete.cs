using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

/// <summary>
/// Summary description for MyWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class autocompelete : System.Web.Services.WebService {

     mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    public autocompelete()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(EnableSession = true)]

    public string[] programList(string prefixText)
    {
        List<string> items = new List<string>();
        HttpContext cur = HttpContext.Current;
        parameters.Clear();
        parameters.Add("@prefixText", prefixText);
        string strsql = "select coursename from course where  status=1  and  coursename like '%' + @prefixText + '%' order by  coursename";
        DataSet ds = clsm.senddataset_Parameter(strsql, parameters);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int j = 0; j < ds.Tables[0].Rows.Count - 1; j++)
            {
                if (items.Contains(ds.Tables[0].Rows[j]["coursename"].ToString()) == false && ds.Tables[0].Rows[j]["coursename"].ToString() != "")
                {
                    items.Add(ds.Tables[0].Rows[j]["coursename"].ToString());
                }

            }

        }
        return items.ToArray();
    }






}
