﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucKeywords.ascx.cs" Inherits="UserControls_ucKeywords" %>

<script type="text/javascript" language="javascript">

    function togConcepts() {

        if (document.getElementById("divConcepts").style.display == "none") {
            document.getElementById("divConcepts").style.display = "block";
        } else {
        document.getElementById("divConcepts").style.display = "none";
        }
    }  
</script>

<asp:GridView ID="grdKeywords" runat="server" AutoGenerateColumns="false" OnRowCreated="grdKeywords_OnRowCreated"
    PageSize="6" GridLines="None" ShowFooter="true" Width="100%">
    <Columns>
        <asp:TemplateField HeaderStyle-CssClass="menuWidgetTitleRight">
            <HeaderTemplate>
                Keywords &nbsp;<img onclick="javascript:togConcepts();" style="cursor: pointer" src="<%=Page.ResolveUrl("~/Images/Info.png")%>"
                    id="imgConcepts" />&nbsp;
                <div class="passive_section_description" id="divConcepts" style="display: none">
                    Derived automatically from this person's publications.</div>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:HyperLink ID="hypLnkKeywords" runat="server" Text='<%# Eval("MeSHKeywords")%>' />
            </ItemTemplate>
            <ControlStyle CssClass="rightColumnLink" />
            <FooterTemplate>
                <asp:HyperLink ID="hypLnkAllKeywords" runat="server" CssClass="rightColumnLinkAll" /></FooterTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
