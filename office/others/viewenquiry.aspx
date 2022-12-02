<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="viewenquiry.aspx.cs" Inherits="backoffice.office.others.viewenquiry" Theme="backtheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <input type="hidden" value="<%=appno%>" name="appno" id="appno">
    <script type="text/javascript" src="/fancybox/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
          <link href="/App_Themes/backtheme/ajax_stylesheet.css" rel="stylesheet" type="text/css" />
    <link href="/App_Themes/backtheme/backoffice.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/calendar_js/epoch_styles.css" />
    <script type="text/javascript" src="/calendar_js/epoch_classes.js"></script>
    <script type="text/javascript">
        /*You can also place this code in a separate file and link to it like epoch_classes.js*/
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=sdate.ClientID%>'));
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=edate.ClientID%>'));
        };
    </script>
   <script type="text/javascript">
       $(document).ready(function () {
           var i = 0;
           var toappno = document.getElementById("appno").value;
           for (i = 1; i <= toappno; i++) {
               $("#various" + i).fancybox({
                   'width': '70%',
                   'height': '65%',
                   'autoScale': true,
                   'scrolling': true,
                   'transitionIn': 'elastic',
                   'transitionOut': 'elastic',
                   'type': 'iframe'
               });
           }
       });
   </script>

     <h2>View Contact Us Enquiry</h2>
<div class="content-panel">
    <table id="TABLE1" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td colspan="2" class="head1"></td>
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
            <td align="center" colspan="2">
                <asp:Label ID="Label1" runat="server" SkinID="redtext" ForeColor="Red"></asp:Label>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="End date must be later than Start date"
                    ControlToCompare="sdate" ControlToValidate="edate" Type="Date" Operator="GreaterThan"
                    Display="Dynamic">
                </asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr height="10">
            <td align="center" colspan="2">
                <asp:Panel ID="Panel3" runat="server" DefaultButton="btnSearch" GroupingText="Search"
                    Width="80%">
                    <table id="Table3" border="0" cellpadding="2" cellspacing="0" class="panelbg" width="100%">
                        <tr>
                            <td align="left" colspan="4" height="5">
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td align="right">
                                Query Type
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="QueryType" runat="server" CssClass="box">
                                    <asp:ListItem Selected="true" Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="1">New</asp:ListItem>
                                    <asp:ListItem Value="2">Existing</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Start Date
                            </td>
                            <td align="left">
                                <asp:TextBox ID="sdate" runat="server" contentEditable="false" MaxLength="100" Width="200px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="sdate"
                                    CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                                    ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
                            </td>
                            <td align="right">
                                End Date
                            </td>
                            <td align="left">
                                <asp:TextBox ID="edate" runat="server" contentEditable="false" MaxLength="100" Width="200px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="edate"
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
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnbg" OnClick="btnSearch_Click" />&nbsp;
                                <asp:Button ID="btnExport" runat="server" Text="Export" CausesValidation="false"
                                    CssClass="btnbg" OnClick="btnExport_Click" />
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
        <tr height="10">
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr height="10">
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="GridView1" runat="server" Width="100%" AllowPaging="True" PageSize="50" AutoGenerateColumns="False"
                    OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand"
                    OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemStyle HorizontalAlign="center" Width="5%" />
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemStyle HorizontalAlign="center" Width="15%" />
                            <ItemTemplate>
                                <%#Eval("FName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="City" Visible="false" HeaderText="City" />
                        <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                        <asp:BoundField DataField="Emailid" HeaderText="Email" />
                        <asp:BoundField DataField="category" HeaderText="Enquiry Type" ItemStyle-Width="15%" Visible="true">
                            <ItemStyle Width="15%"></ItemStyle>
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Course" >
                            <ItemStyle Width="10%" />
                            <ItemTemplate>
                                 <%#Eval("subject")%>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:BoundField DataField="Trdate" DataFormatString="{0: dd/MM/yyyy}" HeaderText="Enquiry Date"
                            ItemStyle-Width="15%">
                            <ItemStyle Width="15%"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Reply" Visible="false">
                            <ItemStyle Width="10%" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkreply" runat="server" CausesValidation="false" CommandArgument='<%# Eval("eid") %>'
                                    OnClick="lnkreply_Click"><img border="0" src="../../office/assets/Preview_24x24.png" alt="" /></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemStyle Width="10%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%# Eval("eid") %>'
                                    CommandName="btndel" ImageUrl="~/office/assets/Remove_24x24.png" />
                                <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to delete this?"
                                    TargetControlID="btndel">
                                </ajaxToolkit:ConfirmButtonExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Details" meta:resourcekey="TemplateFieldResource3">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemTemplate>
                                <a id='various<%# ((GridViewRow)Container).RowIndex + 1 %>' class="toptxt" visible="false"
                                    href='view-enquiry-details.aspx?&eid=<%#Eval("eid")%>'>
                                    <img border="0" width="25" height="25" src="../../office/assets/Preview_24x24.png"
                                        alt="" />
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="View" Visible="false">
                            <ItemStyle Width="10%" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkdetail" runat="server" CausesValidation="false" CommandArgument='<%# Eval("eid") %>'
                                    OnClick="lnkdetail_Click"><img border="0" src="../../office/assets/Preview_24x24.png" alt="" /></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Panel ID="Panel1" Height="300px" ScrollBars="Vertical" runat="server" CssClass="modalPopup"
                    Style="display: none" Width="500px">
                    <table border="0" cellpadding="2" cellspacing="0" width="100%" align="center">
                        <tr>
                            <td class="head1" colspan="2">
                                Enquiry Details
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="h_dot_line">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="Label3" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <table border="0" cellpadding="1" cellspacing="0" style="width: 70%">
                                    <tr>
                                        <td align="right" style="width: 30%" valign="top">
                                            Query Type :&nbsp;
                                        </td>
                                        <td align="left" style="width: 70%" valign="top">
                                            <asp:Label ID="lblquery" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 30%" valign="top">
                                            Name :&nbsp;
                                        </td>
                                        <td align="left" style="width: 70%" valign="top">
                                            <asp:Label ID="lblFName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="display: none">
                                        <td align="right" style="width: 30%" valign="top">
                                            Gender :&nbsp;
                                        </td>
                                        <td align="left" style="width: 70%" valign="top">
                                            <asp:Label ID="lblGender" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 30%" valign="top">
                                            Email :&nbsp;
                                        </td>
                                        <td align="left" style="width: 70%" valign="top">
                                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 30%" valign="top">
                                            Mobile :&nbsp;
                                        </td>
                                        <td align="left" style="width: 70%" valign="top">
                                            <asp:Label ID="lblMobile" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="display: none">
                                        <td align="right" style="width: 30%" valign="top">
                                            Telephone :&nbsp;
                                        </td>
                                        <td align="left" style="width: 70%" valign="top">
                                            <asp:Label ID="lblTelephone" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="tr_Project" visible="false">
                                        <td align="right" valign="top">
                                            Company Name :&nbsp;
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="display: none">
                                        <td align="right" style="width: 30%" valign="top">
                                            State :&nbsp;
                                        </td>
                                        <td align="left" style="width: 70%" valign="top">
                                            <asp:Label ID="lblState" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="display: none">
                                        <td align="right" style="width: 30%" valign="top">
                                            City :&nbsp;
                                        </td>
                                        <td align="left" style="width: 70%" valign="top">
                                            <asp:Label ID="lblCity" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="tr_message" visible="false">
                                        <td align="right" valign="top">
                                            Comments :&nbsp;
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top">
                                            Posted Date :&nbsp;
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:Label ID="lblPostedDate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Button ID="btnCancel" runat="server" Text="Close" CssClass="btnbg" CausesValidation="False"
                                                TabIndex="20" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
                    CancelControlID="btnCancel" DropShadow="false" PopupControlID="Panel1" PopupDragHandleControlID="panelDragHandle"
                    TargetControlID="btnShowModalPopup">
                </ajaxToolkit:ModalPopupExtender>
                <asp:Button ID="btnShowModalPopup" runat="server" Style="display: none" />
                <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup" Style="display: none"
                    Width="900px">
                    <table border="0" cellpadding="2" cellspacing="0" width="100%">
                        <tr>
                            <td class="head1" colspan="2">
                                Feedback Reply
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="h_dot_line">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="Label4" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td align="right" style="width: 30%">
                                            Reply To :&nbsp;
                                        </td>
                                        <td align="left" style="width: 70%">
                                            <asp:TextBox ID="txtemail" runat="server" ReadOnly="True" Rows="10" Width="196px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 30%">
                                            Reply :&nbsp;
                                        </td>
                                        <td align="left" style="width: 70%">
                                            <asp:TextBox ID="txtreply" runat="server" Rows="20" TextMode="MultiLine" Width="427px"
                                                Height="300px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnbg" TabIndex="20"
                                                OnClick="btnSubmit_Click" />
                                            <asp:Button ID="Button1" runat="server" Text="Cancel" CssClass="btnbg" CausesValidation="False"
                                                TabIndex="20" OnClick="Button1_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" BackgroundCssClass="modalBackground"
                    CancelControlID="Button1" DropShadow="false" PopupControlID="Panel2" PopupDragHandleControlID="panelDragHandle"
                    TargetControlID="btnShowModalPopup">
                </ajaxToolkit:ModalPopupExtender>
            </td>
        </tr>
    </table>
</div>
</asp:Content>
