<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="productsubcategory.aspx.cs" Inherits="backoffice.office.Products.productsubcategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="head1">
                            Add/Edit Sub Product Category
                        </td>
                        <td align="right">
                            &nbsp;
                            <asp:TextBox ID="psubcatid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                            <asp:CheckBox ID="Status" runat="server" Visible="False" Checked="true" />
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
                Fields with <span class="star">*</span> are mandatory
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr >
            <td align="right" style="width: 15%; height: 26px;">
                Category<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%; height: 26px;">
                <asp:DropDownList ID="pcatid" runat="server" Width="214px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="psubcatid"
                    Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%; height: 26px;">
                Sub Category<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%; height: 26px;">
                <asp:TextBox ID="Category" runat="server" CssClass="box" MaxLength="100" TabIndex="3"
                    Width="214px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Category"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="15%" height="26px">
                Short Detail : &nbsp;
            </td>
            <td align="left" width="85%" height="26px">
                <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
                <asp:TextBox ID="shortdetail" runat="server" Visible="False" Width="122px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="15%" height="26px">
                Detail : &nbsp;
            </td>
            <td align="left" width="85%" height="26px">
                <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
                <asp:TextBox ID="detail" runat="server" Visible="False" Width="122px"></asp:TextBox>
            </td>
        </tr>
        <tr style="display:none">
            <td align="right">
                Upload Banner<span class="star">*</span> :&nbsp;
            </td>
            <td align="left">
                <input id="File2" runat="server" class="box" contenteditable="false" onchange="showpreview(this);"
                    type="file" />&nbsp;<asp:Label ID="Label1" runat="server" Text="(Image should be of size : 288x209.)"
                        ForeColor="red" Font-Italic="true" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="Label4" runat="server" Text="(Gallery Image show on homepage should be of size : 500 x 511.)"
                    ForeColor="red" Font-Italic="true" Visible="false"></asp:Label>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="toptxt" Visible="false"
                    OnClick="LinkButton1_Click">Remove Image</asp:LinkButton>
                <asp:TextBox ID="banner" runat="server" Visible="False" Width="122px">
                
                
                
                </asp:TextBox>
            </td>
        </tr>
         <tr style="display:none">
            <td align="right">
            </td>
            <td align="left">
                <asp:Image ID="Image1" runat="server" Visible="False" Height="100" Width="100" />
            </td>
        </tr>

            <tr style="display:none">
            <td align="right">
                Upload Mobile Image<span class="star">*</span> :&nbsp;
            </td>
            <td align="left">
                <input id="File1" runat="server" class="box" contenteditable="false" onchange="showpreview(this);"
                    type="file" />&nbsp;<asp:Label ID="Label2" runat="server" Text="(Image should be of size : 288x209.)"
                        ForeColor="red" Font-Italic="true" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="Label3" runat="server" Text="(Gallery Image show on homepage should be of size : 500 x 511.)"
                    ForeColor="red" Font-Italic="true" Visible="false"></asp:Label>
                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="toptxt" Visible="false"
                    OnClick="LinkButton2_Click">Remove Image</asp:LinkButton>
                <asp:TextBox ID="UploadAImage" runat="server" Visible="False" Width="122px">
                
                
                
                </asp:TextBox>
            </td>
        </tr>
        <tr style="display:none">
            <td align="right">
            </td>
            <td align="left">
                <asp:Image ID="Image2" runat="server" Visible="False" Height="100" Width="100" />
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

        <tr>
            <td align="left" colspan="2" height="10">
                <b>SEO Section</b>
            </td>
        </tr>
        <tr style="display:none;">
            <td align="right" style="width: 15%; height: 26px;" valign="top">
                <span class="star"></span>Rewrite Url:&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="rewriteurl" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%; height: 26px;" valign="top">
                <span class="star"></span>Page Name :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="PageTitle" runat="server" Visible="true" Width="300"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%; height: 26px;" valign="top">
                <span class="star"></span>Page Meta :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="PageMeta" runat="server" Visible="true" Width="300" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%; height: 26px;" valign="top">
                <span class="star"></span>Page Description :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="PageMetaDesc" runat="server" Visible="true" Width="300" TextMode="MultiLine"></asp:TextBox>
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
            <td align="right" height="10" style="width: 15%">
            </td>
            <td align="left" style="width: 85%">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
            </td>
            <td align="left" style="width: 85%">
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btnbg" OnClick="btnsubmit_Click" />&nbsp;<asp:Button
                    ID="btncancel" runat="server" Text="Cancel" CssClass="btnbg" CausesValidation="False"
                    OnClick="btncancel_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
            </td>
        </tr>
    </table>
</asp:Content>
