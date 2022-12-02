<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="viewtestimonials.aspx.cs" Inherits="backoffice.office.Testimonials.viewtestimonials" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="/fancybox/jquery-1.4.3.min.js" type="text/javascript"></script>
     <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />
    <script type="text/javascript" src="../../calendar_js/epoch_classes.js"></script>
     <input type="hidden" value="<%=appno%>" name="appno" id="appno">
    <script type="text/javascript" src="../../fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="../../fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="../../fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
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
             var i = 0;
             var toappno = document.getElementById("appno").value;
             for (i = 1; i <= toappno; i++) {
                 $("#various_" + i).fancybox({
                     'width': '70%',
                     'height': '50%',
                     'autoScale': true,
                     'scrolling': true,
                     'transitionIn': 'elastic',
                     'transitionOut': 'elastic',
                     'type': 'iframe'
                 });
             }
         });
     </script>
       <h2>View Testimonials</h2>
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
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="box"></asp:TextBox>
                            </td>
                            <td align="right">
                                Testimonial Type
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="Tesid" runat="server" CssClass="box" Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td align="right">
                                Start Date
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBox5" runat="server" contentEditable="false" CssClass="box"
                                    MaxLength="100" Width="66px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox5"
                                    CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                                    ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
                            </td>
                            <td align="right">
                                End Date
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBox6" runat="server" contentEditable="false" CssClass="box"
                                    MaxLength="100" Width="66px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox6"
                                    CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                                    ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr >
                            <td align="right">
                                Text/Video
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="drttype" runat="server" CssClass="box" Width="200px">
                                    <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="Text Message">Text Message</asp:ListItem>
                                   <asp:ListItem Value="Video">Video</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" height="10">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnbg" OnClick="btnsearch_Click" />
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
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="50" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging" 
OnRowCommand="GridView1_RowCommand" 
OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center"  />
                            <ItemTemplate>
                              <%# ((GridViewRow)Container).DataItemIndex + 1%>.
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type" Visible="true">
                            <HeaderStyle HorizontalAlign="Center" Width="15%" />
                            <ItemStyle HorizontalAlign="Center"  />
                            <ItemTemplate>
                                <%# Eval("Testimonialtype")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Title">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center"  />
                            <ItemTemplate>
                                <%# Eval("Testimonialname")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Course">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center"  />
                            <ItemTemplate>
                                <%# Eval("course")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Designation" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                            <ItemStyle HorizontalAlign="Center"  />
                            <ItemTemplate>
                                <%# Eval("desg")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="displayorder" HeaderText="Display Order">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Image">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center"  />
                            <ItemTemplate>
                                <asp:TextBox ID="txtTestimonialImage" runat="server" Text='<%#Eval("Uploadphoto")%>'
                                    Visible="false"></asp:TextBox>
                                <img id="imageTestimonial" runat="server" width="90" height="75" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center"  />
                            <ItemTemplate>
                                <asp:TextBox ID="txtuploadvedio" runat="server" Text='<%#Eval("uploadvedio")%>'
                                    Visible="false"></asp:TextBox>
                                <img id="imagevideo" runat="server" visible="false" width="45" height="35" />
                                <img id="image" runat="server" visible="false" width="45" height="35" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Publish">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center"  />
                            <ItemTemplate>
                                <asp:TextBox ID="Uploadphoto" runat="server" Text='<%#Eval("Uploadphoto")%>' Visible="false"></asp:TextBox>
                                <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status") %>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkstatus" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%#(Eval("testimonialid")) %>' CommandName="status"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Map Schools" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                           
                             <a id='various_<%#((GridViewRow)Container).DataItemIndex + 1%>.' class="toptxt" visible="false"
                                    href='map_institiute_tetimonials.aspx?testimonialid=<%#(Eval("testimonialid"))%>'>
                                    <asp:Image id="mapimginst" runat="server" border="0" width="25" height="25" ImageUrl ="../assets/Preview_24x24.png" alt="" />
                                </a>


                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Show Home">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center"  />
                            <ItemTemplate>
                                <asp:TextBox ID="txtstatush" runat="server" Text='<%#Eval("showonhome") %>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkstatush" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%#(Eval("testimonialid")) %>' CommandName="statush"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Show Right" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center"  />
                            <ItemTemplate>
                                <asp:TextBox ID="txtstatush_right" runat="server" Text='<%#Eval("showright") %>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkstatush_right" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%#(Eval("testimonialid")) %>' CommandName="statush_right"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center"  />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("testimonialid")) %>'
                                    CommandName="edit" ImageUrl="~/office/assets/edit.png" ToolTip="Click to Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center"  />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("testimonialid")) %>'
                                    CommandName="del" ImageUrl="~/office/assets/Remove_24x24.png" />
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
