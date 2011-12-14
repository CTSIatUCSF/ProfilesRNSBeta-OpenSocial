<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCoAuthorGrid.ascx.cs" Inherits="UserControls_ucCoAuthorGrid" %>
 <%--
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
 --%> 
<asp:GridView ID="grdAuthors" runat="server" AutoGenerateColumns="false" OnRowCreated="grdAuthors_OnRowCreated" DataKeyNames="PersonId"
    GridLines="None" ShowFooter="false" ShowHeader="true" CssClass="coAuthorResults">
    <RowStyle CssClass="coAuthorResultsRow" />
    <AlternatingRowStyle CssClass="coAuthorResultsAltRow" />
    <HeaderStyle CssClass="coAuthorResultsHeader" />
    <FooterStyle CssClass="coAuthorResultsFooter" />
    <PagerStyle CssClass="coAuthorResultsPager" />
    <Columns>
        <asp:BoundField DataField="PersonId" ReadOnly="true" Visible="false" />
        <asp:TemplateField HeaderText="Name">
            <ItemTemplate>
                <asp:HyperLink ID="hypLnkAuthors" runat="server" Text='<%# Eval("Text") %>' NavigateUrl='<%# "~/ProfileDetails.aspx?Person=" + Eval("PersonId") %>'/>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Institution">
            <ItemTemplate>
                <asp:Label ID="lblInst" runat="server" Text='<%# Eval("Institution")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>