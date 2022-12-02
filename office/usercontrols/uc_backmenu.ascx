<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_backmenu.ascx.cs" Inherits="backoffice.office.usercontrols.uc_backmenu" %>
<div class="glossymenu">
    <% if (string.IsNullOrEmpty(Request.QueryString["prodid"]))
       { %>
    <asp:Repeater ID="repmain" runat="server" OnItemDataBound="repmain_ItemDataBound">
        <ItemTemplate>
            <asp:TextBox ID="moduleid" runat="server" Visible="false" Text='<%#Eval("moduleid")%>'></asp:TextBox>
            <a class="menuitem submenuheader" href="#">
                <%#Eval("modulename")%>
            </a>
            <div class="submenu">
                <ul>
                    <asp:Repeater ID="repinner" runat="server" OnItemCommand="repinner_ItemCommand">
                        <ItemTemplate>
                            <li>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandArgument='<%#Eval("Formname")%>'
                                    CommandName="show"><%#Eval("FormCaption")%></asp:LinkButton></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <%} %>
    <%else if (!string.IsNullOrEmpty(Request.QueryString["prodid"]))
       { %>
   
    <a class="menuitem submenuheader" href="#">Home Banner</a>
    <div class="submenu">
        <ul>
        <li><a href="/office/homebanner/addhomebannertype.aspx?prodid=<%=Convert.ToString(Request.QueryString["prodid"]) %>">
                Add/Edit Home Banner Type</a> </li>
            <li><a href="/office/homebanner/addhomebanner.aspx?prodid=<%=Convert.ToString(Request.QueryString["prodid"]) %>">
                Add Banner</a> </li>
            <li><a href="/office/homebanner/viewhomebanner.aspx?prodid=<%=Convert.ToString(Request.QueryString["prodid"]) %>">
                View Banner</a> </li>
        </ul>
    </div>
  

     <a class="menuitem submenuheader" href="#" >Map Testimonial</a>
        <div class="submenu" style="display:none;">
            <ul>
                <li><a href="/office/products/map-testimonial.aspx?prodid=<%=Convert.ToString(Request.QueryString["prodid"]) %>">
                    Map Testimonial </a></li>
            </ul>
        </div>

        <a class="menuitem submenuheader" href="#" >Product Theme</a>
        <div class="submenu" style="display:none;">
            <ul>
                <li><a href="/office/products/theme.aspx?prodid=<%=Convert.ToString(Request.QueryString["prodid"]) %>">
                    Add Theme </a></li>
                     <li><a href="/office/products/View_theme.aspx?prodid=<%=Convert.ToString(Request.QueryString["prodid"]) %>">
                    View / Edit Theme </a></li>
            </ul>
        </div>
    
    <a class="menuitem submenuheader" href="#">Map Gallery</a>
    <div class="submenu">
        <ul>
            <li><a href="/office/gallery/addalbum.aspx?prodid=<%=Convert.ToString(Request.QueryString["prodid"]) %>">
                Album </a></li>
        </ul>
         <ul>
            <li><a href="/office/gallery/viewalbum.aspx?prodid=<%=Convert.ToString(Request.QueryString["prodid"]) %>">
               View Album </a></li>
        </ul>
    </div>
    <a class="menuitem submenuheader" href="#">Media Section</a>
    <div class="submenu">        
         <ul>
            <li><a href="/office/media/media_section.aspx?prodid=<%=Convert.ToString(Request.QueryString["prodid"]) %>">
               Add Media Section </a></li>
        </ul>
        <ul>
            <li><a href="/office/media/viewmedia_section.aspx?prodid=<%=Convert.ToString(Request.QueryString["prodid"]) %>">
               View Media Section </a></li>
        </ul>
    </div>

  
  
    
    <%} %>
</div>