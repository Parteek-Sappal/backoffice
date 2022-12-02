<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="addphotogallery.aspx.cs" Inherits="backoffice.office.gallery.addphotogallery" Theme="backtheme" ValidateRequest="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
        function showpreview(input) {

            if (input.files && input.files[0]) {
                document.getElementById("imgpreview").style.display = 'inline';
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgpreview').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }

        }

        function showpreviewl(input) {

            if (input.files && input.files[0]) {
                document.getElementById("imgpreviewl").style.display = 'inline';
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgpreviewl').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }

        }

     </script>
    <h2> Add/Edit Photo </h2>
    <div class="content-panel">
    <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="2" class="head1">
                <asp:TextBox ID="photoid" runat="server" Visible="False" Width="33px"></asp:TextBox>
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
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr style=" display:none">
            <td align="right" style="width: 15%">
                <span class="star">*</span>Album :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:DropDownList ID="albumid" runat="server">
                </asp:DropDownList>
             <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="albumid"
                    Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td align="right">
                Image Title<span class="star"></span> :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="phototitle" runat="server" Width="359px"></asp:TextBox>
                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="phototitle"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td align="right">
                Upload Small Image<span class="star">*</span> :&nbsp;
            </td>
            <td align="left">
                <input id="File1" runat="server" class="box" contenteditable="false" onchange="showpreview(this);"
                    type="file" /><asp:TextBox ID="Uploadphoto" runat="server" Visible="False" Width="122px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                <img id="imgpreview" height="100" width="100" src="" style="display: none;" />
                <asp:Image ID="Image1" runat="server" Visible="False" Height="100" Width="100" />
            </td>
        </tr>
        <tr>
            <td align="right">
                Upload Large Image<span class="star">*</span> :&nbsp;
            </td>
            <td align="left">
                <input id="File2" runat="server" class="box" contenteditable="false" onchange="showpreviewl(this);"
                    type="file" />
                <asp:TextBox ID="largeimage" runat="server" Visible="False" Height="100" Width="100"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"></asp:LinkButton>&nbsp;&nbsp;<asp:Label
                    ID="Label1" runat="server" Text="(Image should be of size : 288x209px)" ForeColor="red"
                    Font-Italic="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                <img id="imgpreviewl" height="100" width="100" src="" style="display: none;" />
                <asp:Image ID="Image2" runat="server" Visible="False" Height="100" Width="100" />
            </td>
        </tr>
        <tr>
            <td align="right">
                Display Order :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="displayorder" runat="server" Width="44px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                    ControlToValidate="displayorder" ErrorMessage="Enter Numeric" Display="Dynamic"
                    ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                Status :&nbsp;
            </td>
            <td align="left">
                <asp:CheckBox ID="status" runat="server" Checked="True" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
            </td>
        </tr>
        <tr>
            <td style="height: 10px;">
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnbg" OnClick="btnSubmit_Click" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnbg" CausesValidation="False"
                    OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
    </div>
    <asp:Repeater ID="Repeater1" runat="server" Visible="False">
        <ItemTemplate>
            <asp:TextBox ID="txt1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>'
                Visible="false">
            </asp:TextBox>
            <asp:TextBox ID="txt2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "parentid") %>'
                Visible="false">
            </asp:TextBox>
            <asp:TextBox ID="txt3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Depth") %>'
                Visible="false">
            </asp:TextBox>
            <img height="1" width='<%#DataBinder.Eval(Container.DataItem, "Depth")%>' />
            <asp:LinkButton ID="lnk1" runat="server" CausesValidation="False" CommandName="edit">
												<%# DataBinder.Eval(Container.DataItem, "Name") %>
            </asp:LinkButton>
            <br />
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
