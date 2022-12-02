<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="viewproductsubcategory.aspx.cs" Inherits="backoffice.office.Products.viewproductsubcategory" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                <tr>
                    <td align="left" colspan="2">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td class="head1">
                                    View / Edit Sub Category
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
                                        <asp:DropDownList ID="pcatid" runat="server" Width="200px">
                                        </asp:DropDownList>
                                    </td>

                                       <td align="right">
                                        Sub Category:
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="catname" runat="server" Width="197px"></asp:TextBox>
                                    </td>
                                   
                                </tr>
                              
                                <tr>
                                    <td align="left" colspan="4" height="10">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4">
                                        &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnbg" OnClick="btnSearch_Click"  CausesValidation="false"/>
                                       
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
                    OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>

                            <asp:TemplateField HeaderText="Category">
                            <HeaderStyle HorizontalAlign="Left" Width="25%" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <%#Eval("subcategory")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Sub Category">
                            <HeaderStyle HorizontalAlign="Left" Width="25%" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <%#Eval("category")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="displayorder" HeaderText="Display Order">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Publish">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtstatus" runat="server" Text='<%# Eval("status") %>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkstatus" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%#Eval("psubcatid")%>' CommandName="status"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("psubcatid")%>'
                                    CommandName="edit" ImageUrl="~/backoffice/assets/edit.png" ToolTip="Click to Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#Eval("psubcatid")%>'
                                    CommandName="del" ImageUrl="~/backoffice/assets/Remove_24x24.png" ToolTip="Click to Delete" />
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
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
