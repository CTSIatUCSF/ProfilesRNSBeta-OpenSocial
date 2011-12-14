<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSimilarPeopleMap.ascx.cs"
    Inherits="UserControls_ucSimilarPeopleMap" %>
<div class="pageSubTitle">
    <asp:Literal ID="ltsubHeader" runat="server" /></div>
<div class="pageSubTitleCaption">
    Similar people share similar sets of concepts, but are not necessarily co-authors.</div>
<div class='tabContainer'>
    <div class='activeTab'>
        <div class='tabLeft'>
        </div>
        <div class='tabCenter'>
            List View</div>
        <div class='tabRight'>
        </div>
    </div>
    <div id="divMapView" runat="server" class='disabledTab'>
        <a href='javascript:set_MapView();'>
            <div class='tabLeft'>
            </div>
            <div class='tabCenter'>
                Map View</div>
            <div class='tabRight'>
            </div>
        </a>
    </div>
</div>
The people in this list are ordered by decreasing similarity.
<br />
<br />
<asp:DataList ID="dlPeopleList" runat="server" RepeatColumns="3" DataKeyField="PersonID"
    OnItemDataBound="dlPeopleList_OnItemDataBound" Width="100%" Visible="true">
    <ItemTemplate>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblUID" runat="server" Text='<%#Eval("PersonID") %>' Visible="false" />
                </td>
                <td>
                    <asp:Label ID="LblRowNo" runat="server" Visible="false" ForeColor="#333" />
                </td>
                <td>
                    <asp:HyperLink ID="hypLnkPeopleList" runat="server" Text='<%#Eval("similarpeople") %>' />
                    <asp:Label ID="lblStar" runat="server" Style="color: #666666;" Text='<%#Eval("coauthor") %>'></asp:Label>
                </td>
            </tr>
        </table>
    </ItemTemplate>
    <FooterTemplate>
        <div style="margin-top: 14px; padding-left: 6px;">
            <asp:PlaceHolder ID="phSimilarCoauthors" runat="server">
                <div style="margin-bottom: 12px; color: #666666;">
                    * These people are also co-authors
                </div>
            </asp:PlaceHolder>
        </div>
    </FooterTemplate>
</asp:DataList>
