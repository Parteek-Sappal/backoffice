<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="redirection.aspx.cs" Inherits="backoffice.office.redirectionmanagement.redirection" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2> Add/Edit 301 Redirection Management</h2>
<div class="content-panel">
    <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="head1">
                            
                        </td>
                        <td align="right">
                            &nbsp;
                            <asp:TextBox ID="rewriteid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                             <asp:TextBox ID="originalvalue" runat="server" Visible="False" Width="33px"></asp:TextBox>
                            <asp:CheckBox ID="Status" runat="server" Visible="False" Checked="true" />
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
                Fields with <span class="star">*</span> are mandatory
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 30%; height: 26px;">
                Old Url<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 70%; height: 26px;">
                <asp:TextBox ID="redirectFrom" runat="server" CssClass="box"  TabIndex="3"
                    Width="500px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="add" ControlToValidate="redirectFrom"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
        </tr>


        <tr >
            <td align="right" style="width: 30%; height: 26px;">
                 New Redirect Url<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 70%; height: 26px;">
                <asp:TextBox ID="redirectTo" runat="server" CssClass="box"  TabIndex="3"
                    Width="500px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="add" ControlToValidate="redirectTo"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
        </tr>



        
        
        <tr>
            <td align="right" style="width: 30%">
            </td>
            <td align="left" style="width: 70%">
                <asp:Button ID="btnsubmit" runat="server" Text="Submit"  ValidationGroup="add" CssClass="btnbg" OnClick="btnsubmit_Click" />&nbsp;<asp:Button
                    ID="btncancel" runat="server" Text="Cancel" CssClass="btnbg" CausesValidation="False"
                    OnClick="btncancel_Click" />
            </td>
        </tr>


        <tr>
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" height="10">
            </td>
        </tr>
           <tr >
            <td align="right" style="width: 30%; height: 26px;">
                 Search<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 70%; height: 26px;">
                <asp:TextBox ID="txtsearch" runat="server" CssClass="box"  TabIndex="3"
                    Width="500px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="s" ControlToValidate="txtsearch"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>

                    <asp:Button ID="btnsearch" runat="server" Text="Search"  ValidationGroup="s" CssClass="btnbg"  OnClick="btnsearch_Click"  />
            </td>
             <td align="right" style="width: 30%; height: 26px;">
                
                 
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" height="10">
            </td>
        </tr>
        <tr>
       
            <td align="center" colspan="2">
            
                <asp:GridView ID="GridView1" runat="server" Width="100%" AllowPaging="True" PageSize="500" AutoGenerateColumns="False"
                    OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"  onpageindexchanging="GridView1_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                             
                                <%# ((GridViewRow)Container).DataItemIndex + 1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Old Url">
                            <HeaderStyle HorizontalAlign="Left" Width="25%" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <%#Eval("redirectFrom")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="New Redirect Url">
                            <HeaderStyle HorizontalAlign="Left" Width="25%" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <%#Eval("redirectTo")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                         
                      <asp:TemplateField HeaderText="Date">
                            <HeaderStyle HorizontalAlign="Left" Width="25%" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                               <%#Eval("trdate", "{0:dd/MM/yyyy}")%>
                              
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Publish">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtstatus" runat="server" Text='<%# Eval("status") %>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkstatus" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%#Eval("rewriteid")%>' CommandName="status"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Edit">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("rewriteid")%>'
                                    CommandName="edit" ImageUrl="~/office/assets/edit.png" ToolTip="Click to Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" >
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#Eval("rewriteid")%>'
                                    CommandName="del" ImageUrl="~/office/assets/Remove_24x24.png" ToolTip="Click to Delete" />
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
