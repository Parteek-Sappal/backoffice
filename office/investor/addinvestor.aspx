<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="addinvestor.aspx.cs" Inherits="backoffice.office.investor.addinvestor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
    $(function () {
        CKEDITOR.replace('<%=CKeditor1.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
        CKEDITOR.replace('<%=CKeditor2.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
        CKEDITOR.replace('<%=CKeditor3.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
    });
    </script>
 <h2>Add/Edit Investor</h2>
<div class="content-panel">
    <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr style="display:none">
            <td align="left" colspan="2" class="head1">
                <asp:TextBox ID="investorid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                <asp:TextBox ID="linkposition" runat="server" Visible="False" Width="33px"></asp:TextBox>
                <asp:TextBox ID="collageid" runat="server" Visible="False" Width="33px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="h_dot_line">
                &nbsp;
            </td>
        </tr>   
        <tr bgcolor="#6E83BA"  id="tr1" runat="server" visible="false">
        <td colspan="2">
            <table id="TABLE2" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="color: #ffffff; font-size: larger; font-weight: bolder; height: 30px;
                        padding-left: 10px;" width="30%">
                        <asp:Label ID="lblcollage" runat="server"></asp:Label>
                    </td>
                    <td width="70%" align="right">
                        <a href="/backoffice/collage/viewcollage.aspx" style="color: White"><b>Back To Colleges/Institutes</b></a> &nbsp;
                    </td>
                </tr>
            </table>
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
            <td align="right" colspan="2">
                Fields with <span class="star">*</span>are mandatory</td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                Parent Page :</td>
            <td align="left" style="width: 85%">
                <asp:DropDownList ID="parentid"  runat="server" Width="602px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                Page Name<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="pagename" runat="server" Width="600px" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="pagename"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right">
                Link Name<span class="star">*</span> :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="linkname" runat="server" Width="600px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="linkname"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                Tag Line<span class="star"></span> :&nbsp;
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="tagline" runat="server" Width="600px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tagline"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
     <tr>  <%--style="display:none"--%>
            <td align="right" valign="top">
                Page Position :&nbsp;</td>
            <td align="left" valign="top">
                <asp:CheckBoxList ID="linkpositionstatus" runat="server" RepeatDirection="Horizontal"
                    Width="50%">
                    <asp:ListItem>Header</asp:ListItem>
                   <%-- <asp:ListItem>Top-Links</asp:ListItem>--%>
                    <asp:ListItem>Left Side Menu</asp:ListItem>
                    <asp:ListItem>Right Side Menu</asp:ListItem>
                    <asp:ListItem>Footer</asp:ListItem>
                    <%--<asp:ListItem>Sub-Footer</asp:ListItem>--%>
                  <%--<asp:ListItem>Internal</asp:ListItem>
                    <asp:ListItem>quick-links</asp:ListItem>--%>
                     
                </asp:CheckBoxList></td>
        </tr>

          <tr>
            <td align="right" valign="top">
                Mega Menu :&nbsp;
                    <br />
                  <span style="font-style: italic; color: red;">(required wherever applicable)</span>
            </td>
            <td align="left">
                <asp:TextBox ID="megamenu" runat="server" Visible="False"></asp:TextBox>
                  <CKEditor:CKEditorControl ID="CKeditor3" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                Short Description :&nbsp;
                <br />
                <span style="font-style:italic; color: red;">(required wherever applicable)</span>
            </td>
            <td align="left">
                <asp:TextBox ID="smalldesc" runat="server" Visible="False"></asp:TextBox>
                <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                Page Description :&nbsp;
                    <br />
                  <span style="font-style: italic; color: red;">(required wherever applicable)</span>
            </td>
            <td align="left">
                <asp:TextBox ID="Pagedescription" runat="server" Visible="False"></asp:TextBox>
                <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
            </td>
        </tr>

        <tr style="display:none">
            <td align="right" valign="top">
                Page Description1 :&nbsp;
                   <br />
                  <span style="font-style: italic; color: red;">(required wherever applicable)</span>
            </td>
            <td align="left">
                <asp:TextBox ID="PageDescription1" runat="server" Visible="False"></asp:TextBox>
                <CKEditor:CKEditorControl ID="CKeditor4" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
            </td>
        </tr>
          <tr style="display:none">
            <td align="right" valign="top">
                Page Description2 :&nbsp;
                   <br />
                  <span style="font-style: italic; color: red;">(required wherever applicable)</span>
            </td>
            <td align="left">
                <asp:TextBox ID="PageDescription2" runat="server" Visible="False"></asp:TextBox>
                <CKEditor:CKEditorControl ID="CKeditor5" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
            </td>
        </tr>
      
        <tr>
            <td align="right">
                Upload Banner :&nbsp;
            </td>
            <td align="left">
                <input id="File1" runat="server" contenteditable="false" type="file" class="box" />
                <asp:TextBox ID="UploadBanner" runat="server" Visible="False"></asp:TextBox></td>
        </tr>
        <tr >
            <td align="right">
            </td>
            <td align="left">
                <asp:Image ID="Image1" runat="server" Height="120px" Visible="False" Width="400px" /></td>
        </tr>
        <tr >
            <td align="right">
            </td>
            <td align="left">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="toptxt" Visible="False" OnClick="LinkButton1_Click">Remove Banner</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td align="right">
                Display Order :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="displayorder" runat="server" Width="33px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                    ControlToValidate="displayorder" ErrorMessage="Enter Numeric" Display="Dynamic"
                    ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="head1" colspan="2" style="font-size: small;" nowrap>
                SEO Information</td> 
        </tr>
         <tr style="display:none" >
            <td align="right">
                Re-writeurl :&nbsp;
            </td>
            <td align="left">
            <asp:TextBox ID="dynamicurlvalue" runat="server" Visible="true" Width="600px" ></asp:TextBox>
              <asp:TextBox ID="dynamicurlrewrte" runat="server" Visible="false" Width="33px"></asp:TextBox>

              <asp:TextBox ID="rewriteurl" runat="server" Visible="false" Width="222px"></asp:TextBox>
              <asp:TextBox ID="rewriteid" runat="server" Visible="False" Width="33px"></asp:TextBox>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="dynamicurlvalue"
                    CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Only use alphanumeric and -,_"
                    ValidationExpression="^[a-zA-Z0-9-_]*$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                Page Title :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="PageTitle" runat="server" Width="600px"></asp:TextBox>
                 <asp:TextBox ID="pageurl"  runat="server" Visible="false" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                Meta Keywords :</td>
            <td align="left" valign="top">
                <asp:TextBox ID="pagemeta" runat="server" Height="50px" TextMode="MultiLine" Width="600px" /></td>
        </tr>
        <tr>
            <td align="right" valign="top">
                Meta Description :</td>
            <td align="left" valign="top">
                <asp:TextBox ID="pagemetadesc" runat="server" Height="50px" TextMode="MultiLine"
                    Width="600px"></asp:TextBox></td>
        </tr>


         <tr>
            <td align="right" valign="top">
                Page Script :</td>
            <td align="left" valign="top">
                <asp:TextBox ID="other_schema" runat="server" Height="50px" TextMode="MultiLine"
                    Width="600px"></asp:TextBox></td>
        </tr>


        <tr style="display: none">
            <td align="right" valign="top">
                Target :</td>
            <td align="left" valign="top">
                <asp:DropDownList ID="target" CssClass="select" runat="server">
                    <asp:ListItem>_self</asp:ListItem>
                    <asp:ListItem>_blank</asp:ListItem>
                    <asp:ListItem>_parent</asp:ListItem>
                    <asp:ListItem>_search</asp:ListItem>
                    <asp:ListItem>_top</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="display: none;">
            <td align="right">
                Status :&nbsp;
            </td>
            <td align="left">
                <asp:CheckBox ID="Pagestatus" runat="server" /></td>
        </tr>
        <tr style="display: none;">
            <td align="right">
                Quick Links :&nbsp;
            </td>
            <td align="left">
                <asp:CheckBox ID="quicklinks" runat="server" /></td>
        </tr>
        <tr style="display: none;">
            <td align="center" colspan="2">
                <asp:CheckBox ID="restricted" runat="server" />&nbsp;
            </td>
        </tr>


        <tr>
            <td valign="top" align="right">
                <span class="star"></span>Canonical : &nbsp;
            </td>
            <td>
                <asp:TextBox ID="canonical" runat="server" Width="500px"></asp:TextBox>
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
            <td align="right">
            </td>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnbg" OnClick="btnSubmit_Click" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnbg" CausesValidation="False" OnClick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                <asp:Repeater ID="Repeater1" runat="server" Visible="False">
                    <ItemTemplate>
                        <asp:TextBox ID="txt1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "investorid") %>'
                            Visible="false">
                        </asp:TextBox>
                        <asp:TextBox ID="txt2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "parentid") %>'
                            Visible="false">
                        </asp:TextBox>
                        <asp:TextBox ID="txt3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Depth") %>'
                            Visible="false">
                        </asp:TextBox>
                        <img height="1" width='<%# DataBinder.Eval(Container.DataItem, "Depth") %>' />
                        <asp:LinkButton ID="lnk1" runat="server" CausesValidation="False" CommandName="edit">
												<%#DataBinder.Eval(Container.DataItem, "PageName")%>
                        </asp:LinkButton>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
            </td>
        </tr>
    </table>
</div>
</asp:Content>
