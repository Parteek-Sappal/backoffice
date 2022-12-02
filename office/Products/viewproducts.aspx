
<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="viewproducts.aspx.cs" Inherits="backoffice.office.Products.viewproducts" Theme="backtheme" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <input type="hidden" value="<%=appno%>" name="appno" id="appno">
    <script type="text/javascript" src="/fancybox/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <script type="text/javascript">
        $(document).ready(function () {
            var i = 0;
            var toappno = document.getElementById("appno").value;
            for (i = 1; i <= toappno; i++) {
                $("#various_" + i).fancybox({
                    'width': '90%',
                    'height': '90%',
                    'autoScale': true,
                    'scrolling': true,
                    'transitionIn': 'elastic',
                    'transitionOut': 'elastic',
                    'type': 'iframe'
                });
            }
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var i = 0;
            var toappno = document.getElementById("appno").value;
            for (i = 1; i <= toappno; i++) {
                $("#variouss_" + i).fancybox({
                    'width': '90%',
                    'height': '90%',
                    'autoScale': true,
                    'scrolling': true,
                    'transitionIn': 'elastic',
                    'transitionOut': 'elastic',
                    'type': 'iframe'
                });
            }
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var i = 0;
            var toappno = document.getElementById("appno").value;
            for (i = 1; i <= toappno; i++) {
                $("#variousss_" + i).fancybox({
                    'width': '90%',
                    'height': '90%',
                    'autoScale': true,
                    'scrolling': true,
                    'transitionIn': 'elastic',
                    'transitionOut': 'elastic',
                    'type': 'iframe'
                });
            }
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var i = 0;
            var toappno = document.getElementById("appno").value;
            for (i = 1; i <= toappno; i++) {
                $("#variousss1_" + i).fancybox({
                    'width': '50%',
                    'height': '50%',
                    'autoScale': true,
                    'scrolling': true,
                    'transitionIn': 'elastic',
                    'transitionOut': 'elastic',
                    'type': 'iframe'
                });
            }
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".variousgeneral").fancybox({
                'width': '90%',
                'height': '90%',
                'autoScale': true,
                'scrolling': true,
                'transitionIn': 'elastic',
                'transitionOut': 'elastic',
                'type': 'iframe'
            });

        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var i = 0;
            var toappno = document.getElementById("appno").value;
            for (i = 1; i <= toappno; i++) {
                $("#variouserprod_" + i).fancybox({
                    'width': '90%',
                    'height': '90%',
                    'autoScale': true,
                    'scrolling': true,
                    'transitionIn': 'elastic',
                    'transitionOut': 'elastic',
                    'type': 'iframe'
                });
            }
        });
    </script>
    <%--  <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>--%>
    <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="head1">
                            View / Edit Products
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
            <td align="center" colspan="2" height="10">
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
            <td align="center" colspan="2">
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch" GroupingText="Search"
                    Width="80%" meta:resourcekey="Panel1Resource1">
                    <table id="Table3" border="0" cellpadding="2" cellspacing="0" class="panelbg" width="100%">
                        <tr>
                            <td align="left" colspan="4" height="5">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Series:
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="seriesid" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                Color:
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="colorid" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td align="right" style="display: none;">
                                Coat:
                            </td>
                            <td align="left" style="display: none;">
                                <asp:DropDownList ID="coatid" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td align="right" style="display: none;">
                                Size:
                            </td>
                            <td align="left" style="display: none;">
                                <asp:DropDownList ID="sizeid" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Product Name:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="productname" runat="server" Width="197px"></asp:TextBox>
                                <asp:DropDownList ID="psubsubcatid" runat="server" Width="200px" Visible="false">
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                Model:
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="modelid" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td align="right" style="display: none;">
                                Look:
                            </td>
                            <td align="left" style="display: none;">
                                <asp:DropDownList ID="lookid" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td align="right" style="display: none;">
                                Type:
                            </td>
                            <td align="left" style="display: none;">
                                <asp:DropDownList ID="typeid" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="display: none;">
                                Product Code:
                            </td>
                            <td align="left" style="display: none;">
                                <asp:TextBox ID="productcode" runat="server" Width="197px"></asp:TextBox>
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" Visible="false">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td align="right">
                                Product Type :
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlmobile" runat="server" Width="200px">
                                    <asp:ListItem Value="0">--Select Type--</asp:ListItem>
                                    <asp:ListItem Value="1">Mobile Show</asp:ListItem>
                                    <asp:ListItem Value="2">Website Show</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" height="10">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnbg" OnClick="btnSearch_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnexport" runat="server" Text="Export To Excel" OnClick="btnExport_Click"
                                    CssClass="btnbg" Visible="false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" height="5">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                    AllowPaging="True" PageSize="100" OnPageIndexChanging="GridView1_PageIndexChanging"
                    OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).DataItemIndex + 1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--  <asp:BoundField DataField="category" HeaderText="Category">
                                    <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemStyle HorizontalAlign="left" VerticalAlign="top" Width="10%" />
                                </asp:BoundField>--%>
                        <%-- <asp:TemplateField HeaderText="Category">
                                    <ItemStyle Width="3%" />
                                    <ItemTemplate>
                                        <%# Eval("category") %>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                        <%--<asp:TemplateField HeaderText="Sub Category">
                                    <ItemStyle Width="3%" />
                                    <ItemTemplate>
                                        <%# Eval("subcategory")%>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Product">
                            <ItemStyle Width="3%" />
                            <ItemTemplate>
                                <%# Eval("productname")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Color">
                            <ItemStyle Width="3%" />
                            <ItemTemplate>
                                <%# Eval("colortitle")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Model">
                            <ItemStyle Width="3%" />
                            <ItemTemplate>
                                <%# Eval("modelname")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Add Images">
                            <ItemStyle Width="5%" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbtnstatus" runat="server" Visible="false" CausesValidation="false"
                                    CommandArgument='<%#Eval("productid") %>'><img border="0" src="../images/view.gif" alt="" /></asp:LinkButton>
                                <a id='various_<%# ((GridViewRow)Container).RowIndex + 1 %>' class="toptxt" visible="false"
                                    href='productimage.aspx?prodid=<%#Eval("productid") %>'>Add / Edit
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Color Images" Visible="true">
                            <ItemStyle Width="10%" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbtnclrimg" runat="server" Visible="true" CausesValidation="false"
                                    CommandArgument='<%#Eval("productid") %>'><img border="0" src="../images/view.gif" alt="" /></asp:LinkButton>
                                <a id='variouss_<%# ((GridViewRow)Container).RowIndex + 1 %>' class="toptxt" visible="false"
                                    href='productcolorimg.aspx?prodid=<%#Eval("productid") %>'> Add / Edit
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Download File" Visible="false">
                            <ItemStyle Width="3%" />
                            <ItemTemplate>
                                <asp:Label ID="lbldown" runat="server" Text='<%#Eval("prospectus")%>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="downbtn" runat="server" CausesValidation="false" CommandArgument='<%#Eval("productid")%>'
                                    CommandName="downbtn">
                                    <asp:Image ID="imgDown" runat="server" BorderWidth="0" ImageUrl="~/backoffice/assets/Download_24x24.png" /></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="displayorder" HeaderText="Display Order">
                            <HeaderStyle HorizontalAlign="center" Width="3%" />
                            <ItemStyle HorizontalAlign="center" VerticalAlign="top" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Publish">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtstatus" runat="server" Text='<%# Eval("status") %>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkstatus" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%#Eval("productid")%>' CommandName="lnkstatus"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Feature" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtIsfamilyproduct" runat="server" Text='<%# Eval("featureproduct") %>'
                                    Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkIsfamilyproduct" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%#Eval("productid")%>' CommandName="lnkIsfamilyproduct"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mobile Show" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtmobileshow" runat="server" Text='<%# Eval("mobileshow") %>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkmobileshow" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%#Eval("productid")%>' CommandName="lnkmobileshow"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Show home">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtwebsiteshow" runat="server" Text='<%# Eval("websiteshow") %>'
                                    Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkwebsiteshow" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%#Eval("productid")%>' CommandName="lnkwebsiteshow"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("productid") %>'
                                    CommandName="btnedit" ImageUrl="~/office/assets/edit.png" ToolTip="Click to Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#Eval("productid")%>'
                                    CommandName="btndel" ImageUrl="~/office/assets/Remove_24x24.png" />
                                <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to delete this?"
                                    TargetControlID="btndel">
                                </ajaxToolkit:ConfirmButtonExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Detail">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <a href='index.aspx?prodid=<%#Eval("productid")%>'>
                                    <img src="../assets/Preview_24x24.png" border="0" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
