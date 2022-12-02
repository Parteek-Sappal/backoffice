<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productimage.aspx.cs" Inherits="backoffice.office.Products.productimage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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
                                Add/Edit Product Images
                            </td>
                            <td align="right">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="h_dot_line">
                    &nbsp;
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
                <td align="left" colspan="2" height="10">
                    &nbsp;
                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <ajaxToolkit:AjaxFileUpload Width="400px" ID="AjaxFileUpload1" runat="server" ThrobberID="myThrobber"
                                MaximumNumberOFiles="10" OnUploadComplete="AjaxFileUpload1_UploadComplete"></ajaxToolkit:AjaxFileUpload>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <td>
                        &nbsp;
                    </td>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td valign="middle" width="30%" align="left">
                                <asp:Button ID="btnpublish" runat="server" Text="Show" CssClass="btnbg" OnClick="btnpublish_Click" />
                                <asp:Button ID="btnEdit" runat="server" Text="Update" CssClass="btnbg" OnClick="btnEdit_Click" />
                                <asp:Button ID="btncolorimg" runat="server" Text="Mark Color Image" CssClass="btnbg" OnClick="btncolorimg_Click" Visible="false" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btnbg" OnClick="btnDelete_Click" />
                            </td>
                            <td>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp; &nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                                <asp:DataList ID="dtlview" runat="server" RepeatDirection="Horizontal" RepeatColumns="9">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td colspan="2" align="center">
                                                    <asp:Image ID="img" runat="server" Width="100px" Height="100px" ImageUrl='<%# Bind("productimage", "~/uploads/ProductsImage/{0}")%>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblphotoid" runat="server" Visible="false" Text='<%#Eval("imageid") %>'></asp:Label>
                                                    <asp:Label ID="lbluploadphoto" runat="server" Visible="false" Text='<%#Eval("productimage") %>'></asp:Label>
                                                    <asp:Label ID="lblcolorimage" runat="server" Visible="false" Text='<%#Eval("colorimage") %>'></asp:Label>
                                                    <asp:Label ID="lbllargeimg" runat="server" Visible="false" Text='<%#Eval("largeimage") %>'></asp:Label>
                                                    <asp:CheckBox ID="chk" runat="server" />
                                                </td>
                                               
                                            </tr>
                                            <tr>
                                                <td>
                                                    Title:
                                                    <asp:TextBox ID="txtphototitle" runat="server" Text='<%#Eval("imagetitle") %>' Width="100px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <tr>
                                                <td>
                                                    Displayorder:
                                                    <asp:TextBox ID="txtorder" runat="server" Text='<%#Eval("displayorder") %>' Width="100px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" width="15%">
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
