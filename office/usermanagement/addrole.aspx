<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="addrole.aspx.cs" Inherits="backoffice.office.usermanagement.addrole" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Add/Edit Role</h2>
    <div class="content-panel">
    <table id="TABLE1" cellpadding="2" cellspacing="0" width="100%">
     <%--   <tr>
            <td class="head1" style="width: 50%">
                Add/Edit Role
            </td>
            <td align="right" style="width: 50%">
            </td>
        </tr>--%>
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
                <asp:Panel ID="PanelSearch" runat="server" GroupingText="Role Details" HorizontalAlign="Center"
                    Width="80%" Wrap="False">
                    <table border="0" cellpadding="2" cellspacing="0" class="panelbg" style="width: 100%">
                        <tr>
                            <td align="right" colspan="4" height="10">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%" valign="top">
                                <span class="star">*</span>Role Name:&nbsp;
                            </td>
                            <td align="left" valign="top" colspan="3">
                                <asp:TextBox ID="rolename" runat="server" Width="350px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rolename"
                                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                <span class="star"></span>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top" width="20%">
                            </td>
                            <td align="left" colspan="3" height="10" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" height="10">
                                <asp:TextBox ID="roleid" runat="server" CssClass="box" TabIndex="3" Visible="False"
                                    Width="26px"></asp:TextBox><asp:CheckBox ID="rolestatus" runat="server" Visible="False" />
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
            <td align="left" colspan="4" style="background-color: #B4D0F2" id="tr_per" runat="server">
                <strong>&nbsp;PERMISSION</strong>
            </td>
        </tr>
        <% If Val(Request.QueryString("roleid")) <> 1 Then%>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DataList ID="DlAccess" runat="server" Width="100%">
                            <ItemTemplate>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 2%">
                                            <asp:ImageButton ID="btnshow" ImageUrl="~/backoffice/assets/newplus.png" CommandArgument='<%# eval("Moduleid") %>'
                                                CausesValidation="false" CommandName="show" runat="server" />
                                                <asp:ImageButton ID="btnhide"
                                                    Visible="false" ImageUrl="~/backoffice/assets/newsub.png" CausesValidation="false"
                                                    CommandArgument='<%# eval("Moduleid") %>' CommandName="hide" runat="server" />

                                        </td>
                                        <td style="width: 98%">
                                            <table width="100%">
                                                <tr>
                                                    <td align="left">
                                                        <strong>
                                                            <asp:Label runat="server" ID="lblMName" Text='<%# Eval("Modulename")%>'></asp:Label></strong>
                                                    </td>
                                                    <td align="right">
                                                        <asp:TextBox Visible="false" ID="txtmid" runat="server" Text='<%# eval("Moduleid") %>'></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <table width="100%" border="0" align="left">
                                                <tr>
                                                    <td valign="top" align="left" colspan="2">
                                                        <asp:GridView ID="GridView2" OnRowDataBound="GridView2_RowDataBound" runat="server"
                                                            AutoGenerateColumns="False" CellPadding="4" GridLines="Horizontal" Width="100%">
                                                            <HeaderStyle CssClass="head4" HorizontalAlign="Left" />
                                                            <RowStyle CssClass="grid" />
                                                            <Columns>
                                                                <asp:BoundField ItemStyle-Width="5%" DataField="Formid" HeaderText="Form Id" />
                                                                <asp:BoundField ItemStyle-Width="80%" DataField="FormCaption" HeaderText="Form Name"
                                                                    HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="left" />
                                                                <asp:TemplateField HeaderText="Access" ItemStyle-Width="20%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblacc" runat="server" Text="Access"></asp:Label><br />
                                                                        <asp:CheckBox ID="selectall" AutoPostBack="True" runat="server" Visible="false" OnCheckedChanged="selectall_CheckedChanged" />
                                                                    </HeaderTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkselect" AutoPostBack="True" runat="server" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" align="left" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 98%" id="tableDept" align="left">
                                                        <asp:GridView ID="gridSubDepartment" runat="server" OnRowDataBound="gridSubDepartment_RowDataBound"
                                                            AutoGenerateColumns="False" CellPadding="4" GridLines="Horizontal" Width="100%">
                                                            <HeaderStyle CssClass="head4" HorizontalAlign="Left" />
                                                            <RowStyle CssClass="grid" />
                                                            <Columns>
                                                                <asp:BoundField ItemStyle-Width="5%" DataField="deptid" HeaderText="Dept Id" Visible="false" />
                                                                <asp:TemplateField Visible="false">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbldeptid" runat="server" Text='<%#Eval("collageid") %>' Visible="false"></asp:Label><br />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Collage" ItemStyle-Width="20%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSubDepartment" runat="server" Text='<%#Eval("collagename") %>'></asp:Label><br />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Access" ItemStyle-Width="20%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkselect" runat="server" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td style="width: 98%" id="tablecampus" align="left">
                                                     <asp:GridView ID="gridcampus" runat="server" 
                                                            AutoGenerateColumns="False" CellPadding="4" GridLines="Horizontal" Width="100%" OnRowDataBound="gridcampus_RowDataBound" >
                                                            <HeaderStyle CssClass="head4" HorizontalAlign="Left" />
                                                            <RowStyle CssClass="grid" />
                                                            <Columns>
                                                                
                                                                <asp:TemplateField Visible="false">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcampusid" runat="server" Text='<%#Eval("campusid") %>' Visible="false"></asp:Label><br />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Campus Name" ItemStyle-Width="20%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcampusname" runat="server" Text='<%#Eval("campus_name") %>'></asp:Label><br />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Access" ItemStyle-Width="20%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkselect" runat="server" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>

                                                     </td>
                                                </tr>

                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <%End If%>
        <tr>
            <td align="center" colspan="4" style="height: 15px">
                <asp:Button ID="btnSubmit" runat="server" CssClass="btnbg" Text="Submit" />
                <asp:Button ID="btnCancel" runat="server" CssClass="btnbg" Text="Cancel" ausesValidation="False" />
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
