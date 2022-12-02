using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
public class msg
{
    public msg()
    {

    }
    //insert,update,delete,status changed,
    public static string colSelect()
    {
        return "Please add at least one Columns!";
    }
    public static string contactassociate()
    {
        return "Contact Associate Successfully!";
    }
    public static string spacemsg()
    {
        return "Attribute name cannot have spaces!";
    }
    public static string Leadfavadd()
    {
        return "Add in Favorite list.";
    }
    public static string Leadremovefav()
    {
        return "Remove from Favorite list.";
    }
    public static string oppfavadd()
    {
        return "Opportunity add in Favorite list.";
    }
    public static string oppremovefav()
    {
        return "Opportunity remove from Favorite list.";
    }
    public static string attendance()
    {
        return "Attendance generated successfully !";
    }
    public static string removeresume()
    {
        return "Resume deleted successfully !";
    }
    public static string alreadused()
    {
        return "Record can't be deleted its already in use!";
    }
    public static string imgRequired()
    {
        return "Please select a image to upload.";
    }
    public static string fileRequired()
    {
        return "Please select a file to upload.";
    }
    public static string imgdelete()
    {
        return "Image deleted successfully.";
    }
    public static string signaturedelete()
    {
        return "Signature deleted successfully.";
    }
    public static string delete()
    {
        return "Record deleted successfully.";
    }
    public static string update()
    {
        return "Record updated successfully.";
    }
    public static string update_sendmail()
    {
        return "Record updated and mail sent successfully.";
    }
    public static string sendmail()
    {
        return "Mail sent successfully.";
    }
    public static string inserted()
    {
        return "Record Added successfully.";
    }
    public static string statuschage()
    {
        return "Status change successfully.";
    }
    public static string Duplicate()
    {
        return "Record already exist.";
    }

    public static string imageTypeCheck()
    {
        return "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png.";
    }
    public static string fileTypeCheck()
    {
        return "Please select a file with a file format extension of either doc, docx, pdf or txt.";
    }

    public static string EmptyRecord()
    {
        return "Record Not Found.";
    }
    public static string Filedelete()
    {
        return "File deleted successfully.";
    }
    public static string Newsevent()
    {
        return "There is no current news/events available for display.";
    }
    public static bool CheckImageType(string fileName)
    {
        string ext = Path.GetExtension(fileName);
        switch (ext.ToLower())
        {
            case ".png":
                return true;
            case ".gif":
                return true;
            case ".jpeg":
                return true;
            case ".jpg":
                return true;
            case ".bmp":
                return true;
            default:
                return false;
        }
    }
    public static bool CheckFileType(string fileName)
    {
        string ext = Path.GetExtension(fileName);
        switch (ext.ToLower())
        {
            case ".doc":
                return true;
            case ".docx":
                return true;
            case ".xls":
                return true;
            case ".xlsx":
                return true;
            case ".txt":
                return true;
            case ".pdf":
                return true;
            default:
                return false;
        }
    }
}