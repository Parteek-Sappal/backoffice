<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="backoffice.office.user.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
  <link href="../theme/bootstrap.min.css" rel="stylesheet" type="text/css" />
  <script src="../theme/jquery-3.3.1.slim.min.js" type="text/javascript"></script>
  <script src="../theme/bootstrap.min.js" type="text/javascript"></script>
  <link href="../theme/dynamic.css" rel="stylesheet" type="text/css" />

  <h2>Welcome To Okinawa - Admin Panel</h2>
<div class="content-panel">
   <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td>&nbsp;
                
            </td>
        </tr>
        <tr>
            <td height="35" colspan="2">&nbsp;
                </td>
        </tr>
    </table>
    
     <ul class="ulbackoffice" runat="server" visible="true" id="divdashboard">
     <li>
            <a href="/backoffice/others/viewenquiry.aspx">
                <div class="border-colm">
                    <span>
                        <img src="../assets/enquiry-icon.png" alt="Contact Us" /></span><h2>
                            Contact Us(<asp:Literal ID="litenquiries" Text="0" runat="server"></asp:Literal>)</h2>
                </div>
                </a>
            </li>


            <li><a href="/backoffice/others/productenquiry.aspx">
                <div class="border-colm">
                    <span>
                        <img src="../assets/customer.png" alt="Posted Applications" /></span><h2>
                            Product Enquiry(<asp:Literal ID="litpostapp"  Text="0"  runat="server"></asp:Literal>)</h2>
                </div>
            </a></li>
            
            <li>
            <a href="/backoffice/others/subscriber.aspx">
                <div class="border-colm">
                    <span>
                        <img src="../assets/enquiry-icon1.png" alt="Subscribers" /></span><h2>                            
                            Subscribers(<asp:Literal ID="litsubscribers"  Text="0"  runat="server"></asp:Literal>)</h2>
                </div>
                </a>
            </li>            
        </ul> 
    </div>
</asp:Content>
