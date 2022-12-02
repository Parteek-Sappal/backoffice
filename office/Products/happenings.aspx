<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="happenings.aspx.cs" Inherits="backoffice.office.Products.happenings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />
    <script type="text/javascript" src="../../calendar_js/epoch_classes.js"></script>
    <script src="../../fancybox/jquery.mousewheel-3.0.4.pack.js" type="text/javascript"></script>
    <script type="text/javascript">
        /*You can also place this code in a separate file and link to it like epoch_classes.js*/
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=TextBox5.ClientID%>'));
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=TextBox6.ClientID%>'));
        };
    </script>
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
    <h2>
        Map Media</h2>
    <div class="content-panel">
        <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
            <tr>
                <td align="left" colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
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
            <tr bgcolor="#6E83BA">
                <td colspan="2">
                    <table id="TABLE2" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="color: #ffffff; font-size: larger; font-weight: bolder; height: 30px;
                                padding-left: 10px;" width="30%">
                                <asp:Label ID="lblcollage" runat="server"></asp:Label>
                            </td>
                            <td width="70%" align="right">
                                <a href="/backoffice/products/viewproducts.aspx" style="color: White"><b>Back To Products</b></a>
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
            <tr>
                <td colspan="2" align="center">
                    <asp:Panel ID="Panel2" runat="server" DefaultButton="btnSearch" GroupingText="Search"
                        Width="80%">
                        <table id="Table4" border="0" cellpadding="2" cellspacing="0" class="panelbg" width="100%">
                            <tr>
                                <td align="left" colspan="4" height="5">
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Media Type
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ntypeid" runat="server" AutoPostBack="True" Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    &nbsp;Title
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox4" runat="server" CssClass="box" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Start Date
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox5" runat="server" contentEditable="false" CssClass="box"
                                        MaxLength="100" Width="200px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox5"
                                        CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                                        ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
                                </td>
                                <td align="right">
                                    End Date
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox6" runat="server" contentEditable="false" CssClass="box"
                                        MaxLength="100" Width="200px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox6"
                                        CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                                        ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="4" height="10">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnbg" OnClick="btnSearch_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4" height="5">
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" width="100%">
                    <asp:Panel ID="Panel1" runat="server" GroupingText="Map Media" CssClass="mapping"
                        Width="100%" BorderStyle="Groove">
                        <table id="Table3" border="0" cellpadding="2" cellspacing="0" width="100%">
                           <tr width="100%">
                                <td align="right">
                                </td>
                                <td align="right">
                                    Department:<asp:DropDownList ID="drpdept" runat="server" AutoPostBack="True" Width="200px"
                                        OnSelectedIndexChanged="drpdept_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                           
                            <tr width="100%">
                                <td align="left" colspan="2">
                                    <asp:DataList ID="dl_sgroup" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
                                        Width="100%">
                                        <ItemTemplate>
                                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                                <tr>
                                                 <td>
                                                   <%# Container.ItemIndex + 1%>. 
                                                  </td>
                                                    <td>
                                                        <asp:CheckBox ID="checkfeature" runat="server" />
                                                    </td>
                                                    <td class="faculty-name">
                                                        <asp:Label ID="lblcname" runat="server" Text='<%# Eval("EventsTitle") %>' Visible="true"></asp:Label>
                                                        <asp:Label ID="lblEventsid" runat="server" Text='<%#(Eval("Eventsid")) %>' Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        Display Order:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtdisplayorder" runat="server" Width="70px"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                                                            ControlToValidate="txtdisplayorder" Display="Dynamic" ErrorMessage="Enter Numeric"
                                                            ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="showcheck" runat="server" />
                                                    </td>
                                                    <td>
                                                        Show on home
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle Width="50%" />
                                    </asp:DataList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="10">
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" TabIndex="15" CssClass="btnbg"
                        ValidationGroup="addnew" OnClick="btnsubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
