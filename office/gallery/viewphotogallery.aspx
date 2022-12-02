<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="viewphotogallery.aspx.cs" Inherits="backoffice.office.gallery.viewphotogallery" Theme="backtheme" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<h2>View/Edit Photo Gallery</h2>
    <div class="content-panel">
    <table id="TABLE1" cellpadding="2" cellspacing="0" language="javascript" width="98%">
        <tr>
            <td colspan="2" class="head1">
                
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
            <td align="center" colspan="2">
                <table id="TABLE2" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" colspan="7">
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td align="center" colspan="7">
                            <asp:Panel ID="Panel2" runat="server"  DefaultButton="btn" GroupingText="Search" Width="80%">
                                <table id="Table3" border="0" cellpadding="2" cellspacing="0" class="panelbg" width="100%">
                                    <tr>
                                        <td align="left" colspan="4" height="5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Select Album
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DropDownList1" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btn" runat="server" Text="Search" CssClass="btnbg" OnClick="btn_Click" />
                                        </td>
                                        <td align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="GridView1" runat="server" PageSize="50" AllowPaging="True" Width="100%"
                    AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging"
                    OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemStyle Width="5%" />
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Album">
                            <ItemTemplate>
                                <%#Eval("Albumtitle")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Photo Title">
                            <ItemTemplate>
                                <%#Eval("phototitle")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Large Image" >
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>
                                <img id="imgimage" runat="server" width="75" height="69" />
                                <asp:Label ID="lblimage" runat="server" Text='<%#Eval("largeimage")%>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Small Image">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>
                                <img id="imgsmall" runat="server" width="75" height="69" />
                                <asp:Label ID="lblimagesmall" runat="server" Text='<%#Eval("uploadphoto")%>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="displayorder" HeaderText="Display Order">
                            <ItemStyle Width="15%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Publish">
                            <ItemStyle Width="10%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status") %>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkstatus" runat="server" CausesValidation="false" CommandArgument='<%#Eval("photoid")%>'
                                    CommandName="lnkstatus" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemStyle Width="10%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("photoid")%>'
                                    CommandName="btnedit" ImageUrl="~/backoffice/assets/Edit.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemStyle Width="10%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#Eval("photoid")%>'
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
        <tr>
            <td align="center" colspan="2">
                <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none"
                    Width="400px">
                    <div>
                        <p style="text-align: center">
                            <table border="0" cellpadding="2" cellspacing="0" width="98%">
                                <tr>
                                    <td colspan="4">
                                        <asp:Image ID="Image1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4">
                                        <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False" ImageUrl="~/assets/btn_close.gif"
                                            TabIndex="20" />
                                    </td>
                                </tr>
                            </table>
                        </p>
                    </div>
                </asp:Panel>
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
                    CancelControlID="ImageButton3" DropShadow="false" PopupControlID="Panel1" TargetControlID="btnShowModalPopup"
                    PopupDragHandleControlID="panelDragHandle">
                </ajaxToolkit:ModalPopupExtender>
                <asp:Button ID="btnShowModalPopup" runat="server" Style="display: none" />
            </td>
        </tr>
    </table>
    <asp:Repeater ID="Repeater1" runat="server" Visible="False">
        <ItemTemplate>
            <asp:TextBox ID="txt1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>'
                Visible="false">
            </asp:TextBox>
            <asp:TextBox ID="txt2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "parentid") %>'
                Visible="false">
            </asp:TextBox>
            <asp:TextBox ID="txt3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Depth") %>'
                Visible="false">
            </asp:TextBox>
            <img height="1" width='<%#DataBinder.Eval(Container.DataItem, "Depth")%>' />
            <asp:LinkButton ID="lnk1" runat="server" CausesValidation="False" CommandName="edit">
												<%# DataBinder.Eval(Container.DataItem, "Name") %>
            </asp:LinkButton>
            <br />
        </ItemTemplate>
    </asp:Repeater>
    </div>
</asp:Content>
