<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="viewmedia_section.aspx.cs" Inherits="backoffice.office.media.viewmedia_section" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script type="text/javascript" src="/fancybox/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />

    <script type="text/javascript">
        $(document).ready(function () {
            $(".toptxtcampus").fancybox({
                'width': '60%',
                'height': '60%',
                'autoScale': true,
                'scrolling': true,
                'transitionIn': 'elastic',
                'transitionOut': 'elastic',
                'type': 'iframe'
            });
        });
    </script>
    <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />
    <script type="text/javascript" src="../../calendar_js/epoch_classes.js"></script>
    <script type="text/javascript">
        /*You can also place this code in a separate file and link to it like epoch_classes.js*/
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=TextBox5.ClientID%>'));
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=TextBox6.ClientID%>'));
        };
    </script>
     <h2> View Media Section</h2>
<div class="content-panel">
    <table id="TABLE1" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td class="head1" style="width: 20%">
                
            </td>
            <td align="right" style="width: 80%">
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
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" height="10">
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="End date must be later than Start date"
                    ControlToCompare="TextBox5" ControlToValidate="TextBox6" Type="Date" Operator="GreaterThan"
                    Display="Dynamic">
                </asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch" GroupingText="Search"
                    Width="80%">
                    <table id="Table3" border="0" cellpadding="2" cellspacing="0" class="panelbg" width="100%">
                        <tr>
                            <td align="left" colspan="4" height="5">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Title
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="box" Width="200px"></asp:TextBox>
                            </td>
                            <td align="right">
                                Media Type
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ntypeid" runat="server" Width="200px">
                                </asp:DropDownList>
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
                                &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnbg" OnClick="btnSearch_Click1" />
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
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="50" Width="100%"
                    AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" 
                    OnRowCommand="GridView1_RowCommand1" 
                    onpageindexchanging="GridView1_PageIndexChanging1">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Media Type">
                            <ItemTemplate>
                                <%# Eval("ntype")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="left" Width="10%" />
                            <HeaderStyle HorizontalAlign="left" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Title">
                            <ItemTemplate>
                                <%# Eval("EventsTitle")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" Width="20%" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Location" Visible="false">
                            <ItemTemplate>
                                <%# Eval("location")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" Width="20%" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Events Date">
                            <ItemStyle Width="8%" />
                            <ItemTemplate>
                                <%#Eval("eventsdate", "{0:dd/MM/yyyy}")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Color" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                            <ItemTemplate>
                                <asp:Label ID="lblcolor" runat="server" Text='<%#Eval("colorcode")%>' Visible="false"></asp:Label>
                                <asp:TextBox ID="txtcolor" Width="19" CssClass="txtbox" runat="server" BorderStyle="None"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Download File" Visible="true">
                            <ItemStyle Width="8%" />
                            <ItemTemplate>
                                <asp:Label ID="lbldown" runat="server" Text='<%#Eval("uploadfile")%>' Visible="false"></asp:Label>
                                <asp:Label ID="lblsmallimg" runat="server" Text='<%#Eval("UploadEvents")%>' Visible="false"></asp:Label>
                                <asp:Label ID="lbllargeimg" runat="server" Text='<%#Eval("largeimage")%>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="downbtn" runat="server" CausesValidation="false" CommandArgument='<%# Eval("Eventsid") %>'
                                    CommandName="downbtn">
                                    <asp:Image ID="imgDown" runat="server" BorderWidth="0" ImageUrl="~/backoffice/assets/Download_24x24.png" /></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Publish">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status") %>' Visible="false"></asp:Label>
                                <asp:ImageButton ID="lnkstatus" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%# Eval("Eventsid") %>' CommandName="status"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Show on home" Visible="true">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lblshowonhome" runat="server" Text='<%#Eval("showonhome") %>' Visible="false"></asp:Label>
                                <asp:ImageButton ID="lnkshowonhome" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%# Eval("Eventsid") %>' CommandName="lnkshowonhome"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Show on School" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lblshowonschool" runat="server" Text='<%#Eval("showonschool") %>' Visible="false"></asp:Label>
                                <asp:ImageButton ID="lnkshowonschool" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%# Eval("Eventsid") %>' CommandName="lnkshowonschool"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Show on Group" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lblshowongroup" runat="server" Text='<%#Eval("showongroup") %>' Visible="false"></asp:Label>
                                <asp:ImageButton ID="lnkshowongroup" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%# Eval("Eventsid") %>' CommandName="lnkshowongroup"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date" Visible="false">
                            <ItemStyle Width="8%" />
                            <ItemTemplate>
                                <%#Eval("Eventsdate", "{0:dd/MM/yyyy}")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Displayorder" HeaderText="DisplayOrder" Visible="true">
                            <HeaderStyle HorizontalAlign="center" Width="8%" />
                            <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                        </asp:BoundField>
                         <asp:TemplateField HeaderText="Map Campus"  Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                          <a class="toptxtcampus" href='mapmediacampus.aspx?Eventsid=<%#(Eval("Eventsid"))%>'>
                                    <img src="../assets/Preview_24x24.png" border="0"></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%# Eval("Eventsid") %>'
                                    CommandName="edit" ImageUrl="~/office/assets/edit.png" ToolTip="Click to Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%# Eval("Eventsid") %>'
                                    CommandName="del" ImageUrl="~/office/assets/Remove_24x24.png" />
                                <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to delete this?"
                                    TargetControlID="btndel">
                                </ajaxToolkit:ConfirmButtonExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Add Keyword" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="7%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <a id='various1<%# ((GridViewRow)Container).RowIndex + 1 %>' class="toptxt" visible="false"
                                    href='add_mediasection_keyword.aspx?medid=<%#Eval("Eventsid")%>'>
                                    <img border="0" src="../assets/Text Document_24x24.png" alt="" />
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Add Gallery" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="7%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Literal Text='<%# Eval("ntypeid")%>' ID="lit_Eventsid" Visible="false" runat="server" />
                                <asp:Panel runat="server" ID="pnl_gallery" Visible="false">
                                    <a id='various2<%# ((GridViewRow)Container).RowIndex + 1 %>' class="toptxt" visible="false"
                                        href='event_gallery.aspx?Eventsid=<%#Eval("Eventsid")%>'>
                                        <img border="0" src="../assets/Text Document_24x24.png" alt="" />
                                    </a>
                                </asp:Panel>
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
