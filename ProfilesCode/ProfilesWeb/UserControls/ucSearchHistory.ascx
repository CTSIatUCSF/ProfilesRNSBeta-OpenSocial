<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSearchHistory.ascx.cs" Inherits="UserControls_ucSearchHistory" %>
<asp:Panel ID="pnlSearchHistory" runat="server" Visible="true">
    <div class="menuWidgetTitle">Search History</div>
    <asp:GridView ID="grdSearchHistory" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="None" DataKeyNames="PersonID" OnRowCreated="grdSearchHistory_OnRowCreated" ShowHeader="false" EmptyDataText="<div style='font-style:italic;'>None</div>">
        <Columns>
            <asp:BoundField DataField="PersonID" ReadOnly="true" Visible="false" />
            <asp:TemplateField HeaderText="Search History">
                <ItemTemplate>
                    <asp:HyperLink ID="hypLnkSearchHistory" runat="server" Text='<%#Eval("ProfileName") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>None</EmptyDataTemplate>
    </asp:GridView>
    <div style="height: 16px">
    </div>
    <asp:LinkButton ID="LnkClearHistory" runat="server" Text="Clear History" OnClick="LnkClearHistory_Click" />
</asp:Panel>
