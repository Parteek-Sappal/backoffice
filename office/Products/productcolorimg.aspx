<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productcolorimg.aspx.cs" Inherits="backoffice.office.Products.productcolorimg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <script type="text/javascript" src="/fancybox/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css" media="screen" />
    <script type="text/javascript">
       $(document).ready(function () {
          
         
               $(".various1").fancybox({
                   'width': '70%',
                   'height': '70%',
                   'autoScale': true,
                   'scrolling': true,
                   'transitionIn': 'elastic',
                   'transitionOut': 'elastic',
                   'type': 'iframe'
               });
           
       });
    </script>
</head>
<body>
  <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <input type="hidden" value="<%=appno%>" name="appno" id="appno" />
    <div>
        <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
            <tr>
                <td align="left" colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td class="head1">
                                Add/Edit Product Colour Images
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
                <td align="center" colspan="3">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td valign="middle" width="30%" align="left">
                                <asp:Button ID="btnpublish" runat="server" Text="Show" CssClass="btnbg" OnClick="btnpublish_Click" />
                                <asp:Button ID="btnEdit" runat="server" Text="Update" CssClass="btnbg" OnClick="btnEdit_Click" />
                                <asp:Button ID="btnDelete" runat="server" OnClientClick="if ( !confirm('Are you sure you want to delete ?')) return false;"  Text="Delete" CssClass="btnbg"  OnClick="btnDelete_Click" />
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
                                <asp:DataList ID="dtlview" runat="server" RepeatDirection="Horizontal" RepeatColumns="4" onitemdatabound="dtlview_ItemDataBound" Width="100%" >
                                    <ItemTemplate>
                                        <table border="0">
                                            <tr>
                                                <td  align="center">
                                                   <a id='various_<%# Container.ItemIndex + 1 %>' class="toptxt" visible="false" href='upload_multiple_images.aspx?imageid=<%#Eval("colorimageid") %>'>
                                                        <asp:Image ID="img" runat="server" Width="100px" Height="100px" ImageUrl='<%# Bind("colorimage", "~/uploads/ProductsImage/{0}")%>' /></a>
                                                </td>
                                            </tr>
                                           
                                            <tr>
                                                <td  align="left">
                                                    <asp:Label ID="lblphotoid" runat="server" Visible="false" Text='<%#Eval("colorimageid") %>'></asp:Label>
                                                    <asp:Label ID="lblcolorimage" runat="server" Visible="false" Text='<%#Eval("colorimage") %>'></asp:Label>
                                                     <asp:Label ID="lblcolorname" runat="server" Visible="false" Text='<%#Eval("colorname") %>'></asp:Label>
                                                    <asp:CheckBox ID="chk" runat="server" /><br />
                                                     Title:<asp:TextBox ID="txtphototitle" runat="server" Text='<%#Eval("imagetitle") %>' Width="100px"></asp:TextBox><br />
                                                    Color:<asp:DropDownList ID="drpcolor" runat="server" Width="100px">
                                                    </asp:DropDownList><br />
                                                     Price:<asp:TextBox ID="txtprice" runat="server" placeholder="Enter Price" Text='<%#Eval("price")%>' Width="100px"></asp:TextBox>
                                                    <br /> 
                                                 <%--   <a  class="various1" visible="false"
                                    href='map-color-size.aspx?productid=<%#Eval("productid")%>&colorimageid=<%#Eval("colorimageid")%>'>Map Size</a>--%>
                                                </td>
                                              
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <ItemStyle Width="20%" />
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
