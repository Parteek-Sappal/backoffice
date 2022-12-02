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
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Web.Configuration;


/// <summary>
/// Summary description for test
/// </summary>
public class Enc_Decyption
{
    public string encrptdecrpt = "!@12345AaxzZ$#9870";
    public string AES_Decrypt(string input, string pass)
    {
        System.Security.Cryptography.RijndaelManaged AES = new System.Security.Cryptography.RijndaelManaged();
        System.Security.Cryptography.MD5CryptoServiceProvider Hash_AES = new System.Security.Cryptography.MD5CryptoServiceProvider();
        string decrypted = "";
        try
        {
            byte[] hash = new byte[32];
            byte[] temp = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass));
            Array.Copy(temp, 0, hash, 0, 16);
            Array.Copy(temp, 0, hash, 15, 16);
            AES.Key = hash;
            AES.Mode = System.Security.Cryptography.CipherMode.ECB;
            System.Security.Cryptography.ICryptoTransform DESDecrypter = AES.CreateDecryptor();
            byte[] Buffer = Convert.FromBase64String(input);
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length));
            return decrypted;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }


    public string AES_Encrypt(string input, string pass)
    {
        System.Security.Cryptography.RijndaelManaged AES = new System.Security.Cryptography.RijndaelManaged();
        System.Security.Cryptography.MD5CryptoServiceProvider Hash_AES = new System.Security.Cryptography.MD5CryptoServiceProvider();
        string encrypted = "";
        try
        {
            byte[] hash = new byte[32];
            byte[] temp = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass));
            Array.Copy(temp, 0, hash, 0, 16);
            Array.Copy(temp, 0, hash, 15, 16);
            AES.Key = hash;
            AES.Mode = System.Security.Cryptography.CipherMode.ECB;
            System.Security.Cryptography.ICryptoTransform DESEncrypter = AES.CreateEncryptor();
            byte[] Buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(input);
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length));
            return encrypted;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
} 