<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="mapallproduct.aspx.cs" Inherits="backoffice.office.Products.mapallproduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../../fancybox/1.4/jquery.min.js"></script>
    <script type="text/javascript" src="../../fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="../../fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="../../fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <script type="text/javascript">
        $(document).ready(function () {
            $(".toptxt").fancybox({
                'width': '90%',
                'height': '90%',
                'autoScale': true,
                'scrolling': 'yes',
                'transitionIn': 'elastic',
                'transitionOut': 'elastic',
                'type': 'iframe'
            });
        });
    </script>
     <script type="text/javascript">
         $(document).ready(function () {
             $(".toptxt1").fancybox({
                 'width': '90%',
                 'height': '90%',
                 'autoScale': true,
                 'scrolling': 'yes',
                 'transitionIn': 'elastic',
                 'transitionOut': 'elastic',
                 'type': 'iframe'
             });
         });
     </script>
 <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="head1">
                            Add Map Products</td>
                        <td align="right">
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
                Fields with <span style="color: #ff0000">*</span> are mandatory
                <asp:TextBox ID="pmapid" Visible="false" runat="server" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
           <tr>
            <td align="right" colspan="2">
            <tr >
                 <td align="right" colspan="4">
                 <a id="upload_intall" href="uploadmapallproducts.aspx" class="toptxt">Map Products Upload</a>
                 </td> 
                  </tr>
                   <tr>
                  <td align="right" colspan="4">
                 <a id="upload_intall1" href="Uploadstock.aspx" class="toptxt1">Stock Upload</a>
                 </td>        
                 </tr> 
            </td>
          </tr>
        <tr>
            <td colspan="2">
                <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                    <tr>
                        <td valign="top" width="15%" align="right">
                            Category<span class="star">*</span> : &nbsp;</td>
                        <td width="85%">
                            <asp:DropDownList ID="pcatid" runat="server" Width="200px" 
                                onselectedindexchanged="pcatid_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="pcatid"
                                Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                      <tr>
                        <td valign="top" width="15%" align="right">
                           Sub Category<span class="star">*</span> : &nbsp;</td>
                        <td width="85%">
                            <asp:DropDownList ID="psubcatid" runat="server" Width="200px" 
                                onselectedindexchanged="psubcatid_SelectedIndexChanged" AutoPostBack="true" >
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="psubcatid"
                                Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                        </td>
                      </tr>

                       <tr style="display:none">
                        <td valign="top" width="15%" align="right">
                           Sub Sub Category<span class="star">*</span> : &nbsp;</td>
                        <td width="85%">
                            <asp:DropDownList ID="psubsubcatid" runat="server" Width="200px">
                            <asp:ListItem Selected="True" Value="0">select</asp:ListItem>
                            </asp:DropDownList>
                           
                        </td>
                    </tr>
                         <tr>
                        <td valign="top" width="15%" align="right">
                          Product<span class="star">*</span> : &nbsp;</td>
                        <td width="85%">
                            <asp:DropDownList ID="productid" runat="server" Width="200px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="productid"
                                Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                       <tr>
                        <td valign="top" width="15%" align="right">
                            Color<span class="star">*</span> : &nbsp;</td>
                        <td width="85%">
                            <asp:DropDownList ID="colorid" runat="server" Width="200px"> 
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="colorid"
                                Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                      <tr >
                        <td valign="top" width="15%" align="right">
                            Size<span class="star">*</span> : &nbsp;</td>
                        <td width="85%">
                            <asp:DropDownList ID="sizeid" runat="server" Width="200px"> 
                            </asp:DropDownList>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="sizeid"
                                Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                   <tr>
                        <td valign="top" width="15%" align="right">
                            Series<span class="star"></span> : &nbsp;</td>
                        <td width="85%">
                            <asp:DropDownList ID="orientationid" runat="server" Width="200px" 
                               >
                            </asp:DropDownList>
                          <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="orientationid"
                                Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr >
                        <td valign="top" width="15%" align="right">
                            Type<span class="star"></span> : &nbsp;</td>
                        <td width="85%">
                            <asp:DropDownList ID="typeid" runat="server" Width="200px" >
                            </asp:DropDownList>
                          <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="typeid"
                                Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                   <tr >
                        <td valign="top" width="15%" align="right">
                            Feature<span class="star"></span> : &nbsp;</td>
                        <td width="85%">
                            <asp:DropDownList ID="featureid" runat="server" Width="200px" 
                               >
                            </asp:DropDownList>
                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="featureid"
                                Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                  
                       <tr>
               <td align="right">
                Upload Image<span class="star">*</span> :&nbsp;
                
            </td>
            
            <td align="left">
                <input id="File1" runat="server" class="box" contenteditable="false"  onchange="showpreview(this);" type="file" />&nbsp;<asp:Label
                    ID="Label1" runat="server" Text="(Image should be of size : 288x209.)"
                    ForeColor="red" Font-Italic="true" Visible="false"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="(Gallery Image show on homepage should be of size : 500 x 511.)"
                    ForeColor="red" Font-Italic="true" Visible="false"></asp:Label>
                      <asp:LinkButton ID="LinkButton1" runat="server" CssClass="toptxt" Visible="false" OnClick="LinkButton1_Click">Remove File</asp:LinkButton>
                     <asp:TextBox ID="UploadAImage" runat="server" Visible="False" Width="122px">
                
                
                
                </asp:TextBox>
                    </td>
                    
               
                
        </tr>


                  
                     
                          <tr>
                        <td align="right">
                        </td>
                        <td align="left">
                            <asp:Image ID="Image1" runat="server" Height="120px" Visible="False" Width="107px" /></td>
                    </tr>


                      

          
                    <tr style="display:none">
                        <td align="right" valign="top">
                            Status:&nbsp;
                        </td>
                        <td align="left">
                             <asp:CheckBox ID="status" runat="server" Checked="False"/>
                        </td>
                    </tr>


                  


                     <tr>
                        <td valign="top" align="right">
                            Price<span class="star">*</span> : &nbsp;</td>
                        <td>
                            <asp:TextBox ID="price" runat="server" Width="100px"></asp:TextBox>
                              <asp:RegularExpressionValidator ID="Regularexpressionvalidator2" runat="server"
                                ControlToValidate="price" ErrorMessage="Enter Numeric" Display="Dynamic"
                                ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="price"
                                Display="Dynamic" ErrorMessage="Required" ></asp:RequiredFieldValidator>
                       
                        </td>
                    </tr>

                   <tr>
                        <td valign="top" align="right">
                            Stock Availability<span class="star"></span> : &nbsp;</td>
                        <td>
                            <asp:TextBox ID="stock" runat="server" Width="200px"></asp:TextBox>
                              
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="stock"
                                Display="Dynamic" ErrorMessage="Required" ></asp:RequiredFieldValidator>--%>
                       
                        </td>
                    </tr>

                    <tr>
                        <td valign="top" align="right">
                           ERP Code<span class="star"></span> : &nbsp;</td>
                        <td>
                            <asp:TextBox ID="erpcode" runat="server" Width="200px"></asp:TextBox>                                                         
                       
                        </td>
                    </tr>
 

               
                   
                  
                    <tr>
                        <td valign="top">
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnbg" OnClick="btnSubmit_Click" />&nbsp;<asp:Button
                                ID="btnCancel" runat="server" Text="Cancel" CssClass="btnbg" CausesValidation="False" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
