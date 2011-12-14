<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPassiveNetwork.ascx.cs"
    Inherits="UserControls_ucPassiveNetwork" %>
     <%--
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
 --%> 
<p>
<asp:Label runat="server" ID="lblKeywordHeader" Text="Keywords" CssClass="passiveNetworkHeader" Visible="false"></asp:Label>
<asp:DataList ID="rptKeywordList" runat="server" RepeatColumns="4" CellPadding="0" CellSpacing="0" RepeatLayout="Table" RepeatDirection="Horizontal" CssClass="passiveNetworkResults">
    <ItemTemplate>
        <asp:Label runat="server" ID="lblKeywords" Text='<%#Eval("Text") %>' CssClass="passiveNetworkText"></asp:Label>
    </ItemTemplate>
</asp:DataList>

<asp:Label runat="server" ID="lblSimilarPeopleHeader" Text="Similiar People" CssClass="passiveNetworkHeader" Visible="false"></asp:Label>
<asp:DataList ID="dlSimiliarPeople" runat="server" RepeatColumns="4" CellPadding="0" CellSpacing="0" RepeatLayout="Table" RepeatDirection="Horizontal" CssClass="passiveNetworkResults">
    <ItemTemplate>
        <asp:HyperLink runat="server" ID="lnkSimiliarPeople" Text='<%#Eval("Text") %>' NavigateUrl='<%# "~/ProfileDetails.aspx?From=Pinfo&Person=" + Eval("PersonID") %>' CssClass="passiveNetworkText"></asp:HyperLink>
    </ItemTemplate>
</asp:DataList>

<asp:Label runat="server" ID="lblCoAuthorHeader" Text="CoAuthors" CssClass="passiveNetworkHeader" Visible="false"></asp:Label>
<asp:DataList ID="dlCoAuthor" runat="server" RepeatColumns="4" CellPadding="0" CellSpacing="0" RepeatLayout="Table" RepeatDirection="Horizontal" CssClass="passiveNetworkResults">
    <ItemTemplate>
        <asp:HyperLink runat="server" ID="lnkCoAuthor" Text='<%#Eval("Text") %>' NavigateUrl='<%# "~/ProfileDetails.aspx?From=Pinfo&Person=" + Eval("PersonID") %>' CssClass="passiveNetworkText"></asp:HyperLink>    
    </ItemTemplate>
</asp:DataList>

<asp:Label runat="server" ID="lblNeighborHeader" Text="Similiar People" CssClass="passiveNetworkHeader" Visible="false"></asp:Label>
<asp:DataList ID="dlNeighbor" runat="server" RepeatColumns="4" CellPadding="0" CellSpacing="0" RepeatLayout="Table" RepeatDirection="Horizontal" CssClass="passiveNetworkResults">
    <ItemTemplate>
        <asp:HyperLink runat="server" ID="lnkNeighbor" Text='<%#Eval("Text") %>' NavigateUrl='<%# "~/ProfileDetails.aspx?From=Pinfo&Person=" + Eval("PersonID") %>' CssClass="passiveNetworkText"></asp:HyperLink>        
    </ItemTemplate>
</asp:DataList>

</p>
