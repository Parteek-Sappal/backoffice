<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="addalbumtype.aspx.cs" Inherits="backoffice.office.gallery.addalbumtype" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <h2> Add/Edit Video Album Type</h2>
<div class="content-panel"> 

<table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="head1">
                           </td>
                        <td align="right" >
                            &nbsp;
                            <asp:TextBox ID="typeid" runat="server" Visible="true" Width="33px"></asp:TextBox>
                            <asp:CheckBox ID="status" runat="server" Visible="False" Checked="true" />
                        </td>
                    </tr>
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
        <tr>
            <td align="right" colspan="2">
                Fields with <span class="star">*</span> are mandatory</td>
        </tr>
        <tr>
            <td align="center" colspan="2" height="10">
            </td>
        </tr>

        <tr style="display:none">
                <td align="right" style="width: 15%">
               Type :&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:DropDownList ID="ntypeid" runat="server">
                    <asp:ListItem>0</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        <tr>
            <td align="right" style="width: 15%; height: 26px;">
              Video Album Type<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%; height: 26px;">
                <asp:TextBox ID="typename" runat="server" CssClass="box" MaxLength="100" TabIndex="3"
                    Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="typename"
                    Display="Dynamic" ErrorMessage="Required" ValidationGroup="album"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right">
                Thumbnail Image<span class="star">*</span> :&nbsp;
            </td>
            <td align="left">
                <input id="File1" runat="server" contenteditable="false"  style="width:250px" type="file" onchange="showpreview(this);" class="box" />
                <asp:TextBox ID="albumimage" runat="server" Width="200px" Visible="false"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <%--  <asp:Label ID="Label1" runat="server" Text="(Image should be of size : 288x209px)"  ForeColor="red" Font-Italic="true">
               </asp:Label>--%>
                 <asp:LinkButton ID="LinkButton2" runat="server" Visible="False" 
                    CausesValidation="False" onclick="LinkButton2_Click">Remove Thumbnail</asp:LinkButton></td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
            </td>
            <td align="left" style="width: 85%">
             <img id="imgpreview" height="100" width="100" src="" style="display:none;" />
                <asp:Image ID="Image1" runat="server" Visible="False" Width="100" Height="100" />
                </td>
        </tr>
         <tr style="display:none">
            <td align="right" valign="top">
                Upload Youtube Url :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="url" runat="server" Width="300px"></asp:TextBox>
                
                </td>
        </tr>
        <tr>
            <td align="right">Display Order :&nbsp;
            </td>
            <td align="left" >
                <asp:TextBox ID="displayorder" runat="server" Width="39px"></asp:TextBox>
               <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                    ControlToValidate="displayorder" Display="Dynamic" ErrorMessage="Enter Numeric"
                    ValidationExpression="^\d+?$" ValidationGroup="album"></asp:RegularExpressionValidator></td>
        </tr>
         <tr>
                <td align="left" colspan="2" height="10">
                    <b>SEO Section</b>
                </td>
            </tr>
            <tr style="display: none">
                <td align="right" style="width: 15%; height: 26px;" valign="top">
                    <span class="star"></span>Rewrite Url:&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="rewriteurl" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%; height: 26px;" valign="top">
                    <span class="star"></span>Page Name :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="PageTitle" runat="server" Visible="true" Width="500"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%; height: 26px;" valign="top">
                    <span class="star"></span>Page Meta :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="PageMeta" runat="server" Visible="true" Width="500" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%; height: 26px;" valign="top">
                    <span class="star"></span>Page Description :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="PageMetaDesc" runat="server" Visible="true" Width="500" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td align="right" valign="top">
                    Page Script:
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="other_schema" runat="server" Height="50px" TextMode="MultiLine"
                        Width="500px"></asp:TextBox>
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
                    <asp:CheckBox ID="no_indexfollow" runat="server" Checked="false"></asp:CheckBox>
                </td>
            </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left" >
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btnbg" 
                    ValidationGroup="album" OnClick="btnsubmit_Click" />&nbsp;

                    <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="btnbg" OnClick="btncancel_Click" CausesValidation="False" /></td>
        </tr>
        <tr>
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" 
                OnRowCommand="GridView1_RowCommand"   OnRowDataBound="GridView1_RowDataBound"  >
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).DataItemIndex + 1%>.
                               <asp:Label ID="Label1" runat="server" Text='<%#(Eval("typeid")) %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Album Type">
                             <HeaderStyle HorizontalAlign="center"  />
                            <ItemStyle HorizontalAlign="center"  />
                            <ItemTemplate>
                                <%#Eval("typename").ToString()%>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:BoundField DataField="displayorder" HeaderText="Display Order" >
                            <HeaderStyle HorizontalAlign="Center" Width="10%"/>
                            <ItemStyle HorizontalAlign="Center" Width="10%"/>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Publish">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                            <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status") %>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkstatus" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%#(Eval("typeid")) %>' CommandName="status"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("typeid")) %>'
                                    CommandName="edit" ImageUrl="~/backoffice/assets/edit.png" ToolTip="Click to Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("typeid")) %>'
                                    CommandName="del" ImageUrl="~/backoffice/assets/Remove_24x24.png" ToolTip="Click to Delete" />
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
    </table>
    </div>

</asp:Content>
