<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCoAuthorGrid.ascx.cs" Inherits="UserControls_ucCoAuthorGrid" %>
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