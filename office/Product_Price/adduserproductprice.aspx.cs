using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;

namespace backoffice.office.Product_Price
{
    public partial class adduserproductprice : System.Web.UI.Page
    {
        Hashtable parameters = new Hashtable();
        mainclass clsm = new mainclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (Page.IsPostBack == false)
            {
                parameters.Clear();
                clsm.Fillcombo_Parameter("Select username as name,userid from userregistration where status=1 order by username", parameters, userid);
                parameters.Clear();
                clsm.Fillcombo_Parameter("Select Prodname,Prodid from Product order by Prodname", parameters, Prodid);


                Int32 p = 0;
                if (Int32.TryParse(Request.QueryString["id"], out p) == true)
                {

                    parameters.Clear();
                    parameters.Add("@id", Convert.ToInt32(Request.QueryString["id"].ToString()));
                    clsm.MoveRecord_Parameter(this, id.Parent, "Select * from user_product_price where id =@id", parameters);
                }
                if (Convert.ToString(Request.QueryString["add"]) == "add")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Added Successfully.";
                }
            }
        }
        protected void Submit_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(clsm.MasterSave(this, id.Parent, 7, mainclass.Mode.modeCheckDuplicate, "user_product_priceSP", Session["UserId"].ToString()).ToString()) > 0)
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "This Record Already exists";
                    return;
                }
                if (string.IsNullOrEmpty(id.Text))
                {
                    object var = clsm.MasterSave(this, id.Parent, 7, mainclass.Mode.modeAdd, "user_product_priceSP", Session["UserId"].ToString());                   
                    clsm.ClearallPanel(this, id.Parent);
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Added Successfully.";
                }
                else
                {

                    object var = clsm.MasterSave(this, id.Parent, 7, mainclass.Mode.modeModify, "user_product_priceSP", Session["UserId"].ToString());
                    Response.Redirect("viewuserproductprice.aspx?edit=edit");
                }
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message;
            }
        }
        protected void Reset_Click(object sender, System.EventArgs e)
        {
            // If Request.QueryString("ProdID") <> "" Then
            //     Response.Redirect("viewproduct.aspx")
            // Else
            clsm.ClearallPanel(this, Prodid.Parent);
            // End If
        }
    }
}