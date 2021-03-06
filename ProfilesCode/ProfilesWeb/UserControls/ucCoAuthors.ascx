﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCoAuthors.ascx.cs" Inherits="UserControls_ucAuthors" %>
 <%--
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
 --%> 
<script type="text/javascript" language="javascript">


    function togCoAuthors() {

        if (document.getElementById("divCoAuthors").style.display == "none") {
            document.getElementById("divCoAuthors").style.display = "block";
        } else {
        document.getElementById("divCoAuthors").style.display = "none";
        }
    }
  
</script>

<asp:GridView ID="grdAuthors" runat="server" AutoGenerateColumns="false" OnRowCreated="grdAuthors_OnRowCreated"
    DataKeyNames="PersonId" GridLines="None" ShowFooter="true" Width="100%">
    <Columns>
        <asp:BoundField DataField="PersonId" ReadOnly="true" Visible="false" />
        <asp:TemplateField HeaderStyle-CssClass="menuWidgetTitleRight">
            <HeaderTemplate>
                Co-Authors&nbsp;<img onclick="javascript:togCoAuthors();" style="cursor:pointer" src="<%=Page.ResolveUrl("~/Images/Info.png")%>" id="imgCoAuthors" />&nbsp;
                <div class="passive_section_description" id="divCoAuthors" style="display: none">
                    People in Profiles who have published with this person.</div>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:HyperLink ID="hypLnkAuthors" runat="server" Text='<%# Eval("CoAuthors") %>' />
            </ItemTemplate>
            <ControlStyle CssClass="rightColumnLink" />
            <FooterTemplate>
                <asp:HyperLink ID="hypCoAuthors" runat="server" class="rightColumnLinkAll" /></FooterTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
