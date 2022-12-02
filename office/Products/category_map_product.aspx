<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="category_map_product.aspx.cs" Inherits="backoffice.office.Products.category_map_product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:Panel ID="panel1" runat="server" DefaultButton="btnSubmit">
        <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
            <tr>
                <td class="head1" colspan="2">
                    Map Product
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
                <td align="right" colspan="2">
                    Fields with <span class="star">*</span>are mandatory
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                    <asp:TextBox ID="mapcpid" runat="server" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="addedby" runat="server" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="addeddate" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 17%">
                    Category :&nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="CatId" runat="server" Width="204px" AutoPostBack="true" CausesValidation="false"
                        OnSelectedIndexChanged="CatId_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="left" style="width: 17%">
                    &nbsp;OR &nbsp; Exact Product Code &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="exactsku" runat="server" AutoPostBack="true" OnTextChanged="exactsku_Click"></asp:TextBox>
                </td>
            </tr>
            <tr  style="display:none;">
                <td align="right" style="width: 17%">
                    Sub Category :&nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="subcatId" runat="server" Width="204px" AutoPostBack="true"
                        CausesValidation="false" OnSelectedIndexChanged="subcatId_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 17%; height: 24px;">
                    Product Name :&nbsp;
                </td>
                <td align="left" style="height: 24px">
                    <asp:DropDownList ID="pid" runat="server" Width="204px" AutoPostBack="true" OnSelectedIndexChanged="pid_SelectedIndexChanged1">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="pid"
                        Display="Dynamic" ErrorMessage="Required" InitialValue="0" ValidationGroup="product"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 17%; height: 24px">
                    <%--ValidationGroup="product"--%>
                </td>
                <td align="left" style="height: 24px">
                    <asp:Button ID="Search" runat="server" Text="Search" CssClass="btnbg" OnClick="Search_Click" /><asp:TextBox
                        ID="mappid" runat="server" Visible="false"></asp:TextBox><%--<asp:TextBox ID="mappTypeid"
                            runat="server" Visible="false"></asp:TextBox><asp:TextBox ID="mapbrandid" runat="server"
                                Visible="false"></asp:TextBox>--%>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Panel ID="SearchPanel" runat="server" Visible="false">
                        <table id="TABLE2" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                            <tr>
                                <td align="right" style="width: 17%; font-size: 15px; font-weight: bold;" valign="top">
                                </td>
                                <td align="left">
                                    <table border="0" cellpadding="1" cellspacing="0" style="width: 75%">
                                        <tr>
                                            <td align="left" colspan="4">
                                                <asp:Label ID="lblProductMsg" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                <asp:GridView ID="GridView1" runat="server" PageSize="50" AllowPaging="True" Width="100%"
                                                    AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Product">
                                                            <ItemStyle Width="35%" HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblproduct" runat="server" Text='<%#Eval("productname") %>'></asp:Label>
                                                                <asp:TextBox ID="GrdmapPTitle" runat="server" Visible="false" Text='<%#Eval("productid") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Map Product">
                                                            <ItemStyle Width="15%" />
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkselect" runat="server" CausesValidation="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="productid" HeaderText="pid" />
                                                    </Columns>
                                                    <SelectedRowStyle HorizontalAlign="Right" />
                                                    <PagerStyle HorizontalAlign="Right" />
                                                </asp:GridView>
                                                <%--<asp:CheckBoxList ID="lstproduct" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
                                </asp:CheckBoxList><asp:TextBox ID="chkproduct" runat="server" Visible="false"></asp:TextBox>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="font-weight: bold; font-size: 15px; width: 17%" valign="top">
                                </td>
                                <td align="left">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="font-weight: bold; font-size: 15px; width: 17%" valign="top">
                                </td>
                                <td align="left">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnbg" TabIndex="15"
                                        ValidationGroup="product" OnClick="btnSubmit_Click" />&nbsp;<asp:Button ID="btnCancel"
                                            runat="server" Text="Cancel" CssClass="btnbg" CausesValidation="False" TabIndex="16" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
