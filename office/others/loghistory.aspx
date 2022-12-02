<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="loghistory.aspx.cs" Inherits="backoffice.office.others.loghistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />
    <script type="text/javascript" src="../../calendar_js/epoch_classes.js"></script>
    <script type="text/javascript">
        /*You can also place this code in a separate file and link to it like epoch_classes.js*/
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=sdate.ClientID%>'));
            dp_cal1 = new Epoch('epoch_popup', 'popup', document.getElementById('<%=edate.ClientID%>'));

        };
    </script>
    <h2>
        Log History</h2>
    <div class="content-panel">
        <table id="TABLE1" cellpadding="2" cellspacing="0" width="100%">
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
                <td align="center" colspan="2">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="From date must be later To Date"
                        ControlToCompare="sdate" ControlToValidate="edate" Type="Date" Operator="GreaterThanEqual"
                        Display="Dynamic">
                    </asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="10">
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <table border="0" cellpadding="2" cellspacing="0" style="width: 100%">
                        <tr>
                            <td align="center" colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch" GroupingText="Search"
                                    Width="80%">
                                    <table id="Table3" border="0" cellpadding="2" cellspacing="0" class="panelbg" width="100%">
                                        <tr>
                                            <td align="left" colspan="4" height="5">
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td align="right" width="20%">
                                                Date From :
                                            </td>
                                            <td align="left">
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="sdate" runat="server" contentEditable="false" MaxLength="100" Width="200px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <img src="../assets/calendar.png" border="0" alt="Select Order start date." runat="server"
                                                                id="Img2" onclick="dp_cal.toggle();" width="25" />
                                                        </td>
                                                        <td>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="sdate"
                                                                CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                                                                ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="right" width="20%">
                                                Date To :
                                            </td>
                                            <td align="left">
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="edate" runat="server" contentEditable="false" MaxLength="100" Width="200px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <img src="../assets/calendar.png" border="0" alt="Select Order start date." runat="server"
                                                                id="Img1" onclick="dp_cal1.toggle();" width="25" />
                                                        </td>
                                                        <td>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="edate"
                                                                CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                                                                ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="4" height="10">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnbg" OnClick="btnSearch_Click" />
                                                <asp:Button ID="btnExport" runat="server" Text="Export To Excel" CssClass="btnbg"
                                                    OnClick="btnExport_Click" />
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
                            <td align="center" colspan="4" height="10">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="10">
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="50" Width="100%"
                        AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging"
                        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1 %>.
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="IP" Visible="true">
                                <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                <ItemTemplate>
                                    <%#Eval("ip")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Page">
                                <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                <ItemTemplate>
                                    <%#Eval("pagetitle")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Module" Visible="true">
                                <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                <ItemTemplate>
                                    <%#Eval("pagetable")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Type" Visible="true">
                                <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                <ItemTemplate>
                                    <%#Eval("addeditmode")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="User">
                                <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                <ItemTemplate>
                                    <%#Eval("userid")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Delete">
                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#Eval("historyid")%>'
                                        CommandName="btndel" ImageUrl="~/office/assets/Remove_24x24.png" />
                                    <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to delete this?"
                                        TargetControlID="btndel">
                                    </ajaxToolkit:ConfirmButtonExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle HorizontalAlign="Right" />
                        <PagerStyle HorizontalAlign="Right" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
