<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="addhomebanner.aspx.cs" Inherits="backoffice.office.homebanner.addhomebanner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function showpreview(input) {

            if (input.files && input.files[0]) {
                document.getElementById("imgpreview").style.display = 'inline';
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgpreview').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
        function showpreview1(input) {

            if (input.files && input.files[0]) {
                document.getElementById("imgpreview1").style.display = 'inline';
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgpreview1').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }

    </script>
    
   <h2>Add Home Banner</h2>
<div class="content-panel">
    <asp:Panel ID="panel1" runat="server" DefaultButton="btnSubmit">
        <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
            <tr>
                <td class="head1" colspan="2">
                    <asp:TextBox ID="bid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                    <asp:TextBox ID="collageid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="h_dot_line">
                    &nbsp;
                </td>
            </tr>
            <tr bgcolor="#6E83BA" id="tr1" runat="server" visible="false">
                <td colspan="2">
                    <table id="TABLE2" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="color: #ffffff; font-size: larger; font-weight: bolder; height: 30px;
                                padding-left: 10px;" width="30%">
                                <asp:Label ID="lblcollage" runat="server"></asp:Label>
                            </td>
                            <td width="70%" align="right">
                                <a href="/office/products/viewproducts.aspx" style="color: White"><b>Back To Products</b></a>&nbsp;
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
                    Fields with <span class="star">*</span>are mandatory
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="Label1" runat="server" SkinID="redtext" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr >
                <td align="right" style="width: 15%">
                  Type<span class="star">*</span>:&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:DropDownList ID="btypeid" runat="server"  Width="350">
                 
                    </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required"
                        ControlToValidate="btypeid" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                  
                </td>
            </tr>

             <tr >
                <td align="right" style="width: 15%">
                  Device Type<span class="star">*</span>:&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:DropDownList ID="devicetype" runat="server"  Width="350">
                    <asp:ListItem Selected="True" Value="Desktop">Desktop</asp:ListItem>
                     <asp:ListItem  Value="Mobile">Mobile</asp:ListItem>
                    </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required"
                        ControlToValidate="devicetype" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                  
                </td>
            </tr>


            <tr>
                <td align="right" style="width: 15%">
                    Title<span class="star">*</span> :&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:TextBox ID="title" runat="server" Width="350"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required"
                        ControlToValidate="title" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%" valign="top">
                    Tag Line:&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="tagline1" runat="server" Width="350" Height="50" TextMode="MultiLine"
                        Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none">
                <td align="right" style="width: 15%" valign="top">
                    Tag Line2:&nbsp;
                </td>
                <td align="left" style="width: 85%">
                <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="tagline2" runat="server" Width="350" Height="50" TextMode="MultiLine" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%">
                   Banner<span class="star">*</span> :&nbsp;
                </td>
                <td align="left" style="width:85%">
                    <input id="File1" runat="server" class="box" style="width:350px"  contenteditable="false" onchange="showpreview(this);"
                        type="file" />
                    <br />
                    <asp:Label ID="lblapl" runat="server"  Font-Italic="true"
                        ForeColor="#ff0000"></asp:Label>
                    <asp:TextBox ID="bannerimage" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td align="right" style="width: 15%">
                </td>
                <td align="left" style="width: 85%">
                    <img id="imgpreview" height="100" width="100" src="" style="display: none;" />
                    <asp:Image ID="Image1" runat="server" Height="100px" Visible="False" Width="100px" />
                     <video width="200px" height="200px" playsinline="playsinline" autoplay="autoplay" muted="muted" loop="loop" runat="server" Visible="false" id="pvideo">
                                                <source runat="server" id="showvideo" type="video/mp4" />
                                          </video>
                </td>
            </tr>

              <tr style="display:none">
                <td align="right" style="width: 15%">
                    Mobile Banner<span class="star"></span> :&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <input id="File2" runat="server" class="box" style="width:350px"  contenteditable="false" onchange="showpreview1(this);"
                        type="file" />
                    <br />
                    <asp:Label ID="Label2" runat="server"  Font-Italic="true"
                        ForeColor="#ff0000"></asp:Label>
                    <asp:TextBox ID="bannermobile" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>

            <tr style="display:none">
                <td align="right" style="width: 15%">
                </td>
                <td align="left" style="width: 85%">
                    <img id="imgpreview1" height="100" width="100" src="" style="display: none;" />
                    <asp:Image ID="Image2" runat="server" Height="100px" Visible="False" Width="100px" />
                     
                </td>
            </tr>

             <tr>
                <td align="right" style="width: 15%">
                    Logo Banner<span class="star"></span> :&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <input id="File3" runat="server" class="box" style="width:350px"  contenteditable="false" onchange="showpreview1(this);"
                        type="file" />
                    <br />
                    <asp:Label ID="Label3" runat="server"  Font-Italic="true"
                        ForeColor="#ff0000"></asp:Label>
                    <asp:TextBox ID="blogo" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td align="right" style="width: 15%">
                </td>
                <td align="left" style="width: 85%">
                    <img id="img3" height="100" width="100" src="" style="display: none;" />
                    <asp:Image ID="Image3" runat="server" Height="100px" Visible="False" Width="100px" />
                     
                </td>
            </tr>
            <tr >
                <td align="right" style="width: 15%" valign="top">
                    Url:&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:TextBox ID="url" runat="server" Width="350"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Display Order :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="displayorder" runat="server" Width="39px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                        ControlToValidate="displayorder" Display="Dynamic" ErrorMessage="Enter Numeric"
                        ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr style="display: none">
                <td align="right">
                    Status :&nbsp;
                </td>
                <td align="left">
                    <asp:CheckBox ID="Status" runat="server" Checked="true" />
                </td>
            </tr>
            
            <tr>
                <td align="center" colspan="2">
                </td>
            </tr>
            <tr>
                <td style="height: 10px;">
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="15" CssClass="btnbg"
                        OnClick="btnSubmit_Click" />
                    &nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="False"
                        TabIndex="16" CssClass="btnbg" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    </div>
</asp:Content>
