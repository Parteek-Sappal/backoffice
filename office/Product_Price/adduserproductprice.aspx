<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="adduserproductprice.aspx.cs" Inherits="backoffice.office.Product_Price.adduserproductprice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="2" class="head1">
                Add User Wise Product Price Lists
            </td>
        </tr>
        <tr>
            <td colspan="2" class="h_dot_line">
            </td>
        </tr>
        <tr>
            <td class="headingtext" colspan="2">
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
        <tr>
            <td align="right" colspan="2">
                Fields with <span class="star">*</span>are mandatory
                <asp:TextBox ID="id" runat="server" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" height="10px">
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
               
            </td>
        </tr>
        <tr>
            <td colspan="2" height="10px">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table id="Table23" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td valign="top" align="right">
                            &nbsp;User<span class="star">*</span> :&nbsp;
                        </td>
                        <td>
                            <asp:DropDownList ID="userid" runat="server" Width="200px" >
                            </asp:DropDownList>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                InitialValue="0" ControlToValidate="userid" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="15%" align="right">
                            Product : &nbsp;
                        </td>
                        <td style="height: 22px; width: 200px">
                            <asp:DropDownList ID="Prodid" Width="200px" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                    

                    <tr>
                        <td valign="top" width="15%" align="right">
                            Quantity<span class="star">*</span> : &nbsp;
                        </td>
                        <td style="height: 22px; width: 350px">
                            <asp:TextBox ID="quantity" runat="server"  Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                ControlToValidate="quantity" ErrorMessage="Required"></asp:RequiredFieldValidator>&nbsp;
                        </td>
                    </tr>

                     <tr>
                        <td valign="top" width="15%" align="right">
                            Price<span class="star">*</span> : &nbsp;
                        </td>
                        <td style="height: 22px; width: 350px">
                            <asp:TextBox ID="price" runat="server"  Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                ControlToValidate="price" ErrorMessage="Required"></asp:RequiredFieldValidator>&nbsp;
                        </td>
                    </tr>

                   <tr style="display:none">
                        <td valign="top" width="15%" align="right">
                            Sub-total<span class="star">*</span> : &nbsp;
                        </td>
                        <td style="height: 22px; width: 350px">
                            <asp:TextBox ID="subtotal" runat="server"  Width="300px"></asp:TextBox>
                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                                ControlToValidate="subtotal" ErrorMessage="Required"></asp:RequiredFieldValidator>&nbsp;--%>
                        </td>
                    </tr>

                       <tr style="display:none">
                        <td valign="top" width="15%" align="right">
                            Tax<span class="star">*</span> : &nbsp;
                        </td>
                        <td style="height: 22px; width: 350px">
                            <asp:TextBox ID="tax" runat="server"  Width="300px"></asp:TextBox>
                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                                ControlToValidate="tax" ErrorMessage="Required"></asp:RequiredFieldValidator>&nbsp;--%>
                        </td>
                    </tr>
                    <tr>
                    <td style="height: 50px;">
                </td>
                        <td>
                            <asp:Button ID="Submit" runat="server" CssClass="btnbg" OnClick="Submit_Click" Text="Submit" />
                            &nbsp;
                            <asp:Button ID="Reset" runat="server" CssClass="btnbg" OnClick="Reset_Click" Text="Cancel" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
