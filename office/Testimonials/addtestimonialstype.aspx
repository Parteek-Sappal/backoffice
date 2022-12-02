<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="addtestimonialstype.aspx.cs" Inherits="backoffice.office.Testimonials.addtestimonialstype" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add/Edit Testimonials Type</h2>
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
                            <asp:TextBox ID="Tesid" runat="server" Visible="False" Width="33px"></asp:TextBox>
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
            <td align="right" style="width: 15%; height: 26px;">
                Title<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%; height: 26px;">
                <asp:TextBox ID="Testimonialtype" runat="server" CssClass="box" MaxLength="100" TabIndex="3"
                    Width="214px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Testimonialtype"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
                Upload Banner :&nbsp;
            </td>
            <td align="left">
                <input id="File1" runat="server" class="box" contenteditable="false" type="file" /><asp:TextBox
                    ID="banner" runat="server" Visible="False" Width="122px"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
            </td>
            <td align="left">
                <asp:LinkButton ID="LinkButton1" runat="server" Visible="false" CausesValidation="false"></asp:LinkButton>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
            </td>
            <td align="left">
                <asp:Image ID="Image1" runat="server" Visible="False" Height="100" Width="100" />
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
       
        <tr>
            <td align="right">
            </td>
            <td align="left" >
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btnbg" OnClick="btnsubmit_Click" />&nbsp;<asp:Button
                    ID="btncancel" runat="server" Text="Cancel" CssClass="btnbg" CausesValidation="False" OnClick="btncancel_Click" />
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
        <tr>
            <td align="center" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"    
OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                          <%# ((GridViewRow)Container).DataItemIndex + 1%>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Title">
                                        <HeaderStyle HorizontalAlign="Center" Width="25%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%# Eval("Testimonialtype")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Banner" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        <ItemTemplate>
                                            <img id="imgimage" runat="server" width="75" height="69" />
                                            <asp:Label ID="lblimage" runat="server" Text='<%#Eval("banner")%>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="displayorder" HeaderText="Display Order">
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Publish">
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status") %>' Visible="false"></asp:TextBox>
                                            <asp:ImageButton ID="lnkstatus" CssClass="toptxt" runat="server" CausesValidation="false"
                                                CommandArgument='<%#(Eval("Tesid")) %>' CommandName="status"></asp:ImageButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("Tesid")) %>'
                                                CommandName="edit" ImageUrl="~/backoffice/assets/edit.png" ToolTip="Click to Edit" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("Tesid")) %>'
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
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
