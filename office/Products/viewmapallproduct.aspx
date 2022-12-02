<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="viewmapallproduct.aspx.cs" Inherits="backoffice.office.Products.viewmapallproduct" Theme="backtheme" %>
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

       

  <%--  <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>--%>
            <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                <tr>
                    <td align="left" colspan="2">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td class="head1">
                                    View / Edit Map Product
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
                                        Category:
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="pcatid" runat="server" onselectedindexchanged="pcatid_SelectedIndexChanged" AutoPostBack="true" Width="200px">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right">
                                        Sub Category:
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="psubcatid" onselectedindexchanged="psubcatid_SelectedIndexChanged" AutoPostBack="true" runat="server" Width="200px">
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
                                        Product Name:
                                    </td>
                                    <td align="left">
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="4" height="10">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4">
                                        &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnbg" OnClick="btnSearch_Click" />
                                    
                              
                                       <asp:Button ID="btnexport" runat="server" Text="Export To Excel" OnClick="btnExport_Click"
                                    CssClass="btnbg" />
                                       
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
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).DataItemIndex + 1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:TemplateField HeaderText="Category">
                                    <ItemStyle Width="3%" />
                                    <ItemTemplate>
                                        <%# Eval("category") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sub Category">
                                    <ItemStyle Width="3%" />
                                    <ItemTemplate>
                                        <%# Eval("subcategory")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:TemplateField HeaderText="Product">
                                    <ItemStyle Width="3%" />
                                    <ItemTemplate>
                                        <%# Eval("productname")%> ( <%# Eval("productcode")%>)
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="color">
                                    <ItemStyle Width="3%" />
                                    <ItemTemplate>
                                        <%# Eval("colortitle")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Size">
                                    <ItemStyle Width="3%" />
                                    <ItemTemplate>
                                        <%# Eval("sizetitle")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Series">
                                    <ItemStyle Width="3%" />
                                    <ItemTemplate>
                                        <%# Eval("orientationtitle")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type">
                                    <ItemStyle Width="3%" />
                                    <ItemTemplate>
                                        <%# Eval("Typetitle")%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="feature">
                                    <ItemStyle Width="3%" />
                                    <ItemTemplate>
                                        <%# Eval("featuretitle")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 
                                  <asp:TemplateField HeaderText="Price">
                                    <ItemStyle Width="3%" />
                                    <ItemTemplate>
                                        <%# Eval("price")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Stock">
                                    <ItemStyle Width="3%" />
                                    <ItemTemplate>
                                        <%# Eval("stock")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ERP Code">
                                    <ItemStyle Width="3%" />
                                    <ItemTemplate>
                                        <%# Eval("erpcode")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 

                                  

                                 <asp:TemplateField HeaderText="Image" Visible="true">
                            <ItemStyle Width="4%" />
                            <ItemTemplate>
                                
                                <asp:Label ID="lblsmallimg" runat="server" Text='<%#Eval("UploadAImage")%>' Visible="false"></asp:Label>
                                
                             
                                    <asp:Image ID="imgDown" runat="server" width="50" Height="50" Visible="false"  />
                            </ItemTemplate>
                        </asp:TemplateField>
                                 


                              
                            
                                <asp:TemplateField HeaderText="Publish">
                                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status") %>' Visible="false"></asp:TextBox>
                                        <asp:ImageButton ID="lnkstatus" CssClass="toptxt" runat="server" CausesValidation="false"
                                            CommandArgument='<%#Eval("pmapid")%>' CommandName="lnkstatus"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                               


                             

                                <asp:TemplateField HeaderText="Edit">
                                    <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("pmapid") %>'
                                            CommandName="btnedit" ImageUrl="~/backoffice/assets/edit.png" ToolTip="Click to Edit" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#Eval("pmapid")%>'
                                            CommandName="btndel" ImageUrl="~/backoffice/assets/Remove_24x24.png" />
                                        <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to delete this?"
                                            TargetControlID="btndel">
                                        </ajaxToolkit:ConfirmButtonExtender>
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
