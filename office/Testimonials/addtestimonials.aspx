<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="addtestimonials.aspx.cs" Inherits="backoffice.office.Testimonials.addtestimonials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
     $(function () {
         CKEDITOR.replace('<%=CKeditor1.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor2.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
     });
    </script>

       <h2> Add Testimonial</h2>
<div class="content-panel">

    <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="head1">
                           
                        </td>
                        <td align="right">
                            &nbsp;<asp:TextBox ID="testimonialid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                            <asp:CheckBox ID="status" runat="server" Visible="False" Checked="true" />
                            <asp:CheckBox ID="showonhome" runat="server" Visible="False" />
                             <asp:CheckBox ID="showright" runat="server" Visible="False" />
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
        <tr>
            <td align="right" style="width: 15%">
                <span class="star"></span>Testimonial Type <span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:DropDownList ID="Tesid" runat="server" CssClass="box" Width="200px">
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Tesid"
                    Display="Dynamic" InitialValue="0" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                Name<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="Testimonialname" runat="server" CssClass="box" MaxLength="100" TabIndex="3"
                    Width="359px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Testimonialname"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr style="display:none">
            <td align="right" valign="top">
                Designation :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="desg" runat="server" CssClass="box" MaxLength="100" Width="300px"></asp:TextBox>
            </td>
        </tr>
         <tr style="display:none">
            <td align="right" valign="top">
                Branch :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="branch" runat="server" CssClass="box" MaxLength="100" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr  >
            <td align="right" valign="top">
                Batch :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="batch" runat="server" CssClass="box" MaxLength="100" Width="300px"></asp:TextBox>
            </td>
        </tr>
         <tr style="display:none">
            <td align="right" valign="top">
                ID :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="regid" runat="server" CssClass="box" MaxLength="100" Width="300px"></asp:TextBox>
            </td>
        </tr>
         <tr style="display:none">
            <td align="right" valign="top">
                Course:&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="course" runat="server" CssClass="box" MaxLength="100" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr   >
            <td align="right" valign="top">
                 Placed at:&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="Placed" runat="server" CssClass="box" MaxLength="100" Width="300px"></asp:TextBox>
            </td>
        </tr>
         <tr  style="display:none" >
            <td align="right" valign="top">
                Placed Type:&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="placedtype" runat="server" CssClass="box" MaxLength="100" Width="300px"></asp:TextBox>
            </td>
        </tr>
       
        <tr >
            <td align="right" valign="top">
                Text Type :&nbsp;
            </td>
            <td align="left">
                <asp:RadioButtonList ID="texttype" runat="server" RepeatDirection="Horizontal" 
                    AutoPostBack="true" onselectedindexchanged="texttype_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="Text Message">Text Message</asp:ListItem>
                   <asp:ListItem Value="Video">Video</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                Short Detail :&nbsp;
            </td>
            <td align="left">
                <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
                <asp:TextBox ID="testimonialdesc" runat="server" Visible="False" Width="122px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                Detail :&nbsp;
            </td>
            <td align="left">
                <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
                <asp:TextBox ID="detaildesc" runat="server" Visible="False" Width="122px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                Video URL :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="uploadvedio" runat="server" Width="500px" Visible="true"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="right" style="width: 15%">
                Upload Image :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <input id="File1" runat="server" class="box" contenteditable="false" type="file" />
                <asp:TextBox ID="Uploadphoto" runat="server" CssClass="box" MaxLength="100" TabIndex="3"
                    Width="359px" Visible="false"></asp:TextBox>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>&nbsp;&nbsp;<asp:Label
                    ID="Label1" runat="server" Text="" ForeColor="red" Font-Italic="true"></asp:Label>
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
                <asp:TextBox ID="PageTitle" runat="server" Width="200px"></asp:TextBox>
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
            <td align="right" valign="top">
                Page Script :
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
                <asp:Button ID="btnsubmit" runat="server" CssClass="btnbg" Text="Submit" OnClick="btnsubmit_Click" />&nbsp;
                <asp:Button ID="btncancel" runat="server" CssClass="btnbg" Text="Cancel" Visible="false" CausesValidation="false" />
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
