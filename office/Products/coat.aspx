<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="coat.aspx.cs" Inherits="backoffice.office.Products.coat" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td class="head1" colspan="2">
                Add/Edit Coat &nbsp;
                <asp:TextBox ID="coatid" runat="server" Visible="False"></asp:TextBox>          
              
                
               
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
                Fields with <span class="star">*</span>are mandatory
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="Label1" runat="server" SkinID="redtext" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                Coat<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="titlename" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Requiredfieldvalidator1" runat="server" ControlToValidate="titlename"
                    ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td align="right">
                Status :&nbsp;
            </td>
            <td align="left">
                <asp:CheckBox ID="status" runat="server" Checked="true" />
            </td>
        </tr>
        <tr >
            <td align="right">
                Display Order :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="displayorder" runat="server" Width="30"></asp:TextBox>
                <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                    ControlToValidate="displayorder" Display="Dynamic" ErrorMessage="Enter Numeric"
                    ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
            </td>
        </tr>
         <tr>
            <td align="left" colspan="2" height="10">
                <b>SEO Section</b>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%; height: 26px;" valign="top">
                <span class="star"></span>Rewrite URL :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="rewriteurl" runat="server" Visible="true" Width="500"></asp:TextBox>
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
                <asp:TextBox ID="pagemeta" runat="server" Visible="true" Width="500" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%; height: 26px;" valign="top">
                <span class="star"></span>Page Description :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="pagemetadesc" runat="server" Visible="true" Width="500" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td valign="top" align="right">
                <span class="star"></span>Canonical : &nbsp;
            </td>
            <td>
                <asp:TextBox ID="canonical" runat="server" Width="300px"></asp:TextBox>
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
            <td align="right" style="width: 15%; height: 26px;" valign="top">
                <span class="star"></span>Page Script :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="pagescript" runat="server" Visible="true" Width="300" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <tr>
            <td align="center" colspan="2">
            </td>
        </tr>
        <tr>
            <td style="height: 10px;">
            </td>
            <td>
                <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" TabIndex="15" CssClass="btnbg" />
                &nbsp;
                <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="Button2_Click" CausesValidation="False" TabIndex="16"
                    CssClass="btnbg" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" PageSize="50" AllowPaging="True" Width="100%"
                    AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                            OnPageIndexChanging="GridView1_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemStyle Width="5%" />
                            <ItemTemplate>
                                <%--<%# CType(Container, GridViewRow).Dataitemindex + 1%>--%>
                                 <%# ((GridViewRow)Container).RowIndex + 1 %> .
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Coat">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <%#Eval("titlename")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:BoundField DataField="displayorder" HeaderText="Displayorder" ItemStyle-Width="10%" />
                             
                        <%-- <asp:BoundField DataField="Status" HeaderText="Status" Visible="false"  />--%>
                        <asp:TemplateField HeaderText="Publish">
                            <ItemStyle Width="5%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkstatus" runat="server" CausesValidation="false" CommandArgument='<%#Eval("coatid") %>'
                                    CommandName="lnkstatus" />
                                <asp:TextBox ID="txtstatus" Text='<%#Eval("status") %>' Visible="false" runat="server"></asp:TextBox>
                                <asp:TextBox ID="coatid" Text='<%# Eval("coatid") %>' Visible="false" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemStyle Width="7%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("coatid") %>'
                                    CommandName="btnedit" ImageUrl="~/office/assets/Edit.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" Visible="false">
                            <ItemStyle Width="10%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%# Eval("coatid") %>'
                                    CommandName="btndel" ImageUrl="~/office/assets/Remove_24x24.png" />
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
</asp:Content>
