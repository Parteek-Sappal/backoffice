<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="media_section.aspx.cs" Inherits="backoffice.office.media.media_section" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="/App_Themes/backtheme/ajax_stylesheet.css" rel="stylesheet" type="text/css" />
    <link href="/App_Themes/backtheme/backoffice.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/calendar_js/epoch_styles.css" />
    <script type="text/javascript" src="/calendar_js/epoch_classes.js"></script>
    <script type="text/javascript">
        /*You can also place this code in a separate file and link to it like epoch_classes.js*/
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=Eventsdate.ClientID%>'));
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=eventedate.ClientID%>'));
        };
    </script>
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace('<%=CKeditor1.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
            CKEDITOR.replace('<%=CKeditor2.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
        });
    </script>
    <h2>
        Add Media Section</h2>
    <div class="content-panel">
        <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
            <tr>
                <td align="left" colspan="4">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td class="head1">
                            </td>
                            <td align="right">
                                &nbsp;<asp:TextBox ID="Eventsid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                                <asp:CheckBox ID="status" runat="server" Visible="False" Checked="true" />
                                <asp:CheckBox ID="archive" runat="server" Visible="False" Checked="true" />
                                <asp:CheckBox ID="showonhome" runat="server" Visible="False" Checked="false" />
                                <asp:CheckBox ID="showonschool" runat="server" Visible="False" Checked="false" />
                                <asp:CheckBox ID="showongroup" runat="server" Visible="False" Checked="false" />
                                &nbsp;&nbsp; &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="h_dot_line">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="headingtext" colspan="4">
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
                <td align="right" colspan="4">
                    Fields with <span style="color: #ff0000">*</span> are mandatory
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="10">
                    <%-- <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Event start date must be later/equal than end date"
                    ControlToCompare="Eventsdate" ControlToValidate="eventedate" Type="Date"
                    Operator="GreaterThanEqual" Display="Dynamic">
                </asp:CompareValidator>--%>
                </td>
            </tr>
            <tr >
                <td valign="top" align="right">
                    Media Type<span class="star">*</span> : &nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="ntypeid" runat="server" Width="500px" 
                       AutoPostBack="true" onselectedindexchanged="ntypeid_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ntypeid"
                        Display="Dynamic" InitialValue="0" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%">
                    Title<span class="star">*</span> :&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:TextBox ID="EventsTitle" runat="server" CssClass="box" Width="500px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="EventsTitle"
                        Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr  >
                <td align="right">
                    Tagline/Notification No<span class="star"></span> :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="tagline" runat="server" CssClass="box" Width="500px"></asp:TextBox>
                </td>
            </tr>
           
            <tr style="display: none">
                <td align="right">
                    Event Location<span class="star"></span> :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="location" runat="server" CssClass="box" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none">
                <td align="right">
                    Type<span class="star">*</span> :&nbsp;
                </td>
                <td align="left">
                    <asp:DropDownList ID="types" runat="server" Width="500px">
                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                        <asp:ListItem Value="Text" Text="Text"></asp:ListItem>
                        <asp:ListItem Value="Image" Text="Image"></asp:ListItem>
                        <asp:ListItem Value="Video" Text="Video"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Date<span class="star"></span> :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="Eventsdate" runat="server" CssClass="box" Width="200px"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Eventsdate"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Eventsdate"
                    CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                    ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
                    
                </td>
             
            <tr>
                <td align="right">
                    Choose Colour<span class="star"></span> :&nbsp;
                </td>
                <td align="left" style="height: 19px">
                    <script type="text/javascript" src="../../jscolor/jscolor.js"></script>
                    <asp:TextBox ID="colorcode" runat="server" Width="200px" CssClass="color"></asp:TextBox>
                    <%--<asp:TextBox ID="colorcode" runat="server" Width="243px" class="color" value="66ff00"></asp:TextBox>--%>
                </td>
            </tr>
            <tr style="display: none">
                <td align="right">
                    Event End Date<span class="star">*</span> :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="eventedate" runat="server" CssClass="box" Width="66px" Text="01/01/2000"></asp:TextBox>
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="eventedate"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="eventedate"
                    CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                    ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>--%>
                </td>
                <%-- <td align="right" style="width: 15%">
                Event Date :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="eventedate" runat="server" CssClass="box" Width="120px"></asp:TextBox>
            </td>--%>
            </tr>
            <tr>
                <td align="right" valign="top">
                    Short Description :&nbsp;
                </td>
                <td align="left" colspan="3">
                    <CKEditor:CKEditorControl ID="CKeditor2" runat="server" BasePath="~/ckeditor/" Height="150px"
                        Width="90%">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="shortdesc" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    Description :&nbsp;
                </td>
                <td align="left" colspan="3">
                    <CKEditor:CKEditorControl ID="CKeditor1" runat="server" BasePath="~/ckeditor/" Height="250px"
                        Width="90%">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="EventsDesc" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Upload Small Image :&nbsp;
                </td>
                <td align="left">
                    <input id="File1" runat="server" contenteditable="false" style="width:500px" type="file" class="box" />
                    &nbsp;
                    <%--    <asp:Label
                    ID="Label3" runat="server" Text="(Events and News Image should be of size : 405 x 264.)"
                    ForeColor="red" Font-Italic="true"></asp:Label>--%>
                    
                    <asp:TextBox ID="UploadEvents" runat="server" Visible="False"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="left">
                    <asp:Image ID="Image1" runat="server" Visible="False" Width="100" Height="100" />
                    <asp:LinkButton ID="lnkremove" runat="server" Visible="False" Style="color: Black"
                        CausesValidation="False" OnClick="lnkremove_Click">Remove Image</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Upload Large Image :&nbsp;
                </td>
                <td align="left">
                    <input id="File3" runat="server" contenteditable="false" style="width:500px" type="file" class="box" />
                    &nbsp;
                    <%--   <asp:Label
                    ID="Label2" runat="server" Text="(News Detail Image should be of size : 900 x 586.)"
                    ForeColor="red" Font-Italic="true"></asp:Label>--%>
                    <asp:TextBox Visible="false" ID="largeimage" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="left">
                    <asp:Image ID="imglarge" runat="server" Visible="False" Width="100" Height="100" />
                    <asp:LinkButton ID="lnklarge" Visible="False" runat="server" Style="color: Black"
                        OnClick="lnklarge_Click">Remove Image</asp:LinkButton>
                </td>
            </tr>
            <tr style="display: none">
                <td align="right">
                    Upload Home Image :&nbsp;
                </td>
                <td align="left">
                    <input id="File4" runat="server" contenteditable="false" style="width:500px" type="file" class="box" />
                    &nbsp;
                    <asp:TextBox Visible="false" ID="homeimage" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none">
                <td align="right">
                </td>
                <td align="left">
                    <asp:Image ID="imghome" runat="server" Visible="False" Width="100" Height="100" />
                    <asp:LinkButton ID="lnkhome" Visible="False" runat="server" Style="color: Black"
                        OnClick="lnkhome_Click">Remove Image</asp:LinkButton>
                </td>
            </tr>
            <tr style="display:none;">
                <td align="right">
                    Upload Very Lage Image :&nbsp;
                </td>
                <td align="left">
                    <input id="File5" runat="server" contenteditable="false" style="width:500px" type="file" class="box" />
                    &nbsp;
                    <asp:TextBox Visible="false" ID="verylargeimage" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="left">
                    <asp:Image ID="imageverylarge" runat="server" Visible="False" Width="100" Height="100" />
                    <asp:LinkButton ID="lnkverylarge" Visible="False" runat="server" Style="color: Black"
                        OnClick="lnkverylarge_Click">Remove Image</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Upload File :&nbsp;
                </td>
                <td align="left" colspan="3">
                    <input id="File2" runat="server" class="box" contenteditable="false" style="width:500px" type="file" />
                    &nbsp;<asp:Label ID="Label5" runat="server" Text="(Upload file for Press Release)"
                        ForeColor="red" Font-Italic="true"></asp:Label>
                    <asp:TextBox ID="uploadfile" runat="server" Visible="False"></asp:TextBox>
                    <asp:LinkButton ID="lnkremovefile" runat="server" CausesValidation="false" Visible="false"
                        OnClick="lnkremovefile_Click">Remove File</asp:LinkButton>
                </td>
            </tr>
            <tr >
                <td align="right">
                    Url :&nbsp;
                </td>
                <td align="left" colspan="3">
                    <asp:TextBox ID="youtube_url" runat="server" class="box" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Display Order :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="displayorder" runat="server" class="box" Width="50px"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                        FilterType="Numbers" TargetControlID="displayorder" />
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" height="10">
                    <b>SEO Section</b>
                </td>
            </tr>
            <tr style="display: none">
                <td align="right" style="width: 15%; height: 26px;" valign="top">
                    <span class="star"></span>Rewrite URL :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="rewriteurl" runat="server" Visible="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%; height: 26px;" valign="top">
                    <span class="star"></span>Page Name :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="PageTitle" runat="server" class="box" Visible="true" Width="500"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%; height: 26px;" valign="top">
                    <span class="star"></span>Page Meta :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="PageMeta" runat="server" class="box" Visible="true" Width="500" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%; height: 26px;" valign="top">
                    <span class="star"></span>Page Description :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="PageMetaDesc" runat="server" class="box" Visible="true" Width="500" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    Page Script :
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="other_schema" runat="server" class="box" Height="50px" TextMode="MultiLine"
                        Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                    <span class="star"></span>Canonical : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="canonical" runat="server" class="box" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    No Index Follow :
                </td>
                <td align="left" valign="top">
                    <asp:CheckBox ID="no_indexfollow" runat="server"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="10">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnsubmit" runat="server" CssClass="btnbg" Text="Submit" OnClick="btnsubmit_Click" />&nbsp;
                    <asp:Button ID="btncancel" runat="server" CssClass="btnbg" Text="Cancel" CausesValidation="false"
                        OnClick="btncancel_Click" />&nbsp;
                </td>
            </tr>
            <tr style="display: none">
                <td align="left" colspan="2">
                 
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
