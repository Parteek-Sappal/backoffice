<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="courselevelseo.aspx.cs" Inherits="backoffice.office.masters.courselevelseo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <div>
        <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
            <tr>
                <td align="left" colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td class="head1">
                               <%-- Add/Edit Media SEO--%>
                                <asp:TextBox ID="levelid" runat="server" Visible="false" Width="33px"></asp:TextBox>
                                <asp:TextBox ID="id" runat="server" Visible="false" Width="33px"></asp:TextBox>
                                <asp:CheckBox ID="status" runat="server" Visible="false" Checked="true" />
                            </td>
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
                        <td valign="top" width="15%" align="right">
                            College<span class="star">*</span> : &nbsp;</td>
                        <td width="85%">
                            <asp:DropDownList ID="collageid" runat="server" Width="500">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="0" runat="server" ControlToValidate="collageid"
                                Display="Dynamic" ErrorMessage="Required" ></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                  <tr>
                <td align="left" colspan="2" height="10">
                    <b>SEO Section</b>
                </td>
            </tr>

             <tr style="display:none">
                <td align="right" style="width: 15%; height: 26px;" valign="top">
                    <span class="star"></span>Rewrite Url :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="rewrite_url" runat="server" Visible="true" Width="500"></asp:TextBox>
                </td>
            </tr>
         
            <tr>
                <td align="right" style="width: 15%; height: 26px;" valign="top">
                    <span class="star"></span>Page Title :&nbsp;
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
                    Page Script :
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
                    <asp:CheckBox ID="no_indexfollow" runat="server"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="10">
                </td>
            </tr>

                    
                  
            
                    <tr>
                        <td valign="top">
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnbg" 
                                onclick="btnSubmit_Click"  />&nbsp;
                            
                        </td>
                    </tr>
                    
                      <tr>
            <td align="center" colspan="2">
                &nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp;<asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="50"
                    Width="100%" AutoGenerateColumns="false" OnPageIndexChanging="GridView1_PageIndexChanging"  OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                          >
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="School">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#Eval("collagename")%>
                             
                            </ItemTemplate>
                        </asp:TemplateField>
                    
                           <asp:TemplateField HeaderText="PageTitle">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#Eval("PageTitle")%>
                             
                            </ItemTemplate>
                        </asp:TemplateField>
                    
                     
                         
                    
                        
                        <asp:BoundField DataField="Status" Visible="false" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Publish">
                            <ItemTemplate>
                               <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status")%>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkstatus" runat="server" CausesValidation="false" CommandArgument='<%# Eval("id") %>'
                                    CommandName="lnkstatus" />
                            </ItemTemplate>
                        </asp:TemplateField>
                  
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%# Eval("id") %>'
                                    CommandName="btnedit" ImageUrl="~/office/assets/Edit.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Delete" >
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#Eval("id")%>'
                                    CommandName="del" ImageUrl="~/office/assets/Remove_24x24.png" ToolTip="Click to Delete" />
                                <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to delete this?"
                                    TargetControlID="btndel">
                                </ajaxToolkit:ConfirmButtonExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
               
               

            
        </table>
    </div>

    
    </div>
    </form>
</body>
</html>
