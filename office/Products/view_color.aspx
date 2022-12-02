<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="view_color.aspx.cs" Inherits="backoffice.office.Products.view_color" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="TABLE1" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td class="head1" style="width: 20%">
                View/Edit Color
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
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
       
        <tr>
            <td align="center" colspan="2">
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch" GroupingText="Search"
                    Width="80%">
                    <table id="Table3" border="0" cellpadding="2" cellspacing="0" class="panelbg" width="60%">
                        <tr>
                            <td align="left" colspan="4" height="5">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Title
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="box"></asp:TextBox>
                            </td>
                            <td align="left">
                               &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnbg" OnClick="btnSearch_Click1" />
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
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="50" Width="100%"
                    AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" 
                    OnRowCommand="GridView1_RowCommand1" 
                    onpageindexchanging="GridView1_PageIndexChanging1">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center"  />
                            <ItemTemplate>
                                <%--<%# ((GridViewRow)Container).RowIndex + 1 %>--%>
                                <%#Container.DataItemIndex+1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Color Title">
                            <ItemTemplate>
                                <%# Eval("ColorTitle")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center"  />
                        </asp:TemplateField>

                       
                      

                        <asp:TemplateField HeaderText="Color" >
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center"  Width="5%" />
                            <ItemTemplate>
                                <asp:Label ID="lblcolor" runat="server" Text='<%#Eval("colorcode")%>' Visible="false"></asp:Label>
                                <asp:TextBox ID="txtcolor" Width="30" CssClass="txtbox" runat="server" BorderStyle="None"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Image" Visible="false">
                            <ItemStyle Width="8%" />
                            <ItemTemplate>
                                
                                <asp:Label ID="lblsmallimg" runat="server" Text='<%#Eval("UploadImage")%>' Visible="false"></asp:Label>
                                
                                <asp:LinkButton ID="downbtn" runat="server" Visible="false" CausesValidation="false" CommandArgument='<%# Eval("colorid") %>'
                                    CommandName="downbtn"></asp:LinkButton>
                                    <asp:Image ID="imgDown" runat="server" width="50" Height="50" Visible="false"  />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Publish">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status") %>' Visible="false"></asp:Label>
                                <asp:ImageButton ID="lnkstatus" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%# Eval("colorid") %>' CommandName="status"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Show on home" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center"  />
                            <ItemTemplate>
                                <asp:Label ID="lblshowonhome" runat="server" Text='<%#Eval("showonhome") %>' Visible="false"></asp:Label>
                                <asp:ImageButton ID="lnkshowonhome" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%# Eval("colorid") %>' CommandName="lnkshowonhome"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="Displayorder" HeaderText="DisplayOrder" Visible="true">
                            <HeaderStyle HorizontalAlign="Center" Width="8%" />
                            <ItemStyle HorizontalAlign="Center"  Width="8%"/>
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Edit">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%# Eval("colorid") %>'
                                    CommandName="edit" ImageUrl="~/office/assets/edit.png" ToolTip="Click to Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center"  />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%# Eval("colorid") %>'
                                    CommandName="del" ImageUrl="~/office/assets/Remove_24x24.png" />
                                <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to delete this?"
                                    TargetControlID="btndel">
                                </ajaxToolkit:ConfirmButtonExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        
                    </Columns>
                    <SelectedRowStyle HorizontalAlign="Right" />
                    <PagerStyle HorizontalAlign="Right" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        
    </table>
</asp:Content>
