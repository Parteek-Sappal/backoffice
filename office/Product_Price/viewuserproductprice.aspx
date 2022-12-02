<%@ Page Title="" Language="C#" MasterPageFile="~/office/layouts/BackMaster.Master" AutoEventWireup="true" CodeBehind="viewuserproductprice.aspx.cs" Inherits="backoffice.office.Product_Price.viewuserproductprice"  Theme="backtheme"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />
    <script type="text/javascript" src="../../calendar_js/epoch_classes.js"></script>
    <script type="text/javascript" src="../../fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="../../fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="../../fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
           <script type="text/javascript">
               /*You can also place this code in a separate file and link to it like epoch_classes.js*/
               var dp_cal;
               window.onload = function () {
                   dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=sdate.ClientID%>'));
                   dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=edate.ClientID%>'));
               };
           </script>

 <table id="TABLE1" cellpadding="2" cellspacing="0" width="98%" language="javascript">
        <tr>
            <td class="head1" style="width: 50%">
                View/Edit Product Price Lists
            </td>
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
            <td align="center" colspan="2">
                <asp:Label ID="Label1" runat="server" SkinID="redtext" ForeColor="Red"></asp:Label>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="End date must be later than Start date"
                    ControlToCompare="sdate" ControlToValidate="edate" Type="Date" Operator="GreaterThan"
                    Display="Dynamic">
                </asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Panel ID="Panel2" runat="server" Width="50%" Height="130px" GroupingText="Search">
                    <table border="0" cellpadding="2" cellspacing="0" width="50%" id="TABLE2" class="panelbg">
                        <tr>
                            <td align="right">
                                User
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="userid" runat="server" AutoPostBack="True" OnSelectedIndexChanged="userid_SelectedIndexChanged" Width="150px">
                                </asp:DropDownList>
                            </td>
                          <%--  <td align="right">
                                Order No
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="drporderno" runat="server" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="drporderno_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>--%>
                        </tr>

                        <tr style="display:none">
                            <td align="right">
                                Start Date
                            </td>
                            <td align="left">
                                <asp:TextBox ID="sdate" runat="server" contentEditable="false" MaxLength="100" Width="75px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="sdate"
                                    CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                                    ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
                            </td>
                            <td align="right">
                                End Date
                            </td>
                            <td align="left">
                                <asp:TextBox ID="edate" runat="server" contentEditable="false" MaxLength="100" Width="75px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="edate"
                                    CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                                    ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>

                        <tr style="display: none">
                            <td align="right">
                                Product Type :
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="Prodtype" runat="server" Width="220px">
                                    <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                                    <asp:ListItem Value="New Products">New Products</asp:ListItem>
                                    <asp:ListItem Value="Used Products">Used Products</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                Product Code
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Prodcode" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Button ID="btnsearch" runat="server" OnClick="btnsearch_Click" CssClass="btnbg"
                                    Text="Search" />
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
        <tr>
            <td align="center" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="GridView1" runat="server" Width="100%" PageSize="50" AllowPaging="True"
                    AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging"
                   
                    OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemStyle HorizontalAlign="center" Width="1%" />
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1 %>
                                .
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User Name" HeaderStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="center" Width="10%" />
                            <ItemTemplate>
                             <asp:TextBox ID="txtid" runat="server" Visible="false" Text='<%#Eval("id") %>'></asp:TextBox>
                                <%#Eval("Name")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                     
                        
                        <asp:TemplateField HeaderText="Product">
                            <HeaderStyle HorizontalAlign="Center" Width="35%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtuserid" runat="server" Visible="false" Text='<%#Eval("userid") %>'></asp:TextBox>
                               
                               <asp:Label ID="lblproduct" runat="server" Text='<%# Eval("Prodname") %>'></asp:Label>
                               <asp:Label ID="lblProdid" runat="server" Text='<%# Eval("Prodid") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Quantity">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                             
                               <asp:Label ID="lblquatity" runat="server" Text='<%# Eval("quantity") %>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Price">
                            <ItemStyle Width="7%" />
                            <ItemTemplate>
                              <asp:Label ID="lblprice" runat="server" Text='<%#Eval("price") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                             <asp:TextBox ID="txtprice" runat="server" Text='<%#Eval("price") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>


                         <asp:TemplateField HeaderText="Edit">
                            <ItemStyle Width="10%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("id") %>'
                                    CommandName="btnedit" ImageUrl="~/office/assets/Edit.png" />
                            </ItemTemplate>
                        </asp:TemplateField>


                        
                    
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
    </table>
</asp:Content>
