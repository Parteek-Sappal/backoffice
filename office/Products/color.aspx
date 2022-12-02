<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="color.aspx.cs" Inherits="backoffice.office.Products.color" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../App_Themes/backtheme/ajax_stylesheet.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/backtheme/backoffice.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />
    <script type="text/javascript" src="../../calendar_js/epoch_classes.js"></script>
    <%--<script type="text/javascript">
        /*You can also place this code in a separate file and link to it like epoch_classes.js*/
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=Eventsdate.ClientID%>'));
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=eventedate.ClientID%>'));

        };
    </script>--%>
    <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="4">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="head1">
                            Add Color
                        </td>
                        <td align="right">
                            &nbsp;<asp:TextBox ID="colorid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                            <asp:CheckBox ID="status" runat="server" Visible="False" Checked="true" />
                            
                            <asp:CheckBox ID="showonhome" runat="server" Visible="False" Checked="false" />
                            &nbsp;&nbsp; &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="h_dot_line">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="headingtext" colspan="4">
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
            <td align="right" colspan="4">
                Fields with <span style="color: #ff0000">*</span> are mandatory
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" height="10">
             
            </td>
        </tr>
       
        <tr>
            <td align="right" style="width: 15%">
                Title<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="ColorTitle" runat="server"   Width="500px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ColorTitle"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr style="display:none;">
            <td align="right">
                Tagline<span class="star"></span> :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="tagline" runat="server" CssClass="box" Width="500px"></asp:TextBox>
            </td>
        </tr>

       
      
        <tr>
            <td align="right">
                Choose Colour<span class="star"></span> :&nbsp;
            </td>
            <td align="left" style="height: 19px">
                <script type="text/javascript" src="/jscolor/jscolor.js"></script>
                <asp:TextBox ID="colorcode" runat="server" Width="243px" CssClass="color"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td align="right">
                Upload Image :&nbsp;
            </td>
            <td align="left">
                <input id="File1" runat="server" contenteditable="false" type="file" class="box" /><asp:TextBox
                    ID="UploadImage" runat="server" Visible="False"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkremove" runat="server" Visible="False" 
                    CausesValidation="False" onclick="lnkremove_Click">Remove Image</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                <asp:Image ID="Image1" runat="server" Visible="False" Width="100" Height="100" />
            </td>
        </tr>
        
        <tr>
            <td align="right">
                Display Order :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="displayorder" runat="server" Width="31px"></asp:TextBox>
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterType="Numbers"
    TargetControlID="displayorder" />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" height="10">
                <b>SEO Section</b>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%; height: 26px;" valign="top">
                <span class="star"></span>Rewrite URL :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="rewriteurl" runat="server" Visible="true" Width="500"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%; height: 26px;" valign="top">
                <span class="star"></span>Page Name :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="PageTitle" runat="server" Visible="true" Width="500"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%; height: 26px;" valign="top">
                <span class="star"></span>Page Meta :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="PageMeta" runat="server" Visible="true" Width="500" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%; height: 26px;" valign="top">
                <span class="star"></span>Page Description :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="PageMetaDesc" runat="server" Visible="true" Width="500" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td valign="top" align="right" style="width: 15%; height: 26px;">
                <span class="star"></span>Canonical : &nbsp;
            </td>
            <td>
                <asp:TextBox ID="canonical" runat="server" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" style="width: 15%; height: 26px;">
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
                <asp:TextBox ID="pagescript" runat="server" Visible="true" Width="500" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnsubmit" runat="server" CssClass="btnbg" Text="Submit" 
                    onclick="btnsubmit_Click" />&nbsp;
                <asp:Button ID="btncancel" runat="server" CssClass="btnbg" Text="Cancel" 
                    CausesValidation="false" onclick="btncancel_Click" />&nbsp;
            </td>
        </tr>
       
    </table>
</asp:Content>
