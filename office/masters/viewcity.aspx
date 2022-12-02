<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="viewcity.aspx.cs" Inherits="backoffice.office.masters.viewcity" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>View City</h2>
<div class="content-panel">
 <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="head1">
                            </td>
                        <td align="right">
                           <asp:TextBox ID="cityid" runat="server" Visible="False" Width="33px"></asp:TextBox>
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
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                Country :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:DropDownList ID="countryid" runat="server" AutoPostBack="true" 
                 Width="350px"   onselectedindexchanged="countryid_SelectedIndexChanged">
                </asp:DropDownList>
               </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
               State :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:DropDownList ID="sid" Width="350px" runat="server">
                </asp:DropDownList>
              </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
              City :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="cityname" runat="server" CssClass="box" TabIndex="3" Width="350px"></asp:TextBox>
               </td>
        </tr>
       
       
        <tr>
            <td align="right">
            </td>
            <td align="left" height="10">
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                <asp:Button ID="btnsubmit" runat="server" CssClass="btnbg" Text="Search" OnClick="btnsubmit_Click" />
                <asp:Button ID="btncancel" runat="server" CssClass="btnbg" Text="Cancel" CausesValidation="false" Visible="false" OnClick="btncancel_Click" /></td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp;<asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="50"
                    Width="100%" AutoGenerateColumns="false" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                 <%--<%# ((GridViewRow)Container).RowIndex + 1 %>.--%>
                                   <%#Container.DataItemIndex+1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                  
                          <asp:TemplateField HeaderText="Country">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#Eval("countryname")%>
                             
                            </ItemTemplate>
                        </asp:TemplateField>
                    
                          <asp:TemplateField HeaderText="State">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#Eval("statename")%>
                             
                            </ItemTemplate>
                        </asp:TemplateField>
                      
                         <asp:TemplateField HeaderText="City">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#Eval("cityname")%>
                             
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="displayorder" HeaderText="Display Order" Visible="false">
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Publish">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkstatus" runat="server" CausesValidation="false" CommandArgument='<%# Eval("cityid") %>'
                                    CommandName="lnkstatus" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%# Eval("cityid") %>'
                                    CommandName="btnedit" ImageUrl="~/office/assets/Edit.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
