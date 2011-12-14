<%@ Page Language="C#" MasterPageFile="~/ProfilesPage.master" Theme="blue" AutoEventWireup="true"
    CodeFile="ProxyEdit.aspx.cs" Inherits="ProxyEdit" Title="Proxies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MiddleContentPlaceHolder" runat="Server">
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td><div class="pageTitle"><asp:Literal ID="ltHeader" runat="server"/></div></td>
            <td><div style="text-align: right; padding-right: 8px;"><a onclick="history.back();">Back</a></div></td>
        </tr>
    </table>
    <div style="margin-top: 10px;">
        <asp:GridView ID="gridProxies" runat="server" DataKeyNames="PersonId" AllowPaging="true"
            PageSize="20" EmptyDataText="No proxies have been designated." AutoGenerateColumns="False"
            OnRowDataBound="gridProxies_RowDataBound" OnSelectedIndexChanged="gridProxies_SelectedIndexChanged" OnPageIndexChanged="gridProxies_PageIndexChanged"
            OnRowDeleting="gridProxies_RowDeleting" OnPageIndexChanging="gridProxies_PageIndexChanging" OnDataBound="gridProxies_DataBound"
            CssClass="searchResults">
            <RowStyle CssClass="searchResultsRow" />
            <AlternatingRowStyle CssClass="searchResultsAltRow" />
            <HeaderStyle CssClass="searchResultsHeader" />
            <FooterStyle CssClass="searchResultsFooter" />
            <PagerStyle CssClass="searchResultsPager" />
            <PagerTemplate>
                <table id="pagerOuterTable" class="pagerOuterTable" runat="server" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <table id="pagerInnerTable" class="pagerInnerTable" cellpadding="0" cellspacing="0"
                                runat="server" width="100%">
                                <tr>
                                    <td class="pageFirst">
                                        <asp:LinkButton CommandName="Page" CommandArgument="First" ID="lnkFirstPage" runat="server">«</asp:LinkButton>
                                    </td>
                                    <td class="pagePrevNumber">
                                        <asp:LinkButton CommandName="Page" CommandArgument="Prev" ID="lnkPrevPage" runat="server">Previous</asp:LinkButton>
                                    </td>
                                    <td width="100%">
                                        <div align="center">
                                            <table id="pagerNumberTable" cellpadding="0" cellspacing="3" runat="server">
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton CommandName="PageGroup" CommandArgument="Prev" ID="lnkPrevPageGroup"
                                                            runat="server" OnClick="lnkPrevPageGroup_OnClick">.....</asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton CommandName="PageGroup" CommandArgument="Next" ID="lnkNextPageGroup"
                                                            runat="server" OnClick="lnkNextPageGroup_OnClick">.....</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td class="pageNextNumber">
                                        <asp:LinkButton CommandName="Page" CommandArgument="Next" ID="lnkNextPage" runat="server">Next</asp:LinkButton>
                                    </td>
                                    <td class="pageLast">
                                        <asp:LinkButton CommandName="Page" CommandArgument="Last" ID="lnkLastPage" runat="server">»</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </PagerTemplate>
            <Columns>
                <asp:CommandField ShowSelectButton="True">
                    <HeaderStyle CssClass="hiddenColumn"></HeaderStyle>
                    <ItemStyle CssClass="hiddenColumn"></ItemStyle>
                </asp:CommandField>
                <asp:HyperLinkField DataTextField="displayname" HeaderText="Name" DataNavigateUrlFields="PersonId" DataNavigateUrlFormatString="~/ProfileDetails.aspx?Person={0}" />
                <asp:BoundField DataField="institutionname" HeaderText="Institution" SortExpression="institutionname" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

