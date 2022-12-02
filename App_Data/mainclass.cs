using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Text;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Configuration;
//using System.Web.UI.MasterPage;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Web.UI.WebControls;
using System.Web.Configuration;



public class mainclass
{

    private byte[] key = {
		
	};
    private byte[] IV = {
		0x12,
		0x34,
		0x56,
		0x78,
		0x90,
		0xab,
		0xcd,
		0xef
	};
    object Vartemp;
    public int test;
    System.Web.SessionState.HttpSessionState session = HttpContext.Current.Session;

    //    public string strconnect = ConfigurationManager.AppSettings["dsn_SQL"];

    public static Enc_Decyption objEncrypt = new Enc_Decyption();

    public string strconnect = objEncrypt.AES_Decrypt(ConfigurationManager.AppSettings["dsn_SQL"], "!@12345AaxzZ$#9870");
    //   public string strServer = ConfigurationManager.AppSettings["ServerN"];
    //   public string strDatabase = ConfigurationManager.AppSettings["DatabseN"];
    //   public string strUID = ConfigurationManager.AppSettings["uidN"];
    //   public string strPWD = ConfigurationManager.AppSettings["pwdN"];

    static DataSet mgrid = new DataSet();

    public static string rvariable;

    public static string csspath;

    public static string imagespath;
    HttpCookie UserSession = default(HttpCookie);

    public enum Mode
    {
        modeAdd = 1,
        //Honda
        modeModify = 2,
        //Maruti
        modeDelete = 3,
        //Mtnl
        modeCheckDuplicate = 4,
        modeCheckDuplicate2 = 5,
        modeCheckDuplicate3 = 6
    }

    public void initilize(ref System.Web.UI.Page page)
    {
        //    if (page.Session["strconnect1"] !="")
        //        strconnect = page.Session["strconnect1"].ToString();
        //    else
        //        strconnect = System.Configuration.ConfigurationManager.AppSettings["dsn_SQL"];
        //if (HttpContext.Current.Request.Cookies["UserSessionTest"] != null)
        //{
        //    UserSessionTest = HttpContext.Current.Request.Cookies["UserSessionTest"];
        //    UserSessionTest["USTest"] = "5";
        //}
        //if (HttpContext.Current.Request.Cookies["UserSessionTest"] != null)
        //{
        //    HttpContext.Current.Request.Cookies["UserSessionTest"]="5";
        //}

    }

    //public string AES_Decrypt(string input, string pass)
    //{
    //    System.Security.Cryptography.RijndaelManaged AES = new System.Security.Cryptography.RijndaelManaged();
    //    System.Security.Cryptography.MD5CryptoServiceProvider Hash_AES = new System.Security.Cryptography.MD5CryptoServiceProvider();
    //    string decrypted = "";
    //    try
    //    {
    //        byte[] hash = new byte[32];
    //        byte[] temp = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass));
    //        Array.Copy(temp, 0, hash, 0, 16);
    //        Array.Copy(temp, 0, hash, 15, 16);
    //        AES.Key = hash;
    //        AES.Mode = System.Security.Cryptography.CipherMode.ECB;
    //        System.Security.Cryptography.ICryptoTransform DESDecrypter = AES.CreateDecryptor;
    //        byte[] Buffer = Convert.FromBase64String(input);
    //        decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length));
    //        return decrypted;
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    //public string AES_Encrypt(string input, string pass)
    //{
    //    System.Security.Cryptography.RijndaelManaged AES = new System.Security.Cryptography.RijndaelManaged();
    //    System.Security.Cryptography.MD5CryptoServiceProvider Hash_AES = new System.Security.Cryptography.MD5CryptoServiceProvider();
    //    string encrypted = "";
    //    try
    //    {
    //        byte[] hash = new byte[32];
    //        byte[] temp = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass));
    //        Array.Copy(temp, 0, hash, 0, 16);
    //        Array.Copy(temp, 0, hash, 15, 16);
    //        AES.Key = hash;
    //        AES.Mode = System.Security.Cryptography.CipherMode.ECB;
    //        System.Security.Cryptography.ICryptoTransform DESEncrypter = AES.CreateEncryptor;
    //        byte[] Buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(input);
    //        encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length));
    //        return encrypted;
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    public string Encrypt(string stringToEncrypt, string SEncryptionKey)
    {
        try
        {
            key = System.Text.Encoding.UTF8.GetBytes(Strings.Left(SEncryptionKey, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string Decrypt(string stringToDecrypt, string sEncryptionKey)
    {
        byte[] inputByteArray = new byte[stringToDecrypt.Length + 1];
        try
        {
            key = System.Text.Encoding.UTF8.GetBytes(Strings.Left(sEncryptionKey, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(stringToDecrypt);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string GetAppno(string tablename, string colname, string ocol)
    {
        string strsql;
        SqlConnection connection = new SqlConnection(strconnect);
        connection.Open();
        SqlDataAdapter adapter;
        DataSet dataset = new DataSet();

        Int32 APPNO1;
        string APPNO2;
        strsql = "SELECT TOP 1 REPLACE(" + colname + ",'APP','') FROM " + tablename + " ORDER BY " + ocol + " DESC ";
        adapter = new SqlDataAdapter(strsql, connection);
        adapter.Fill(dataset);
        if (dataset.Tables[0].Rows.Count > 0)
        {
            APPNO1 = Convert.ToInt32(dataset.Tables[0].Rows[0][0].ToString());
            APPNO1 = APPNO1 + 1;
            if (APPNO1 < 10)
            {
                APPNO2 = "APP000" + APPNO1;

            }
            else if (APPNO1 < 100)
            {
                APPNO2 = "APP00" + APPNO1;

            }
            else if (APPNO1 < 1000)
            {
                APPNO2 = "APP0" + APPNO1;

            }
            else if (APPNO1 < 10000)
            {
                APPNO2 = "APP" + APPNO1;

            }
            else
            {
                APPNO2 = "APP0001";
            }


        }
        else
        {

            APPNO2 = "APP0001";
        }
        return APPNO2;
    }

    public string GetFileExt(string filename, HtmlImage img1, string path)
    {
        string ext = "";

        try
        {
            if (filename != null | filename != "")
            {
                ext = System.IO.Path.GetExtension(filename.Trim());

                if (ext.ToLower().Contains("txt") == true)
                {
                    img1.Src = path + "/Images/default_document.jpeg";
                }
                else if (ext.ToLower().Contains("doc") == true | ext.ToLower().Contains("docx") == true)
                {
                    img1.Src = path + "/Images/file_doc.jpeg";
                }
                else if (ext.ToLower().Contains("xls") == true | ext.ToLower().Contains("xlsx") == true)
                {
                    img1.Src = path + "/images/excelicon.jpeg";
                }
                else if (ext.ToLower().Contains("pdf") == true)
                {
                    img1.Src = path + "/images/filetype_pdf.jpeg";
                }
                else if (ext.ToLower().Contains("jpg") == true | ext.ToLower().Contains("gif") == true)
                {
                    img1.Src = path + "/images/download.gif";
                }
                else
                {
                    img1.Src = path + "/Images/default_document.jpeg";
                }
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        return ext;
    }

    public bool Checking(string str)
    {
        bool functionReturnValue = false;
        SqlConnection cn = new SqlConnection(strconnect);
        SqlCommand cmd = new SqlCommand();
        try
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = str;
            SqlDataReader datareader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (datareader.Read() == true)
            {
                functionReturnValue = true;
            }
            else
            {
                functionReturnValue = false;
            }
            cmd.Dispose();
            cn.Close();
            cn.Dispose();
        }
        catch (Exception err)
        {
            cmd.Dispose();
            cn.Close();
            cn.Dispose();
            throw (err);
        }
        return functionReturnValue;
    }

    public void ClearallPanel(Control frmObj1, Control frmObj)
    {
        try
        {
            Control Commcont = null;
            Control Commcont1 = null;
            Control Commcont2 = null;

            foreach (Control Commcont_loopVariable in frmObj.Controls)
            {
                Commcont = Commcont_loopVariable;
                if (Commcont is UpdatePanel)
                {
                    foreach (Control Commcont1_loopVariable in Commcont.Controls)
                    {
                        Commcont1 = Commcont1_loopVariable;
                        foreach (Control Commcont2_loopVariable in Commcont1.Controls)
                        {
                            Commcont2 = Commcont2_loopVariable;
                            if (Commcont2 is DropDownList)
                            {
                                ((DropDownList)Commcont2).SelectedIndex = ((DropDownList)Commcont2).Items.IndexOf(((DropDownList)Commcont2).Items.FindByValue("0"));
                            }

                            if (Commcont2 is CheckBox)
                            {
                                ((CheckBox)Commcont2).Checked = false;
                            }

                            if (Commcont2 is TextBox)
                            {
                                ((TextBox)Commcont2).Text = "";
                            }

                            if (Commcont is CheckBoxList)
                            {
                                ((CheckBoxList)Commcont).SelectedIndex = ((CheckBoxList)Commcont).Items.IndexOf(((CheckBoxList)Commcont).Items.FindByValue("0"));
                            }

                        }

                    }
                }

                if (Commcont is TextBox)
                {
                    ((TextBox)Commcont).Text = "";
                }

                if (Commcont is DropDownList)
                {
                    ((DropDownList)Commcont).SelectedIndex = ((DropDownList)Commcont).Items.IndexOf(((DropDownList)Commcont).Items.FindByValue("0"));
                }

                if (Commcont is CheckBox)
                {
                    ((CheckBox)Commcont).Checked = false;
                }

                if (Commcont is CheckBoxList)
                {
                    ((CheckBoxList)Commcont).SelectedIndex = ((CheckBoxList)Commcont).Items.IndexOf(((CheckBoxList)Commcont).Items.FindByValue("0"));
                }

            }

        }
        catch (Exception ERR)
        {
            throw (ERR);
        }
    }

    public void MoveRecord(Control frmObj1, Control frmObj, string strSQL)
    {
        try
        {
            Control Commcont = null;
            Control Commcont1 = null;
            Control Commcont2 = null;

            System.Data.SqlClient.SqlDataAdapter adapter = null;
            adapter = new System.Data.SqlClient.SqlDataAdapter(strSQL, strconnect);
            System.Data.DataSet selecttable = new System.Data.DataSet();
            adapter.Fill(selecttable);
            if (selecttable.Tables[0].Rows.Count > 0)
            {
                //_with1 = selecttable.Tables[0];

                foreach (Control Commcont_loopVariable in frmObj.Controls)
                {
                    Commcont = Commcont_loopVariable;


                    if (Commcont is UpdatePanel)
                    {
                        foreach (Control Commcont1_loopVariable in Commcont.Controls)
                        {
                            Commcont1 = Commcont1_loopVariable;
                            foreach (Control Commcont2_loopVariable in Commcont1.Controls)
                            {
                                Commcont2 = Commcont2_loopVariable;

                                if (Commcont2 is DropDownList)
                                {
                                    if (((DropDownList)Commcont2).EnableViewState == true)
                                    {
                                        if (Information.IsDBNull(selecttable.Tables[0].Rows[0][Commcont2.ID].ToString()) == false)
                                        {
                                            //((DropDownList)Commcont2).SelectedIndex = ((DropDownList)Commcont2).Items.IndexOf(((DropDownList)Commcont2).Items.FindByValue(selecttable.Tables[0].Rows[0][Commcont2.ID]).ToString());
                                            ((DropDownList)Commcont2).SelectedIndex = ((DropDownList)Commcont2).Items.IndexOf(((DropDownList)Commcont2).Items.FindByValue(selecttable.Tables[0].Rows[0][Commcont2.ID].ToString()));
                                        }
                                    }
                                }

                                if (Commcont2 is CheckBox)
                                {
                                    if (((CheckBox)Commcont2).EnableViewState == true)
                                    {
                                        ((CheckBox)Commcont2).Checked = (selecttable.Tables[0].Rows[0][Commcont2.ID].ToString() == "False" ? false : true);
                                    }

                                }

                                if (Commcont2 is RadioButtonList)
                                {
                                    if (((RadioButtonList)Commcont2).EnableViewState == true)
                                    {
                                        if (Information.IsDBNull(selecttable.Tables[0].Rows[0][Commcont2.ID]) == false)
                                        {
                                            ((RadioButtonList)Commcont2).SelectedIndex = ((RadioButtonList)Commcont2).Items.IndexOf(((RadioButtonList)Commcont2).Items.FindByValue(selecttable.Tables[0].Rows[0][Commcont2.ID].ToString()));
                                        }
                                    }
                                }


                                if (Commcont2 is TextBox)
                                {
                                    if (((TextBox)Commcont2).ReadOnly == false)
                                    {
                                        if (selecttable.Tables[0].Rows[0][Commcont2.ID].GetType().FullName == "System.Double")
                                        {
                                            ((TextBox)Commcont2).Text = Strings.Format(selecttable.Tables[0].Rows[0][Commcont2.ID], "0.00");
                                        }
                                        else if (selecttable.Tables[0].Rows[0][Commcont2.ID].GetType().FullName == "System.DateTime")
                                        {
                                            if (System.Convert.ToDateTime(selecttable.Tables[0].Rows[0][Commcont2.ID]).ToString("MM/dd/yyyy") == "01/01/1900")
                                            {
                                                ((TextBox)Commcont2).Text = "";
                                            }
                                            else
                                            {
                                                ((TextBox)Commcont2).Text = Strings.Format(selecttable.Tables[0].Rows[0][Commcont2.ID], "MM/dd/yyyy");
                                            }
                                        }
                                        else
                                        {
                                            ((TextBox)Commcont2).Text = (Information.IsDBNull(selecttable.Tables[0].Rows[0][Commcont2.ID]) ? "" : selecttable.Tables[0].Rows[0][Commcont2.ID].ToString());
                                        }
                                    }
                                }
                            }

                        }
                    }

                    if (Commcont is TextBox)
                    {
                        if (((TextBox)Commcont).ReadOnly == false)
                        {
                            if (selecttable.Tables[0].Rows[0][Commcont.ID].GetType().FullName == "System.Double")
                            {
                                ((TextBox)Commcont).Text = Strings.Format(selecttable.Tables[0].Rows[0][Commcont.ID], "0.00");
                            }
                            else if (selecttable.Tables[0].Rows[0][Commcont.ID].GetType().FullName == "System.DateTime")
                            {
                                if (System.Convert.ToDateTime(selecttable.Tables[0].Rows[0][Commcont.ID]).ToString("MM/dd/yyyy") == "01/01/1900")
                                {
                                    ((TextBox)Commcont).Text = "";
                                }
                                else
                                {
                                    ((TextBox)Commcont).Text = Strings.Format(selecttable.Tables[0].Rows[0][Commcont.ID], "MM/dd/yyyy");
                                }
                            }
                            else
                            {
                                ((TextBox)Commcont).Text = (Information.IsDBNull(selecttable.Tables[0].Rows[0][Commcont.ID]) ? "" : selecttable.Tables[0].Rows[0][Commcont.ID].ToString());
                            }
                        }
                    }

                    if (Commcont is DropDownList)
                    {
                        if (((DropDownList)Commcont).EnableViewState == true)
                        {
                            if (Information.IsDBNull(selecttable.Tables[0].Rows[0][Commcont.ID].ToString()) == false)
                            {
                                ((DropDownList)Commcont).SelectedIndex = ((DropDownList)Commcont).Items.IndexOf(((DropDownList)Commcont).Items.FindByValue(selecttable.Tables[0].Rows[0][Commcont.ID].ToString()));
                            }
                        }
                    }
                    if (Commcont is RadioButtonList)
                    {
                        if (((RadioButtonList)Commcont).EnableViewState == true)
                        {
                            if (Information.IsDBNull(selecttable.Tables[0].Rows[0][Commcont.ID]) == false)
                            {
                                ((RadioButtonList)Commcont).SelectedIndex = ((RadioButtonList)Commcont).Items.IndexOf(((RadioButtonList)Commcont).Items.FindByValue(selecttable.Tables[0].Rows[0][Commcont.ID].ToString()));
                            }
                        }
                    }

                    if (Commcont is CheckBox)
                    {
                        if (((CheckBox)Commcont).EnableViewState == true)
                        {
                            ((CheckBox)Commcont).Checked = (selecttable.Tables[0].Rows[0][Commcont.ID].ToString() == "False" ? false : true);
                        }
                    }
                }
            }
        }
        catch (Exception ERR)
        {
            throw (ERR);
        }
    }

    #region " MoveRecord_Sp.."
    public void MoveRecord_SP(Control frmObj1, Control frmObj, string stored_proc, Hashtable parameters)
    {
        System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(strconnect);
        SqlCommand cmd = new SqlCommand(stored_proc, connection);
        try
        {
            Control Commcont = null;
            Control Commcont1 = null;
            Control Commcont2 = null;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet selecttable = new DataSet();
            DictionaryEntry Item = default(DictionaryEntry);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (DictionaryEntry Item_loopVariable in parameters)
            {
                Item = Item_loopVariable;
                cmd.Parameters.AddWithValue(Item.Key.ToString(), Item.Value);
            }
            if (cmd.Connection.State == ConnectionState.Open || cmd.Connection.State == ConnectionState.Broken)
            {
                cmd.Connection.Close();
            }

            cmd.Connection.Open();
            adapter.SelectCommand = cmd;
            adapter.Fill(selecttable);
            if (selecttable.Tables[0].Rows.Count > 0)
            {
                //var _with1 = selecttable.Tables[0];
                foreach (Control Commcont_loopVariable in frmObj.Controls)
                {
                    Commcont = Commcont_loopVariable;
                    if (Commcont is UpdatePanel)
                    {
                        foreach (Control Commcont1_loopVariable in Commcont.Controls)
                        {
                            Commcont1 = Commcont1_loopVariable;
                            foreach (Control Commcont2_loopVariable in Commcont1.Controls)
                            {
                                Commcont2 = Commcont2_loopVariable;
                                if (Commcont2 is DropDownList)
                                {
                                    if (((DropDownList)Commcont2).EnableViewState == true)
                                    {
                                        if (Information.IsDBNull(selecttable.Tables[0].Rows[0][Commcont2.ID].ToString()) == false)
                                        {
                                            ((DropDownList)Commcont2).SelectedIndex = ((DropDownList)Commcont2).Items.IndexOf(((DropDownList)Commcont2).Items.FindByValue(selecttable.Tables[0].Rows[0][Commcont2.ID].ToString()));
                                        }
                                    }
                                }

                                if (Commcont2 is CheckBox)
                                {
                                    ((CheckBox)Commcont2).Checked = (selecttable.Tables[0].Rows[0][Commcont2.ID].ToString() == "False" ? false : true);
                                }

                                //if (Commcont2 is TextBox)
                                //{
                                //    if (((TextBox)Commcont2).ReadOnly == false)
                                //    {
                                //        if (selecttable.Tables[0].Rows[0][Commcont2.ID].ToString().GetType().FullName == "System.Double")
                                //        {
                                //            ((TextBox)Commcont2).Text = Strings.Format(selecttable.Tables[0].Rows[0][Commcont2.ID].ToString(), "0.00");
                                //        }
                                //        else
                                //        {
                                //            ((TextBox)Commcont2).Text = (Information.IsDBNull(selecttable.Tables[0].Rows[0][Commcont2.ID].ToString()) ? "" : selecttable.Tables[0].Rows[0][Commcont2.ID].ToString());
                                //        }
                                //    }
                                //}
                                if (Commcont2 is TextBox)
                                {
                                    if (((TextBox)Commcont2).ReadOnly == false)
                                    {
                                        if (selecttable.Tables[0].Rows[0][Commcont2.ID].GetType().FullName == "System.Double")
                                        {
                                            ((TextBox)Commcont2).Text = Strings.Format(selecttable.Tables[0].Rows[0][Commcont2.ID], "0.00");
                                        }
                                        else if (selecttable.Tables[0].Rows[0][Commcont2.ID].GetType().FullName == "System.DateTime")
                                        {
                                            if (System.Convert.ToDateTime(selecttable.Tables[0].Rows[0][Commcont2.ID]).ToString("MM/dd/yyyy") == "01/01/1900")
                                            {
                                                ((TextBox)Commcont2).Text = "";
                                            }
                                            else
                                            {
                                                ((TextBox)Commcont2).Text = Strings.Format(selecttable.Tables[0].Rows[0][Commcont2.ID], "MM/dd/yyyy");
                                            }
                                        }
                                        else
                                        {
                                            ((TextBox)Commcont2).Text = (Information.IsDBNull(selecttable.Tables[0].Rows[0][Commcont2.ID]) ? "" : selecttable.Tables[0].Rows[0][Commcont2.ID].ToString());
                                        }
                                    }
                                }
                            }

                        }
                    }

                    //if (Commcont is TextBox)
                    //{
                    //    if (((TextBox)Commcont).ReadOnly == false)
                    //    {
                    //        if (selecttable.Tables[0].Rows[0][Commcont.ID].ToString().GetType().FullName == "System.Double")
                    //        {
                    //            ((TextBox)Commcont).Text = Strings.Format(selecttable.Tables[0].Rows[0][Commcont.ID].ToString(), "0.00");
                    //        }
                    //        else
                    //        {
                    //            ((TextBox)Commcont).Text = (Information.IsDBNull(selecttable.Tables[0].Rows[0][Commcont.ID].ToString()) ? "" : selecttable.Tables[0].Rows[0][Commcont.ID].ToString());
                    //        }
                    //    }
                    //}
                    if (Commcont is TextBox)
                    {
                        if (((TextBox)Commcont).ReadOnly == false)
                        {
                            if (selecttable.Tables[0].Rows[0][Commcont.ID].GetType().FullName == "System.Double")
                            {
                                ((TextBox)Commcont).Text = Strings.Format(selecttable.Tables[0].Rows[0][Commcont.ID], "0.00");
                            }
                            else if (selecttable.Tables[0].Rows[0][Commcont.ID].GetType().FullName == "System.DateTime")
                            {
                                if (System.Convert.ToDateTime(selecttable.Tables[0].Rows[0][Commcont.ID]).ToString("MM/dd/yyyy") == "01/01/1900")
                                {
                                    ((TextBox)Commcont).Text = "";
                                }
                                else
                                {
                                    ((TextBox)Commcont).Text = Strings.Format(selecttable.Tables[0].Rows[0][Commcont.ID], "MM/dd/yyyy");
                                }
                            }
                            else
                            {
                                ((TextBox)Commcont).Text = (Information.IsDBNull(selecttable.Tables[0].Rows[0][Commcont.ID]) ? "" : selecttable.Tables[0].Rows[0][Commcont.ID].ToString());
                            }
                        }
                    }
                    if (Commcont is DropDownList)
                    {
                        if (((DropDownList)Commcont).EnableViewState == true)
                        {
                            if (Information.IsDBNull(selecttable.Tables[0].Rows[0][Commcont.ID].ToString()) == false)
                            {
                                ((DropDownList)Commcont).SelectedIndex = ((DropDownList)Commcont).Items.IndexOf(((DropDownList)Commcont).Items.FindByValue(selecttable.Tables[0].Rows[0][Commcont.ID].ToString()));
                            }
                        }
                    }
                    if (Commcont is RadioButtonList)
                    {
                        if (((RadioButtonList)Commcont).EnableViewState == true)
                        {
                            if (Information.IsDBNull(selecttable.Tables[0].Rows[0][Commcont.ID].ToString()) == false)
                            {
                                ((RadioButtonList)Commcont).SelectedIndex = ((RadioButtonList)Commcont).Items.IndexOf(((RadioButtonList)Commcont).Items.FindByValue(selecttable.Tables[0].Rows[0][Commcont.ID].ToString()));
                            }
                        }
                    }
                    if (Commcont is CheckBox)
                    {
                        ((CheckBox)Commcont).Checked = (selecttable.Tables[0].Rows[0][Commcont.ID].ToString() == "False" ? false : true);
                    }
                }
            }
        }

        catch (Exception ERR)
        {
            throw (ERR);
        }
        finally
        {
            cmd.Connection.Close();
        }
    }
    #endregion

    //public object rightpermission(int str1, int str2)
    //{
    //    object functionReturnValue = null;
    //    SqlConnection cn = new SqlConnection(strconnect);
    //    SqlCommand cmd = new SqlCommand();
    //    try
    //    {
    //        cn.Open();
    //        cmd.Connection = cn;
    //        cmd.CommandText = str;
    //        SqlDataReader datareader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
    //        if (datareader.Read() == true)
    //        {
    //            functionReturnValue = (Information.IsDBNull(datareader[0]) ? "" : datareader[0]);
    //        }
    //        else
    //        {
    //            functionReturnValue = "";
    //        }
    //        cmd.Dispose();
    //        cn.Close();
    //        cn.Dispose();
    //    }
    //    catch (Exception err)
    //    {
    //        cmd.Dispose();
    //        cn.Close();
    //        cn.Dispose();
    //        throw (err);
    //    }
    //    return functionReturnValue;
    //}
    public object SendValue(string str)
    {
        object functionReturnValue = null;
        SqlConnection cn = new SqlConnection(strconnect);
        SqlCommand cmd = new SqlCommand();
        try
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = str;
            SqlDataReader datareader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (datareader.Read() == true)
            {
                functionReturnValue = (Information.IsDBNull(datareader[0]) ? "" : datareader[0]);
            }
            else
            {
                functionReturnValue = "";
            }
            cmd.Dispose();
            cn.Close();
            cn.Dispose();
        }
        catch (Exception err)
        {
            cmd.Dispose();
            cn.Close();
            cn.Dispose();
            throw (err);
        }
        return functionReturnValue;
    }

    public object SendValue_SP(string stored_proc, Hashtable parameters)
    {
        object functionReturnValue = null;
        System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(strconnect);
        SqlCommand cmd = new SqlCommand(stored_proc, connection);
        try
        {
            DictionaryEntry Item = default(DictionaryEntry);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (DictionaryEntry Item_loopVariable in parameters)
            {
                Item = Item_loopVariable;
                cmd.Parameters.AddWithValue(Item.Key.ToString(), Item.Value.ToString());
            }
            cmd.Connection.Open();
            functionReturnValue = cmd.ExecuteScalar();
            cmd.Connection.Close();
        }
        catch (Exception err)
        {
            cmd.Connection.Close();
            throw (err);
        }
        return functionReturnValue;
    }

    public void datalistDatashow(DataList datalist, string strsql)
    {
        try
        {
            SqlConnection connection = new SqlConnection(strconnect);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(strsql, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            datalist.DataSource = dataset;
            datalist.DataBind();
            connection.Close();
        }
        catch (Exception err)
        {
            throw (err);
        }
    }

    public void datalistDatashow_SP(DataList datalist, string stored_proc, Hashtable parameters)
    {
        try
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(strconnect);
            SqlCommand cmd = new SqlCommand(stored_proc, connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dataset = new DataSet();
            DictionaryEntry Item = default(DictionaryEntry);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (DictionaryEntry Item_loopVariable in parameters)
            {
                Item = Item_loopVariable;
                cmd.Parameters.AddWithValue(Item.Key.ToString(), Item.Value.ToString());
            }
            cmd.Connection.Open();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataset);
            datalist.DataSource = dataset;
            datalist.DataBind();
            cmd.Connection.Close();
        }
        catch (Exception err)
        {
            throw (err);
        }
    }

    public void repeaterDatashow(Repeater repeater, string strsql, bool AddNewRecord)
    {
        try
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(strconnect);
            connection.Open();
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(strsql, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            repeater.DataSource = dataset;
            repeater.DataBind();
            connection.Close();
        }
        catch (Exception err)
        {
            throw (err);
        }
    }

    public void RepeaterDatashow_SP(Repeater Repeater, string stored_proc, Hashtable parameters)
    {
        try
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(strconnect);
            SqlCommand cmd = new SqlCommand(stored_proc, connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dataset = new DataSet();
            DictionaryEntry Item = default(DictionaryEntry);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (DictionaryEntry Item_loopVariable in parameters)
            {
                Item = Item_loopVariable;
                cmd.Parameters.AddWithValue(Item.Key.ToString(), Item.Value.ToString());
            }
            cmd.Connection.Open();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataset);
            Repeater.DataSource = dataset;
            Repeater.DataBind();
            cmd.Connection.Close();
        }
        catch (Exception err)
        {
            throw (err);
        }
    }

    public void GridDatashow(DataGrid datagrid, string strsql, bool AddNewRecord)
    {
        try
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(strconnect);
            connection.Open();
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(strsql, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            datagrid.DataSource = dataset.Tables[0].DefaultView;
            datagrid.DataBind();
            adapter.Dispose();
            connection.Close();

        }
        catch (Exception err)
        {
            throw (err);
        }
    }

    public DataTable sendDataTable(string strsql)
    {
        DataTable Dt = null;

        try
        {
            SqlConnection connection = new SqlConnection(strconnect);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(strsql, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(Dt);

            adapter.Dispose();
            connection.Close();

        }
        catch (Exception err)
        {
            throw (err);
        }
        return Dt;
    }

    public DataTable sendDatatable(string strsql, bool Addnewrecord)
    {
        DataTable functionReturnValue = null;

        try
        {
            SqlConnection connection = new SqlConnection(strconnect);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(strsql, connection);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            if (Addnewrecord == true)
            {
                DataRow myNewRow = null;
                object[] rowVals = new object[datatable.Rows.Count];
                rowVals[0] = 1;
                myNewRow = datatable.Rows.Add(rowVals);
            }

            functionReturnValue = datatable;
            adapter.Dispose();
            connection.Close();

        }
        catch (Exception err)
        {
            throw (err);
        }
        return functionReturnValue;
    }

    public DataSet sendDataset(string strsql, bool Addnewrecord)
    {
        DataSet functionReturnValue = null;
        try
        {
            SqlConnection connection = new SqlConnection(strconnect);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(strsql, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            if (Addnewrecord == true)
            {
                DataRow myNewRow = null;
                object[] rowVals = new object[dataset.Tables[0].Columns.Count];
                rowVals[0] = 1;
                myNewRow = dataset.Tables[0].Rows.Add(rowVals);
            }
            functionReturnValue = dataset;
            adapter.Dispose();
            connection.Close();

        }
        catch (Exception err)
        {
            throw (err);
        }
        return functionReturnValue;
    }

    public void ExecuteQry(string myExecuteQuery)
    {
        SqlConnection cn = new SqlConnection(strconnect);
        SqlCommand myCommand = new SqlCommand(myExecuteQuery, cn);
        myCommand.Connection.Open();
        myCommand.ExecuteNonQuery();
        cn.Close();
    }

    #region "ExecuteQuerySP.."
    public void ExecuteQry_SP(string stored_proc, Hashtable parameters)
    {
        System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(strconnect);
        SqlCommand cmd = new SqlCommand(stored_proc, connection);
        try
        {
            DictionaryEntry Item = default(DictionaryEntry);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (DictionaryEntry Item_loopVariable in parameters)
            {
                Item = Item_loopVariable;
                //cmd.Parameters.AddWithValue(Item.Key, Item.Value);
                cmd.Parameters.AddWithValue(Item.Key.ToString(), Item.Value);
            }
            if (cmd.Connection.State == ConnectionState.Open || cmd.Connection.State == ConnectionState.Broken)
            {
                cmd.Connection.Close();
            }
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ERR)
        {
            throw (ERR);
        }
        finally
        {
            cmd.Connection.Close();
        }
    }
    #endregion

    public void ShowMessage(Page frmobj, string Message)
    {
        string str = null;
        //StringBuilder str = new StringBuilder();
        str = "<script language='javascript'>";
        str = str + "alert('" + Message + "' )";
        str = str + "</script>";

        frmobj.RegisterStartupScript("Msg", str.ToString());
    }

    public void Fillcombo(String strsql, DropDownList droplist)
    {
        try
        {
            // strconnect = page.Session["strconnect1"].ToString();
            System.Data.SqlClient.SqlDataAdapter adapter = null;
            adapter = new System.Data.SqlClient.SqlDataAdapter(strsql, strconnect);
            System.Data.DataSet selecttable = new System.Data.DataSet();
            adapter.Fill(selecttable);
            droplist.Items.Clear();
            if (selecttable.Tables[0].Rows.Count > 0)
            {
                droplist.DataSource = selecttable.Tables[0];
                droplist.DataTextField = selecttable.Tables[0].Columns[0].ColumnName;
                droplist.DataValueField = selecttable.Tables[0].Columns[1].ColumnName;
                droplist.DataBind();
            }
            droplist.Items.Insert(0, "--Choose One--");
            droplist.Items[0].Value = "0";
            droplist.SelectedIndex = droplist.Items.IndexOf(droplist.Items.FindByText("Select"));
            adapter.Dispose();
            selecttable.Dispose();
        }
        catch (Exception ERR)
        {
            throw (ERR);
        }
    }

    public void Fillcombo(String strsql, DropDownList droplist, string dispitem)
    {
        try
        {
            // strconnect = page.Session["strconnect1"].ToString();
            System.Data.SqlClient.SqlDataAdapter adapter = null;
            adapter = new System.Data.SqlClient.SqlDataAdapter(strsql, strconnect);
            System.Data.DataSet selecttable = new System.Data.DataSet();
            adapter.Fill(selecttable);
            droplist.Items.Clear();
            if (selecttable.Tables[0].Rows.Count > 0)
            {
                droplist.DataSource = selecttable.Tables[0];
                droplist.DataTextField = selecttable.Tables[0].Columns[0].ColumnName;
                droplist.DataValueField = selecttable.Tables[0].Columns[1].ColumnName;
                droplist.DataBind();
            }
            droplist.Items.Insert(0, dispitem);
            droplist.Items[0].Value = "0";
            droplist.SelectedIndex = droplist.Items.IndexOf(droplist.Items.FindByText("Select"));
            adapter.Dispose();
            selecttable.Dispose();
        }
        catch (Exception ERR)
        {
            throw (ERR);
        }
    }

    public void Fillcombo_SP(string stored_proc, Hashtable parameters, DropDownList droplist, string dispname)
    {
        try
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(strconnect);
            SqlCommand cmd = new SqlCommand(stored_proc, connection);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dataset = new DataSet();
            DictionaryEntry Item = default(DictionaryEntry);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (DictionaryEntry Item_loopVariable in parameters)
            {
                Item = Item_loopVariable;
                cmd.Parameters.AddWithValue(Item.Key.ToString(), Item.Value.ToString());
            }
            adapter.SelectCommand = cmd;
            adapter.Fill(dataset);
            droplist.Items.Clear();
            if (dataset.Tables[0].Rows.Count > 0)
            {
                droplist.DataSource = dataset.Tables[0];
                droplist.DataTextField = dataset.Tables[0].Columns[0].ColumnName;
                droplist.DataValueField = dataset.Tables[0].Columns[1].ColumnName;
                droplist.DataBind();
            }
            droplist.Items.Insert(0, dispname);
            droplist.Items[0].Value = "0";
            droplist.SelectedIndex = droplist.Items.IndexOf(droplist.Items.FindByText("- -Select- -"));
            adapter.Dispose();
            dataset.Dispose();
        }
        catch (Exception ERR)
        {
            throw (ERR);
        }
    }

    public void fillattgroup(String strsql, DropDownList droplist)
    {
        try
        {
            System.Data.SqlClient.SqlDataAdapter adapter = null;
            adapter = new System.Data.SqlClient.SqlDataAdapter(strsql, strconnect);
            System.Data.DataSet selecttable = new System.Data.DataSet();
            adapter.Fill(selecttable);
            droplist.Items.Clear();
            if (selecttable.Tables[0].Rows.Count > 0)
            {
                droplist.DataSource = selecttable.Tables[0];
                droplist.DataTextField = selecttable.Tables[0].Columns[0].ColumnName;
                droplist.DataValueField = selecttable.Tables[0].Columns[1].ColumnName;
                droplist.DataBind();
            }
            droplist.Items.Insert(0, "--No Attribute--");
            droplist.Items[0].Value = "0";
            droplist.SelectedIndex = droplist.Items.IndexOf(droplist.Items.FindByText("Select"));
            adapter.Dispose();
            selecttable.Dispose();
        }
        catch (Exception ERR)
        {
            throw (ERR);
        }

    }

    public void FillListBox(System.String strsql, ListBox listbox)
    {
        try
        {
            System.Data.SqlClient.SqlDataAdapter adapter = null;
            adapter = new System.Data.SqlClient.SqlDataAdapter(strsql, strconnect);
            System.Data.DataSet selecttable = new System.Data.DataSet();
            adapter.Fill(selecttable);
            listbox.Items.Clear();
            if (selecttable.Tables[0].Rows.Count > 0)
            {
                listbox.DataSource = selecttable.Tables[0];
                listbox.DataTextField = selecttable.Tables[0].Columns[0].ColumnName;
                listbox.DataValueField = selecttable.Tables[0].Columns[1].ColumnName;
                listbox.DataBind();
            }
            adapter.Dispose();
            selecttable.Dispose();
        }
        catch (Exception ERR)
        {
            throw (ERR);
        }
    }

    public void fillRadio(String strsql, ref RadioButtonList RBList)
    {
        try
        {
            System.Data.SqlClient.SqlDataAdapter adapter = null;
            adapter = new System.Data.SqlClient.SqlDataAdapter(strsql, strconnect);
            System.Data.DataSet selecttable = new System.Data.DataSet();
            adapter.Fill(selecttable);
            if (selecttable.Tables[0].Rows.Count > 0)
            {
                RBList.DataSource = selecttable.Tables[0];
                RBList.DataTextField = selecttable.Tables[0].Columns[0].ColumnName;
                RBList.DataValueField = selecttable.Tables[0].Columns[1].ColumnName;
                RBList.DataBind();
            }
            // RBList.SelectedIndex = RBList.Items.IndexOf(RBList.Items.FindByValue(0))
            adapter.Dispose();
            selecttable.Dispose();
        }
        catch (Exception ERR)
        {
            throw (ERR);
        }
    }

    public void ChkList(System.String strsql, CheckBoxList RBList)
    {
        try
        {
            System.Data.SqlClient.SqlDataAdapter adapter = null;
            adapter = new System.Data.SqlClient.SqlDataAdapter(strsql, strconnect);
            System.Data.DataSet selecttable = new System.Data.DataSet(); 
            adapter.Fill(selecttable);
            if (selecttable.Tables[0].Rows.Count > 0)
            {
                RBList.DataSource = selecttable.Tables[0];
                RBList.DataTextField = selecttable.Tables[0].Columns[0].ColumnName;
                RBList.DataValueField = selecttable.Tables[0].Columns[1].ColumnName;
                RBList.DataBind();
            }

            // RBList.SelectedIndex = RBList.Items.IndexOf(RBList.Items.FindByValue(0))
            adapter.Dispose();
            selecttable.Dispose();
        }
        catch (Exception ERR)
        {
            throw (ERR);
        }
    }

    public void ChkList_SP(CheckBoxList RBList, string stored_proc, Hashtable parameters)
    {
        try
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(strconnect);
            SqlCommand cmd = new SqlCommand(stored_proc, connection);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dataset = new DataSet();
            DictionaryEntry Item = default(DictionaryEntry);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (DictionaryEntry Item_loopVariable in parameters)
            {
                Item = Item_loopVariable;
                cmd.Parameters.AddWithValue(Item.Key.ToString(), Item.Value.ToString());
            }
            adapter.SelectCommand = cmd;
            adapter.Fill(dataset);
            RBList.Items.Clear();
            if (dataset.Tables[0].Rows.Count > 0)
            {
                RBList.DataSource = dataset.Tables[0];
                RBList.DataTextField = dataset.Tables[0].Columns[0].ColumnName;
                RBList.DataValueField = dataset.Tables[0].Columns[1].ColumnName;
                RBList.DataBind();
            }

            // RBList.SelectedIndex = RBList.Items.IndexOf(RBList.Items.FindByValue(0))
            adapter.Dispose();
            dataset.Dispose();
        }
        catch (Exception ERR)
        {
            throw (ERR);
        }
    }

    public void fillday(DropDownList day1, DropDownList year1)
    {
        Int32 j = default(Int32);

        for (j = 1; j <= 31; j++)
        {
            string x = string.Empty;
            x = 0 + j.ToString();
            day1.Items.Add(x);
        }

        for (j = 1; j <= 200; j++)
        {
            year1.Items.Add("1900" + j.ToString());
        }

    }
    //public void BackDate(TextBox Datadate, DropDownList Day2, DropDownList Month2, DropDownList Year2)
    //{
    //    string recdate = null;
    //    string MyDate = null;
    //    Array ary = null;
    //    recdate = Datadate.Text;
    //    ary = recdate.Split("/");
    //    MyDate = Strings.Mid(ary(2), 1, 4);
    //    Day2.SelectedIndex = Day2.Items.IndexOf(Day2.Items.FindByValue(ary(1)));
    //    Month2.SelectedIndex = Month2.Items.IndexOf(Month2.Items.FindByValue(ary(0)));
    //    Year2.SelectedIndex = Year2.Items.IndexOf(Year2.Items.FindByValue(MyDate));
    //}
    //public void EnterDate(TextBox Datadate, DropDownList Day2, DropDownList Month2, DropDownList Year2)
    //{
    //    Datadate.Text = Month2.SelectedValue + "/" + Day2.SelectedValue + "/" + Year2.SelectedValue;
    //}

    //public string getdate(System.DateTime fval)
    //{
    //    dynamic myvar = fval.ToString("MM-dd-yyyy");
    //    return myvar;
    //}


    //public Int16 DuplicateCheck(string TableName, string ColumnName, string idfield, string idvalue, string ColumnName1)
    //{
    //    Int16 functionReturnValue = default(Int16);
    //    int i = 0;
    //    try {
    //        functionReturnValue = 0;
    //        DataSet ds = new DataSet();
    //        if (string.IsNullOrEmpty(idvalue)) {
    //            ds = sendDataset("select " + ColumnName + " from " + TableName);
    //        } else {
    //            ds = sendDataset("select " + ColumnName + " from " + TableName + " where " + idfield + "<>" + idvalue);
    //        }

    //        for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++) {
    //            if (ds.Tables[0].Rows[i][0] == ColumnName1) {
    //                functionReturnValue = 1;
    //                break; // TODO: might not be correct. Was : Exit For
    //            }
    //        }
    //    } catch (Exception err) {
    //        throw (err);
    //    }
    //    return functionReturnValue;
    //}
    public void GridviewDatashow(GridView gridview, string strsql)
    {
        try
        {
            SqlConnection connection = new SqlConnection(strconnect);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(strsql, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            gridview.DataSource = dataset.Tables[0].DefaultView;
            gridview.DataBind();
            adapter.Dispose();
            connection.Close();
        }
        catch (Exception err)
        {
            throw (err);
        }
    }

    public string MasterTransaction(Control frmObj1, Control frmObj, int iParam, Mode iMode, string strMasterProcedure, string strTransactionProcedure, ref DataSet GridData, string SaveCol, string Uid)
    {
        string functionReturnValue = null;
        try
        {

            //string [,] arrMY = null;
            string[,] arrMY = new string[iParam, 2];

            Array varTemp1 = SaveCol.Split(',');

            int iCols1 = Information.UBound(varTemp1, 1);
            string[,] arrDeep = new string[GridData.Tables[0].Rows.Count, iCols1 + 1];
            // string[,] arrDeep = null;
            Control Control1 = null;
            Control Commcont2 = null;
            Control Commcont3 = null;
            object varTemp = null;
            int iCols = default(int);
            int k = default(int);
            int i = default(int);
            int j = default(int);
            int col = default(int);
            string strsql = null;

            // ERROR: Not supported in C#: ReDimStatement

            System.Data.SqlClient.SqlDataAdapter adapter = null;
            System.Data.DataSet selecttable = new System.Data.DataSet();

            strsql = "SELECT syscolumns.colorder As [ColumnOrder], syscolumns.name AS ColumnName,systypes.name AS DataType,syscolumns.length As Length FROM { oj (sysobjects sysobjects INNER JOIN syscolumns syscolumns ON   sysobjects.id = syscolumns.id)      INNER JOIN systypes systypes ON         syscolumns.xtype = systypes.xtype} WHERE     sysobjects.xtype = 'P' AND sysobjects.Name='" + strMasterProcedure + "' ORDER BY    syscolumns.colorder ASC";
            adapter = new System.Data.SqlClient.SqlDataAdapter(strsql, strconnect);
            adapter.Fill(selecttable);

            foreach (Control Control1_loopVariable in frmObj.Controls)
            {
                Control1 = Control1_loopVariable;
                if (Control1 is UpdatePanel)
                {
                    foreach (Control Commcont2_loopVariable in Control1.Controls)
                    {
                        Commcont2 = Commcont2_loopVariable;
                        foreach (Control Commcont3_loopVariable in Commcont2.Controls)
                        {
                            Commcont3 = Commcont3_loopVariable;
                            if (Commcont3 is DropDownList)
                            {
                                if (((DropDownList)Commcont3).EnableViewState == true)
                                {
                                    for (i = 0; i <= selecttable.Tables[0].Rows.Count - 1; i++)
                                    {
                                        if (Strings.UCase(selecttable.Tables[0].Rows[i][1].ToString()) == "@" + Strings.UCase(Commcont3.ID))
                                        {
                                            j = Int16.Parse(selecttable.Tables[0].Rows[i][0].ToString());
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }
                                    varTemp = j - 1;
                                    arrMY[int.Parse(varTemp.ToString()), 0] = Commcont3.ID;
                                    arrMY[int.Parse(varTemp.ToString()), 1] = ((DropDownList)Commcont3).SelectedItem.Value;
                                }
                            }


                            if (Commcont3 is TextBox)
                            {
                                if (((TextBox)Commcont3).ReadOnly == false)
                                {
                                    for (i = 0; i <= selecttable.Tables[0].Rows.Count - 1; i++)
                                    {
                                        if (Strings.UCase(selecttable.Tables[0].Rows[i][1].ToString()) == "@" + Strings.UCase(Commcont3.ID))
                                        {
                                            j = Int16.Parse(selecttable.Tables[0].Rows[i][0].ToString());
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }

                                    varTemp = j - 1;
                                    arrMY[int.Parse(varTemp.ToString()), 0] = Strings.UCase(Commcont3.ID);
                                    arrMY[int.Parse(varTemp.ToString()), 1] = ((TextBox)Commcont3).Text;
                                }
                            }


                            if (Commcont3 is CheckBox)
                            {
                                if (((CheckBox)Commcont3).EnableViewState == true)
                                {
                                    for (i = 0; i <= selecttable.Tables[0].Rows.Count - 1; i++)
                                    {
                                        if (Strings.UCase(selecttable.Tables[0].Rows[i][1].ToString()) == "@" + Strings.UCase(Commcont3.ID))
                                        {
                                            j = Int16.Parse(selecttable.Tables[0].Rows[i][0].ToString());
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }
                                    varTemp = j - 1;
                                    arrMY[int.Parse(varTemp.ToString()), 0] = Commcont3.ID;
                                    arrMY[int.Parse(varTemp.ToString()), 1] = (((CheckBox)Commcont3).Checked == false ? 0 : 1).ToString();
                                }

                            }
                        }
                    }


                }


                if (Control1 is TextBox)
                {
                    if (((TextBox)Control1).ReadOnly == false)
                    {
                        for (i = 0; i <= selecttable.Tables[0].Rows.Count - 1; i++)
                        {

                            if (Strings.UCase(selecttable.Tables[0].Rows[i][1].ToString()) == "@" + Strings.UCase(Control1.ID))
                            {
                                j = Int16.Parse(selecttable.Tables[0].Rows[i][0].ToString());
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }

                        varTemp = j - 1;
                        arrMY[int.Parse(varTemp.ToString()), 0] = Control1.ID;
                        arrMY[int.Parse(varTemp.ToString()), 1] = ((TextBox)Control1).Text;
                    }
                }


                if (Control1 is DropDownList)
                {
                    if (((DropDownList)Control1).EnableViewState == true)
                    {
                        for (i = 0; i <= selecttable.Tables[0].Rows.Count - 1; i++)
                        {
                            if (Strings.UCase(selecttable.Tables[0].Rows[i][1].ToString()) == "@" + Strings.UCase(Control1.ID))
                            {
                                j = Int16.Parse(selecttable.Tables[0].Rows[i][0].ToString());
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }

                        varTemp = j - 1;
                        arrMY[int.Parse(varTemp.ToString()), 0] = Control1.ID;
                        arrMY[int.Parse(varTemp.ToString()), 1] = ((DropDownList)Control1).SelectedItem.Value.ToString();
                    }
                }

                if (Control1 is CheckBox)
                {
                    if (((CheckBox)Control1).EnableViewState == true)
                    {
                        for (i = 0; i <= selecttable.Tables[0].Rows.Count - 1; i++)
                        {
                            if (Strings.UCase(selecttable.Tables[0].Rows[i][1].ToString()) == "@" + Strings.UCase(Control1.ID))
                            {
                                j = Int16.Parse(selecttable.Tables[0].Rows[i][0].ToString());
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }
                        varTemp = j - 1;
                        arrMY[int.Parse(varTemp.ToString()), 0] = Control1.ID;
                        arrMY[int.Parse(varTemp.ToString()), 1] = (((CheckBox)Control1).Checked == false ? 0 : 1).ToString();
                    }
                }


                if (Control1 is RadioButtonList)
                {
                    if (((RadioButtonList)Control1).EnableViewState == true)
                    {
                        for (i = 0; i <= selecttable.Tables[0].Rows.Count - 1; i++)
                        {
                            if (Strings.UCase(selecttable.Tables[0].Rows[i][1].ToString()) == "@" + Strings.UCase(Control1.ID))
                            {
                                j = Int16.Parse(selecttable.Tables[0].Rows[i][0].ToString());
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }

                        varTemp = j - 1;
                        arrMY[int.Parse(varTemp.ToString()), 0] = Control1.ID;
                        arrMY[int.Parse(varTemp.ToString()), 1] = ((RadioButtonList)Control1).SelectedValue.ToString();
                    }
                }

            }

            // ShowMessage(frmObj1, "San")
            varTemp = SaveCol.Split(',');
            //int vt = int.Parse(varTemp);
            Array varTemp2 = SaveCol.Split(',');

            String[] arr = new string[0];
            arr = SaveCol.Split(',');

            iCols = Information.UBound(varTemp2, 1);

            for (i = 1; i <= GridData.Tables[0].Rows.Count; i++)
            {
                k = 0;
                for (j = 0; j <= iCols; j++)
                {
                    //col = Convert.ToInt16(varTemp[j]); 

                    col = int.Parse(arr[j].ToString());
                    arrDeep[i - 1, k] = GridData.Tables[0].Rows[i - 1][col].ToString();// Convert.ToInt16(GridData.Tables[0].Rows[i - 1][col].ToString()).ToString();
                    k = k + 1;
                }
            }

            functionReturnValue = "true";

            //public string MasterTransaction(Control frmObj1, Control frmObj, int iParam, Mode iMode, string strMasterProcedure, string strTransactionProcedure, ref DataSet GridData, string SaveCol, string Uid)

            //functionReturnValue = SaveMasterTransaction(arrMY, arrDeep, strMasterProcedure, strTransactionProcedure, Convert.ToInt32(iCols), CommandType.StoredProcedure, Convert.ToInt32(iMode), frmObj1, Uid);


            //functionReturnValue = ADDProcDS(arrMY, ProcName, CommandType.StoredProcedure, Convert.ToInt32(iMode), frmObj1, Uid);

            functionReturnValue = SaveMasterTransaction(arrMY, arrDeep, strMasterProcedure, strTransactionProcedure, iCols, CommandType.StoredProcedure, Convert.ToInt16(iMode), frmObj1, Uid);


        }
        catch (Exception ERR)
        {
            throw (ERR);
            functionReturnValue = "false";
        }
        return functionReturnValue;
    }

    private string SaveMasterTransaction(string[,] ArrParamAndValue, string[,] ArrDeep, string strProcName, string strTransactionProcName, int Gcols, CommandType EnumCommandType, int iMode, object frmobj, string uid)
    {
        //private string ADDProcDS(string[,] ArrParamAndValue, string strProcName, CommandType EnumCommandType, int iMode, object frmobj, string uid)
        string functionReturnValue = null;
        Int16 i = default(Int16);
        Int16 j = default(Int16);

        SqlCommand _with3;


        int iCounter = 0;
        string strsql = null;
        string Pcode = null;
        string varA = null;
        string varc = null;
        int varB = 0;
        DataSet MData = new DataSet();
        System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(strconnect);
        System.Data.SqlClient.SqlDataAdapter adapter = null;
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
        System.Data.DataSet selecttable = new System.Data.DataSet();
        cn.Open();
        System.Data.SqlClient.SqlTransaction myTrans = cn.BeginTransaction();
        try
        {
            strsql = "SELECT syscolumns.colorder As [ColumnOrder], syscolumns.name AS ColumnName,systypes.name AS DataType,syscolumns.length As Length FROM { oj (sysobjects sysobjects INNER JOIN syscolumns syscolumns ON   sysobjects.id = syscolumns.id)      INNER JOIN systypes systypes ON         syscolumns.xtype = systypes.xtype} WHERE     sysobjects.xtype = 'P' AND sysobjects.Name='" + strProcName + "' ORDER BY    syscolumns.colorder ASC";
            adapter = new System.Data.SqlClient.SqlDataAdapter(strsql, strconnect);

            adapter.Fill(selecttable);
            cmd.Transaction = myTrans;
            // var _with3 = cmd;
            _with3 = cmd;
            _with3.Connection = cn;
            _with3.CommandText = strProcName;
            _with3.CommandType = EnumCommandType;
            //ParamName   AdChar   In/out  Len   Value
            for (iCounter = 0; iCounter <= Information.UBound(ArrParamAndValue, 1); iCounter++)
            //for (iCounter = 0; iCounter <= Information.UBound(ArrParamAndValue); iCounter++)
            {
                varA = selecttable.Tables[0].Rows[iCounter][2].ToString();
                varB = Int16.Parse(selecttable.Tables[0].Rows[iCounter][3].ToString());

                if ((varA == "int") || (varA == "tinyint"))
                {
                    _with3.Parameters.AddWithValue("@" + ArrParamAndValue[iCounter, 0], checkval(ArrParamAndValue[iCounter, 1]));
                }
                else if ((varA == "float"))
                {
                    if (((ArrParamAndValue[iCounter, 1]) == null) || (ArrParamAndValue[iCounter, 1]) == "")
                    {
                        ArrParamAndValue[iCounter, 1] = "0";
                    }
                    //cmd.Parameters.AddWithValue("@" + ArrParamAndValue[iCounter, 0], (ArrParamAndValue[iCounter, 1]));
                    _with3.Parameters.AddWithValue("@" + ArrParamAndValue[iCounter, 0], Math.Round((decimal.Parse(ArrParamAndValue[iCounter, 1])), 2)
);
                }
                else if ((varA == "decimal"))
                {
                    if (((ArrParamAndValue[iCounter, 1]) == null) || (ArrParamAndValue[iCounter, 1]) == "")
                    {
                        ArrParamAndValue[iCounter, 1] = "0";
                    }
                    //cmd.Parameters.AddWithValue("@" + ArrParamAndValue[iCounter, 0], (ArrParamAndValue[iCounter, 1]));
                    _with3.Parameters.AddWithValue("@" + ArrParamAndValue[iCounter, 0], Math.Round((decimal.Parse(ArrParamAndValue[iCounter, 1])), 4)
);
                }
                else if ((varA == "varchar") || (varA == "text"))
                {
                    _with3.Parameters.AddWithValue("@" + ArrParamAndValue[iCounter, 0], ArrParamAndValue[iCounter, 1].ToString());
                }
                else
                {
                    _with3.Parameters.AddWithValue("@" + ArrParamAndValue[iCounter, 0], ArrParamAndValue[iCounter, 1].ToString());
                }

                if (iCounter == 0)
                    _with3.Parameters[0].Direction = ParameterDirection.InputOutput;
            }


            _with3.Parameters.Add("@UName", SqlDbType.VarChar, 20).Value = uid;
            _with3.Parameters.Add("@Mode", SqlDbType.Int, 1).Value = iMode;
            _with3.ExecuteNonQuery();
            //Done
            Pcode = cmd.Parameters[0].Value.ToString();

            //-----------------transaction------------- 
            SqlCommand _with4;
            //cmd = New SqlClient.SqlCommand()
            strsql = "SELECT syscolumns.colorder As [ColumnOrder],    syscolumns.name AS ColumnName,systypes.name AS DataType,syscolumns.length As Length FROM { oj (sysobjects sysobjects INNER JOIN syscolumns syscolumns ON   sysobjects.id = syscolumns.id)      INNER JOIN systypes systypes ON         syscolumns.xtype = systypes.xtype} WHERE     sysobjects.xtype = 'P' AND sysobjects.Name='" + strTransactionProcName + "' ORDER BY    syscolumns.colorder ASC";
            adapter = new System.Data.SqlClient.SqlDataAdapter(strsql, strconnect);
            adapter.Fill(MData);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = strTransactionProcName;
            cmd.Connection = cn;
            for (i = 0; i <= Information.UBound(ArrDeep, 1); i++)
            {
                // var _with4 = cmd;
                _with4 = cmd;
                //_with4.Parameters.Clear();
                _with4.Parameters.Clear();
                for (j = 0; j <= Gcols + 1; j++)
                {
                    if (j == 0)
                    {

                        _with4.Parameters.AddWithValue(MData.Tables[0].Rows[j][1].ToString(), Int16.Parse((MData.Tables[0].Rows[j][3]).ToString())).Value = Pcode;
                    }
                    else
                    {

                        varA = MData.Tables[0].Rows[j][2].ToString();
                        varB = int.Parse(MData.Tables[0].Rows[j][3].ToString());
                        varc = MData.Tables[0].Rows[j][1].ToString();
                        //if (varA == "int" | varA == "float" | varA == "tinyint")
                        //{
                        //    _with4.Parameters.AddWithValue(MData.Tables[0].Rows[j][1].ToString(), Int16.Parse((MData.Tables[0].Rows[j][3]).ToString())).Value = Conversion.Val(ArrDeep[i, j - 1]);
                        //}
                        //else
                        //{
                        //    _with4.Parameters.AddWithValue(MData.Tables[0].Rows[j][1].ToString(), Int16.Parse((MData.Tables[0].Rows[j][3]).ToString())).Value = ArrDeep[i, j - 1];
                        //}
                        if (varA == "int" | varA == "tinyint")
                        {
                            _with4.Parameters.AddWithValue(MData.Tables[0].Rows[j][1].ToString(), Int16.Parse((MData.Tables[0].Rows[j][3]).ToString())).Value = checkval(ArrDeep[i, j - 1]);
                        }
                        else if (varA == "float")
                        {
                            if (((ArrDeep[i, j - 1]) == null) || (ArrDeep[i, j - 1]) == "")
                            {
                                ArrDeep[i, j - 1] = "0";
                            }
                            _with4.Parameters.AddWithValue(MData.Tables[0].Rows[j][1].ToString(), float.Parse((MData.Tables[0].Rows[j][3]).ToString())).Value = Math.Round((decimal.Parse(ArrDeep[i, j - 1])), 2);
                        }
                        else if (varA == "decimal")
                        {
                            if (((ArrDeep[i, j - 1]) == null) || (ArrDeep[i, j - 1]) == "")
                            {
                                ArrDeep[i, j - 1] = "0";
                            }
                            _with4.Parameters.AddWithValue(MData.Tables[0].Rows[j][1].ToString(), decimal.Parse((MData.Tables[0].Rows[j][3]).ToString())).Value = Math.Round((decimal.Parse(ArrDeep[i, j - 1])), 4);
                        }
                        else
                        {
                            _with4.Parameters.AddWithValue(MData.Tables[0].Rows[j][1].ToString(), MData.Tables[0].Rows[j][3]).Value = ArrDeep[i, j - 1];
                        }
                    }
                }



                _with4.Parameters.Add("@Mode", SqlDbType.Int, 1).Value = iMode;
                _with4.ExecuteNonQuery();
                if (iMode == 2)
                    iMode = 4;
            }

            myTrans.Commit();
            cmd.Dispose();
            adapter.Dispose();
            cn.Close();
            cn.Dispose();
            ArrDeep = null;
            functionReturnValue = Pcode;
        }
        catch (Exception e)
        {
            myTrans.Rollback();
            cmd.Dispose();
            //adapter.Dispose()
            cn.Close();
            cn.Dispose();
            throw (e);
            functionReturnValue = "false";
        }
        return functionReturnValue;
    }

    public string DataSave(DataTable DT, Control frmObj, int iParam, Mode iMode, string ProcName, string Uid, int id)
    {
        string functionReturnValue = null;
        string[,] arrMY = new string[iParam, 2];
        string strsql = null;
        string DataSave1 = "";
        SqlDataAdapter adapter = null;
        DataSet selecttable = new DataSet();
        int x = 0;
        int y = 0;
        try
        {
            // ERROR: Not supported in C#: ReDimStatement

            strsql = "SELECT syscolumns.colorder As [ColumnOrder], syscolumns.name AS ColumnName,systypes.name AS DataType,syscolumns.length As Length FROM { oj (sysobjects sysobjects INNER JOIN syscolumns syscolumns ON   sysobjects.id = syscolumns.id) INNER JOIN systypes systypes ON syscolumns.xtype = systypes.xtype} WHERE     sysobjects.xtype = 'P' AND sysobjects.Name='" + ProcName + "' ORDER BY syscolumns.colorder ASC";
            adapter = new SqlDataAdapter(strsql, strconnect);
            adapter.Fill(selecttable);
            for (x = 0; x <= DT.Rows.Count - 1; x++)
            {
                for (y = 0; y <= DT.Columns.Count - 1; y++)
                {
                    if (id > 0 & y == 0)
                    {
                        arrMY[y, 0] = DT.Columns[y].ColumnName;
                        arrMY[y, 1] = id.ToString();
                    }
                    else
                    {
                        arrMY[y, 0] = DT.Columns[y].ColumnName;
                        arrMY[y, 1] = DT.Rows[x][y].ToString();
                    }
                }

                DataSave1 = ADDProcDS(arrMY, ProcName, CommandType.StoredProcedure, Convert.ToInt32(iMode), frmObj, Uid);
            }
            functionReturnValue = DataSave1;
        }
        catch (Exception ERR)
        {
            throw (ERR);
            functionReturnValue = "";
        }
        return functionReturnValue;
    }

    public string MasterSave(Control frmObj1, Control frmObj, int iParam, Mode iMode, string ProcName, string Uid)
    {
        int Vartemp;
        string functionReturnValue = null;

        string[,] arrMY = new string[iParam, 2];

        string strsql = null;
        //Dim Control As Object
        Control Control1 = null;
        Control Commcont2 = null;
        Control Commcont3 = null;
        Int16 i = default(Int16);
        Int16 j = default(Int16);
        System.Data.SqlClient.SqlDataAdapter adapter = null;
        System.Data.DataSet selecttable = new System.Data.DataSet();

        try
        {
            strsql = "SELECT syscolumns.colorder As [ColumnOrder], syscolumns.name AS ColumnName,systypes.name AS DataType,syscolumns.length As Length FROM { oj (sysobjects sysobjects INNER JOIN syscolumns syscolumns ON   sysobjects.id = syscolumns.id) INNER JOIN systypes systypes ON         syscolumns.xtype = systypes.xtype} WHERE     sysobjects.xtype = 'P' AND sysobjects.Name='" + ProcName + "' ORDER BY    syscolumns.colorder ASC";
            adapter = new System.Data.SqlClient.SqlDataAdapter(strsql, strconnect);
            adapter.Fill(selecttable);

            foreach (Control Control1_loopVariable in frmObj.Controls)
            {
                Control1 = Control1_loopVariable;

                if (Control1 is UpdatePanel)
                {
                    foreach (Control Commcont2_loopVariable in Control1.Controls)
                    {
                        Commcont2 = Commcont2_loopVariable;
                        foreach (Control Commcont3_loopVariable in Commcont2.Controls)
                        {
                            Commcont3 = Commcont3_loopVariable;


                            if (Commcont3 is DropDownList)
                            {
                                if (((DropDownList)Commcont3).EnableViewState == true)
                                {
                                    for (i = 0; i <= selecttable.Tables[0].Rows.Count - 1; i++)
                                    {
                                        if (Strings.UCase(selecttable.Tables[0].Rows[i][1].ToString()) == "@" + Strings.UCase(Commcont3.ID))
                                        {
                                            j = Convert.ToInt16(selecttable.Tables[0].Rows[i][0]);
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }
                                    Vartemp = j - 1;
                                    arrMY[Vartemp, 0] = Commcont3.ID;
                                    arrMY[Vartemp, 1] = ((DropDownList)Commcont3).SelectedItem.Value;
                                }
                            }

                            if (Commcont3 is TextBox)
                            {
                                if (((TextBox)Commcont3).ReadOnly == false)
                                {
                                    for (i = 0; i <= selecttable.Tables[0].Rows.Count - 1; i++)
                                    {
                                        if (Strings.UCase(selecttable.Tables[0].Rows[i][1].ToString()) == "@" + Strings.UCase(Commcont3.ID))
                                        {
                                            j = Convert.ToInt16(selecttable.Tables[0].Rows[i][0]);
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }
                                    Vartemp = j - 1;
                                    arrMY[Vartemp, 0] = Commcont3.ID;
                                    arrMY[Vartemp, 1] = ((TextBox)Commcont3).Text;
                                }
                            }

                            ///////////Rad Text Box
                            //if (Commcont3 is RadTimePicker)
                            //{
                            //    if (((RadTimePicker)Commcont3).EnableViewState == true)
                            //    {
                            //        for (i = 0; i <= selecttable.Tables[0].Rows.Count - 1; i++)
                            //        {
                            //            if (Strings.UCase(selecttable.Tables[0].Rows[i][1].ToString()) == "@" + Strings.UCase(Commcont3.ID))
                            //            {
                            //                j = Convert.ToInt16(selecttable.Tables[0].Rows[i][0]);
                            //                break; // TODO: might not be correct. Was : Exit For
                            //            }
                            //        }
                            //        Vartemp = j - 1;
                            //        arrMY[Vartemp, 0] = Commcont3.ID;
                            //        arrMY[Vartemp, 1] = ((RadTimePicker)Commcont3).ToString();
                            //    }
                            //}

                            if (Commcont3 is CheckBox)
                            {
                                if (((CheckBox)Control1).EnableViewState == true)
                                {
                                    for (i = 0; i <= selecttable.Tables[0].Rows.Count - 1; i++)
                                    {
                                        if (Strings.UCase(selecttable.Tables[0].Rows[i][1].ToString()) == "@" + Strings.UCase(Commcont3.ID))
                                        {
                                            j = Convert.ToInt16(selecttable.Tables[0].Rows[i][0]);
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }
                                    Vartemp = j - 1;
                                    arrMY[Vartemp, 0] = Commcont3.ID;
                                    arrMY[Vartemp, 1] = Convert.ToInt16((((CheckBox)Commcont3).Checked == false ? 0 : 1)).ToString();
                                }
                            }

                            if (Commcont3 is CheckBoxList)
                            {
                                if (((CheckBoxList)Commcont3).EnableViewState == true)
                                {
                                    for (i = 0; i <= selecttable.Tables[0].Rows.Count - 1; i++)
                                    {
                                        if (Strings.UCase(selecttable.Tables[0].Rows[i][1].ToString()) == "@" + Strings.UCase(Commcont3.ID))
                                        {
                                            j = Convert.ToInt16(selecttable.Tables[0].Rows[i][0]);
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }
                                    Vartemp = j - 1;
                                    arrMY[Vartemp, 0] = Commcont3.ID;
                                    arrMY[Vartemp, 1] = ((CheckBoxList)Commcont3).SelectedItem.Value;
                                }
                            }

                            if (Commcont3 is RadioButtonList)
                            {
                                if (((RadioButtonList)Commcont3).EnableViewState == true)
                                {
                                    for (i = 0; i <= selecttable.Tables[0].Rows.Count - 1; i++)
                                    {
                                        if (Strings.UCase(selecttable.Tables[0].Rows[i][1].ToString()) == "@" + Strings.UCase(Commcont3.ID))
                                        {
                                            j = Convert.ToInt16(selecttable.Tables[0].Rows[i][0]);
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }
                                    Vartemp = j - 1;
                                    arrMY[Vartemp, 0] = Commcont3.ID;
                                    arrMY[Vartemp, 1] = ((RadioButtonList)Commcont3).SelectedValue;
                                }
                            }
                        }
                    }
                }

                if (Control1 is TextBox)
                {
                    if (((TextBox)Control1).ReadOnly == false)
                    {
                        for (i = 0; i <= selecttable.Tables[0].Rows.Count - 1; i++)
                        {

                            if (Strings.UCase(selecttable.Tables[0].Rows[i][1].ToString()) == "@" + Strings.UCase(Control1.ID))
                            {
                                j = Convert.ToInt16(selecttable.Tables[0].Rows[i][0]);
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }

                        Vartemp = j - 1;
                        arrMY[Vartemp, 0] = Control1.ID;
                        arrMY[Vartemp, 1] = ((TextBox)Control1).Text;
                    }
                }

                if (Control1 is DropDownList)
                {
                    if (((DropDownList)Control1).EnableViewState == true)
                    {
                        for (i = 0; i <= selecttable.Tables[0].Rows.Count - 1; i++)
                        {
                            if (Strings.UCase(selecttable.Tables[0].Rows[i][1].ToString()) == "@" + Strings.UCase(Control1.ID))
                            {
                                j = Convert.ToInt16(selecttable.Tables[0].Rows[i][0]);
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }

                        Vartemp = j - 1;
                        arrMY[Vartemp, 0] = Control1.ID;
                        arrMY[Vartemp, 1] = ((DropDownList)Control1).SelectedItem.Value;
                    }
                }

                if (Control1 is CheckBox)
                {
                    if (((CheckBox)Control1).EnableViewState == true)
                    {
                        for (i = 0; i <= selecttable.Tables[0].Rows.Count - 1; i++)
                        {
                            if (Strings.UCase(selecttable.Tables[0].Rows[i][1].ToString()) == "@" + Strings.UCase(Control1.ID))
                            {
                                j = Convert.ToInt16(selecttable.Tables[0].Rows[i][0]);
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }
                        Vartemp = j - 1;
                        arrMY[Vartemp, 0] = Control1.ID;
                        arrMY[Vartemp, 1] = Convert.ToInt16((((CheckBox)Control1).Checked == false ? 0 : 1)).ToString();
                    }
                }

                if (Control1 is CheckBoxList)
                {
                    if (((CheckBoxList)Control1).EnableViewState == true)
                    {
                        for (i = 0; i <= selecttable.Tables[0].Rows.Count - 1; i++)
                        {
                            if (Strings.UCase(selecttable.Tables[0].Rows[i][1].ToString()) == "@" + Strings.UCase(Control1.ID))
                            {
                                j = Convert.ToInt16(selecttable.Tables[0].Rows[i][0]);
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }

                        Vartemp = j - 1;
                        arrMY[Vartemp, 0] = Control1.ID;
                        arrMY[Vartemp, 1] = ((CheckBoxList)Control1).SelectedValue;
                    }
                }

                if (Control1 is RadioButtonList)
                {
                    if (((RadioButtonList)Control1).EnableViewState == true)
                    {
                        for (i = 0; i <= selecttable.Tables[0].Rows.Count - 1; i++)
                        {
                            if (Strings.UCase(selecttable.Tables[0].Rows[i][1].ToString()) == "@" + Strings.UCase(Control1.ID))
                            {
                                j = Convert.ToInt16(selecttable.Tables[0].Rows[i][0]);
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }
                        Vartemp = j - 1;
                        arrMY[Vartemp, 0] = Control1.ID;
                        arrMY[Vartemp, 1] = ((RadioButtonList)Control1).SelectedValue;
                    }
                }

                //if (Control1 is RadPageView)
                //{
                //    foreach (Control Commcont2_loopVariable in Control1.Controls)
                //    {
                //        Commcont2 = Commcont2_loopVariable;
                //        foreach (Control Commcont3_loopVariable in Commcont2.Controls)
                //        {
                //            Commcont3 = Commcont3_loopVariable;

                //            if (Commcont3 is TextBox)
                //            {
                //                if (((TextBox)Commcont3).ReadOnly == false)
                //                {
                //                    for (i = 0; i <= selecttable.Tables[0].Rows.Count - 1; i++)
                //                    {
                //                        if (Strings.UCase(selecttable.Tables[0].Rows[i][1].ToString()) == "@" + Strings.UCase(Commcont3.ID))
                //                        {
                //                            j = Convert.ToInt16(selecttable.Tables[0].Rows[i][0]);
                //                            break; // TODO: might not be correct. Was : Exit For
                //                        }
                //                    }
                //                    Vartemp = j - 1;
                //                    arrMY[Vartemp, 0] = Commcont3.ID;
                //                    arrMY[Vartemp, 1] = ((TextBox)Commcont3).Text;
                //                }
                //            }
                //        }
                //    }

                //}
            }
            functionReturnValue = ADDProcDS(arrMY, ProcName, CommandType.StoredProcedure, Convert.ToInt32(iMode), frmObj1, Uid);
            ////---------//
            // if (Control1 is RadPageView)
            //    {
            //        foreach (Control Commcont2_loopVariable in Control1.Controls)
            //        {
            //            Commcont2 = Commcont2_loopVariable;
            //            foreach (Control Commcont3_loopVariable in Commcont2.Controls)
            //            {
            //                Commcont3 = Commcont3_loopVariable;

            //    if (Control1 is TextBox)
            //    {
            //        if (((TextBox)Control1).ReadOnly == false)
            //        {
            //            for (i = 0; i <= selecttable.Tables[0].Rows.Count - 1; i++)
            //            {

            //                if (Strings.UCase(selecttable.Tables[0].Rows[i][1].ToString()) == "@" + Strings.UCase(Control1.ID))
            //                {
            //                    j = Convert.ToInt16(selecttable.Tables[0].Rows[i][0]);
            //                    break; // TODO: might not be correct. Was : Exit For
            //                }
            //            }
            //            Vartemp = j - 1;
            //            arrMY[Vartemp, 0] = Control1.ID;
            //            arrMY[Vartemp, 1] = ((TextBox)Control1).Text;
            //        }
            //    }
        }
        catch (Exception ERR)
        {
            throw (ERR);

        }
        return functionReturnValue;
    }

    private string ADDProcDS(string[,] ArrParamAndValue, string strProcName, CommandType EnumCommandType, int iMode, object frmobj, string uid)
    {
        string functionReturnValue = null;
        int iCounter = 0;
        string strsql = null;
        string varA = null;
        int varB = 0;

        System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(strconnect);
        System.Data.SqlClient.SqlDataAdapter adapter = null;
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
        System.Data.DataSet selecttable = new System.Data.DataSet();
        cn.Open();
        System.Data.SqlClient.SqlTransaction myTrans = cn.BeginTransaction();
        try
        {
            strsql = "SELECT syscolumns.colorder As [ColumnOrder], syscolumns.name AS ColumnName,systypes.name AS DataType,syscolumns.length As Length FROM { oj (sysobjects sysobjects INNER JOIN syscolumns syscolumns ON   sysobjects.id = syscolumns.id)      INNER JOIN systypes systypes ON         syscolumns.xtype = systypes.xtype} WHERE     sysobjects.xtype = 'P' AND sysobjects.Name='" + strProcName + "' ORDER BY    syscolumns.colorder ASC";
            adapter = new System.Data.SqlClient.SqlDataAdapter(strsql, strconnect);
            adapter.Fill(selecttable);
            cmd.Transaction = myTrans;

            //var _with1 = cmd;
            cmd.Connection = cn;
            cmd.CommandText = strProcName;
            cmd.CommandType = EnumCommandType;

            //ParamName  AdChar  In/out   Len  Value
            for (iCounter = 0; iCounter <= Information.UBound(ArrParamAndValue, 1); iCounter++)
            {
                varA = selecttable.Tables[0].Rows[iCounter][2].ToString();
                varB = int.Parse(selecttable.Tables[0].Rows[iCounter][3].ToString());
                if (string.IsNullOrEmpty(ArrParamAndValue[iCounter, 0].ToString()))
                {
                    ShowMessage(frmobj, "Hello " + iCounter.ToString()); //frmobj, "hello " + iCounter);
                    functionReturnValue = "";
                    return functionReturnValue;

                }

                if ((varA == "int") || (varA == "tinyint"))
                {
                    cmd.Parameters.AddWithValue("@" + ArrParamAndValue[iCounter, 0], checkval(ArrParamAndValue[iCounter, 1]));
                }
                else if ((varA == "float"))
                {
                    if (((ArrParamAndValue[iCounter, 1]) == null) || (ArrParamAndValue[iCounter, 1]) == "")
                    {
                        ArrParamAndValue[iCounter, 1] = "0";
                    }

                    cmd.Parameters.AddWithValue("@" + ArrParamAndValue[iCounter, 0], Math.Round((decimal.Parse(ArrParamAndValue[iCounter, 1])), 2));
                }
                else if ((varA == "decimal"))
                {
                    if (((ArrParamAndValue[iCounter, 1]) == null) || (ArrParamAndValue[iCounter, 1]) == "")
                    {
                        ArrParamAndValue[iCounter, 1] = "0";
                    }

                    cmd.Parameters.AddWithValue("@" + ArrParamAndValue[iCounter, 0], Math.Round((decimal.Parse(ArrParamAndValue[iCounter, 1])), 3));
                }
                else if ((varA == "varchar") || (varA == "text"))
                {
                    cmd.Parameters.AddWithValue("@" + ArrParamAndValue[iCounter, 0], ArrParamAndValue[iCounter, 1].ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@" + ArrParamAndValue[iCounter, 0], ArrParamAndValue[iCounter, 1].ToString());
                }
                if (iCounter == 0)
                    cmd.Parameters[0].Direction = ParameterDirection.InputOutput;
            }
            cmd.Parameters.Add("@UName", SqlDbType.VarChar, 20).Value = uid;
            cmd.Parameters.Add("@Mode", SqlDbType.Int, 1).Value = iMode;


            cmd.ExecuteNonQuery();
            functionReturnValue = Convert.ToString(cmd.Parameters[0].Value);
            myTrans.Commit();
            cmd.Dispose();
            adapter.Dispose();
            cn.Close();
            cn.Dispose();
        }
        catch (Exception err)
        {
            myTrans.Rollback();
            cmd.Dispose();
            //adapter.Dispose()
            cn.Close();
            cn.Dispose();
            throw (err);
            functionReturnValue = "";
            ShowMessage(frmobj, ADDProcDS(ArrParamAndValue, strProcName, EnumCommandType, iMode, frmobj, uid));
        }
        return functionReturnValue;
    }

    protected int checkval(string abc)
    {
        if ((abc == null) || (abc == ""))
        {
            return int.Parse("0");
        }
        else
        {
            return int.Parse(abc);
        }
    }

    protected float checkfloat(string abc)
    {
        if ((abc == null) || (abc == ""))
        {
            return float.Parse("0");
        }
        else
        {
            return float.Parse(abc);
        }
    }

    private void ShowMessage(object frmobj, string p)
    {
        throw new NotImplementedException();
    }

    private SqlDbType DbType(string varA)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public void GridviewDatashow(GridView gridview, string strsql, bool AddNewRecord)
    {
        try
        {
            SqlConnection connection = new SqlConnection(strconnect);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(strsql, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            gridview.DataSource = dataset.Tables[0].DefaultView;
            gridview.DataBind();
            adapter.Dispose();
            connection.Close();
        }
        catch (Exception err)
        {
            throw (err);
        }
    }

    public DataSet senddataset_SP(string stored_proc, Hashtable parameters)
    {
        DataSet functionReturnValue = null;
        System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(strconnect);
        SqlCommand cmd = new SqlCommand(stored_proc, connection);
        try
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dataset = new DataSet();
            DictionaryEntry Item = default(DictionaryEntry);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (DictionaryEntry Item_loopVariable in parameters)
            {
                Item = Item_loopVariable;
                cmd.Parameters.AddWithValue(Item.Key.ToString(), Item.Value);
            }
            cmd.Connection.Open();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataset);
            functionReturnValue = dataset;
            cmd.Connection.Close();
        }
        catch (Exception err)
        {
            cmd.Connection.Close();
            throw (err);
        }
        return functionReturnValue;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="multiview"></param>
    /// <param name="strsql"></param>
    /// <param name="AddNewRecord"></param>
    ///////*************Multi View Bind*****************//
    //public void MultiViewDataBind(MultiView multiview, string strsql, bool AddNewRecord = false)
    //{
    //    try
    //    {
    //        SqlConnection connection = new SqlConnection(strconnect);
    //        connection.Open();
    //        SqlDataAdapter adapter = new SqlDataAdapter(strsql, connection);
    //        DataSet dataset = new DataSet();
    //        adapter.Fill(dataset);
    //        multiview.DataBinding(dataset); // = dataset; // DataSource = dataset;
    //        multiview.DataBind();
    //        connection.Close();
    //    }
    //    catch (Exception err)
    //    {
    //        throw (err);
    //    }
    //}


    //public DateTime ConvertUKdatetoUS(string ukdate)
    //{
    //    //' change to MM/dd/yyyy from dd/MM/yyyy
    //    ArrayList ar = new ArrayList(ukdate.Split("/"));
    //    int dday = ar[0];
    //    int dmonth = ar[1];
    //    int dyear = ar[2];
    //    dynamic dt = dmonth + "/" + dday + "/" + dyear;
    //    DateTime dtdate = Convert.ToDateTime(dt);
    //    return dtdate;
    //}

    //public string ConvertUSdatetoUK(string usdate)
    //{
    //    //' change to dd/MM/yyyy from MM/dd/yyyy
    //    ArrayList ar = new ArrayList(usdate.Split("/"));
    //    int dmonth = ar[0];
    //    int dday = ar[1];
    //    int dyear = ar[2];
    //    dynamic dt = dday + "/" + dmonth + "/" + dyear;
    //    string dtdate = dt;
    //    return dtdate;
    //}

    public void OpenPopUp(Page frmobj, string PageUrl, Int32 height, Int32 width)
    {
        string popupScript = "<script language='javascript'>" + "window.open('" + PageUrl + "', 'CustomPopUp', " + "'height=" + height + ",width=" + width + ",toolbar=no, menubar=no,location=center, resizable=yes, scrollbars=yes')" + "</script>";
        frmobj.RegisterStartupScript("PopupScript", popupScript);
        //ClientScriptManager CSM = frmobj.ClientScript;
        //ClientScript.RegisterStartupScript("PopupScript", popupScript);
    }

    public void OpenPopUpscript(Page frmobj, string PageUrl, Int32 height, Int32 width)
    {
        string popupScript = "<script language='javascript'>" + "window.open('" + PageUrl + "', 'CustomPopUp', " + "'height=" + height + ",width=" + width + ",toolbar=no, menubar=no,location=center, resizable=yes, scrollbars=yes)" + "</script>";

        ScriptManager.RegisterStartupScript(frmobj, frmobj.GetType(), "PopupScript", popupScript, false);

    }

    public void OpenPopUpscript1(Page frmobj, string PageUrl, Int32 height, Int32 width)
    {
        string popupScript = "<script language='javascript'>" + "window.open('" + PageUrl + "', 'CustomPopUp', " + "'height=" + height + ",width=" + width + ",toolbar=no, menubar=no,location=center, resizable=yes, scrollbars=yes ,target=_blank')" + "</script>";

        ScriptManager.RegisterStartupScript(frmobj, frmobj.GetType(), "PopupScript", popupScript, false);

    }

    public void RedirectParent(Page frmobj, string url)
    {
        string js = "";
        js += "window.opener.location.href='" + url + "';";
        js += "window.close();";

        ScriptManager.RegisterStartupScript(frmobj, frmobj.GetType(), "PopupScript", js, true);
    }

    public int DeleteData12(string str)
    {
        int j = 0;
        try
        {

            SqlConnection connection = new SqlConnection(strconnect);
            connection.Open();
            SqlCommand cmd = new SqlCommand(str, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            j = Convert.ToInt32(dt.Rows[0][0].ToString());

            if (j > 0)
            {
                return j;
            }
            else
            {
                return j = 0;
            }

            connection.Close();
        }
        catch (Exception err)
        {

        }
        return j;
    }

    // Read data from database for grid bind
    public DataTable Dataset(string strsql)
    {
        try
        {
            SqlConnection connection = new SqlConnection(strconnect);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(strsql, connection);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            if (datatable.Rows.Count > 0)
            {
                return datatable;
            }

            connection.Close();
        }
        catch (Exception err)
        {

        }
        return new DataTable();
    }

    // new parameterize query
    public object SendValue_Parameter(string stored_text, Hashtable parameters)
    {
        object functionReturnValue = null;
        System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(strconnect);
        SqlCommand cmd = new SqlCommand(stored_text, connection);
        try
        {
            DictionaryEntry Item = default(DictionaryEntry);
            cmd.CommandType = CommandType.Text;
            foreach (DictionaryEntry Item_loopVariable in parameters)
            {
                Item = Item_loopVariable;
                cmd.Parameters.AddWithValue(Item.Key.ToString(), Item.Value.ToString());

            }
            cmd.Connection.Open();
            functionReturnValue = cmd.ExecuteScalar();
            cmd.Connection.Close();
        }
        catch (Exception err)
        {
            cmd.Connection.Close();
            throw (err);
        }
        return functionReturnValue;
    }

    public void ExecuteQry_Parameter(string stored_text, Hashtable parameters)
    {
        System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(strconnect);
        SqlCommand cmd = new SqlCommand(stored_text, connection);
        try
        {
            DictionaryEntry Item = default(DictionaryEntry);
            cmd.CommandType = CommandType.Text;
            foreach (DictionaryEntry Item_loopVariable in parameters)
            {
                Item = Item_loopVariable;
                cmd.Parameters.AddWithValue(Item.Key.ToString(), Item.Value.ToString());
            }
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        catch (Exception err)
        {
            cmd.Connection.Close();
            throw (err);
        }
    }

    public void GridviewData_Parameter(GridView gridview, string stored_text, Hashtable parameters)
    {
        System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(strconnect);
        SqlCommand cmd = new SqlCommand(stored_text, connection);
        try
        {
            DictionaryEntry Item = default(DictionaryEntry);
            cmd.CommandType = CommandType.Text;
            foreach (DictionaryEntry Item_loopVariable in parameters)
            {
                Item = Item_loopVariable;
                cmd.Parameters.AddWithValue(Item.Key.ToString(), Item.Value.ToString());
            }
            cmd.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            cmd.Connection.Close();
            gridview.DataSource = dataset.Tables[0].DefaultView;
            gridview.DataBind();

        }
        catch (Exception err)
        {
            cmd.Connection.Close();
            throw (err);
        }
    }

    public void datalistDatashow_Parameter(DataList datalist, string stored_text, Hashtable parameters)
    {
        try
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(strconnect);
            SqlCommand cmd = new SqlCommand(stored_text, connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dataset = new DataSet();
            DictionaryEntry Item = default(DictionaryEntry);
            cmd.CommandType = CommandType.Text;
            foreach (DictionaryEntry Item_loopVariable in parameters)
            {
                Item = Item_loopVariable;
                cmd.Parameters.AddWithValue(Item.Key.ToString(), Item.Value.ToString());
            }
            cmd.Connection.Open();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataset);
            datalist.DataSource = dataset;
            datalist.DataBind();
            cmd.Connection.Close();
        }
        catch (Exception err)
        {
            throw (err);
        }
    }

    public void repeaterDatashow_Parameter(Repeater repeater, string stored_text, Hashtable parameters)
    {
        try
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(strconnect);
            SqlCommand cmd = new SqlCommand(stored_text, connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dataset = new DataSet();
            DictionaryEntry Item = default(DictionaryEntry);
            cmd.CommandType = CommandType.Text;
            foreach (DictionaryEntry Item_loopVariable in parameters)
            {
                Item = Item_loopVariable;
                cmd.Parameters.AddWithValue(Item.Key.ToString(), Item.Value.ToString());
            }
            cmd.Connection.Open();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataset);
            repeater.DataSource = dataset;
            repeater.DataBind();
            connection.Close();
        }
        catch (Exception err)
        {
            throw (err);
        }
    }

    public void Fillcombo_Parameter(string stored_text, Hashtable parameters, DropDownList droplist)
    {
        try
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(strconnect);
            SqlCommand cmd = new SqlCommand(stored_text, connection);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dataset = new DataSet();
            DictionaryEntry Item = default(DictionaryEntry);
            cmd.CommandType = CommandType.Text;
            foreach (DictionaryEntry Item_loopVariable in parameters)
            {
                Item = Item_loopVariable;
                cmd.Parameters.AddWithValue(Item.Key.ToString(), Item.Value.ToString());
            }
            adapter.SelectCommand = cmd;
            adapter.Fill(dataset);
            droplist.Items.Clear();
            if (dataset.Tables[0].Rows.Count > 0)
            {
                droplist.DataSource = dataset.Tables[0];
                droplist.DataTextField = dataset.Tables[0].Columns[0].ColumnName;
                droplist.DataValueField = dataset.Tables[0].Columns[1].ColumnName;
                droplist.DataBind();
            }
            droplist.Items.Insert(0, "- -Select- -");
            droplist.Items[0].Value = "0";
            droplist.SelectedIndex = droplist.Items.IndexOf(droplist.Items.FindByText("- -Select- -"));
            adapter.Dispose();
            dataset.Dispose();
        }
        catch (Exception ERR)
        {
            throw (ERR);
        }
    }

    public DataSet senddataset_Parameter(string stored_text, Hashtable parameters)
    {
        DataSet functionReturnValue = null;
        System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(strconnect);
        SqlCommand cmd = new SqlCommand(stored_text, connection);
        try
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dataset = new DataSet();
            DictionaryEntry Item = default(DictionaryEntry);
            cmd.CommandType = CommandType.Text;
            foreach (DictionaryEntry Item_loopVariable in parameters)
            {
                Item = Item_loopVariable;
                cmd.Parameters.AddWithValue(Item.Key.ToString(), Item.Value.ToString());
            }
            cmd.Connection.Open();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataset);
            functionReturnValue = dataset;
            cmd.Connection.Close();
        }
        catch (Exception err)
        {
            cmd.Connection.Close();
            throw (err);
        }
        return functionReturnValue;
    }

    public void MoveRecord_Parameter(Control frmObj1, Control frmObj, string stored_text, Hashtable parameters)
    {
        System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(strconnect);
        SqlCommand cmd = new SqlCommand(stored_text, connection);
        try
        {
            Control Commcont = null;
            Control Commcont1 = null;
            Control Commcont2 = null;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet selecttable = new DataSet();
            DictionaryEntry Item = default(DictionaryEntry);
            cmd.CommandType = CommandType.Text;
            foreach (DictionaryEntry Item_loopVariable in parameters)
            {
                Item = Item_loopVariable;
                cmd.Parameters.AddWithValue(Item.Key.ToString(), Item.Value);
            }
            if (cmd.Connection.State == ConnectionState.Open || cmd.Connection.State == ConnectionState.Broken)
            {
                cmd.Connection.Close();
            }

            cmd.Connection.Open();
            adapter.SelectCommand = cmd;
            adapter.Fill(selecttable);
            if (selecttable.Tables[0].Rows.Count > 0)
            {
                //var _with1 = selecttable.Tables[0];
                foreach (Control Commcont_loopVariable in frmObj.Controls)
                {
                    Commcont = Commcont_loopVariable;
                    if (Commcont is UpdatePanel)
                    {
                        foreach (Control Commcont1_loopVariable in Commcont.Controls)
                        {
                            Commcont1 = Commcont1_loopVariable;
                            foreach (Control Commcont2_loopVariable in Commcont1.Controls)
                            {
                                Commcont2 = Commcont2_loopVariable;
                                if (Commcont2 is DropDownList)
                                {
                                    if (((DropDownList)Commcont2).EnableViewState == true)
                                    {
                                        if (Information.IsDBNull(selecttable.Tables[0].Rows[0][Commcont2.ID].ToString()) == false)
                                        {
                                            ((DropDownList)Commcont2).SelectedIndex = ((DropDownList)Commcont2).Items.IndexOf(((DropDownList)Commcont2).Items.FindByValue(selecttable.Tables[0].Rows[0][Commcont2.ID].ToString()));
                                        }
                                    }
                                }

                                if (Commcont2 is CheckBox)
                                {
                                    ((CheckBox)Commcont2).Checked = (selecttable.Tables[0].Rows[0][Commcont2.ID].ToString() == "False" ? false : true);
                                }

                                //if (Commcont2 is TextBox)
                                //{
                                //    if (((TextBox)Commcont2).ReadOnly == false)
                                //    {
                                //        if (selecttable.Tables[0].Rows[0][Commcont2.ID].ToString().GetType().FullName == "System.Double")
                                //        {
                                //            ((TextBox)Commcont2).Text = Strings.Format(selecttable.Tables[0].Rows[0][Commcont2.ID].ToString(), "0.00");
                                //        }
                                //        else
                                //        {
                                //            ((TextBox)Commcont2).Text = (Information.IsDBNull(selecttable.Tables[0].Rows[0][Commcont2.ID].ToString()) ? "" : selecttable.Tables[0].Rows[0][Commcont2.ID].ToString());
                                //        }
                                //    }
                                //}
                                if (Commcont2 is TextBox)
                                {
                                    if (((TextBox)Commcont2).ReadOnly == false)
                                    {
                                        if (selecttable.Tables[0].Rows[0][Commcont2.ID].GetType().FullName == "System.Double")
                                        {
                                            ((TextBox)Commcont2).Text = Strings.Format(selecttable.Tables[0].Rows[0][Commcont2.ID], "0.00");
                                        }
                                        else if (selecttable.Tables[0].Rows[0][Commcont2.ID].GetType().FullName == "System.DateTime")
                                        {
                                            if (System.Convert.ToDateTime(selecttable.Tables[0].Rows[0][Commcont2.ID]).ToString("MM/dd/yyyy") == "01/01/1900")
                                            {
                                                ((TextBox)Commcont2).Text = "";
                                            }
                                            else
                                            {
                                                ((TextBox)Commcont2).Text = Strings.Format(selecttable.Tables[0].Rows[0][Commcont2.ID], "MM/dd/yyyy");
                                            }
                                        }
                                        else
                                        {
                                            ((TextBox)Commcont2).Text = (Information.IsDBNull(selecttable.Tables[0].Rows[0][Commcont2.ID]) ? "" : selecttable.Tables[0].Rows[0][Commcont2.ID].ToString());
                                        }
                                    }
                                }
                            }

                        }
                    }

                    //if (Commcont is TextBox)
                    //{
                    //    if (((TextBox)Commcont).ReadOnly == false)
                    //    {
                    //        if (selecttable.Tables[0].Rows[0][Commcont.ID].ToString().GetType().FullName == "System.Double")
                    //        {
                    //            ((TextBox)Commcont).Text = Strings.Format(selecttable.Tables[0].Rows[0][Commcont.ID].ToString(), "0.00");
                    //        }
                    //        else
                    //        {
                    //            ((TextBox)Commcont).Text = (Information.IsDBNull(selecttable.Tables[0].Rows[0][Commcont.ID].ToString()) ? "" : selecttable.Tables[0].Rows[0][Commcont.ID].ToString());
                    //        }
                    //    }
                    //}
                    if (Commcont is TextBox)
                    {
                        if (((TextBox)Commcont).ReadOnly == false)
                        {
                            if (selecttable.Tables[0].Rows[0][Commcont.ID].GetType().FullName == "System.Double")
                            {
                                ((TextBox)Commcont).Text = Strings.Format(selecttable.Tables[0].Rows[0][Commcont.ID], "0.00");
                            }
                            else if (selecttable.Tables[0].Rows[0][Commcont.ID].GetType().FullName == "System.DateTime")
                            {
                                if (System.Convert.ToDateTime(selecttable.Tables[0].Rows[0][Commcont.ID]).ToString("MM/dd/yyyy") == "01/01/1900")
                                {
                                    ((TextBox)Commcont).Text = "";
                                }
                                else
                                {
                                    ((TextBox)Commcont).Text = Strings.Format(selecttable.Tables[0].Rows[0][Commcont.ID], "MM/dd/yyyy");
                                }
                            }
                            else
                            {
                                ((TextBox)Commcont).Text = (Information.IsDBNull(selecttable.Tables[0].Rows[0][Commcont.ID]) ? "" : selecttable.Tables[0].Rows[0][Commcont.ID].ToString());
                            }
                        }
                    }
                    if (Commcont is DropDownList)
                    {
                        if (((DropDownList)Commcont).EnableViewState == true)
                        {
                            if (Information.IsDBNull(selecttable.Tables[0].Rows[0][Commcont.ID].ToString()) == false)
                            {
                                ((DropDownList)Commcont).SelectedIndex = ((DropDownList)Commcont).Items.IndexOf(((DropDownList)Commcont).Items.FindByValue(selecttable.Tables[0].Rows[0][Commcont.ID].ToString()));
                            }
                        }
                    }
                    if (Commcont is RadioButtonList)
                    {
                        if (((RadioButtonList)Commcont).EnableViewState == true)
                        {
                            if (Information.IsDBNull(selecttable.Tables[0].Rows[0][Commcont.ID].ToString()) == false)
                            {
                                ((RadioButtonList)Commcont).SelectedIndex = ((RadioButtonList)Commcont).Items.IndexOf(((RadioButtonList)Commcont).Items.FindByValue(selecttable.Tables[0].Rows[0][Commcont.ID].ToString()));
                            }
                        }
                    }
                    if (Commcont is CheckBox)
                    {
                        ((CheckBox)Commcont).Checked = (selecttable.Tables[0].Rows[0][Commcont.ID].ToString() == "False" ? false : true);
                    }
                }
            }
        }

        catch (Exception ERR)
        {
            throw (ERR);
        }
        finally
        {
            cmd.Connection.Close();
        }
    }

    public bool Checking_Parameter(string str, Hashtable parameters)
    {
        bool functionReturnValue = false;
        System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(strconnect);
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
        try
        {
            DictionaryEntry Item = default(DictionaryEntry);
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = str;
            foreach (DictionaryEntry Item_loopVariable in parameters)
            {
                Item = Item_loopVariable;
                cmd.Parameters.AddWithValue(Item.Key.ToString(), Item.Value.ToString());
            }
            System.Data.SqlClient.SqlDataReader datareader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (datareader.Read() == true)
            {
                functionReturnValue = true;
            }
            else
            {
                functionReturnValue = false;
            }
            cmd.Dispose();
            cn.Close();
            cn.Dispose();

        }
        catch (Exception err)
        {
            cmd.Dispose();
            cn.Close();
            cn.Dispose();
            throw (err);
        }
        return functionReturnValue;
    }

    public bool Checking_Sp(string str, Hashtable parameters)
    {
        bool functionReturnValue = false;
        System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(strconnect);
        SqlCommand cmd = new SqlCommand(str, cn);
        try
        {
            DictionaryEntry Item = default(DictionaryEntry);
            cn.Open();
            //cmd.Connection = cn;
            //cmd.CommandText = str;
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (DictionaryEntry Item_loopVariable in parameters)
            {
                Item = Item_loopVariable;
                cmd.Parameters.AddWithValue(Item.Key.ToString(), Item.Value.ToString());
            }
            System.Data.SqlClient.SqlDataReader datareader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (datareader.Read() == true)
            {
                functionReturnValue = true;
            }
            else
            {
                functionReturnValue = false;
            }
            cmd.Dispose();
            cn.Close();
            cn.Dispose();

        }
        catch (Exception err)
        {
            cmd.Dispose();
            cn.Close();
            cn.Dispose();
            throw (err);
        }
        return functionReturnValue;
    }


    public void Check_EditDelete(int Utypeid, int FORMID, Repeater repcat)
    {
        if (Utypeid != 1)
        {

            Hashtable parameters = new Hashtable();
            DataSet dschek = new DataSet();
            parameters.Clear();
            parameters.Add("@UTYPEID", Utypeid);
            parameters.Add("@FORMID", FORMID);
            parameters.Add("@Mode", 8);
            dschek = senddataset_SP("UDSP_MODULE", parameters);
            if (dschek.Tables[0].Rows.Count > 0)
            {
                if (dschek.Tables[0].Rows[0]["EDITSTATUS"].ToString() == "True")
                {
                    Control HeaderTemplate = repcat.Controls[0].Controls[0];
                    HtmlTableCell thedit = HeaderTemplate.FindControl("thedit") as HtmlTableCell;
                    foreach (RepeaterItem item in repcat.Items)
                    {
                        HtmlTableCell tdedit = (HtmlTableCell)item.FindControl("tdedit");
                        tdedit.Visible = true;
                    }
                    thedit.Visible = true;
                }
                else
                {
                    Control HeaderTemplate = repcat.Controls[0].Controls[0];
                    HtmlTableCell thedit = HeaderTemplate.FindControl("thedit") as HtmlTableCell;
                    foreach (RepeaterItem item in repcat.Items)
                    {
                        HtmlTableCell tdedit = (HtmlTableCell)item.FindControl("tdedit");
                        tdedit.Visible = false;
                    }
                    thedit.Visible = false;
                }
                if (dschek.Tables[0].Rows[0]["DELETESTATUS"].ToString() == "True")
                {
                    Control HeaderTemplate = repcat.Controls[0].Controls[0];
                    HtmlTableCell thdelete = HeaderTemplate.FindControl("thdelete") as HtmlTableCell;
                    foreach (RepeaterItem item in repcat.Items)
                    {
                        HtmlTableCell tddelete = (HtmlTableCell)item.FindControl("tddelete");
                        tddelete.Visible = true;
                    }
                    thdelete.Visible = true;
                }
                else
                {
                    Control HeaderTemplate = repcat.Controls[0].Controls[0];
                    HtmlTableCell thdelete = HeaderTemplate.FindControl("thdelete") as HtmlTableCell;
                    foreach (RepeaterItem item in repcat.Items)
                    {
                        HtmlTableCell tddelete = (HtmlTableCell)item.FindControl("tddelete");
                        tddelete.Visible = false;
                    }
                    thdelete.Visible = false;
                }
            }
        }

    }

    public bool CheckPermission(int Utypeid, int FORMID)
    {
        bool functionReturnValue = false;
        if (Utypeid != 1)
        {
            Hashtable parameters = new Hashtable();
            DataSet dschek = new DataSet();
            parameters.Clear();
            parameters.Add("@UTYPEID", Utypeid);
            parameters.Add("@FORMID", FORMID);
            parameters.Add("@Mode", 11);
            dschek = senddataset_SP("UDSP_MODULE", parameters);
            if (dschek.Tables[0].Rows.Count > 0)
            {
                functionReturnValue = true;
            }

        }
        return functionReturnValue;
    }

    public void AddLogHistory(string pageurl, string oinstid, string addeditmode, string pagetitle, string pageid, string tablename, string strInstituteId, string strInstituteName)
    {
        HttpCookie AUserSession = null;
        string strip = Convert.ToString(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
        if (string.IsNullOrEmpty(strip))
        {
            strip = Convert.ToString(HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
        }
        Hashtable Parameters = new Hashtable();
        Parameters.Clear();


        //string strInstituteId = "0";
        //string strInstituteName = "";
        string strCampusID = "0";
        string strCampusName = "";



        if (HttpContext.Current.Request.Cookies["AUserSession"] == null)
        {
            AUserSession = new HttpCookie("AUserSession");
        }
        else
        {
            AUserSession = HttpContext.Current.Request.Cookies["AUserSession"];
        }


        SqlConnection cn = new SqlConnection(strconnect);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "loghistorySP";
        //cmd.Parameters.AddWithValue("@pageurl", Convert.ToString(pageurl));
        //cmd.Parameters.AddWithValue("@ip", Convert.ToString(strip));
        //cmd.Parameters.AddWithValue("@institutid", Convert.ToString(AUserSession["Trid"]));
        //cmd.Parameters.AddWithValue("@institutename", Convert.ToString(strInstituteName));
        //cmd.Parameters.AddWithValue("@campusid", Convert.ToString(strCampusID));
        //cmd.Parameters.AddWithValue("@campusname", Convert.ToString(strCampusName));
        //cmd.Parameters.AddWithValue("@addeditmode", Convert.ToString(addeditmode));
        //cmd.Parameters.AddWithValue("@userid", Convert.ToString(AUserSession["userid"]));
        //cmd.Parameters.AddWithValue("@userpass", Convert.ToString(AUserSession["userpassword"]));
        //cmd.Parameters.AddWithValue("@pagetitle", Convert.ToString(pagetitle));

        //cmd.Parameters.AddWithValue("@pageid", Convert.ToString(pageid));
        //cmd.Parameters.AddWithValue("@pagetable", Convert.ToString(tablename));

        cmd.Parameters.AddWithValue("@pageurl", Convert.ToString(pageurl));
        cmd.Parameters.AddWithValue("@ip", Convert.ToString(strip));
        cmd.Parameters.AddWithValue("@institutid", Convert.ToString(strInstituteId));
        cmd.Parameters.AddWithValue("@institutename", Convert.ToString(strInstituteName));
        cmd.Parameters.AddWithValue("@campusid", Convert.ToString(strCampusID));
        cmd.Parameters.AddWithValue("@campusname", Convert.ToString(strCampusName));
        cmd.Parameters.AddWithValue("@addeditmode", Convert.ToString(addeditmode));
        cmd.Parameters.AddWithValue("@userid", Convert.ToString(AUserSession["userid"]));
        cmd.Parameters.AddWithValue("@Trid", Convert.ToString(AUserSession["Trid"]));
        cmd.Parameters.AddWithValue("@pagetitle", Convert.ToString(pagetitle));
        cmd.Parameters.AddWithValue("@pageid", Convert.ToString(pageid));
        cmd.Parameters.AddWithValue("@pagetable", Convert.ToString(tablename));

        cmd.Parameters.AddWithValue("@Mode", 1);
        cmd.Parameters.Add("@historyid", SqlDbType.Int, 0, "@historyid").Direction = ParameterDirection.Output;
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();

    }

    public string CHECK_ADD()
    {
        HttpCookie AUserSession = null;
        string str = "no";
        if (HttpContext.Current.Request.Cookies["AUserSession"] == null)
        {
            AUserSession = new HttpCookie("AUserSession");
        }
        else
        {
            AUserSession = HttpContext.Current.Request.Cookies["AUserSession"];
        }

        if (Convert.ToString(AUserSession["Trid"]) != "1")
        {
            if (Convert.ToString(AUserSession["AddUser"]) != "True")
            {
                str = "yes";
                // string funcCall = "<script language='javascript'>alert('hello');</script>";

                // ClientScript.RegisterStartupScript(this.GetType(), "JSScript", funcCall);
                //  ShowMessage(this.GetType(), "You are not authorised persion to add data.");
                //  return;
            }
        }
        //AUserSession["AddUser"]
        // UserSession["EditUser"]
        // AUserSession["DeleteUser"]
        return str;
    }
    public string CHECK_EDIT()
    {
        HttpCookie AUserSession = null;
        string str = "no";
        if (HttpContext.Current.Request.Cookies["AUserSession"] == null)
        {
            AUserSession = new HttpCookie("AUserSession");
        }
        else
        {
            AUserSession = HttpContext.Current.Request.Cookies["AUserSession"];
        }

        if (Convert.ToString(AUserSession["Trid"]) != "1")
        {
            if (Convert.ToString(AUserSession["EditUser"]) != "True")
            {
                str = "yes";
            }
        }

        return str;
    }
    public string CHECK_DELETE()
    {
        HttpCookie AUserSession = null;
        string str = "no";
        if (HttpContext.Current.Request.Cookies["AUserSession"] == null)
        {
            AUserSession = new HttpCookie("AUserSession");
        }
        else
        {
            AUserSession = HttpContext.Current.Request.Cookies["AUserSession"];
        }
        if (Convert.ToString(AUserSession["Trid"]) != "1")
        {
            if (Convert.ToString(AUserSession["DeleteUser"]) != "True")
            {
                str = "yes";
            }
        }
        return str;
    }
    public string replacestring(string str)
    {
        try
        {
            string strnew = str.ToString().TrimStart().TrimEnd().ToLower().Replace(".", "-").Replace(" ", "-").Replace("&", "-").Replace("@", "").Replace("'", "").Replace("/", "").Replace(",-", "").Replace("‘", "").Replace("“", "").Replace("”", "").Replace(":", "").Replace(":", "").Replace("-–-", "-").Replace("%", "").Replace("--", "-").Replace("---", "-").Replace("--", "-");

            return strnew;
        }
        catch (Exception err)
        {
            throw (err);
        }
    }
    public string checkpassword(string username)
    {
        Hashtable parameters = new Hashtable();
        string str;
        parameters.Add("@userid", username);
        str = Convert.ToString(SendValue_Parameter("select userpassword from bousermaster where userid=@userid", parameters));
        return str;
    }
}












