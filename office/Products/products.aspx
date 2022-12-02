<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="backoffice.office.Products.products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script type="text/javascript" src="/fancybox/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <script type="text/javascript">
        $(document).ready(function () {
            $(".various4").fancybox({
                'width': '90%',
                'height': '90%',
                'autoScale': true,
                'scrolling': 'yes',
                'transitionIn': 'elastic',
                'transitionOut': 'elastic',
                'type': 'iframe'
            });
        });
    </script>
    <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="head1">
                            Add Products
                        </td>
                        <td align="right" style="display: none;">
                            <a class="various4 btnbg" href="uploadproduct.aspx">Upload Product</a>
                        </td>
                    </tr>
            </td>
        </tr>
    </table>
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
            <asp:TextBox ID="productid" runat="server" Visible="false"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2">
        </td>
    </tr>
    <tr>
        <td align="right" colspan="2">
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                <tr>
                    <td valign="top" width="15%" align="right">
                        Series<span class="star">*</span> : &nbsp;
                    </td>
                    <td width="85%">
                        <asp:DropDownList ID="seriesid" runat="server" Width="200px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="seriesid"
                            Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr style="display: none">
                    <td valign="top" width="15%" align="right">
                        Sub Category<span class="star"></span> : &nbsp;
                    </td>
                    <td width="85%">
                        <asp:TextBox ID="psubcatid" runat="server" Text="0" Width="350px"></asp:TextBox>
                        <%--<asp:DropDownList ID="psubcatid" runat="server" Width="200px">
                            </asp:DropDownList>--%>
                    </td>
                </tr>
                <tr style="display: none">
                    <td valign="top" width="15%" align="right">
                        Sub Category<span class="star">*</span> : &nbsp;
                    </td>
                    <td width="85%">
                        <asp:DropDownList ID="psubsubcatid" runat="server" Width="200px">
                            <asp:ListItem Selected="True" Value="0">select</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="display: none">
                    <td valign="top" width="15%" align="right">
                        Sub-Sub-Sub-Category<span class="star">*</span> : &nbsp;
                    </td>
                    <td width="85%">
                        <asp:DropDownList ID="psubsubsubcatid" runat="server" Width="200px">
                            <asp:ListItem Selected="True" Value="0">select</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="15%" align="right">
                        Color <span class="star">*</span> : &nbsp;
                    </td>
                    <td width="85%">
                        <asp:DropDownList ID="colorid" runat="server" Width="200px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="colorid"
                            Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="15%" align="right">
                        Model <span class="star">*</span> : &nbsp;
                    </td>
                    <td width="85%">
                        <asp:DropDownList ID="modelid" runat="server" Width="200px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="modelid"
                            Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td valign="top" width="15%" align="right">
                        Type <span class="star">*</span> : &nbsp;
                    </td>
                    <td width="85%">
                        <asp:DropDownList ID="typeid" runat="server" Width="200px">
                        </asp:DropDownList>
                        <%--     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="typeid"
                                Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td valign="top" width="15%" align="right">
                        Look <span class="star">*</span> : &nbsp;
                    </td>
                    <td width="85%">
                        <asp:DropDownList ID="lookid" runat="server" Width="200px">
                        </asp:DropDownList>
                        <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="lookid"
                                Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td valign="top" width="15%" align="right">
                        Size<span class="star">*</span> : &nbsp;
                    </td>
                    <td width="85%">
                        <asp:DropDownList ID="sizeid" runat="server" Width="200px">
                        </asp:DropDownList>
                        <%--     <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="sizeid"
                                Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td valign="top" width="15%" align="right">
                        Coat<span class="star">*</span> : &nbsp;
                    </td>
                    <td width="85%">
                        <asp:DropDownList ID="coatid" runat="server" Width="200px">
                        </asp:DropDownList>
                        <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="coatid"
                                Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td valign="top" width="15%" align="right">
                        UOM<span class="star">*</span> : &nbsp;
                    </td>
                    <td width="85%">
                        <asp:DropDownList ID="uomid" runat="server" Width="200px">
                        </asp:DropDownList>
                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="uomid"
                                Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td valign="top" width="15%" align="right">
                        EPPD<span class="star">*</span> : &nbsp;
                    </td>
                    <td width="85%">
                        <asp:DropDownList ID="eppdid" runat="server" Width="200px">
                        </asp:DropDownList>
                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="eppdid"
                                Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right">
                        Product Name<%--<span class="star">*</span>--%>
                        : &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="productname" runat="server" Width="350px"></asp:TextBox>
                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="productname"
                                Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td valign="top" align="right">
                        Product Code<span class="star">*</span> : &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="productcode" runat="server" Width="350px"></asp:TextBox>
                        <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="productcode"
                                Display="Dynamic" ErrorMessage="Required" ></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right">
                        Short Detail : &nbsp;
                    </td>
                    <td>
                        <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                        </CKEditor:CKEditorControl>
                        <asp:TextBox ID="shortdetail" runat="server" Visible="False" Width="122px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right">
                        Detail : &nbsp;
                    </td>
                    <td>
                        <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="250" BasePath="~/ckeditor">
                        </CKEditor:CKEditorControl>
                        <asp:TextBox ID="productdetail" runat="server" Visible="False" Width="122px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Upload Image<span class="star">*</span> :&nbsp;
                    </td>
                    <td align="left">
                        <input id="File2" runat="server" class="box" contenteditable="false" onchange="showpreview(this);"
                            type="file" />&nbsp;<asp:Label ID="Label1" runat="server" Text="(Image should be of size : 288x209.)"
                                ForeColor="red" Font-Italic="true" Visible="false"></asp:Label>
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="(Gallery Image show on homepage should be of size : 500 x 511.)"
                            ForeColor="red" Font-Italic="true" Visible="false"></asp:Label>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="toptxt" Visible="false"
                            OnClick="LinkButton1_Click">Remove File</asp:LinkButton>
                        <asp:TextBox ID="UploadAImage" runat="server" Visible="False" Width="122px">
                
                
                
                        </asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td align="right">
                    </td>
                    <td align="left">
                        <asp:Image ID="Image1" runat="server" Height="120px" Visible="False" Width="107px" />
                    </td>
                </tr>
                <tr style="display: none;">
                    <td align="right" valign="top">
                        Upload Tech. Specification File<span class="star">*</span> :&nbsp;
                    </td>
                    <td align="left">
                        <input id="File1" runat="server" contenteditable="false" type="file" class="box" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="prospectus" runat="server" Visible="False"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td align="right" valign="top">
                        Decor :&nbsp;
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="Decor" runat="server" />&nbsp;&nbsp;
                        <asp:TextBox ID="DecorName" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        New Arrivals :&nbsp;
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="Isnewlaunches" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        Feature Product :&nbsp;
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="featureproduct" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right">
                        Main Price<span class="star"></span> : &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="mainprice" runat="server" Width="100px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator2" runat="server" ControlToValidate="mainprice"
                            ErrorMessage="Enter Numeric" Display="Dynamic" ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr style="display: none">
                    <td valign="top" align="right">
                        Retail Price<span class="star"></span> : &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="retailprice" runat="server" Width="100px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator1" runat="server" ControlToValidate="retailprice"
                            ErrorMessage="Enter Numeric" Display="Dynamic" ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td align="right" valign="top">
                        You Tube URL:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="youtubeurl" runat="server" Width="350px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td align="right" valign="top">
                        URL First:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="urlfirst" runat="server" Width="350px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td align="right" valign="top">
                        URL Second:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="urlsecond" runat="server" Width="350px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td align="right" valign="top">
                        URL Third:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="urlthird" runat="server" Width="350px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td align="right" valign="top">
                        URL Four:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="urlfour" runat="server" Width="350px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td align="right" valign="top">
                        URL Five:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="urlfive" runat="server" Width="350px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right" valign="top">
                    </td>
                    <td align="left">
                        <asp:TextBox ID="purl" runat="server" Width="350px" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none">
                    <td valign="top" align="right">
                        Rewrite Url<%--<span class="star">*</span>--%>
                        : &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="rewrite_url" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right">
                        Display Order<span class="star">*</span> : &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="displayorder" runat="server" Width="50px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="displayorder"
                            Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                            ControlToValidate="displayorder" ErrorMessage="Enter Numeric" Display="Dynamic"
                            ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                        <asp:CheckBox ID="status" runat="server" Checked="True" Visible="false" />
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
                        <asp:TextBox ID="PageTitle" runat="server" Width="200px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="coursename"
                                Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right">
                        <span class="star"></span>Page Meta : &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="PageMeta" runat="server" Width="500px" Height="100" TextMode="MultiLine"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="coursename"
                                Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right">
                        <span class="star"></span>Page Meta Desc : &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="PageMetaDesc" runat="server" Width="500px" Height="100" TextMode="MultiLine"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="coursename"
                                Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right">
                        <span class="star"></span>Canonical : &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="canonical" runat="server" Width="300px"></asp:TextBox>
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
                    <td align="right" style="width: 15%; height: 26px;" valign="top">
                        <span class="star"></span>Page Script :&nbsp;
                    </td>
                    <td align="left">
                        <asp:TextBox ID="pagescript" runat="server" Visible="true" Width="300" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnbg" OnClick="btnSubmit_Click" />&nbsp;<asp:Button
                            ID="btnCancel" runat="server" Text="Cancel" CssClass="btnbg" CausesValidation="False"
                            OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    </table>
</asp:Content>
