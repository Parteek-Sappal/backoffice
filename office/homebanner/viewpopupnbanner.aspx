<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="viewpopupnbanner.aspx.cs" Inherits="backoffice.office.homebanner.viewpopupnbanner" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h2>View Popup Banner</h2>
<div class="content-panel">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <table id="TABLE1" cellpadding="2" cellspacing="0" width="100%">
                <tr>
                
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
                     <a href="/backoffice/collage/viewcollage.aspx" style="color: White"><b>Back To School</b></a> &nbsp;
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
                    <td align="center" colspan="2">
                        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>&nbsp;
                         <asp:TextBox ID="collageid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                    </td>
                </tr>

                <tr style="display:none;">
                    <td align="right" style="width: 15%">
                        Company :&nbsp;
                    </td>
                    <td align="left" style="width: 85%">
                        <asp:DropDownList ID="companyid" runat="server" Width="200px"></asp:DropDownList>
                    </td>
                </tr>

                <br />

                <tr style="display:none;">
                    <td align="right">
                    </td>
                    <td align="left">
                        <asp:Button ID="btnsubmit" runat="server" CssClass="btnbg" Text="Search" OnClick="btnsubmit_Click" />
                    </td>
                </tr>


                <tr>
                    <td align="center" colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:GridView ID="GridView1" runat="server" PageSize="50" AllowPaging="True" Width="100%"
                            AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                            OnPageIndexChanging="GridView1_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemStyle Width="5%" />
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1 %>
                                        .
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Type">
                                    <ItemStyle HorizontalAlign="center" Width="20%" />
                                    <ItemTemplate>
                                        <%#Eval("btype").ToString()%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Banner">
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    <ItemTemplate>
                                        <img id="imgimage" runat="server" width="75" height="69" />
                                        <asp:Label ID="lblimage" runat="server" Text='<%# Eval("bannerimage") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lbltype" runat="server" Text='<%# Eval("btype") %>' Visible="false"></asp:Label>
                                         <asp:Literal ID="lblvideo" runat="server" Visible="false"></asp:Literal>
                                          <video width="100px" height="100px" playsinline="playsinline" autoplay="autoplay" muted="muted" loop="loop" runat="server" Visible="false" id="pvideo">
                                                <source src="/Uploads/banner/<%# Eval("bannerimage") %>" type="video/mp4">
                                          </video>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                                <asp:TemplateField HeaderText="Title">
                                    <ItemStyle HorizontalAlign="center" Width="20%" />
                                    <ItemTemplate>
                                        <%#Eval("title").ToString()%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Trdate" DataFormatString="{0: dd/MM/yyyy}" HeaderText="Upload Date">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="displayorder" HeaderText="Display Order">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>


                                <asp:TemplateField HeaderText="Publish">
                                    <ItemStyle Width="6%" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status")%>' Visible="false"></asp:TextBox>
                                        <asp:ImageButton ID="lnkstatus" runat="server" CausesValidation="false" CommandArgument='<%#Eval("bid")%>'
                                            CommandName="lnkstatus" />
                                    </ItemTemplate>
                                </asp:TemplateField>


                                
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemStyle Width="6%" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("bid")%>'
                                            CommandName="btnedit" ImageUrl="~/backoffice/assets/Edit.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemStyle Width="6%" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#Eval("bid")%>'
                                            CommandName="btndel" ImageUrl="~/backoffice/assets/Remove_24x24.png" />
                                        <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to delete this?"
                                            TargetControlID="btndel">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle HorizontalAlign="Right" />
                            <PagerStyle HorizontalAlign="Right" ForeColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>

</asp:Content>
