<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="service.aspx.cs" Inherits="backoffice.office.Services.service" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add Services</h2>
<div class="content-panel">
 <table id="TABLE1" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td class="head1" style="width: 29%">
               
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
            <td align="left" colspan="2">
                <table id="Table2" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                   <tr>
                        <td align="right" width="15%">
                            Service Type<span class="star">*</span> :&nbsp;
                        </td>
                        <td align="left" style="width: 85%">
                         <asp:DropDownList ID="stypeid" runat="server" Width="200px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="stypeid"
                    Display="Dynamic" InitialValue="0" ErrorMessage="Required"></asp:RequiredFieldValidator>
                          
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="15%">
                            Service Name<span class="star">*</span> :&nbsp;
                        </td>
                        <td align="left" style="width: 85%">
                            <asp:TextBox ID="servicename" CssClass="box" runat="server" Width="600px"></asp:TextBox>
                             <asp:TextBox ID="serviceid" CssClass="box" runat="server" Visible="False" Width="600px"></asp:TextBox>
                            <asp:CheckBox ID="status" runat="server" Visible="False" Checked="True" />
                         <asp:CheckBox ID="showonhome" runat="server" Visible="False" Checked="True" />
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="servicename"
                                Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                   
                    <tr>
                        <td align="right" width="15%" valign="top">
                            Small desc : &nbsp;
                        </td>
                        <td align="left" style="width: 85%">
                            <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="smalldesc" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" width="15%" valign="top">
                            Details desc : &nbsp;
                        </td>
                        <td align="left" style="width: 85%">
                            <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="details" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                      <tr  style="display:none">
                        <td align="right" width="15%" valign="top">
                            Details1 desc : &nbsp;
                        </td>
                        <td align="left" style="width: 85%">
                            <CKEditor:CKEditorControl ID="CKeditor3" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="details1" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>


                      <tr>
                <td align="right" style="width: 15%">
                    Upload Image :&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <input id="File1" runat="server" class="box" contenteditable="false" type="file" />
                    <asp:TextBox ID="smallimage" runat="server" CssClass="box" MaxLength="100" TabIndex="3"
                        Width="359px" Visible="false"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"  Visible="false" Text="Remove Image"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%">
                </td>
                <td align="left" style="width: 85%">
                    <asp:Image ID="Image1" runat="server" Width="100px" Height="100px" Visible="false" />
                </td>
            </tr>
                <tr>
                     <td align="right" style="width: 15%">
                    Home Image :&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <input id="File2" runat="server" class="box" contenteditable="false" type="file" />
                    <asp:TextBox ID="homebanner" runat="server" CssClass="box" MaxLength="100" TabIndex="3"
                        Width="359px" Visible="false"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton2" runat="server" Visible="false" OnClick="LinkButton2_Click" Text="Remove Image"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%">
                </td>
                <td align="left" style="width: 85%">
                    <asp:Image ID="Image2" runat="server" Width="100px" Height="100px" Visible="false" />
                </td>
            </tr>    


                     <tr>
                        <td align="right" width="15%">
                            Display Order
                        </td>
                        <td align="left" style="width: 85%">
                            <asp:TextBox ID="displayorder" CssClass="box" runat="server" Width="84px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                                ControlToValidate="displayorder" ErrorMessage="Enter Numeric" Display="Dynamic"
                                ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                   
                  
                    <tr style="display: none">
                        <td class="head1" colspan="2" style="font-size: small;" nowrap>
                            SEO Information</td>
                    </tr>
                    <tr >
                        <td align="right">
                            Page Title :&nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="PageTitle" runat="server" Width="600px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr >
                        <td align="right" valign="top">
                            Meta Keywords :</td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="pagemeta" runat="server" Height="50px" TextMode="MultiLine" Width="600px" /></td>
                    </tr>
                    <tr >
                        <td align="right" valign="top">
                            Meta Description :</td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="pagemetadesc" runat="server" Height="50px" TextMode="MultiLine"
                                Width="600px"></asp:TextBox></td>
                    </tr>
                    <tr>
                            <td align="right" valign="top">
                                Page Script :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="pagescript" runat="server" Height="50px" TextMode="MultiLine"
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
                                <asp:CheckBox ID="no_indexfollow" runat="server"></asp:CheckBox>
                            </td>
                        </tr>
                      <tr>
                        <td align="right">
                        </td>
                        <td align="left" height="10">
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td align="left">
                            <asp:Button ID="btnsubmit" runat="server" CssClass="btnbg" Text="Submit" OnClick="btnsubmit_Click" />
                            
                        </td>
                    </tr>
                </table>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
    </table>
</div>
</asp:Content>
