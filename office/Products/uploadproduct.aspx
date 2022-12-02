
<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="uploadproduct.aspx.cs" Inherits="backoffice.office.Products.uploadproduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        #ptag
        {
            padding-bottom: 1px;
            font-size: 16px;
            color: #9a292a;
            font-weight: 600;
        }
        
        .mkmage-overlay
        {
            display: block;
            position: fixed;
            width: 100%;
            height: 100%;
            opacity: 0.5;
            background-color: #363636 !important;
            z-index: 10000;
            top: 0;
            left: 0;
        }
    </style>

    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="53%" class="head1" colspan="2">
                Upload Product
            </td>
        </tr>
        <tr>
            <td colspan="2" class="h_dot_line">
                &nbsp;
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="1" cellspacing="0" width="400">
        <tr>
            <td class="headingtext">
                <div class="error" align="left" id="trerror" runat="server">
                    <asp:Label ID="lblerror" runat="server"></asp:Label>
                </div>
                <div class="success" align="left" id="trsuccess" runat="server">
                    <asp:Label ID="lblsuccess" runat="server"></asp:Label>
                </div>
                <div class="notice" align="left" id="trnotice" runat="server">
                    <asp:Label ID="lblnotice" runat="server"></asp:Label>
                </div>
            </td>
        </tr>
    </table>
    <table width="350" border="0" cellpadding="2" cellspacing="2">
        <tr>
            <td align="left">
                <input id="File1" class="" type="file" runat="server" size="20" />
                &nbsp;<asp:LinkButton ID="lnkdownload" runat="server" OnClick="lnkdownload_Click" Visible="true">Sample file</asp:LinkButton>
                <asp:TextBox ID="txtfile" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <div class="load" style="text-align: center">
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <div class="mkmage-overlay">
                    </div>
                    <img alt="Loading..." src="/images/ajax-loader.gif" width="25px" width="25px" />
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>

        <tr>
            <td align="left">
                <asp:TextBox ID="txtfileupload" runat="server" Visible="false"></asp:TextBox>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btnbg" />
            </td>
        </tr>
        
    </table>
</asp:Content>
