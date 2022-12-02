using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Configuration;
using System.Net;

using EvoPdf;
using System.Drawing.Printing;

namespace backoffice.office.Product_Price
{
    public partial class assigneprice : System.Web.UI.Page
    {
        mainclass clsm = new mainclass();
        Hashtable parameters = new Hashtable();
        public int appno;
        bool Quotestatus = true;
        HttpCookie UserSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            trerror.Visible = false;
            trsuccess.Visible = false;
            trnotice.Visible = false;
            if (Request.Cookies["UserSession"] == null)
            {
                UserSession = new HttpCookie("UserSession");
            }
            else
            {
                UserSession = Request.Cookies["UserSession"];
            }
            Filldetails();
            if (!Page.IsPostBack)
            {

                FillData();
                if ((Request.QueryString["edit"] == "edit"))
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record(s) updated successfully.";
                }

            }
        }

        public void Filldetails()
        {
            try
            {
                DataSet ds = clsm.sendDataset("select * from order_history where orderno='" + Convert.ToString(Request.QueryString["orderno"]) + "' ", false);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblstatus.Text = ds.Tables[0].Rows[0]["enquirystatus"].ToString();

                    if (lblstatus.Text == "Completed")
                    {
                        btnupdate.Visible = false;
                    }

                    lblorder.Text = ds.Tables[0].Rows[0]["orderno"].ToString();
                    lbldate.Text = ds.Tables[0].Rows[0]["trdate"].ToString();
                    lbldate.Text = Convert.ToDateTime(lbldate.Text).ToString("dd/MM/yyyy");
                    if (ds.Tables[0].Rows[0]["ddate"].ToString() != "")
                    {
                        lblddate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ddate"]).ToString("dd/MM/yyyy");
                        trdd.Visible = true;
                    }
                    lblname.Text = ds.Tables[0].Rows[0]["name"].ToString();
                    lblemail.Text = ds.Tables[0].Rows[0]["email"].ToString();
                    lblphone.Text = ds.Tables[0].Rows[0]["phone"].ToString();
                    lbladdress.Text = ds.Tables[0].Rows[0]["address"].ToString();
                    lblamount.Text = ds.Tables[0].Rows[0]["subtotalamount"].ToString();
                    // lbldiscount.Text = ds.Tables[0].Rows[0]["discount"].ToString();


                    lbltotalamount.Text = ds.Tables[0].Rows[0]["subtotalamount"].ToString();
                    lbltotalsubamount.Text = ds.Tables[0].Rows[0]["subtotalamount"].ToString();
                    if (Conversion.Val(ds.Tables[0].Rows[0]["subtotalamount"].ToString()) != 0)
                    {

                        lblgrand.Text = ds.Tables[0].Rows[0]["subtotalamount"].ToString();
                    }
                    else
                    {
                        lblgrand.Text = "0.0";
                    }

                    billadd.Text = ds.Tables[0].Rows[0]["address"].ToString().Replace(Environment.NewLine, "<br/>");
                    if (ds.Tables[0].Rows[0]["address"].ToString() != "")
                    {
                        lbladdress.Text = ds.Tables[0].Rows[0]["address"].ToString().Replace(Environment.NewLine, "<br/>");
                        traddress.Visible = true;
                    }

                    billcity.Text = ds.Tables[0].Rows[0]["city"].ToString();
                    billphone.Text = ds.Tables[0].Rows[0]["phone"].ToString();
                    TranStatus.Text = ds.Tables[0].Rows[0]["TranStatus"].ToString();
                    MerchantrefNo.Text = ds.Tables[0].Rows[0]["MerchantrefNo"].ToString();
                    PaymentId.Text = ds.Tables[0].Rows[0]["PaymentId"].ToString();
                    TranRefNo.Text = ds.Tables[0].Rows[0]["TranRefNo"].ToString();
                    Tranid.Text = ds.Tables[0].Rows[0]["Tranid"].ToString();
                    TranError.Text = ds.Tables[0].Rows[0]["TranError"].ToString();
                }
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }
        }

        void FillData()
        {
            try
            {
                string strquery1 = "";
                parameters.Clear();
                //strquery1 = @"select p.Prodname,p.Prodcode,  c.* FROM cart c inner join Product p ON c.productid = p.Prodid  where 1=1 and c.enqirystatus=0 ";
                strquery1 = "select p.*, od.* FROM order_details od inner join Product p on od.productid=p.Prodid where  1=1 ";
                if (Convert.ToString(Request.QueryString["orderno"]) != "0")
                {
                    parameters.Add("@orderno", Convert.ToString(Request.QueryString["orderno"]));
                    strquery1 += " and od.orderno=@orderno";
                }
                strquery1 += " order by od.orderno ";
                clsm.GridviewData_Parameter(GridView1, strquery1, parameters);
                Session["qry"] = strquery1;
                if ((GridView1.Rows.Count > 0))
                {
                    GridView1.Visible = true;
                }
                else
                {
                    GridView1.Visible = false;
                    trnotice.Visible = true;
                    lblnotice.Text = "Record(s) not found.";
                }
                appno = GridView1.Rows.Count;
            }


            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }

        }
        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                FillData();
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }
        }

        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {


        }

        protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            try
            {
                if ((e.Row.RowType == DataControlRowType.DataRow))
                {

                    TextBox txtprice = (TextBox)e.Row.FindControl("txtprice");


                    string Existprice = "";
                    string userid = ((TextBox)e.Row.FindControl("txtuserid") as TextBox).Text;
                    string productid = ((TextBox)e.Row.FindControl("txtproductid") as TextBox).Text;
                    string price = ((TextBox)e.Row.FindControl("txtprice") as TextBox).Text;
                    string quantity = ((Label)e.Row.FindControl("lblquantity") as Label).Text;
                    string productprice = ((TextBox)e.Row.FindControl("txtproductdprice") as TextBox).Text;


                    parameters.Clear();
                    parameters.Add("@Prodid", Conversion.Val(productid));
                    parameters.Add("@userid", userid);
                    parameters.Add("@quantity", Conversion.Val(quantity));
                    parameters.Add("@orderno", Convert.ToString(Request.QueryString["orderno"]));

                    Existprice = Convert.ToString(clsm.SendValue_Parameter("select price from order_details where userid=@userid and productid=@Prodid and quantity=@quantity and orderno=@orderno", parameters));



                    //int totalprice = Convert.ToInt32(Existprice) * Convert.ToInt32(quantity);

                    // Existprice = Convert.ToString(clsm.SendValue_Parameter("select price from user_product_price where userid=@userid and Prodid=@Prodid and quantity=@quantity", parameters));
                    if (Conversion.Val(Existprice) > 0)
                    {
                        // txtprice.Text = Existprice;
                        //productprice = Existprice;
                        // txtprice.Text = Convert.ToInt32(totalprice).ToString();
                    }
                    else
                    {
                        txtprice.Text = "0";
                    }

                    RequiredFieldValidator RequiredFieldValidator1 = (RequiredFieldValidator)e.Row.FindControl("RequiredFieldValidator1");
                    if (!string.IsNullOrEmpty(productprice) && Conversion.Val(productprice) != 0)
                    {
                        RequiredFieldValidator1.Visible = false;
                    }

                    //RadioButtonList rbtnlisttype = (RadioButtonList)e.Row.FindControl("rbtnlisttype");
                    //if (rbtnlisttype.SelectedValue == "All User")
                    //{
                    //    Response.Write(rbtnlisttype.SelectedValue);
                    //}
                    //if (rbtnlisttype.SelectedValue == "Current User")
                    //{
                    //    Response.Write(rbtnlisttype.SelectedValue);
                    //}
                    //if (rbtnlisttype.SelectedValue == "Order No By User")
                    //{
                    //    Response.Write(rbtnlisttype.SelectedValue);
                    //}


                }

            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }

        }


        //protected void rbtnlisttype_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    RadioButtonList rbtnlisttype = (RadioButtonList)sender;
        //    // Get the row Selected
        //    GridViewRow row = (GridViewRow)rbtnlisttype.NamingContainer;
        //    if (rbtnlisttype.SelectedValue == "All User")
        //    {
        //        Response.Write(rbtnlisttype.SelectedValue);
        //    }
        //    if (rbtnlisttype.SelectedValue == "Current User")
        //    {
        //        Response.Write(rbtnlisttype.SelectedValue);
        //    }
        //    if (rbtnlisttype.SelectedValue == "Order No By User")
        //    {
        //        Response.Write(rbtnlisttype.SelectedValue);
        //    }

        //}
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            string Existprice = "";
            string Existpriceqty = "";

            double subtotal = 0.0;
            try
            {
                foreach (GridViewRow gr in GridView1.Rows)
                {
                    string productid = ((TextBox)gr.FindControl("txtproductid") as TextBox).Text;
                    string price = ((TextBox)gr.FindControl("txtprice") as TextBox).Text;
                    string userid = ((TextBox)gr.FindControl("txtuserid") as TextBox).Text;
                    string quantity = ((Label)gr.FindControl("lblquantity") as Label).Text;
                    //5 oct change
                    string productprice = ((TextBox)gr.FindControl("txtproductdprice") as TextBox).Text;


                    TextBox txtprice = (TextBox)gr.FindControl("txtprice");

                    RadioButtonList rbtnlisttype = (RadioButtonList)gr.FindControl("rbtnlisttype");


                    parameters.Clear();
                    parameters.Add("@productid", Conversion.Val(productid));
                    parameters.Add("@price", Conversion.Val(price));

                    parameters.Add("@productprice", Conversion.Val(productprice));


                    parameters.Add("@userid", Convert.ToString(userid));
                    parameters.Add("@quantity", Conversion.Val(quantity));
                    parameters.Add("@orderno", Convert.ToString(Request.QueryString["orderno"]));
                    //clsm.ExecuteQry_Parameter("update cart set price=@price,enqirystatus=1 where orderid=@orderid and userid=@userid ", parameters);

                    if (rbtnlisttype.SelectedItem != null)
                    {
                        if (rbtnlisttype.SelectedItem.Text == "All User")
                        {
                            clsm.ExecuteQry_Parameter("update Product set Prodprice=@productprice where  Prodid=@productid", parameters);
                            Existprice = Convert.ToString(clsm.SendValue_Parameter("select Prodprice from Product where Prodid=@productid", parameters));

                            clsm.ExecuteQry_Parameter("update order_details set price=" + Conversion.Val(Existprice) + " where orderno=@orderno and productid=@productid and quantity=@quantity", parameters);



                            Existpriceqty = Convert.ToString(clsm.SendValue_Parameter("select price from order_details where orderno=@orderno  and productid=@productid and quantity=@quantity", parameters));

                            int totalprice = Convert.ToInt32(Existpriceqty) * Convert.ToInt32(quantity);
                            txtprice.Text = Convert.ToInt32(totalprice).ToString();
                            clsm.ExecuteQry_Parameter("update order_details set subtotal=" + Conversion.Val(txtprice.Text) + " where orderno=@orderno and productid=@productid and quantity=@quantity", parameters);

                        }
                        else if (rbtnlisttype.SelectedItem.Text == "Current User" || rbtnlisttype.SelectedItem.Text == "Order No By User")
                        {
                            Existprice = Convert.ToString(clsm.SendValue_Parameter("select isnull(price,0) from user_product_price where userid=@userid and Prodid=@productid and quantity=@quantity", parameters));

                            if ((Conversion.Val(Existprice) > 0))
                            {
                                clsm.ExecuteQry_Parameter("update user_product_price set price=@productprice where  Prodid=@productid and userid=@userid and quantity=@quantity", parameters);

                            }
                            else if ((Conversion.Val(productprice) != 0) && ((Convert.ToString(Existprice) == "")))
                            {
                                clsm.ExecuteQry_Parameter("insert into  user_product_price ( price,Prodid,quantity,userid) values (@productprice,@productid,@quantity,@userid)", parameters);

                            }

                            Existprice = Convert.ToString(clsm.SendValue_Parameter("select isnull(price,0) from user_product_price where userid=@userid and Prodid=@productid and quantity=@quantity", parameters));

                            clsm.ExecuteQry_Parameter("update order_details set price=" + Conversion.Val(Existprice) + " where orderno=@orderno and productid=@productid and quantity=@quantity", parameters);

                            Existpriceqty = Convert.ToString(clsm.SendValue_Parameter("select price from order_details where orderno=@orderno  and productid=@productid and quantity=@quantity", parameters));

                            txtprice.Text = Existpriceqty;
                            clsm.ExecuteQry_Parameter("update order_details set subtotal=" + Conversion.Val(txtprice.Text) + " where orderno=@orderno and productid=@productid and quantity=@quantity", parameters);

                        }
                    }

                    //if (Conversion.Val(price) == 0)
                    //{
                    //    Quotestatus = false;
                    //}
                    if (Conversion.Val(productprice) == 0 || Convert.ToString(productprice) == "")
                    {
                        Quotestatus = false;
                    }

                    subtotal += Convert.ToDouble(txtprice.Text);
                }
                if (Quotestatus == true)
                {
                    parameters.Clear();
                    parameters.Add("@orderno", Convert.ToString(Request.QueryString["orderno"]));

                    parameters.Add("@grandtotal", Conversion.Val(subtotal));
                    parameters.Add("@totalamount", Conversion.Val(subtotal));
                    parameters.Add("@subtotalamount", Conversion.Val(subtotal));

                    clsm.ExecuteQry_Parameter("update order_history set enquirystatus='Quote Received', grandtotal=@grandtotal,totalamount=@totalamount, subtotalamount=@subtotalamount where orderno=@orderno", parameters);

                    //SendPDF();
                    MailingPDF();
                    Mailinguser();

                }
                else
                {
                    parameters.Clear();
                    parameters.Add("@orderno", Convert.ToString(Request.QueryString["orderno"]));
                    parameters.Add("@grandtotal", Conversion.Val(subtotal));
                    parameters.Add("@totalamount", Conversion.Val(subtotal));
                    parameters.Add("@subtotalamount", Conversion.Val(subtotal));

                    //clsm.ExecuteQry_Parameter("update order_history set enquirystatus='Quote In-Process',subtotalamount=@subtotalamount where orderno=@orderno", parameters);
                    clsm.ExecuteQry_Parameter("update order_history set enquirystatus='Quote In Process', grandtotal=@grandtotal,totalamount=@totalamount,subtotalamount=@subtotalamount where orderno=@orderno", parameters);
                }
                Filldetails();
                trsuccess.Visible = true;
                lblsuccess.Text = "Record(s) updated successfully.";
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {

        }

        private void Mailinguser()
        {
            try
            {
                string link = (ConfigurationManager.AppSettings["path"].ToString());

                DataSet dsdetail = new DataSet();
                dsdetail = clsm.sendDataset("select * from order_history where orderno='" + Convert.ToString(Request.QueryString["orderno"]) + "'", true);


                string mailmsgtest;
                mailmsgtest = "<html><body> <table cellpadding=\'3\' align=\'left\' cellspacing=\'1\' width =\'450px\'>";
                mailmsgtest += "<tr><td colspan='2'> Dear " + dsdetail.Tables[0].Rows[0]["name"].ToString() + ", </td><td colspan=5>Order Placed on <strong> " + ((DateTime)dsdetail.Tables[0].Rows[0]["trdate"]).ToString("d MMM yyyy") + "</strong></td> </tr>";

                mailmsgtest += "<tr><td colspan='5'>Based on your request, your order <strong> " + dsdetail.Tables[0].Rows[0]["orderno"].ToString() + "</strong>" + " with status <b>" + dsdetail.Tables[0].Rows[0]["enquirystatus"].ToString() + "</b> for the below listed item has been successfully submitted. Now You can Make Payment. </td></tr><br />";
                mailmsgtest += "<tr><td colspan='3'><b>The prices of your ordered items has been updated. Complete your order now. </b></td></tr><br /> ";

                DataSet ds = new DataSet();
                ds = clsm.sendDataset("select * from order_details where  orderno='" + Convert.ToString(Request.QueryString["orderno"]) + "'", true);
                int i = 0;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
                    {
                        mailmsgtest += "<tr Style='border-bottom:1px solid #ccc;'><td>" + ds.Tables[0].Rows[i]["productname"].ToString() + "</td> Qty<td>" + "(" + ds.Tables[0].Rows[i]["quantity"].ToString() + ")" + "</td><td>" + "$" + ds.Tables[0].Rows[i]["subtotal"].ToString() + "</td></tr>";
                    }
                }
                //  mailmsgtest += "<tr><td Style='border-bottom:1px solid #ccc;'></td></tr>";
                mailmsgtest += "<tr><td></td><td colspan='4'>Grand Total :</td>  <td colspan=2>" + "$" + dsdetail.Tables[0].Rows[0]["grandtotal"].ToString() + "</td></tr>";
                //  mailmsgtest += "<tr><td></td><td colspan=4> <b>Amount to be Paid : </b></td>  <td colspan=1><b>" + "$" + dsdetail.Tables[0].Rows[0]["grandtotal"].ToString() + "</b></td></tr><br/>";

                mailmsgtest += "<tr><td colspan='2'>We thank you for choosing Turbo Control Solutions.</td></tr> ";

                mailmsgtest += "<tr><td colspan='2'><a href=" + (link + ">Keep Shopping! </a><br/><br/></td></tr>");

                mailmsgtest += "<tr><td colspan='2'><b></b></td></tr> <br />";

                mailmsgtest += "<tr><td colspan='2'>Best Regards</td></tr> ";
                mailmsgtest += "<tr><td colspan='2'>Turbo Control Solutions Inc.</td></tr> ";
                mailmsgtest += "<tr><td colspan='2'>63 Rue De Calais, Kirkland, Quebec, Canada</td></tr> ";

                mailmsgtest += "<tr><td colspan='2'><b>Mobile:</b>+1 514 430 2912</td></tr> ";

                mailmsgtest += "<tr><td colspan='2'><b>Emails:</b>General@tcssb.com</td></tr> ";


                mailmsgtest += "<tr><td colspan='2'><b>Visit: </b> " + link + "</td></tr> <br />";
                mailmsgtest += "</table></body></html>";



                MailMessage oMessage = new MailMessage();
                oMessage.Body = mailmsgtest;
                oMessage.IsBodyHtml = true;
                oMessage.Subject = "TCS – Price updated for your order!";
                oMessage.From = new MailAddress(ConfigurationManager.AppSettings["authmail"].ToString());
                oMessage.To.Add(new MailAddress(Convert.ToString(lblemail.Text.Trim())));
                oMessage.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["mailserver"]);
                client.Send(oMessage);
                client.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;


                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = ConfigurationManager.AppSettings["mailserver"];
                //smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["mail"].ToString(), ConfigurationManager.AppSettings["password"]);
                //MailMessage mail = new MailMessage();
                //mail.From = new MailAddress(ConfigurationManager.AppSettings["authmail"].ToString());
                //mail.To.Add(new MailAddress(Convert.ToString(lblemail.Text.Trim())));
                //mail.Subject = "TCS – Price updated for your order!";
                //mail.Body = mailmsgtest;
                //mail.IsBodyHtml = true;
                //smtp.Send(mail);

            }
            catch (Exception ex)
            {
            }

        }


        public void SendPDF()
        {
            string invoiceno = Convert.ToString(clsm.SendValue("select invoiceno from order_history where orderno='" + Convert.ToString(Request.QueryString["orderno"]) + "'"));
            ViewState["InvoiceNo"] = invoiceno;
            invoiceno = invoiceno + ".pdf";

            ViewState["InvoicePDF"] = invoiceno;
            Document pdfDocument = null;
            pdfDocument = new Document();

            pdfDocument.LicenseKey = "B4mYiJubiJiInIaYiJuZhpmahpGRkZE=";
            PdfPageSize pdfPageSize__1 = PdfPageSize.A4;
            EvoPdf.Margins pdfPageMargins = new EvoPdf.Margins(0, 0, 20, 0);

            PdfPage firstPdfPage = pdfDocument.AddPage(pdfPageSize__1, pdfPageMargins, 0);

            try
            {
                string oidnew = clsm.Encrypt(Convert.ToString(Request.QueryString["orderno"]), "#1234%23");
                string urlToConvert = String.Empty;

                urlToConvert = (Convert.ToString(ConfigurationManager.AppSettings["invoicepage"] + "?orderno=" + Convert.ToString(Request.QueryString["orderno"]) + ""));
                HtmlToPdfElement htmlToPdfElement = new HtmlToPdfElement(urlToConvert);

                firstPdfPage.AddElement(htmlToPdfElement);
                byte[] outPdfBuffer = pdfDocument.Save();
                string filename = invoiceno;

                FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("\\Uploads\\" + invoiceno)));
                if (F1.Exists)
                {
                    F1.Delete();
                }
                string fileNameWitPath = (Convert.ToString((HttpContext.Current.Request.ServerVariables["Appl_Physical_Path"] + "/Uploads/File/")) + filename);

                FileStream fs;
                fs = new FileStream(fileNameWitPath, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                byte[] data = outPdfBuffer;
                bw.Write(data);
                bw.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                pdfDocument.Close();
            }
        }

        public void MailingPDF()
        {
            string invoiceno = Convert.ToString(clsm.SendValue("select invoiceno from order_history where orderno='" + Convert.ToString(Request.QueryString["orderno"]) + "'"));
            ViewState["InvoiceNo"] = invoiceno;

            DataSet dsdetail = new DataSet();
            dsdetail = clsm.sendDataset("select * from order_history where orderno='" + Convert.ToString(Request.QueryString["orderno"]) + "'", true);

            WebRequest request;
            request = WebRequest.Create(ConfigurationManager.AppSettings["invoicepage"] + "?orderno=" + Convert.ToString(Request.QueryString["orderno"] + ""));

            WebResponse responsenew = request.GetResponse();
            StreamReader reader = new StreamReader(responsenew.GetResponseStream());
            string html = reader.ReadToEnd();

            MailMessage oMessage = new MailMessage();
            oMessage.Body = html;
            oMessage.IsBodyHtml = true;
            oMessage.Subject = "TCS Invoice -" + ViewState["InvoiceNo"].ToString() + "";
            oMessage.From = new MailAddress(ConfigurationManager.AppSettings["authmail"].ToString());
            oMessage.To.Add(new MailAddress(dsdetail.Tables[0].Rows[0]["email"].ToString()));

            //if (ViewState["InvoicePDF"] != "")
            //{
            //    oMessage.Attachments.Add(new Attachment(Server.MapPath("/Uploads/File/" + ViewState["InvoicePDF"])));
            //}

            oMessage.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["mailserver"]);
            client.Send(oMessage);
            client.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
        }
    }
}