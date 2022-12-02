<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="viewregistration.aspx.cs" Inherits="backoffice.office.Registration.viewregistration" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table id="TABLE1" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td class="head1" style="width: 40%">
                View Registration</td>
            <%--<td align="right" style="width: 60%">
                <a href="adduser.aspx" class="head1">Add Customer</a>
            </td>--%>
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
                <asp:Panel ID="Panel2" runat="server" DefaultButton="btnSearch" GroupingText="Search"
                    Width="80%">
                    <table id="Table3" border="0" cellpadding="2" cellspacing="0" class="panelbg" width="100%">
                        <tr>
                            <td align="left" colspan="4" height="5">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Name :&nbsp;</td>
                            <td align="left">
                                <asp:TextBox ID="username" runat="server" Width="150"></asp:TextBox></td>
                            <td align="right">
                                Email :&nbsp;</td>
                            <td align="left">
                                <asp:TextBox ID="emailid" runat="server" Width="150"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" height="10">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                &nbsp;<asp:Button ID="btnSearch" runat="server" OnClick="btnsearch_Click" Text="Search" CssClass="btnbg" />
                                
                                 <asp:Button ID="btnexport" runat="server" OnClick="btnexport_Click" Text="Export To Excel" CssClass="btnbg" />
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
            <td align="center" colspan="2" style="height: 5px">
                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>&nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="GridView1" runat="server" PageSize="50" AllowPaging="True" Width="100%"
                  OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"  AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemStyle Width="5%" />
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1 %> .
                                .
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User Name">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" Width="10%" />
                            <ItemTemplate>
                                <%#Eval("username")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" Width="10%" />
                            <ItemTemplate>
                                <%#Eval("emailid")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="password" HeaderText="Password" Visible="false">
                            <ItemStyle HorizontalAlign="center" Width="10%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Reg. Date">
                            <ItemStyle Width="10%" />
                            <ItemTemplate>
                                <%#Eval("trdate", "{0: dd/MM/yyyy}")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Publish">
                            <ItemStyle Width="5%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status") %>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkstatus" runat="server" CausesValidation="false" CommandArgument='<%#Eval("userid") %>'
                                    CommandName="lnkstatus" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit" Visible="false">
                            <ItemStyle Width="5%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("userid") %>'
                                    CommandName="btnedit" ImageUrl="~/office/assets/Edit.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemStyle Width="5%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#Eval("userid") %>'
                                    CommandName="btndel" ImageUrl="~/office/assets/Remove_24x24.png" />
                                <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to delete this?"
                                    TargetControlID="btndel">
                                </ajaxToolkit:ConfirmButtonExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="View">
                            <ItemStyle Width="5%" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkdetail" runat="server" CausesValidation="false" CommandArgument='<%#Eval("userid") %>'
                                    OnClick="lnkdetail_Click"><img border="0" src="../../office/assets/Preview_24x24.png" alt="" /></asp:LinkButton>
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
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="Panel1" Height="300px" ScrollBars="Vertical" runat="server" CssClass="modalPopup"
                    Style="display: none" Width="500px">
                    <table border="0" cellpadding="2" cellspacing="0" width="100%" align="center">
                        <tr>
                            <td class="head1" colspan="2">
                                User Details
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="h_dot_line">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="Label3" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <table border="0" cellpadding="1" cellspacing="0" style="width: 70%">
                                    <tr>
                                        <td align="right" style="width: 30%" valign="top">
                                            User Name :&nbsp;
                                        </td>
                                        <td align="left" style="width: 70%" valign="top">                                           
                                            <asp:Label ID="lblusername" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 30%" valign="top">
                                            Email :&nbsp;
                                        </td>
                                        <td align="left" style="width: 70%" valign="top">
                                            <asp:Label ID="lblemail" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr runat="server" visible="false">
                                        <td align="right" style="width: 30%" valign="top">
                                            Password :&nbsp;
                                        </td>
                                        <td align="left" style="width: 70%" valign="top">
                                            <asp:Label ID="lblpassword" runat="server"></asp:Label></td>
                                    </tr>                                 
                                    <tr>
                                        <td align="right" style="width: 30%" valign="top">
                                            Phone :&nbsp;
                                        </td>
                                        <td align="left" style="width: 70%" valign="top">
                                            <asp:Label ID="lblphone" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top">
                                            Country :&nbsp;
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:Label ID="lblcountry" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top">
                                            Date :&nbsp;
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:Label ID="lbldate" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Button ID="btnCancel" runat="server" Text="Close" CssClass="btnbg" CausesValidation="False"
                                                TabIndex="20" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
                    CancelControlID="btnCancel" DropShadow="false" PopupControlID="Panel1" PopupDragHandleControlID="panelDragHandle"
                    TargetControlID="btnShowModalPopup">
                </ajaxToolkit:ModalPopupExtender>
                <asp:Button ID="btnShowModalPopup" runat="server" Style="display: none" />
            </td>
        </tr>
    </table>
</asp:Content>
