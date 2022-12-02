<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="assigneprice.aspx.cs" Inherits="backoffice.office.Product_Price.assigneprice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <script type="text/javascript">
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46) {
                return false;
            }
            return true;
        }
    </script>
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
            <tr>
                <td align="left" colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td class="head1">
                                Assign Product Price
                            </td>
                            <td align="right">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="100" class="h_dot_line">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="headingtext" colspan="4">
                    <div class="error" align="left" id="trerror" runat="server">
                        &nbsp;&nbsp;
                        <asp:Label ID="lblerror" runat="server"></asp:Label>
                    </div>
                    <div class="success" align="left" id="trsuccess" runat="server">
                        &nbsp;&nbsp;
                        <asp:Label ID="lblsuccess" runat="server"></asp:Label>
                    </div>
                    <div class="notice" align="left" id="trnotice" runat="server">
                        &nbsp;&nbsp;
                        <asp:Label ID="lblnotice" runat="server"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr class="table-padding">
                <td valign="top" class="padtdRight20">
                    <table border='0' cellpadding='4' cellspacing='0' width="100%">
                        <tr>
                            <td colspan='2' class='personalDetails'>
                                <strong>Order No #:
                                    <asp:Label ID="lblorder" runat="server"></asp:Label></strong>
                            </td>
                        </tr>
                        <tr>
                            <td valign='top'>
                                Quote Status
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td valign='top'>
                                <asp:Label ID="lblstatus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign='top'>
                                Order Date
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td valign='top'>
                                <asp:Label ID="lbldate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trdd" runat="server" visible="false">
                            <td valign="top">
                                Dispatch Date
                            </td>
                            <td valign="top">
                                :
                            </td>
                            <td valign="top">
                                <asp:Label ID="lblddate" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <table border='0' align="right" cellpadding='4' cellspacing='0' class='tblBorder'
                        width="100%">
                        <tr>
                            <td colspan='2' class='personalDetails'>
                                <strong>Account Information&nbsp;</strong>
                            </td>
                        </tr>
                        <tr>
                            <td valign='top'>
                                Customer Name
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td valign='top'>
                                <asp:Label ID="lblname" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign='top'>
                                Email Address
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td valign='top'>
                                <asp:Label ID="lblemail" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign='top'>
                                Phone
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td valign='top'>
                                <asp:Label ID="lblphone" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr valign="top" id="traddress" runat="server" visible="true">
                <td width='51%' valign='top' class='padtdRight20'>
                    <table width='99%' border='0' cellpadding='4' cellspacing='0'>
                        <tr>
                            <td class='personalDetails'>
                                <strong>Address</strong>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%">
                                Address :
                            </td>
                           
                            <td valign='top'>
                                <asp:Label ID="lbladdress" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr valign="top" style="display: none">
                <td width='51%' valign='top' class='padtdRight20'>
                    <table width='99%' border='0' cellpadding='4' cellspacing='0'>
                        <tr>
                            <td colspan='3' class='personalDetails'>
                                <strong>Address</strong>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td width='43%' valign='top'>
                                Company Name
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td width='57%' valign='top'>
                                <asp:Label ID="billcompname" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td valign='top'>
                                Name
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td valign='top'>
                                <asp:Label ID="bilname" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign='top'>
                                Address
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td valign='top'>
                                <asp:Label ID="billadd" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign='top'>
                                State
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td valign='top'>
                                <asp:Label ID="lblstate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign='top'>
                                City
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td valign='top'>
                                <asp:Label ID="billcity" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td valign='top'>
                                State/Province
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td valign='top'>
                                <asp:Label ID="billstate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td valign='top'>
                                Country
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td valign='top'>
                                <asp:Label ID="billcountry" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td valign='top'>
                                Zip/Postal Code
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td valign='top'>
                                <asp:Label ID="billzip" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td valign='top'>
                                Phone
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td valign='top'>
                                <asp:Label ID="billphone" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                </td>
                <td>
                    <table width='99%' border='0' align="right" cellpadding='4' cellspacing='0' class='tblBorder'
                        style="display: none">
                        <tr>
                            <td colspan='3' class='personalDetails'>
                                <strong>Shipping Address</strong>
                            </td>
                        </tr>
                        <tr>
                            <td width='43%' valign='top'>
                                Company Name
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td width='57%' valign='top'>
                                <asp:Label ID="shipcompname" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign='top'>
                                Name
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td valign='top'>
                                <asp:Label ID="shipname" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign='top'>
                                Street Address
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td valign='top'>
                                <asp:Label ID="shipadd" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign='top'>
                                City
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td valign='top'>
                                <asp:Label ID="shipcity" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign='top'>
                                State/Province
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td valign='top'>
                                <asp:Label ID="shipstate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign='top'>
                                Country
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td valign='top'>
                                <asp:Label ID="shipcountry" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign='top'>
                                Zip/Postal Code
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td valign='top'>
                                <asp:Label ID="shipzip" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign='top'>
                                Phone
                            </td>
                            <td valign='top'>
                                :
                            </td>
                            <td valign='top'>
                                <asp:Label ID="shipphone" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width='51%' valign='top' class='padtdRight20'>
                    <table width='99%' border='0' cellpadding='4' cellspacing='0'>
                        <tr>
                            <td colspan='4' class='personalDetails'>
                                <b>Payment Information</b>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%">
                                Payment Amount :
                            </td>
                            <td class='inr'>
                                $<asp:Label ID="lblamount" runat="server"></asp:Label>
                            </td>
                            <td width="20%">
                                Transaction Status :
                            </td>
                            <td class='inr'>
                                <asp:Label ID="TranStatus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Merchant Reference No :
                            </td>
                            <td class='inr'>
                                <asp:Label ID="MerchantrefNo" runat="server"></asp:Label>
                            </td>
                            <td>
                                Transaction PaymentID :
                            </td>
                            <td class='inr'>
                                <asp:Label ID="PaymentId" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Transaction Reference No. :
                            </td>
                            <td class='inr'>
                                <asp:Label ID="TranRefNo" runat="server"></asp:Label>
                            </td>
                            <td>
                                Transaction Id :
                            </td>
                            <td class='inr'>
                                <asp:Label ID="Tranid" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Error Description :
                            </td>
                            <td class='inr'>
                                <asp:Label ID="TranError" runat="server"></asp:Label>
                            </td>
                            <td>
                            </td>
                            <td class='inr'>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                </td>
                <td valign="top">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="100">
                    <asp:GridView ID="GridView1" runat="server" Width="100%" PageSize="50" AllowPaging="True"
                        AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging"
                        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemStyle HorizontalAlign="center" Width="5%" />
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1 %>
                                    .
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Product Code" HeaderStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="left" Width="7%" />
                            <ItemTemplate>
                                <%#Eval("Prodcode")%>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Order No." HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="left" Width="7%" />
                                <ItemTemplate>
                                    <%#Eval("orderno")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="left" Width="7%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblproductname" runat="server" Text='<%#Eval("productname")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                             <asp:TemplateField HeaderText="Product Code" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="left" Width="7%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblproductcode" runat="server" Text='<%#Eval("Prodcode")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Quantity" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="left" Width="7%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblquantity" runat="server" Text=' <%#Eval("quantity")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Price" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="left" Width="7%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtorderid" runat="server" Text=' <%#Eval("orderid")%>' Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="txtproductid" runat="server" Text=' <%#Eval("productid")%>' Visible="false"></asp:TextBox>
                                   
                                    <%-- <asp:TextBox ID="txtprice" runat="server" Text=' <%#Eval("price")%>'></asp:TextBox>--%>
                                    <asp:TextBox ID="txtprice" runat="server" Text=' <%#Eval("subtotal")%>' onkeypress="return isNumber(event)" ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Product Price" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="left" Width="7%" />
                                <ItemTemplate>
                                    <%-- <%# string.Concat("$", " ", Eval("Prodprice")) %>--%>
                                    <asp:TextBox ID="txtproductdprice" runat="server" Text='<%#Eval("price")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                           <%-- <asp:TemplateField HeaderText="Select" HeaderStyle-HorizontalAlign="Left">
                             <ItemStyle HorizontalAlign="left" Width="7%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server"  />All User <br />
                                     <asp:CheckBox ID="CheckBox1" runat="server" /> Current User
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Select" HeaderStyle-HorizontalAlign="Left" Visible="false">
                             <ItemStyle HorizontalAlign="left" Width="10%" />
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rbtnlisttype" runat="server" BorderStyle="NotSet" >
                                            <asp:ListItem Text="All User" Value="All User"></asp:ListItem>
                                            <asp:ListItem Text="Current User" Value="Current User"></asp:ListItem>
                                            <asp:ListItem Text="Order No By User" Value="Order No By User"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Please select Type.<br />"
    ControlToValidate="rbtnlisttype" runat="server" ForeColor="Red" Display="Dynamic" />
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("userid")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Publish" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtorderno" runat="server" Visible="false" Text='<%#Eval("orderno") %>'></asp:TextBox>
                                    <asp:TextBox ID="txtuserid" runat="server" Visible="false" Text='<%#Eval("userid") %>'></asp:TextBox>                                    
                                    <asp:ImageButton ID="lnkstatus" CssClass="toptxt" runat="server" CausesValidation="false"
                                        CommandArgument='<%#Eval("orderid") %>' CommandName="lnkstatus"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td width="80%">
                    <table border='0' align="right" cellpadding='4' cellspacing='0'>
                        <tr>
                            <td colspan='4' class='personalDetails'>
                                <%--<strong>Order Total</strong>--%>
                            </td>
                        </tr>
                        <%--    <tr>
                        <td align="right">
                            <b>Shipping charges (Rs.) :</b></td>
                        <td align="left" colspan='2'>
                            <asp:Label ID="lblship" runat="server" Text="0.0"></asp:Label></td>
                    </tr>--%>
                       
                        <tr>
                            <td align="right">
                                <b>Total :</b>
                            </td>
                            <td align="left">
                                <asp:Label ID="lbltotalamount" runat="server" Text="0.0"></asp:Label>
                            </td>
                        </tr>
                       <%-- <tr>
                            <td align="right">
                                <b>Discount (Rs.) :</b>
                            </td>
                            <td align="left">
                                $<asp:Label ID="lbldiscount" runat="server" Text="0.0"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="right">
                                <b>Sub Total :</b>
                            </td>
                            <td align="left">
                                <asp:Label ID="lbltotalsubamount" runat="server" Text="0.0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>Grand Total :</strong>
                            </td>
                            <%--  <td align="center">
                            :</td>--%>
                            <td align="left" nowrap='nowrap' class='inr'>
                                <strong><asp:Label ID="lblgrand" runat="server"></asp:Label></strong>
                            </td>
                            <td align="right" width="20%">
                                <asp:Button ID="btnupdate" CssClass="btnbg" runat="server" Text="Submit" OnClick="btnupdate_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <%-- <td align="right" width="10%">
                </td>--%>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
