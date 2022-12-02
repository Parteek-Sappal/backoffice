<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="media_coverage.aspx.cs" Inherits="backoffice.office.media.media_coverage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
<h2>
        Add Media Coverage</h2>
    <div class="content-panel">
      <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width:100%">
           
            <tr>
                <td colspan="2" class="h_dot_line">
                    &nbsp;
                </td>
            </tr>
             <tr style="display:none">
                <td valign="top" align="right">
                    Media Type<span class="star">*</span> : &nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="ntypeid" runat="server" Width="500">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ntypeid"
                        Display="Dynamic" InitialValue="0" ErrorMessage="Required"></asp:RequiredFieldValidator>
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
                <td align="left" colspan="2" height="10">
                    &nbsp;
                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <ajaxToolkit:AjaxFileUpload Width="400px" ID="AjaxFileUpload1" runat="server" ThrobberID="myThrobber"
                                MaximumNumberOFiles="10" OnUploadComplete="AjaxFileUpload1_UploadComplete"></ajaxToolkit:AjaxFileUpload>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <td>
                        &nbsp;
                    </td>
                </td>
            </tr>
            
            <tr>
                <td colspan="2" align="center" width="100%">
                
                    <table border="0" cellpadding="0" cellspacing="0" style="width:100%">
                        <tr>
                            <td valign="middle" width="15%" align="left">
                                <asp:Button ID="btnpublish" runat="server" Text="Preview" CssClass="btnbg" OnClick="btnpublish_Click" />
                                
                            </td>
                            <td width="85%" align="right">
                                </td>
                            <td>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp; &nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
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
                          
                        </tr>
                        <tr style="display:none">
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
       
        <tr width="100%" align="left" >
        <td  align="right"> 
        <asp:Button ID="btnEdit" runat="server" Text="Update" CssClass="btnbg" OnClick="btnEdit_Click" />
        </td>
        <td  align="left">
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btnbg" OnClick="btnDelete_Click" />
                        </td>
                       
                        </tr>
                       
                        <tr>
                        </tr>
                        <tr>
                        </tr>
                        <tr  width="100%">
                            <td  align="left" colspan="2">
                              
                                <asp:DataList ID="dtlview" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" Width="100%" OnItemDataBound="dtlview_ItemDataBound">
                                    <ItemTemplate>
                                          <table  border="1" cellpadding="2" cellspacing="0" width="100%">
                                          <tr>
                                          <td Width="20px">
                                                          <asp:Label ID="lbleventsid" runat="server" Visible="false" Text='<%#Eval("eventsid") %>'></asp:Label>
                                                    <asp:Label ID="lbluploadphoto" runat="server" Visible="false" Text='<%#Eval("UploadEvents") %>'></asp:Label>
                                                    <asp:CheckBox ID="chk" runat="server" />
                                                
                                                       </td>
                                             <td Width="20px">
                                                   <%# Container.ItemIndex + 1%>. 
                                                  </td>
                                                       
                                                        <td  Width="100px">
                                                         <asp:Image ID="img" runat="server" Width="100px" Height="100px" ImageUrl='<%# Bind("UploadEvents", "~/uploads/SmallImages/{0}")%>' />
                                               
                                                        </td>
                                                          <td width="300px">
                                                          Title    <asp:TextBox ID="txteventstitle" runat="server" Text='<%#Eval("eventstitle") %>' Width="100%"></asp:TextBox>
                                          
                                                          </td>
                                                           <td  Width="100px">
                                                           Diaplayorder  <asp:TextBox ID="txtdisplayorder" runat="server" Text='<%#Eval("displayorder") %>' Width="100px"></asp:TextBox>
                                         
                                                           </td>


                                                            <td  Width="100px">

                                                            
                                                          Date  <asp:TextBox ID="txtdate" runat="server" Text='<%#Eval("Eventsdate","{0:MM/dd/yyyy}") %>' Width="100px"></asp:TextBox>
                                                           <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtdate"
                                        Format="MM/dd/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                         
                                                           </td>
                                          </tr>
                                          

                                            
                                            

                                            
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" width="15%">
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                   
                </td>
            </tr>
        </table>
        </div>
</asp:Content>
