<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSearchList.ascx.cs" Inherits="ucSearchList" %>
 <%--
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
 --%> 
<table width="100%">
    <tr>
        <td>
            <h3 style="margin-bottom: 6px;">
                <asp:Literal ID="ltsubHeader" runat="server" /></h3>
        </td>
    </tr>
    <tr>
        <td>
            <asp:DataList ID="dlMeSH" runat="server" RepeatColumns="2" RepeatLayout="Table" OnItemDataBound="dlMeSH_OnItemDataBound" Visible="true" CssClass="SearchList" Width="100%">
                <ItemTemplate>
                    <asp:HyperLink ID="hypLnkMeSHlist" runat="server" CssClass="SearchListLink" Text='<%#Eval("link_text") %>' /></ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:DataList ID="dlPeopleList" runat="server" RepeatColumns="3" DataKeyField="PersonID" OnItemDataBound="dlPeopleList_OnItemDataBound" CssClass="SearchList" Width="100%" Visible="true">
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
                                <asp:HyperLink ID="hypLnkPeopleList" runat="server" Text='<%#Eval("ProfileNames") %>' />
                                <asp:Label ID="lblStar" runat="server" Style="color: #666666;" Text='<%#Eval("coauthor") %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <FooterTemplate>
                    <div style="margin-top: 14px;">
                        <asp:PlaceHolder ID="phSimilarCoauthors" runat="server">
                            <div style="margin-bottom: 12px; color: #666666;">
                                * These people are also co-authors
                            </div>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="phGoogleMap" runat="server">
                            <asp:HyperLink ID="hypNeighborMap" runat="server">View in Google Maps</asp:HyperLink>
                            <div style="font-size: 10px;">
                                (please wait while the map loads)</div>
                        </asp:PlaceHolder>
                    </div>
                </FooterTemplate>
            </asp:DataList>
        </td>
    </tr>
</table>
