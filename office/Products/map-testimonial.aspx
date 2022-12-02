<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="map-testimonial.aspx.cs" Inherits="backoffice.office.Products.map_testimonial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>
        Map Testimonials</h2>
    <div class="content-panel">
        <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
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
            <tr bgcolor="#6E83BA">
                <td colspan="2">
                    <table id="TABLE2" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="color: #ffffff; font-size: larger; font-weight: bolder; height: 30px;
                                padding-left: 10px;" width="30%">
                                <asp:Label ID="lblcollage" runat="server"></asp:Label>
                            </td>
                            <td width="70%" align="right">
                                <a href="/backoffice/products/viewproducts.aspx" style="color: White"><b>Back To Products</b></a>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="10">
                    <asp:TextBox ID="collageid" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Panel ID="Panel1" runat="server" GroupingText="Search" Width="70%" Visible="true">
                        <table id="TABLE3" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                            <tr>
                                <td align="right">
                                    Testimonial Type
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="Tesid" runat="server" Width="400px" AutoPostBack="true" OnSelectedIndexChanged="Tesid_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="Tesid" InitialValue="0" ValidationGroup="addnew"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td align="right">
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
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" width="100%">
                    <asp:Panel ID="Panel2" runat="server" CssClass="mapping" GroupingText="Map Testimonials"
                        Width="100%" BorderStyle="Groove">
                        <table id="Table4" border="0" cellpadding="2" cellspacing="0" width="100%">
                            <tr width="100%">
                                <td align="right">
                                </td>
                                <td align="right">
                                    Department:<asp:DropDownList ID="drpdept" runat="server" AutoPostBack="True" Width="200px"
                                        OnSelectedIndexChanged="drpdept_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr width="100%">
                                <td align="left" colspan="2">
                                    <asp:DataList ID="dl_sgroup" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
                                        Width="100%" OnItemDataBound="dl_sgroup_ItemDataBound">
                                        <ItemTemplate>
                                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <%# Container.ItemIndex + 1%>.
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="checkfeature" runat="server" />
                                                    </td>
                                                    <td class="faculty-name">
                                                        <asp:Label ID="lblcname" runat="server" Text='<%#Eval("Testimonialname") %>' Visible="true"></asp:Label>
                                                        <asp:Label ID="lbltestimonialid" runat="server" Text='<%#(Eval("testimonialid")) %>'
                                                            Visible="false"></asp:Label>
                                                    </td>
                                                    <td class="faculty-name">
                                                        <asp:Label ID="lblcourse" runat="server" Text='<%#Eval("course") %>' Visible="true"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtfacultyImage" Visible="false" runat="server" Text='<%#Eval("uploadphoto")%>'></asp:TextBox>
                                                        <img id="imagefaculty" runat="server" width="50" height="50" />
                                                    </td>
                                                    <td>
                                                        Display Order:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtdisplayorder" runat="server" Width="70px"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                                                            ControlToValidate="txtdisplayorder" Display="Dynamic" ErrorMessage="Enter Numeric"
                                                            ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                                                        <asp:Literal ID="litralschool" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="showcheck" runat="server" />
                                                    </td>
                                                    <td>
                                                        Show on Home
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle Width="50%" />
                                    </asp:DataList>
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
                <td colspan="2" align="center">
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" TabIndex="15" CssClass="btnbg"
                        ValidationGroup="addnew" OnClick="btnsubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
