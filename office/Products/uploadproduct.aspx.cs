using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Collections;
using System.IO;

namespace backoffice.office.Products
{
    public partial class uploadproduct : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        SqlConnection consql = new SqlConnection();
        OleDbConnection conacc = new OleDbConnection();
        OleDbDataAdapter daacc;
        DataSet dsacc;
        string fpath;
        Hashtable parameters = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
        }
        public bool CheckFileType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".xls":
                    return true;
                case ".xlsx":
                    return true;
                default:
                    return false;
            }
        }
        protected void btnSubmit_Click(object sender, System.EventArgs e)
        {
            try
            {
                if ((File1.PostedFile.FileName != ""))
                {
                    if ((CheckFileType(Path.GetFileName(File1.PostedFile.FileName)) == true))
                    {
                        string strfile;
                        strfile = Path.GetFileName(File1.PostedFile.FileName.Replace(" ", ""));
                        int _min = 1000;
                        int _max = 9999;
                        Random _rdm = new Random();
                        strfile = _rdm.Next(_min, _max) + "_" + strfile;
                        if ((Path.GetFileName(File1.PostedFile.FileName) != ""))
                        {
                            FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\Files\\" + strfile)));
                            if (F1.Exists)
                            {
                                F1.Delete();
                            }

                            File1.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + ("\\Uploads\\Files\\" + strfile)));
                        }

                        fpath = (Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\Files\\" + strfile));
                        consql.ConnectionString = clsm.strconnect;
                        if ((consql.State == ConnectionState.Open))
                        {
                            consql.Close();
                        }

                        consql.Open();
                        conacc.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                                   + (fpath + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\";"));
                     

                        conacc.Open();
                        int i;
                        daacc = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", conacc);
                        dsacc = new DataSet();
                        daacc.Fill(dsacc);
                        for (i = 0; (i <= (dsacc.Tables[0].Rows.Count - 1)); i++)
                        {                            
                            if ((dsacc.Tables[0].Rows[i]["PartNo"].ToString().Trim().Replace("\'", "") != ""))
                            {


                                string strprodid;

                                if ((clsm.Checking(("Select productid From Products where status=1 and productcode=\'"
                                                + (dsacc.Tables[0].Rows[i]["PartNo"].ToString().Trim().Replace("\'", "") + "\'"))) == false))
                                {
                                    SqlCommand objcmdlocadd = new SqlCommand("ProductuploadSP", consql);
                                    objcmdlocadd.CommandType = CommandType.StoredProcedure;


                                    objcmdlocadd.Parameters.AddWithValue("@seriesid", dsacc.Tables[0].Rows[i]["Series"].ToString().Trim().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@psubcatid", 0);
                                    objcmdlocadd.Parameters.AddWithValue("@psubsubcatid", 0);
                                    objcmdlocadd.Parameters.AddWithValue("@psubsubsubcatid", 0);
                                    objcmdlocadd.Parameters.AddWithValue("@productname", dsacc.Tables[0].Rows[i]["Description"].ToString().Trim().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@shortdetail", "");
                                    objcmdlocadd.Parameters.AddWithValue("@productdetail", "");
                                    objcmdlocadd.Parameters.AddWithValue("@displayorder", 0);
                                    objcmdlocadd.Parameters.AddWithValue("@rewrite_url", "");
                                    objcmdlocadd.Parameters.AddWithValue("@PageTitle", dsacc.Tables[0].Rows[i]["Description"].ToString().Trim().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@PageMeta", dsacc.Tables[0].Rows[i]["Description"].ToString().Trim().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@PageMetaDesc", dsacc.Tables[0].Rows[i]["Description"].ToString().Trim().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@prospectus", "");
                                    objcmdlocadd.Parameters.AddWithValue("@UploadAImage", dsacc.Tables[0].Rows[i]["ProductImage"].ToString().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@status", "1");





                                    objcmdlocadd.Parameters.AddWithValue("@productcode", dsacc.Tables[0].Rows[i]["PartNo"].ToString().Trim().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@purl", "");
                                    objcmdlocadd.Parameters.AddWithValue("@Isnewlaunches", 0);
                                    objcmdlocadd.Parameters.AddWithValue("@mainprice", dsacc.Tables[0].Rows[i]["mainprice"].ToString().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@retailprice", dsacc.Tables[0].Rows[i]["mainprice"].ToString().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@youtubeurl", "");
                                    objcmdlocadd.Parameters.AddWithValue("@pagescript", "");
                                    objcmdlocadd.Parameters.AddWithValue("@no_indexfollow", 0);
                                    objcmdlocadd.Parameters.AddWithValue("@canonical", "");
                                    objcmdlocadd.Parameters.AddWithValue("@urlfirst", "");
                                    objcmdlocadd.Parameters.AddWithValue("@urlsecond", "");
                                    objcmdlocadd.Parameters.AddWithValue("@urlthird", "");
                                    objcmdlocadd.Parameters.AddWithValue("@urlfour", "");
                                    objcmdlocadd.Parameters.AddWithValue("@urlfive", "");
                                    objcmdlocadd.Parameters.AddWithValue("@lookid", dsacc.Tables[0].Rows[i]["Look"].ToString().Trim().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@coatid", dsacc.Tables[0].Rows[i]["Coat"].ToString().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@Decor", 0);
                                    objcmdlocadd.Parameters.AddWithValue("@DecorName", dsacc.Tables[0].Rows[i]["DecorName"].ToString().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@featureproduct", 0);
                                    objcmdlocadd.Parameters.AddWithValue("@colorid", dsacc.Tables[0].Rows[i]["Color"].ToString().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@modelid", dsacc.Tables[0].Rows[i]["ModelName"].ToString().Trim().Replace("\'", ""));

                                    objcmdlocadd.Parameters.AddWithValue("@typeid", dsacc.Tables[0].Rows[i]["Type"].ToString().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@sizeid", "All Size Available");
                                    objcmdlocadd.Parameters.AddWithValue("@uomid", 1);
                                    objcmdlocadd.Parameters.AddWithValue("@eppdid", dsacc.Tables[0].Rows[i]["eppd"].ToString().Replace("\'", ""));


                                    objcmdlocadd.Parameters.AddWithValue("@Uname", "admin");
                                    objcmdlocadd.Parameters.AddWithValue("@Mode", 1);
                                    objcmdlocadd.Parameters.Add("@productid", SqlDbType.Int, 0).Direction = ParameterDirection.Output;
                                    objcmdlocadd.ExecuteNonQuery();
                                    strprodid = objcmdlocadd.Parameters["@productid"].Value.ToString();
                                }
                                else
                                {
                                    SqlCommand objcmdlocadd = new SqlCommand("ProductuploadSP", consql);
                                    objcmdlocadd.CommandType = CommandType.StoredProcedure;

                                    objcmdlocadd.Parameters.AddWithValue("@seriesid", dsacc.Tables[0].Rows[i]["Series"].ToString().Trim().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@psubcatid", "0");
                                    objcmdlocadd.Parameters.AddWithValue("@psubsubcatid", "0");
                                    objcmdlocadd.Parameters.AddWithValue("@psubsubsubcatid", "0");
                                    objcmdlocadd.Parameters.AddWithValue("@productname", dsacc.Tables[0].Rows[i]["Description"].ToString().Trim().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@shortdetail", "");
                                    objcmdlocadd.Parameters.AddWithValue("@productdetail", "");
                                    objcmdlocadd.Parameters.AddWithValue("@displayorder", "0");
                                    objcmdlocadd.Parameters.AddWithValue("@rewrite_url", "");
                                    objcmdlocadd.Parameters.AddWithValue("@PageTitle", dsacc.Tables[0].Rows[i]["Description"].ToString().Trim().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@PageMeta", dsacc.Tables[0].Rows[i]["Description"].ToString().Trim().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@PageMetaDesc", dsacc.Tables[0].Rows[i]["Description"].ToString().Trim().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@prospectus", "");
                                    objcmdlocadd.Parameters.AddWithValue("@UploadAImage", dsacc.Tables[0].Rows[i]["ProductImage"].ToString().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@status", "1");


                                    objcmdlocadd.Parameters.AddWithValue("@productcode", dsacc.Tables[0].Rows[i]["PartNo"].ToString().Trim().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@purl", "");
                                    objcmdlocadd.Parameters.AddWithValue("@Isnewlaunches", "0");
                                    objcmdlocadd.Parameters.AddWithValue("@mainprice", dsacc.Tables[0].Rows[i]["mainprice"].ToString().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@retailprice", dsacc.Tables[0].Rows[i]["mainprice"].ToString().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@youtubeurl", "");
                                    objcmdlocadd.Parameters.AddWithValue("@pagescript", "");
                                    objcmdlocadd.Parameters.AddWithValue("@no_indexfollow", 0);
                                    objcmdlocadd.Parameters.AddWithValue("@canonical", "0");
                                    objcmdlocadd.Parameters.AddWithValue("@urlfirst", "");
                                    objcmdlocadd.Parameters.AddWithValue("@urlsecond", "");
                                    objcmdlocadd.Parameters.AddWithValue("@urlthird", "");
                                    objcmdlocadd.Parameters.AddWithValue("@urlfour", "");
                                    objcmdlocadd.Parameters.AddWithValue("@urlfive", "");
                                    objcmdlocadd.Parameters.AddWithValue("@lookid", dsacc.Tables[0].Rows[i]["Look"].ToString().Trim().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@coatid", dsacc.Tables[0].Rows[i]["Coat"].ToString().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@Decor", dsacc.Tables[0].Rows[i]["Decor"].ToString().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@DecorName", dsacc.Tables[0].Rows[i]["DecorName"].ToString().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@featureproduct", "0");
                                    objcmdlocadd.Parameters.AddWithValue("@colorid", dsacc.Tables[0].Rows[i]["Color"].ToString().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@modelid", dsacc.Tables[0].Rows[i]["ModelName"].ToString().Trim().Replace("\'", ""));

                                    objcmdlocadd.Parameters.AddWithValue("@typeid", dsacc.Tables[0].Rows[i]["Type"].ToString().Replace("\'", ""));
                                    objcmdlocadd.Parameters.AddWithValue("@sizeid", "All Size Available");
                                    objcmdlocadd.Parameters.AddWithValue("@uomid", "1");
                                    objcmdlocadd.Parameters.AddWithValue("@eppdid", dsacc.Tables[0].Rows[i]["eppd"].ToString().Replace("\'", ""));


                                    objcmdlocadd.Parameters.AddWithValue("@Uname", "admin");
                                    objcmdlocadd.Parameters.AddWithValue("@Mode", 3);

                                    objcmdlocadd.ExecuteNonQuery();

                                }

                            }

                            // ***********************************************************
                        }

                        conacc.Close();
                        conacc.Open();
                    }

                    consql.Close();
                    conacc.Close();
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Product(s) added successfully.";
                }
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }

        }
       

        protected void lnkdownload_Click(object sender, System.EventArgs e)
        {
            string strfile;
            strfile = "sparkminda.xls";
            FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("uploads\\Files\\SampleFile\\" + strfile)));
            if (F1.Exists)
            {
                Response.Redirect("~/Office/DownloadFile.aspx?D=~/uploads/Files/SampleFile/" + strfile);
            }

        }
    }
}