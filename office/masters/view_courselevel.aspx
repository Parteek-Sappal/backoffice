<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="view_courselevel.aspx.cs" Inherits="backoffice.office.masters.view_courselevel" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" src="/fancybox/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />

        
     <script type="text/javascript">
         $(document).ready(function () {
             $(".toptxtseo").fancybox({
                 'width': '80%',
                 'height': '80%',
                 'autoScale': true,
                 'scrolling': true,
                 'transitionIn': 'elastic',
                 'transitionOut': 'elastic',
                 'type': 'iframe'
             });
         });
     </script>


  <h2> View/Edit Course Level</h2>
<div class="content-panel">
<table id="TABLE1" cellpadding="2" cellspacing="0" width="100%">
        
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
            <td align="center" colspan="2" height="10">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="Horizontal"
                    HorizontalAlign="Center" Width="100%" AllowPaging="true" PageSize="50" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                    <HeaderStyle HorizontalAlign="Left" />
                    <RowStyle HorizontalAlign="Left" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                            <ItemTemplate>
                              <%# ((GridViewRow)Container).DataItemIndex + 1%>.
                            </ItemTemplate>
                        </asp:TemplateField>                                          

                        <asp:TemplateField HeaderText="Course Level Name" ItemStyle-Width="15%">
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="center" />
                            <ItemTemplate>
                                <%# Server.HtmlDecode(Eval("levelname").ToString())%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="displayorder" HeaderText="Display Order">
                            <HeaderStyle HorizontalAlign="center" Width="10%" />
                            <ItemStyle HorizontalAlign="center" VerticalAlign="top" Width="10%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Publish">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status") %>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkstatus" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("levelid")) %>'
                                    CommandName="lnkstatus"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="SEO"  >
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                          <a class="toptxtseo" href='courselevelseo.aspx?levelid=<%#(Eval("levelid"))%>'>
                                    <img src="../assets/Preview_24x24.png" border="0"></a>
                       
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("levelid")) %>'
                                    CommandName="redit" ImageUrl="~/backoffice/assets/edit.png" ToolTip="Click to Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle HorizontalAlign="Right" />
                    <PagerStyle HorizontalAlign="Right" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
