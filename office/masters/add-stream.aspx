<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="add-stream.aspx.cs" Inherits="backoffice.office.masters.add_stream" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>  Add Stream</h2>
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
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                <table id="Table2" border="0" cellpadding="1" cellspacing="0" style="width: 100%">

                <tr>
            <td valign="top" width="15%" align="right">
                Course Level<span class="star">*</span> : &nbsp;
            </td>
            <td width="85%">
                <asp:DropDownList ID="levelid" runat="server" Width="350px" AutoPostBack="false">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="levelid"
                    Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
            </td>
        </tr>
                    <tr>
                        <td align="right" width="15%">
                            Stream Name<span class="star">*</span> :&nbsp;
                        </td>
                        <td align="left" style="width: 85%">
                            <asp:TextBox ID="streamname" CssClass="box" runat="server" Width="600px"></asp:TextBox>
                            <asp:TextBox ID="streamid" runat="server" Visible="False" Width="23px"></asp:TextBox>
                            <asp:TextBox ID="rewriteurl" CssClass="box" runat="server" Width="330" Visible="False"></asp:TextBox>
                            <asp:TextBox ID="rewriteurl_sec" CssClass="box" runat="server" Width="330" Visible="False"></asp:TextBox>
                            <asp:CheckBox ID="status" runat="server" Visible="False" Checked="True" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="streamname"
                                Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" width="15%">
                            Display Order
                        </td>
                        <td align="left" style="width: 85%">
                            <asp:TextBox ID="displayorder" CssClass="box" runat="server" Width="50px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                                ControlToValidate="displayorder" ErrorMessage="Enter Numeric" Display="Dynamic"
                                ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td align="right" width="15%" valign="top">
                            Detail : &nbsp;
                        </td>
                        <td align="left" style="width: 85%">
                            <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="stream_tdetail" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td align="right" style="width: 15%">
                            Upload Banner<span class="star"></span> :&nbsp;
                        </td>
                        <td align="left" style="width: 85%">
                            <asp:FileUpload ID="File1" runat="server" />
                            <asp:TextBox ID="uploadimage" runat="server" Visible="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td align="right" style="width: 15%">
                        </td>
                        <td align="left" style="width: 85%">
                            <asp:Image ID="Image1" runat="server" Height="100px" Visible="False" Width="100px" />
                            <asp:LinkButton ID="lnkremove" runat="server" Visible="false">Remove Image</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td class="head1" colspan="2" style="font-size: small;" nowrap>
                            SEO Information</td>
                    </tr>
                    <tr>
                        <td align="right">
                            Page Title :&nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="PageTitle" runat="server" Width="600px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            Meta Keywords :</td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="pagemeta" runat="server" Height="50px" TextMode="MultiLine" Width="600px" /></td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            Meta Description :</td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="pagemetadesc" runat="server" Height="50px" TextMode="MultiLine"
                                Width="600px"></asp:TextBox></td>
                    </tr>

                     <tr>
                            <td valign="top" align="right">
                                <span class="star"></span>Page Script : &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="pagescript" runat="server" Width="500px" Height="100" TextMode="MultiLine"></asp:TextBox>
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
                        <td align="right">
                        </td>
                        <td align="left" height="10">
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td align="left">
                            <asp:Button ID="btnsubmit" runat="server" CssClass="btnbg" Text="Submit" OnClick="btnsubmit_Click" />
                            <asp:Button ID="btncancel" runat="server" CssClass="btnbg" Text="Cancel" OnClick="btncancel_Click" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
                &nbsp;
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
