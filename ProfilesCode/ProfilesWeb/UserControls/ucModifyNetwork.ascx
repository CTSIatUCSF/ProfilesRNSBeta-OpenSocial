<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucModifyNetwork.ascx.cs" Inherits="UserControls_ucModifyNetwork" %>
<%@ Register Src="ucMyNetwork.ascx" TagName="MyNetwork" TagPrefix="ucMyNetwork" %>
<asp:Panel ID="pnlChkList" runat="server" Visible="true">
    <div style="font-weight: bold;">
        <div class="menuWidgetTitle">This Person is my...</div>
    </div>
    <div>
        <asp:CheckBoxList ID="chklist" runat="server" AutoPostBack="true" 
            OnSelectedIndexChanged="chklist_SelectedIndexChanged">
            <asp:ListItem Text="Collaborator" Value="Collaborator" />
            <asp:ListItem Text="Advisor (Current)" Value="CurrentAdvisor" />
            <asp:ListItem Text="Advisor (Past)" Value="PastAdvisor" />
            <asp:ListItem Text="Advisee (Current)" Value="CurrentAdvisee" />
            <asp:ListItem Text="Advisee (Past)" Value="PastAdvisee" />
        </asp:CheckBoxList>
    </div>
</asp:Panel>

