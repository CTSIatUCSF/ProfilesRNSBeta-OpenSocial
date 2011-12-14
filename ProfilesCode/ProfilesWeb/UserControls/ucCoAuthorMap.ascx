<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCoAuthorMap.ascx.cs" Inherits="UserControls_ucCoAuthorMap" %>
<div class="pageSubTitle"><asp:Literal ID="ltsubHeader" runat="server" /></div>
<asp:DataList ID="dlPeopleList" runat="server" RepeatColumns="3" DataKeyField="PersonId" OnItemDataBound="dlPeopleList_OnItemDataBound" Visible="true" Width="100%">
    <ItemTemplate>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblUID" runat="server" Text='<%#Eval("PersonId") %>' Visible="false" />
                </td>
                <td>
                    <asp:Label ID="LblRowNo" runat="server" Visible="false" ForeColor="#333" />
                </td>
                <td>
                    <asp:HyperLink ID="hypLnkPeopleList" runat="server" Text='<%#Eval("coauthors") %>' />
                    <asp:Label ID="lblStar" runat="server" Style="color: #666666;" Text='<%#Eval("coauthor") %>'></asp:Label>
                </td>
            </tr>
        </table>
    </ItemTemplate>
    <FooterTemplate>
        <div style="margin-top: 14px;">
            <asp:PlaceHolder ID="phGoogleMap" runat="server">
                <asp:HyperLink ID="hypNeighborMap" runat="server">View in Google Maps</asp:HyperLink>
                <div style="font-size: 10px;">
                    (please wait while the map loads)</div>
            </asp:PlaceHolder>
        </div>
    </FooterTemplate>
</asp:DataList>

