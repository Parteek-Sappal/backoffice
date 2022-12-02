<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="viewpages.aspx.cs" Inherits="backoffice.office.cms.viewpages" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="/fancybox/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css" media="screen" />
    <link href="../theme/backoffice.css" rel="stylesheet" />
    

      <script type="text/javascript">

          $(document).ready(function () {
              $(".toptxtpage").fancybox({
                  'width': '90%',
                  'height': '95%',
                  'autoScale': true,
                  'scrolling': true,
                  'transitionIn': 'elastic',
                  'transitionOut': 'elastic',
                  'type': 'iframe'
              });
          });

      </script>
    <h2>
        View Pages</h2>
    <div class="content-panel">
        <table id="TABLE1" cellpadding="2" cellspacing="0" width="98%" language="javascript">
            <tr>
                <td class="head1" style="width: 20%">
                </td>
                <td align="right" style="width: 80%">
                </td>
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
                                <a href="/backoffice/collage/viewcollage.aspx" style="color: White"><b>Back To Colleges/Institutes</b></a>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="headingtext" colspan="2">
                    <div class="error" align="left" id="trerror" runat="server" visible="false">
                        &nbsp;&nbsp;
                        <asp:Label ID="lblerror" runat="server"></asp:Label>
                    </div>
                    <div class="success" align="left" id="trsuccess" runat="server" visible="false">
                        &nbsp;&nbsp;
                        <asp:Label ID="lblsuccess" runat="server"></asp:Label>
                    </div>
                    <div class="notice" align="left" id="trnotice" runat="server" visible="false">
                        &nbsp;&nbsp;
                        <asp:Label ID="lblnotice" runat="server"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" style="height: 23px">
                    <asp:Label ID="Label1" runat="server" SkinID="redtext"></asp:Label>
                    <asp:TextBox ID="collageid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" Width="100%" OnRowCommand="GridView1_RowCommand"
                        OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemStyle HorizontalAlign="center" Width="5%" />
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1 %>
                                    .
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Page Name" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="left" Width="20%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Depth") %>'
                                        Visible="false"></asp:TextBox>
                                    <%#Eval("PageName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Link Name" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="left" Width="20%" />
                                <ItemTemplate>
                                    <%#Eval("linkname")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--  <asp:BoundField DataField="PageStatus" HeaderText="Status" />--%>
                            <asp:TemplateField HeaderText="Display Order">
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <%#Eval("displayorder")%>
                                    <%--<asp:Label ID="lblpagename" runat="server" Text='<%#Eval("PageName")%>'></asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemStyle Width="10%" HorizontalAlign="center" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkstatus" runat="server" CausesValidation="false" CommandArgument='<%# Eval("Pageid")%>'
                                        CommandName="lnkstatus" />
                                    <asp:Label ID="lblstatus" runat="server" Visible="false" Text='<%#Eval("pagestatus")%>'></asp:Label>
                                    <asp:Label ID="lblpagename" runat="server" Visible="false" Text='<%#Eval("PageName")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Dynamic URL" Visible="false">
                            <ItemStyle Width="10%" />
                            <ItemTemplate>
                                <asp:Literal ID="litrewriteurl" runat="server" Text='<%#Eval("dynamicurlvalue")%>'></asp:Literal>
                                 <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                                  <asp:Literal ID="litparentid" runat="server" Visible="false" Text='<%#Eval("parentid")%>'></asp:Literal>
                              <%-- /page-details/ <%#Eval("rewriteurl")%>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemStyle Width="10%" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%# Eval("Pageid") %>'
                                        CommandName="btnedit" ImageUrl="~/office/assets/Edit.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Add Slide"  Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                          <a class="toptxtpage" id="divanchslide" visible="true" href='mapslide.aspx?pageid=<%#(Eval("pageid"))%>'>
                                    <img src="../assets/Preview_24x24.png" border="0"></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete(User Page)">
                                <ItemStyle Width="10%" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnrest" runat="server" CausesValidation="false" CommandArgument='<%# Eval("Pageid") %>'
                                        CommandName="btnrest" />
                                    <img src="../assets/Cancel_24x24.png" alt="Restricted" runat="server" id="imgdelres"
                                        width="20" height="20" />
                                    <ajaxToolkit:ConfirmButtonExtender ID="cbee" runat="server" ConfirmText="Are you sure you want to delete this?"
                                        TargetControlID="btnrest">
                                    </ajaxToolkit:ConfirmButtonExtender>
                                    <asp:Label ID="lblrestricted" runat="server" Visible="false" Text='<%#Eval("restricted")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:BoundField DataField="restricted" HeaderText="Restricted" />--%>
                            <asp:TemplateField HeaderText="Delete" Visible="false">
                                <ItemStyle Width="10%" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%# Eval("Pageid")%>'
                                        CommandName="btndel" Width="22" Height="22" />
                                    <img src="../assets/Cancel_24x24.png" alt="Restricted" runat="server" id="imgdel"
                                        width="20" height="20" />
                                    <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure, you want to delete this?"
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
