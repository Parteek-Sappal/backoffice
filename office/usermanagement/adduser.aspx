<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="adduser.aspx.cs" Inherits="backoffice.office.usermanagement.adduser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Add/Edit User</h2>
    <div class="content-panel">
        <table id="TABLE1" cellpadding="2" cellspacing="0" width="100%" >
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
                <td align="right" colspan="2">
                    Fields with <span class="star">*</span> are mandatory
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="10">
                    <asp:Panel ID="PanelSearch" runat="server" GroupingText="User Details" HorizontalAlign="Center"
                        Width="100%" Wrap="False">
                        <table border="0" cellpadding="2" cellspacing="0" class="panelbg" style="width: 100%">
                            <tr>
                                <td align="right" colspan="4" height="10">
                                    <asp:TextBox ID="TrId" runat="server" CssClass="box" Visible="False" Width="26px"></asp:TextBox>
                                    <asp:TextBox ID="Name" runat="server" CssClass="box" Visible="False" Width="26px"></asp:TextBox>
                                    <asp:TextBox ID="themeid" runat="server" CssClass="box" Visible="False" Width="26px"></asp:TextBox>
                                    <asp:CheckBox ID="Status" runat="server" Visible="False" />
                                </td>
                            </tr>
                            <tr valign="top">
                                <td align="right" width="20%">
                                    <span class="star">*</span>User Name:&nbsp;
                                </td>
                                <td align="left" colspan="3" width="30%">
                                    <asp:TextBox ID="Userid" runat="server" Width="250px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Userid"
                                        Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </td>
                                <td width="20%" align="right">
                                    <span class="star">*</span>Role:&nbsp;
                                </td>
                                <td width="30%">
                                    <asp:DropDownList ID="Roleid" runat="server" Width="252px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Roleid"
                                        Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top" width="20%">
                                    <span class="star">*</span>Email:
                                </td>
                                <td align="left" colspan="3" height="10" valign="top">
                                    <asp:TextBox ID="Email" runat="server" Width="250px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Email"
                                        Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Valid Email."
                                        ControlToValidate="Email" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </td>
                                <td width="20%" align="right" valign="top">
                                    <span class="star">*</span>Password:&nbsp;
                                </td>
                                <td width="30%" valign="top">
                                    <asp:TextBox ID="UserPassword" runat="server" Width="250px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="UserPassword"
                                        Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr align="center" >
                                <td colspan="4" >
                                    <table id="TABLE2" border="0" cellpadding="2" cellspacing="0" width="40%">
                                        <tr>
                                       
                                            <td align="right">
                                            <asp:CheckBox ID="adduser" runat="server" />
                                            </td>
                                            <td>Add</td>
                                            <td align="right">
                                            <asp:CheckBox ID="edituser" runat="server" />
                                            </td>
                                            <td>Edit</td>
                                            <td align="right">
                                             <asp:CheckBox ID="deleteuser" runat="server" />
                                            </td>
                                             <td>Delete</td>
                                        </tr>
                                    </table>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top" width="20%" height="10">
                                </td>
                                <td align="left" colspan="3" valign="top">
                                </td>
                                <td align="right" valign="top" width="20%">
                                </td>
                                <td valign="top" width="30%">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top" width="20%">
                                </td>
                                <td align="left" colspan="3" valign="top">
                                </td>
                                <td align="left" valign="top" width="20%">
                                    <asp:Button ID="btnsubmit" runat="server" CssClass="btnbg" Text="Submit" />
                                    <asp:Button ID="btncancel" runat="server" CssClass="btnbg" Text="Cancel" CausesValidation="False" />
                                </td>
                                <td valign="top" width="30%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4" height="10">
                                </td>
                                <td align="right" valign="top" width="20%">
                                    &nbsp;
                                </td>
                                <td valign="top" width="30%">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="Horizontal"
                        HorizontalAlign="Center" Width="100%">
                        <HeaderStyle HorizontalAlign="Left" />
                        <RowStyle HorizontalAlign="Left" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="rolename" HeaderText="Role">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Userid" HeaderText="User Name">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="email" HeaderText="Email Id">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:TemplateField HeaderText="Publish">
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkstatus" runat="server" CausesValidation="false" CommandArgument='<%# Eval("TrId") %>'
                                        CommandName="lnkstatus" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%# Eval("TrId") %>'
                                        CommandName="btnedit" ImageUrl="~/office/assets/Edit.png" ToolTip="Click to Edit" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle HorizontalAlign="Right" />
                        <PagerStyle HorizontalAlign="Right" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
