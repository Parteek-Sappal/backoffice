<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/backmaster.Master" AutoEventWireup="true" CodeBehind="addcoursetype.aspx.cs" Inherits="backoffice.office.masters.addcoursetype" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
    $(function () {
        CKEDITOR.replace('<%=CKeditor1.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
        CKEDITOR.replace('<%=CKeditor2.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
    });
    </script>
    <h2>
        Add Course Type </h2>
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
                <td align="right" colspan="2">
                    Fields with <span class="star">*</span>are mandatory
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
                            <td align="right" width="15%">
                                Course Type<span class="star">*</span> :&nbsp;
                            </td>
                            <td align="left" style="width: 85%">
                                <asp:TextBox ID="ctypename" CssClass="box" runat="server" Width="500"></asp:TextBox>
                                <asp:TextBox ID="ctid" runat="server" Visible="False" Width="23px"></asp:TextBox>
                                <asp:TextBox ID="rewrite_url" CssClass="box" runat="server" Width="330" Visible="False"></asp:TextBox>
                                <asp:TextBox runat="server" ID="levelimg" Visible="false" />
                                <asp:TextBox runat="server" ID="colorcode" Visible="false" />
                                <asp:CheckBox ID="status" runat="server" Visible="False" Checked="True" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ctypename"
                                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td align="right" width="15%">
                                Tag Name
                            </td>
                            <td align="left" style="width: 85%">
                                <asp:TextBox ID="tagname" CssClass="box" runat="server" Width="600px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr >
                            <td align="right" width="15%">
                                Short Desc
                            </td>
                            <td align="left" style="width: 85%">
                                <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                                </CKEditor:CKEditorControl>
                                <asp:TextBox ID="details" runat="server" Visible="False" Width="122px"></asp:TextBox>
                            </td>
                        </tr>

                        <tr style="display:none">
                            <td align="right" width="15%">
                                 Desc
                            </td>
                            <td align="left" style="width: 85%">
                                <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="250" BasePath="~/ckeditor">
                                </CKEditor:CKEditorControl>
                                <asp:TextBox ID="pdetails" runat="server" Visible="False" Width="122px"></asp:TextBox>
                            </td>
                        </tr>



                        <tr style="display: none">
                            <td align="right" width="15%">
                                Code
                            </td>
                            <td align="left" style="width: 85%">
                                <asp:TextBox ID="code" CssClass="box" runat="server" Width="50px"></asp:TextBox>
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
                        <tr style="display:none" >
                            <td align="right" style="width: 15%">
                                Upload Image Home<span class="star"></span> :&nbsp;
                            </td>
                            <td align="left" style="width: 85%">
                                <asp:FileUpload ID="File1" runat="server" />
                                <asp:TextBox ID="uploadbanner" runat="server" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr >
                            <td align="right" style="width: 15%">
                            </td>
                            <td align="left" style="width: 85%">
                                <asp:Image ID="Image1" runat="server" Height="100px" Visible="False" Width="100px" />
                                <asp:LinkButton ID="lnkremove" runat="server" Visible="false">Remove Image</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                            </td>
                            <td align="left" height="10">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <b>SEO SECTION</b>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="right">
                                <span class="star"></span>Page Title : &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="PageTitle" runat="server" Width="500px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="right">
                                <span class="star"></span>Page Meta : &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="PageMeta" runat="server" Width="500px" Height="100" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="right">
                                <span class="star"></span>Page Meta Desc : &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="PageMetaDesc" runat="server" Width="500px" Height="100" TextMode="MultiLine"></asp:TextBox>
                            </td>
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
                            <td align="left">
                                <asp:Button ID="btnsubmit" runat="server" CssClass="btnbg" Text="Submit" OnClick="btnsubmit_Click" />                         
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
