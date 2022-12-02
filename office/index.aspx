<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/sigininmaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="backoffice.office.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4>
    <strong>Admin Login </strong>
</h4>
<div class="error" align="left" id="trerror" runat="server" visible="false">
    &nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server"></asp:Label>
</div>
<div class="notice" align="left" id="trnotice" runat="server" visible="false">
    <asp:Label ID="lblnotice" runat="server"></asp:Label>
</div>
<div class="input-login">
    <label>
        User Name</label>
    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtUser"
        Display="None" ErrorMessage="Required"></asp:RequiredFieldValidator>
    <ajaxToolkit:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="txtUser"
        WatermarkText="Enter Username" WatermarkCssClass="watermarked" />
    <ajaxToolkit:ValidatorCalloutExtender ID="checkid" runat="server" TargetControlID="RequiredFieldValidator5"
        HighlightCssClass="validatorCalloutHighlight" CssClass="BlockPopup">
    </ajaxToolkit:ValidatorCalloutExtender>

</div>

<div class="input-login">
    <label>
        Password
    </label>
    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPass"
        Display="None" ErrorMessage="Required"></asp:RequiredFieldValidator>
    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
        TargetControlID="txtPass" WatermarkText="Password" WatermarkCssClass="watermarked" />
    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
        TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
        CssClass="BlockPopup">
    </ajaxToolkit:ValidatorCalloutExtender>
</div>

<div class="btn-login">
    <asp:Button ID="Button1" runat="server" CssClass="" Text="Sign In" onclick="login" />
</div>
<div style="display: none">
    <asp:Button ID="Button2" runat="server" CssClass="btnbghome" Text="Sign Off" 
        CausesValidation="false" /></div>
<asp:LinkButton ID="lnkForgotPswd" runat="server" CausesValidation="false" Visible="false">Forgot Password</asp:LinkButton>
<asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none"
    Height="350px" ScrollBars="Vertical" Width="500px">
    <div class="head1">
        User Profile&nbsp;
    </div>
    <div class="headingtext">
        <asp:Label ID="Label7" runat="server" ForeColor="red"></asp:Label>
    </div>
    <p>
        Please change your password and fill your email.</p>
    <asp:Label ID="Label5" runat="server" Font-Bold="True">User Name :</asp:Label>&nbsp;
    &nbsp;<asp:Label ID="UserId" runat="server"></asp:Label>
    <asp:Label ID="Label2" runat="server" Font-Bold="True">Password :</asp:Label>&nbsp;
    &nbsp;<asp:TextBox ID="UserPassword" runat="server" TextMode="password" ValidationGroup="profilegroup"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
        ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="UserPassword"
        Display="dynamic" ValidationGroup="profilegroup"></asp:RequiredFieldValidator>
    <asp:Label ID="Label4" runat="server" Font-Bold="True">Confirm Password :</asp:Label>&nbsp;
    &nbsp;<asp:TextBox ID="txtConPassword" runat="server" TextMode="password" ValidationGroup="profilegroup"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
        ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="txtConPassword"
        Display="dynamic" ValidationGroup="profilegroup"></asp:RequiredFieldValidator><asp:CompareValidator
            ID="CompareValidator1" runat="server" ErrorMessage="Password Mismatch" Display="Dynamic"
            ControlToCompare="UserPassword" ControlToValidate="txtConPassword"></asp:CompareValidator>
    <asp:Label ID="Label3" runat="server" Font-Bold="True">Name :</asp:Label>
    &nbsp;<asp:TextBox ID="Name" runat="server" ValidationGroup="profilegroup"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
        ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="Name"
        Display="dynamic" ValidationGroup="profilegroup"></asp:RequiredFieldValidator>
    <asp:Label ID="Label6" runat="server" Font-Bold="True">Email :</asp:Label>&nbsp;
    &nbsp;<asp:TextBox ID="Email" runat="server" ValidationGroup="profilegroup"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
        ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="Email"
        Display="dynamic" ValidationGroup="profilegroup"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
            ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email"
            ControlToValidate="Email" Display="dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            ValidationGroup="profilegroup"></asp:RegularExpressionValidator>
    <asp:Button ID="btnSave" runat="server" Text="Update" CssClass="btnbg" ValidationGroup="profilegroup" />&nbsp;
    <asp:Button ID="btnsubmit" runat="server" CssClass="btnbg" Text="Close" CausesValidation="false" />
</asp:Panel>
<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
    CancelControlID="btnsubmit" DropShadow="false" PopupControlID="Panel1" PopupDragHandleControlID="panelDragHandle"
    TargetControlID="btnShowModalPopup">
</ajaxToolkit:ModalPopupExtender>
<asp:Button ID="btnShowModalPopup" runat="server" Style="display: none" />
<table width="100%" runat="server" visible="false" id="trdate" border="0" cellpadding="0"
    cellspacing="0">
    <tr>
        <td colspan="3">
            <asp:TextBox ID="txtdate" runat="server" AutoComplete="Off"></asp:TextBox>
            <asp:TextBox ID="txtadmin" runat="server" AutoComplete="Off"></asp:TextBox>
            <asp:TextBox ID="txtencrypt" runat="server" AutoComplete="Off" TextMode="Password"></asp:TextBox>
         <%--   <asp:Button ID="bntsubmit" runat="server" Text="Button" ValidationGroup="testsubmit"
                OnClick="bntsubmit_Click" />--%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdate"
                Display="Dynamic" ErrorMessage="Required" ValidationGroup="testsubmit"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtdate"
                CssClass="msgvalidator" Display="Dynamic" ValidationGroup="testsubmit" ErrorMessage="Required"
                ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
            <div>
                &nbsp;</div>
            <div>
                <asp:TextBox ID="txtshow" runat="server" Visible="false"></asp:TextBox>
                <%--<asp:Button ID="btnshow" runat="server" Text="Button" OnClick="btnshow_Click" CausesValidation="false" />--%>
                <asp:Label ID="lblfirst" runat="server" Visible="false"></asp:Label><br />
                <asp:Label ID="lblsecond" runat="server" Visible="false"></asp:Label>
            </div>
        </td>
    </tr>
</table>
</asp:Content>
