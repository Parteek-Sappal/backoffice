<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="viewservice.aspx.cs" Inherits="backoffice.office.Services.viewservice" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" src="/fancybox/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />

    <script type="text/javascript">
        $(document).ready(function () {
            $(".various").fancybox({
                'width': '60%',
                'height': '60%',
                'autoScale': true,
                'scrolling': true,
                'transitionIn': 'elastic',
                'transitionOut': 'elastic',
                'type': 'iframe'
            });
        });
    </script>


<h2>  View/Edit Services</h2>
<div class="content-panel">
<table id="TABLE1" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td class="head1" style="width: 29%">
              
            </td>
            <td align="right" style="width: 80%">
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
            <td align="center" colspan="2">
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch" GroupingText="Search"
                    Width="80%">
                    <table id="Table3" border="0" cellpadding="2" cellspacing="0" class="panelbg" width="100%">
                        <tr>
                            <td align="left" colspan="4" height="5">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Service Name
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="box"></asp:TextBox>
                            </td>
                            <td align="right">
                                Service Type
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="stypeid" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnbg" OnClick="btnSearch_Click1" />
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
        <tr>
            <td align="center" colspan="2" height="10">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="Horizontal"
                    HorizontalAlign="Center" Width="100%" AllowPaging="true" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                    <HeaderStyle HorizontalAlign="Left" />
                    <RowStyle HorizontalAlign="Left" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                     
                         <asp:TemplateField HeaderText="Service Name" ItemStyle-Width="25%">
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="center" />
                            <ItemTemplate>
                                <%#Eval("servicename")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Service Type" ItemStyle-Width="25%">
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="center" />
                            <ItemTemplate>
                                <%#Eval("stype")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="displayorder" HeaderText="Display Order">
                            <HeaderStyle HorizontalAlign="center" Width="2%" />
                            <ItemStyle HorizontalAlign="center" VerticalAlign="top" Width="2%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Map Project" Visible="false">
                                <ItemStyle Width="10%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnevents" runat="server" Visible="false" CausesValidation="false"
                                        CommandArgument='<%#Eval("serviceid") %>'><img border="0" src="../images/view.gif" alt="" /></asp:LinkButton>
                                    <div runat="server" id="divevents" visible="true" >
                                        <a class="various" style="color: Black" href='mapproject.aspx?serviceid=<%#Eval("serviceid") %>'>
                                            Map Projects</a></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Status">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                            <ItemTemplate>
                              <asp:TextBox ID="txtstatus" runat="server" Text='<%# Eval("status") %>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkstatus" runat="server" CausesValidation="false" CommandArgument='<%#Eval("serviceid")%>'
                                    CommandName="lnkstatus"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Show on home">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                            <ItemTemplate>
                              <asp:TextBox ID="txtshowonhome" runat="server" Text='<%# Eval("showonhome") %>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkshowonhome" runat="server" CausesValidation="false" CommandArgument='<%#Eval("serviceid")%>'
                                    CommandName="lnkshowonhome"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("serviceid")%>'
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
