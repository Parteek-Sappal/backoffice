<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="city.aspx.cs" Inherits="backoffice.office.masters.city" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>  Add City</h2>
<div class="content-panel">
 <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="head1">
                            </td>
                        <td align="right">
                            &nbsp; &nbsp;<asp:TextBox ID="cityid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                             <asp:TextBox ID="displayorder" runat="server" Width="150px" Visible="false"></asp:TextBox>
                            &nbsp; &nbsp;&nbsp; &nbsp;
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
                Fields with <span class="star">*</span> are mandatory</td>
        </tr>
        <tr>
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                <span class="star">*</span>Country :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:DropDownList ID="countryid" runat="server" AutoPostBack="true" Width="350px" OnSelectedIndexChanged="countryid_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="countryid"
                    Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                <span class="star">*</span>State :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:DropDownList ID="sid" runat="server" Width="350px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="sid"
                    Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                <span class="star">*</span>City :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="cityname" runat="server" CssClass="box" TabIndex="3" Width="350px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cityname"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator></td>
        </tr>
       
        <tr>
            <td align="right">
                Status :&nbsp;
            </td>
            <td align="left" height="10">
                <asp:CheckBox ID="status" runat="server" Checked="true" /></td>
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
                <asp:Button ID="btncancel" runat="server" CssClass="btnbg" Text="Cancel" CausesValidation="false" OnClick="btncancel_Click" /></td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp; &nbsp;</td>
        </tr>
       
    </table>
    </div>
</asp:Content>
