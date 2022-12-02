<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mapproject.aspx.cs" Inherits="backoffice.office.Services.mapproject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
 <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="2" align="center" class="head1">
                <img id="image" runat="server" width="110" height="110" style="display: none" />
                <h3>
                    Map Project
                </h3>
                <b></b>
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
            <td align="center">
                <table border="0" cellpadding="2" cellspacing="2" width="80%">
                    <tr>
                        <td align="right" style="width: 15%">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 85%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 85%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%" valign="top">
                            Project: <span class="star">*</span> :&nbsp;
                        </td>
                        <asp:Panel ID="panelChk" runat="server">
                            <td align="left" style="width: 85%">
                                <asp:DataList ID="projectlist" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
                                    <ItemTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td width="90%" align="left">
                                                    <asp:CheckBox ID="checkfeature" runat="server" />
                                                    <asp:Label ID="lblprojectname" runat="server" Text='<%#Eval("projectname")%>'
                                                        Visible="true"></asp:Label>
                                                   
                                                    <asp:Label ID="lblprojectid" runat="server" Text='<%#Eval("projectid")%>'
                                                        Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </asp:Panel>
                    </tr>
                   
                    <tr>
                        <td>
                        </td>
                        <td align="center">
                            <asp:Button ID="Button1" Visible="false" runat="server" Text="Submit" TabIndex="15"
                                class="btnbg" ValidationGroup="addnew" OnClick="Button1_Click" />
                        </td>
                    </tr>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
