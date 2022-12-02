<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="view-discipline.aspx.cs" Inherits="backoffice.office.masters.view_discipline" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2> View/Edit Discipline </h2>
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
                       
                   

                        <asp:TemplateField HeaderText="Discipline Name" ItemStyle-Width="15%">
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="center" />
                            <ItemTemplate>
                                <%# Server.HtmlDecode(Eval("dpname").ToString())%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="displayorder" HeaderText="Display Order">
                            <HeaderStyle HorizontalAlign="center" Width="10%" />
                            <ItemStyle HorizontalAlign="center" VerticalAlign="top" Width="10%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Status">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status") %>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkstatus" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("dpid")) %>'
                                    CommandName="lnkstatus"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("dpid")) %>'
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
