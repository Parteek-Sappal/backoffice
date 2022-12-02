<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="backoffice.office.Products.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />
    <script type="text/javascript" src="../../calendar_js/epoch_classes.js"></script>
    <script src="../../fancybox/jquery.mousewheel-3.0.4.pack.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#various4").fancybox({
                'width': '50%',
                'height': '40%',
                'autoScale': false,
                'scrolling': 'no',
                'transitionIn': 'elastic',
                'transitionOut': 'elastic',
                'type': 'iframe'
            });
        });
    </script>
    <div class="content-panel">
        <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
            <tr>
                <td align="left">
                    <h2>
                        Welcome To
                        <asp:Label ID="lblcollage" runat="server"></asp:Label>
                        -Micro Site
                    </h2>
                </td>
                <td width="30%" align="right">
                    <h2>
                        <a href="/office/products/viewproducts.aspx" style="color: Black">Back To Products</a></h2>
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
            <tr bgcolor="#6E83BA" style="display: none">
                <td colspan="2">
                    <table id="TABLE2" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="color: #ffffff; font-size: larger; font-weight: bolder; height: 30px;
                                padding-left: 10px;" width="30%">
                                <%--<asp:Label ID="lblcollage" runat="server"></asp:Label>--%>
                            </td>
                            <td width="70%" align="right">
                                <a href="/office/collage/viewcollage.aspx" style="color: White"><b>Back To School</b></a>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="10">
                    <asp:TextBox ID="collageid" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
