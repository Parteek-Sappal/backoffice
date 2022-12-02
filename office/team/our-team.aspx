<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="our-team.aspx.cs" Inherits="backoffice.office.team.our_team" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
        $(function () {
            CKEDITOR.replace('<%=CKeditor1.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
        });
     </script>
    <h2>
        Add Leadership & Management</h2>
    <div class="content-panel">
        <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
            <tr>
                <td align="left" colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <%-- <td class="head1">
                            Add Team</td>--%>
                            <td align="right">
                                &nbsp;<asp:TextBox ID="teamid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                                <asp:CheckBox ID="status" runat="server" Visible="false" Checked="true" Width="122px">
                                </asp:CheckBox>
                                &nbsp;&nbsp; &nbsp;
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
                    Fields with <span style="color: #ff0000">*</span> are mandatory
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="10">
                </td>
            </tr>
            <tr >
                <td valign="top" align="right">
                    Leadership Type<span class="star">*</span> : &nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="ttypeid" runat="server" Width="200px">
                       <%-- <asp:ListItem Value="0">-Select-</asp:ListItem>
                        <asp:ListItem Value="1">Leadership</asp:ListItem>
                          <asp:ListItem Value="2">Promoter</asp:ListItem>--%>
                    </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ttypeid"
                    Display="Dynamic" InitialValue="0" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>

             <tr  style="display:none">
                <td valign="top" align="right">
                    Leadership SubType<span class="star"></span> : &nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="tsubtypeid" runat="server" Width="200px">
                    </asp:DropDownList>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tsubtypeid"
                    Display="Dynamic" InitialValue="0" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>

            <tr>
                <td align="right" style="width: 15%">
                    Name <span class="star">*</span> :&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:TextBox ID="name" runat="server" CssClass="box" TabIndex="3" Width="359px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="name"
                        Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%">
                    Designation<span class="star"></span> :&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:TextBox ID="designation" runat="server" CssClass="box" TabIndex="3" Width="359px"></asp:TextBox>
                  <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="designation"
                        Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr style="display: none;">
                <td align="right" style="width: 15%">
                    Qualification <span class="star"></span>:&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:TextBox ID="qualification" runat="server" CssClass="box" TabIndex="3" Width="359px"></asp:TextBox>
                    <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="qualification"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr style="display: none;">
                <td align="right" style="width: 15%">
                    Nationality <span class="star"></span>:&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:TextBox ID="nationality" runat="server" CssClass="box" TabIndex="3" Width="359px"></asp:TextBox>
                    <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="nationality"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr style="display: none;">
                <td align="right" style="width: 15%">
                    Head Quarter <span class="star"></span>:&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:TextBox ID="headquarter" runat="server" CssClass="box" TabIndex="3" Width="359px"></asp:TextBox>
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="headquarter"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%">
                    Tagline <span class="star">*</span> :&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:TextBox ID="experience" runat="server" CssClass="box" TextMode="MultiLine" TabIndex="3"
                        Width="359px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="experience"
                        Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="display: none;">
                <td align="right" style="width: 15%">
                    Industries <span class="star"></span>:&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:TextBox ID="industries" runat="server" CssClass="box" TabIndex="3" Width="359px"></asp:TextBox>
                    <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="industries"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    Profile Short Desc.:&nbsp;
                </td>
                <td align="left">
                    <CKEditor:CKEditorControl ID="CKeditor2" runat="server" BasePath="~/ckeditor/" Height="200px"
                        Width="100%">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="shortdesc" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    Profile Desc. :&nbsp;
                </td>
                <td align="left">
                    <CKEditor:CKEditorControl ID="CKeditor1" runat="server" BasePath="~/ckeditor/" Height="350px"
                        Width="90%">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="detaildesc" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%">
                    Upload Small Image :&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <input id="File1" runat="server" class="box" contenteditable="false" type="file" />
                    <asp:TextBox ID="Uploadphoto" runat="server" CssClass="box" MaxLength="100" TabIndex="3"
                        Width="359px" Visible="false"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%">
                </td>
                <td align="left" style="width: 85%">
                    <asp:Image ID="Image1" runat="server" Width="100px" Height="100px" Visible="false" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%">
                    Upload Large Image :&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <input id="File2" runat="server" class="box" contenteditable="false" type="file" />
                    <asp:TextBox ID="Uploadphoto1" runat="server" CssClass="box" MaxLength="100" TabIndex="3"
                        Width="359px" Visible="false"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%">
                </td>
                <td align="left" style="width: 85%">
                    <asp:Image ID="Image2" runat="server" Width="100px" Height="100px" Visible="false" />
                </td>
            </tr>
            <tr style="display: none">
                <td align="right">
                    Show On Top :&nbsp;
                </td>
                <td align="left">
                    <asp:CheckBox ID="showtop" runat="server" Width="122px"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Display Order :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="displayorder" runat="server" Width="39px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                        ControlToValidate="displayorder" Display="Dynamic" ErrorMessage="Enter Numeric"
                        ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr style="display: none">
                <td align="right" valign="top">
                    Show On Home :&nbsp;
                </td>
                <td align="left">
                    <asp:CheckBox ID="showonhome" runat="server" Width="122px"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td class="head1" colspan="2" style="font-size: small;" nowrap>
                    SEO Information
                </td>
            </tr>
            <tr>
                <td align="right">
                    Page Title :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="PageTitle" runat="server" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    Meta Keywords :
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="pagemeta" runat="server" Height="50px" TextMode="MultiLine" Width="500px" />
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    Meta Description :
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="pagemetadesc" runat="server" Height="50px" TextMode="MultiLine"
                        Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    Page Script:
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="other_schema" runat="server" Height="50px" TextMode="MultiLine"
                        Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                    <span class="star"></span>Canonical : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="canonical" runat="server" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    No Index Follow :
                </td>
                <td align="left" valign="top">
                    <asp:CheckBox ID="no_indexfollow" runat="server"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="10">
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="left">
                    <asp:Button ID="btnsubmit" runat="server" CssClass="btnbg" Text="Submit" OnClick="btnsubmit_Click" />
                &nbsp;
            </tr>
        </table>
    </div>
</asp:Content>
