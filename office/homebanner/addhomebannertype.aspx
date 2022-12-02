<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="addhomebannertype.aspx.cs" Inherits="backoffice.office.homebanner.addhomebannertype" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../../fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="../../fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="../../fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />

  
      <h2> Add/Edit Banner Type</h2>
<div class="content-panel"> 

<table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">

 <tr>
                <td class="head1" colspan="2">
                   <asp:TextBox ID="collageid" runat="server" Visible="False" Width="33px"></asp:TextBox>
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
                                <a href="/backoffice/products/viewproducts.aspx" style="color: White"><b>Back To Products</b></a>&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        
        <tr>
            <td align="left" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="head1">
                           </td>
                        <td align="right" >
                            &nbsp;
                            <asp:TextBox ID="btypeid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                            <asp:CheckBox ID="Status" runat="server" Visible="False" Checked="false" />
                            <asp:CheckBox ID="mobilestatus" runat="server" Visible="False" Checked="false" />
                             
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
        <tr style="display:inline" >
            <td align="right" style="width: 15%; height: 26px;">
              Banner Type<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%; height: 26px;">
                <asp:DropDownList ID="btype" runat="server" Width="214px">
                 <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                <asp:ListItem Value="Banner">Banner</asp:ListItem>
                  <asp:ListItem Value="Video">Video</asp:ListItem>
                    <asp:ListItem Value="About Banner">About Banner</asp:ListItem>
                </asp:DropDownList>
               <%-- <asp:TextBox ID="btype" runat="server" CssClass="box" MaxLength="100" TabIndex="3"
                    Width="214px"></asp:TextBox>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="0" runat="server" ControlToValidate="btype"
                    Display="Dynamic" ErrorMessage="Required" ValidationGroup="album"></asp:RequiredFieldValidator></td>
        </tr >
         <tr style="display:inline">
            <td align="right">Display Order :&nbsp;
            </td>
            <td align="left" >
                <asp:TextBox ID="displayorder" runat="server" Width="39px"></asp:TextBox>
               <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                    ControlToValidate="displayorder" Display="Dynamic" ErrorMessage="Enter Numeric"
                    ValidationExpression="^\d+?$" ValidationGroup="album"></asp:RegularExpressionValidator></td>
        </tr>
       
       
        <tr style="display:inline">
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
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).DataItemIndex + 1%>.
                               <asp:Label ID="Label1" runat="server" Text='<%#(Eval("btypeid")) %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                      
                         <asp:TemplateField HeaderText="Banner Type">
                             <HeaderStyle HorizontalAlign="center" Width="10%"  />
                            <ItemStyle HorizontalAlign="center" Width="10%"  />
                            <ItemTemplate>
                                <%#Eval("btype").ToString()%>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:BoundField DataField="displayorder" HeaderText="Display Order" >
                            <HeaderStyle HorizontalAlign="Center" Width="10%"/>
                            <ItemStyle HorizontalAlign="Center" Width="10%"/>
                        </asp:BoundField>
                      
                        <asp:TemplateField HeaderText="Publish/Desktop">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                            <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status") %>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkstatus" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%#(Eval("btypeid")) %>' CommandName="status"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Publish/Mobile">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                            <asp:TextBox ID="mobiletxtstatus" runat="server" Text='<%#Eval("mobilestatus") %>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="mobilelnkstatus" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%#(Eval("btypeid")) %>' CommandName="mobilestatus"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Edit" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("btypeid")) %>'
                                    CommandName="edit" ImageUrl="~/backoffice/assets/edit.png" ToolTip="Click to Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("btypeid")) %>'
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
