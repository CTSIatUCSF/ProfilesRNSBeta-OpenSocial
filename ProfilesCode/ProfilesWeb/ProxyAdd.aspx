<%@ Page Language="C#" MasterPageFile="~/ProfilesPage.master" Theme="blue" AutoEventWireup="true"
    CodeFile="ProxyAdd.aspx.cs" Inherits="ProxyAdd" Title="Proxies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MiddleContentPlaceHolder" runat="Server">
  <div id="contentPosition">
    <div class="pageTitle"><asp:Literal ID="ltHeader" runat="server" /></div>
    <div style="margin-top: 10px;">
        <asp:Panel ID="pnlProxySearch" runat="server" DefaultButton="btnProxySearch">
            <table border="0" cellspacing="0" cellpadding="0" class="mainSearchForm">
                <tr>
                    <th>
                        Last Name
                    </th>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server" Width="250px" ToolTip="Enter LastName" />
                    </td>
                </tr>
                <tr>
                    <th>
                        First Name
                    </th>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server" Width="250px" ToolTip="Enter FirstName" />
                    </td>
                </tr>
<!--
                <tr>
                    <th style="text-align: right;">
                        Institution
                    </th>
                    <td>
                        <asp:DropDownList ID="drpInstitution" runat="server" Width="255px" AutoPostBack="false"
                            ToolTip="Select Institution" />
                    </td>
                </tr>
                <tr>
                    <th>
                        Department
                    </th>
                    <td>
                        <asp:DropDownList ID="drpDepartment" runat="server" Width="255px" AutoPostBack="false"
                            ToolTip="Select Department Name" />
                    </td>
                </tr>
-->
                <tr>
                    <th>
                    </th>
                    <td>
                        <div style="padding: 12px 0px;">
                            <asp:Button ID="btnProxySearch" runat="server" Text="Search" OnClick="btnProxySearch_Click" />&nbsp;&nbsp;
                            <asp:Button ID="btnSearchReset" runat="server" Text="Reset" OnClick="btnSearchReset_Click" />&nbsp;&nbsp;
                            <asp:Button ID="btnSearchCancel" runat="server" Text="Cancel" OnClick="btnSearchCancel_Click" />
                        </div>
                    </td>
                </tr>
            </table>
            <div class="sectionHeader"><asp:Literal ID="litGridHeader" runat="server" /></div>
        </asp:Panel>
        <asp:Panel ID="pnlProxySearchResults" runat="server" Visible="false">
            <div style="margin-top: 8px;">
                <p style="margin:4px 10px">To add any of the people below as your proxy, simply click on the name of the individual in the list.</p>
                <asp:GridView ID="gridSearchResults" runat="server" DataKeyNames="UID" AllowPaging="true"
                    PageSize="15" EmptyDataText="No matching people could be found." AutoGenerateColumns="False"
                    OnRowDataBound="gridSearchResults_RowDataBound" OnSelectedIndexChanged="gridSearchResults_SelectedIndexChanged"
                    OnPageIndexChanging="gridSearchResults_PageIndexChanging" CssClass="searchResults">
                    <RowStyle CssClass="searchResultsRow" />
                    <AlternatingRowStyle CssClass="searchResultsAltRow" />
                    <HeaderStyle CssClass="searchResultsHeader" />
                    <FooterStyle CssClass="searchResultsFooter" />
                    <PagerStyle CssClass="searchResultsPager" />
                    <PagerTemplate>
                        <asp:LinkButton CommandName="Page" CommandArgument="First" ID="LinkButton1" runat="server">« First</asp:LinkButton>
                        <asp:LinkButton CommandName="Page" CommandArgument="Prev" ID="LinkButton2" runat="server">< Prev</asp:LinkButton>
                        [Records
                        <%= gridSearchResults.PageIndex * gridSearchResults.PageSize%>-<%= gridSearchResults.PageIndex * gridSearchResults.PageSize + gridSearchResults.PageSize - 1%>]
                        <asp:LinkButton CommandName="Page" CommandArgument="Next" ID="LinkButton3" runat="server">Next ></asp:LinkButton>
                        <asp:LinkButton CommandName="Page" CommandArgument="Last" ID="LinkButton4" runat="server">Last »</asp:LinkButton>
                    </PagerTemplate>
                    <Columns>
                        <asp:CommandField ShowSelectButton="True">
                            <HeaderStyle CssClass="hiddenColumn"></HeaderStyle>
                            <ItemStyle CssClass="hiddenColumn"></ItemStyle>
                        </asp:CommandField>
                        <asp:BoundField DataField="name" HeaderText="Name" SortExpression="" />
                        <asp:BoundField DataField="institution" HeaderText="Institution" SortExpression="" />
                    </Columns>
                </asp:GridView>
            </div>
        </asp:Panel>
    </div>
  </div>
</asp:Content>
