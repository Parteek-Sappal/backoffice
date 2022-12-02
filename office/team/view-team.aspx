<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="view-team.aspx.cs" Inherits="backoffice.office.team.view_team" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />

    <script type="text/javascript" src="../../calendar_js/epoch_classes.js"></script>

  
   <h2>View/Edit Leadership & Management</h2>
<div class="content-panel">
    <table id="TABLE1" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <%--<td class="head1" style="width: 20%">
                View Team</td>--%>
            <td align="right" style="width: 80%">
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
            <td align="center" colspan="2" height="10">
             
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch" GroupingText="Search"
                    Width="80%">
                    <table id="Table3" border="0" cellpadding="2" cellspacing="0" class="panelbg" width="100%">
                        <tr>
                            <td align="left" colspan="4" height="5">
                            </td>
                        </tr>
                       
                        <tr>
                            <td align="right">
                                Name</td>
                            <td align="left">
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="box" Width="200px"></asp:TextBox></td>
                           
                           <td align="right">
                                Designation</td>
                            <td align="left">
                                <asp:TextBox ID="txtdesignation" runat="server" CssClass="box" Width="200px"></asp:TextBox></td>
                        </tr>
                     
                        <tr >
                        <td align="right" >
                                Leadership Type</td>
                            <td align="left" >
                                <asp:DropDownList ID="typeid" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="center" colspan="4">
                                &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnbg" 
                                    onclick="btnSearch_Click" /></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" height="5">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="50" Width="100%"  AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                            OnPageIndexChanging="GridView1_PageIndexChanging">  
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                              <%# ((GridViewRow)Container).RowIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                   
                        <asp:TemplateField HeaderText="Leadership Type">
                            <ItemTemplate>
                                <%# Eval("ttype")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                   
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%# Eval("name")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                    
                       
                      

                      <asp:TemplateField HeaderText="Designation">
                            <ItemTemplate>
                                <%# Eval("Designation")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Team Pics">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>
                             <asp:Label ID="lbllargeimage" runat="server" Text='<%#Eval("uploadphoto1")%>' Visible="false"></asp:Label>
                                <img id="imgsmall" runat="server" width="75" height="69" />
                                <asp:Label ID="lblimagesmall" runat="server" Text='<%#Eval("uploadphoto")%>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        

                        <asp:TemplateField HeaderText="Display Order">
                            <ItemTemplate>
                                <%# Eval("displayorder")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="7%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                      
                        <asp:BoundField DataField="Status" HeaderText="Status" Visible="false"  ItemStyle-VerticalAlign="top" />
                        <asp:TemplateField HeaderText="Publish">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                            <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("Status") %>'
                                    Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkstatus" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%#Eval("teamid") %>' CommandName="status"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>




                        <asp:TemplateField HeaderText="Show on home">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lblshowonhome" runat="server" Text='<%#Eval("showonhome") %>' Visible="false"></asp:Label>
                                <asp:ImageButton ID="lnkshowonhome" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%# Eval("teamid") %>' CommandName="lnkshowonhome"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>


                     
                     
                       
                        <asp:TemplateField HeaderText="Edit">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("teamid") %>'
                                    CommandName="edit" ImageUrl="~/office/assets/edit.png" ToolTip="Click to Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" >
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%# Eval("teamid") %>'
                                    CommandName="del" ImageUrl="~/office/assets/Remove_24x24.png" />
                                <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to delete this?"
                                    TargetControlID="btndel">
                                </ajaxToolkit:ConfirmButtonExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Uploadphoto" HeaderText="Photo" Visible="false"></asp:BoundField>
                    </Columns>
                    <SelectedRowStyle HorizontalAlign="Right" />
                    <PagerStyle HorizontalAlign="Right" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
