<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="viewalbum.aspx.cs" Inherits="backoffice.office.gallery.viewalbum" Theme="backtheme" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input type="hidden" value="<%=appno%>" name="appno" id="appno">
    <script type="text/javascript" src="/fancybox/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <script type="text/javascript">
        $(document).ready(function () {

            $(".various").fancybox({
                'width': '90%',
                'height': '90%',
                'autoScale': true,
                'scrolling': true,
                'transitionIn': 'elastic',
                'transitionOut': 'elastic',
                'type': 'iframe'
            });

        });
    </script>
    <h2>
        View Album</h2>
    <div class="content-panel">
        <table id="TABLE1" cellpadding="2" cellspacing="0" width="98%" language="javascript">
            <tr>
                <td class="head1" colspan="2">
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
                <td align="center" colspan="2">
                    <asp:Label ID="Label1" runat="server" SkinID="redtext"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <table id="TABLE2" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="center" colspan="7">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="7">
                                <asp:Panel ID="Panel1" runat="server" DefaultButton="btn" GroupingText="Search" Width="80%">
                                    <table id="Table3" border="0" cellpadding="2" cellspacing="0" class="panelbg" width="100%">
                                        <tr>
                                            <td align="left" colspan="4" height="5">
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <td align="right">
                                                Select Album
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlAlbum" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                &nbsp; Album Title:
                                                <asp:TextBox ID="title" runat="server" Width="359px"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btn" runat="server" Text="Search" CssClass="btnbg" OnClick="btn_Click" />
                                            </td>
                                            <td align="left">
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
                <td align="center" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging"
                        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container ).RowIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Album Type" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Literal ID="lbltype" runat="server" Text=' <%#Eval("typename")%>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Album Title">
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <%#Eval("Albumtitle")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Image">
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                <ItemTemplate>
                                    <img id="imgimage" runat="server" width="75" height="69" />
                                    <asp:Label ID="lblimage" runat="server" Text='<%# Eval("UploadAImage")%>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Album Title" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblAlbumtitle" runat="server" Text='<%#Eval("Albumtitle")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="displayorder" HeaderText="Display Order" />
                            <asp:TemplateField HeaderText="Status">
                                <ItemStyle Width="10%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status") %>' Visible="false"></asp:TextBox>
                                    <asp:ImageButton ID="lnkstatus" runat="server" CausesValidation="false" CommandArgument='<%#Eval("Albumid")%>'
                                        CommandName="lnkstatus" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Show on Group" Visible="false">
                                <ItemStyle Width="6%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtshowonmainsite" runat="server" Text='<%#Eval("showonmainsite")%>'
                                        Visible="false"></asp:TextBox>
                                    <asp:ImageButton ID="lnkstatus1" runat="server" CausesValidation="false" CommandArgument='<%#Eval("Albumid")%>'
                                        CommandName="lnkstatus1" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Show on micro site" Visible="false">
                                <ItemStyle Width="6%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtshowonmicrosite" runat="server" Text='<%#Eval("showonmicrosite")%>'
                                        Visible="false"></asp:TextBox>
                                    <asp:ImageButton ID="lnkstatus2" runat="server" CausesValidation="false" CommandArgument='<%#Eval("Albumid")%>'
                                        CommandName="lnkstatus2" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Add Pic">
                                <ItemStyle Width="10%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnstatus" runat="server" Visible="false" CausesValidation="false"
                                        CommandArgument='<%#Eval("Albumid") %>'><img border="0" src="../images/view.gif" alt="" /></asp:LinkButton>
                                    <div runat="server" id="divanch" visible="false">
                                        <a class="various" style="color: Black" href='upload_image.aspx?Albumid=<%#Eval("Albumid") %>'>
                                            Add Edit pic</a></div>
                                </ItemTemplate>
                            </asp:TemplateField>

                                <asp:TemplateField HeaderText="Map Events" Visible="false">
                                <ItemStyle Width="10%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnevents" runat="server" Visible="false" CausesValidation="false"
                                        CommandArgument='<%#Eval("Albumid") %>'><img border="0" src="../images/view.gif" alt="" /></asp:LinkButton>
                                    <div runat="server" id="divevents" visible="false" >
                                        <a class="various" style="color: Black" href='mapevents.aspx?Albumid=<%#Eval("Albumid") %>'>
                                            Map Events</a></div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Edit">
                                <ItemStyle Width="10%" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("Albumid")%>'
                                        CommandName="btnedit" ImageUrl="~/backoffice/assets/Edit.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete" Visible="true">
                                <ItemStyle Width="10%" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#Eval("Albumid")%>'
                                        CommandName="del" ImageUrl="~/backoffice/assets/Remove_24x24.png" />
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
</asp:Content>
