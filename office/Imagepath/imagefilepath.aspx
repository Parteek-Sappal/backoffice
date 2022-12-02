<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="imagefilepath.aspx.cs" Inherits="backoffice.office.Imagepath.imagefilepath" Theme="backtheme" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Upload Image/File</h2>
<div class="content-panel">
    <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td class="head1" colspan="2">
                <asp:TextBox ID="Fileid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                <asp:CheckBox ID="status" runat="server" Visible="False" />
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
        <tr >
            <td align="right" style="width: 15%" >
                Path:&nbsp;
              
            </td>
            <td align="left" style="width: 85%">
              <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right" style="width: 15%">
                Title<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="FileTitle" runat="server" CssClass="box" MaxLength="100" TabIndex="3"
                    Width="359px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                Upload File<span class="star">*</span> :&nbsp;
            </td>
            <td align="left">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <input id="File1" runat="server" class="box" contenteditable="false" type="file" /><asp:TextBox
                                ID="UploadFile" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="LinkButton1" runat="server" Visible="False" CssClass="toptxt">Remove File</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right" style="height: 26px">
                Display Order :&nbsp;
            </td>
            <td align="left" style="height: 26px">
                <asp:TextBox ID="displayorder" runat="server" Width="31px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                    ControlToValidate="displayorder" ErrorMessage="Enter Numeric" Display="Dynamic"
                    ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
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
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnbg" TabIndex="15"
                    OnClick="btnSubmit_Click" />&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel"
                        Visible="false" CssClass="btnbg" CausesValidation="False" TabIndex="16" OnClick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" PageSize="50" AllowPaging="True" Width="100%"
                    AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging"
                    OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemStyle Width="5%" />
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1 %>
                                .
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Image/File Title">
                            <ItemTemplate>
                                <%#Eval("Filetitle")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Trdate" DataFormatString="{0: dd/MM/yyyy}" HeaderText="Upload Date">
                            <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Download Image/File">
                            <ItemStyle Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lbldown" runat="server" Text='<%#Eval("uploadfile")%>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="downbtn" runat="server" CausesValidation="false" CommandArgument='<%# Eval("fileid") %>'
                                    CommandName="downbtn">
                                    <asp:Image ID="imgDown" runat="server" BorderWidth="0" ImageUrl="~/backoffice/assets/Download_24x24.png" /></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit" Visible="false">
                            <ItemStyle Width="5%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%# Eval("fileid") %>'
                                    CommandName="btnedit" ImageUrl="~/backoffice/assets/Edit.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" Visible="false">
                            <ItemStyle Width="5%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%# Eval("fileid") %>'
                                    CommandName="btndel" ImageUrl="~/backoffice/assets/Remove_24x24.png" />
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
