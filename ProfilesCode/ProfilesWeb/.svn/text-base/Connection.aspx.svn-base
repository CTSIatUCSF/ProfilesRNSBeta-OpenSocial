<%@ Page Title="" Language="C#" MasterPageFile="~/ProfilesPage.master" AutoEventWireup="true"
    CodeFile="Connection.aspx.cs" Inherits="Connection" %>
 <%--
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
 --%> 
<asp:Content ID="Content1" ContentPlaceHolderID="HeadingContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContainerContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MiddleContentPlaceHolder" runat="Server">
    <script src="JQuery/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery.noConflict();

        function togglePubMatch(tabToControl) {
            $(document).ready(function() {

                var imgColl;
                var divColl;
                var lnkSource;

                if (tabToControl == 0) {
                    imgColl = $("img[id*=imgPubMatchDetail]");
                    divColl = $("div[id*=divPubMatchDetail]");
                    lnkSource = $("a[id*=lnkToggleExpand]");
                }
                else {
                    imgColl = $("img[id*=imgPubMatchDetail2]");
                    divColl = $("div[id*=divPubMatchDetail2]");
                    lnkSource = $("a[id*=lnkToggleExpand]");
                }

                if (lnkSource[0].innerHTML == "Expand All") {

                    for (var j = 0; j < divColl.length; j++) {
                        divColl.get(j).style.display = "block";
                        divColl.get(j).style.height = "auto";
                        imgColl.get(j).src = "Images/arrowExpand_open.gif"
                    }

                    lnkSource[0].innerHTML = "Close All"
                }
                else {

                    for (var j = 0; j < divColl.length; j++) {
                        divColl.get(j).style.display = "none";
                        divColl.get(j).style.height = "0px";
                        imgColl.get(j).src = "Images/arrowExpand_closed.gif"
                    }

                    lnkSource[0].innerHTML = "Expand All"
                }
            });
        }
                
    </script>

    <div class="main_container_center">
        <table width="100%">
            <tr>
                <td>
                    <div class="pageTitle">
                        Connection</div>
                </td>
                <td>
                    <div style="text-align: right; padding-right: 8px;">
                        <a href="javascript:history.back()">Back to Search Results</a>
                    </div>
                </td>
            </tr>
        </table>
        <div class="pageSubTitle">
            <asp:Label ID="lblSubTitle" runat="server"></asp:Label></div>
        <div class="pageSubTitleCaption">
            <asp:Label ID="lblSubTitleCaptionText" runat="server"></asp:Label></div>
        <div class="connectionContainer">
            <asp:DataList ID="lstViewHeader" runat="server" Width="100%" CssClass="connectionContainerTable">
                <ItemTemplate>
                    <td class="connectionContainerItem">
                        <div>
                            <a href="javascript:history.back()">Search Results</a></div>
                        <div class="connectionItemSubText">
                            <asp:Label ID="lblHeaderKeywords" runat="server" OnDataBinding="lblHeaderKeywords_DataBinding" /></div>
                    </td>
                    <td class="connectionContainerArrow">
                        <table class="connectionArrowTable">
                            <tbody>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <div class="connectionDescription">
                                            <asp:Label ID="lblMatchPubCount" runat="server" Text='<%# String.Format("{0} Matching Publications", Eval("BasicStatistics.MatchingPublicationCount")) %>'></asp:Label></div>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="connectionLine" colspan="3">
                                        <img src="Images/arrow_doubleEnded.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                         &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td class="connectionContainerItem">
                        <div>
                            <asp:HyperLink ID="Label9" runat="server" Text='<%# Eval("Name.FullName") %>' NavigateUrl='<%# String.Format("~/ProfileDetails.aspx?Person={0}", Eval("PersonID")) %>' /></div>
                        <div class="connectionItemSubText">
                            <asp:Label ID="lblTotPubCount" runat="server" Text='<%# String.Format("{0} Total Publications", Eval("BasicStatistics.PublicationCount")) %>'></asp:Label></div>
                    </td>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <table width="100%">
            <tr>
                <td>
                    <span class="connectionFirstSearchPhrase">Publications matching search keywords:</span>
                    <br />                   
                </td>
                <td align="right">
                    <%--<a id="lnkToggleExpand" onclick="togglePubMatch(0)">Expand All</a>--%>
                </td>
            </tr>
        </table>
        <div class="publications">
            <ol>
                <asp:Repeater ID="rptMatchingPubs" runat="server">
                    <ItemTemplate>
                        <li class='<%# (Container.ItemIndex==0 ? "first" : "") %>'>
                            <asp:Label ID="lblPubRef" runat="server" Text='<%# Eval("PublicationReference") %>' />
                            <br />
                            <span class="viewInLabel">View in:</span>
                            <asp:Repeater ID="rptPubSource" runat="server" DataSource='<%# Eval("PublicationSourceList") %>'>
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkPubLoc" runat="server" Text='<%# Eval("Name") %>' NavigateUrl='<%# Eval("URL") %>'
                                        Target="_new"></asp:HyperLink>&nbsp;&nbsp;
                                </ItemTemplate>
                            </asp:Repeater>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ol>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
    <asp:DataList ID="lstSearchCriteriaDisplay" runat="server">
        <HeaderTemplate>
            <asp:Label ID="lblSearchCriteria" runat="server" Text="Search Criteria" CssClass="menuWidgetTitleRight"></asp:Label>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:Label ID="lblCriteria" runat="server" CssClass="keywordsList" Text='<%#Container.DataItem%>'></asp:Label>
        </ItemTemplate>
        <FooterTemplate><br /></FooterTemplate>
    </asp:DataList>    
    <asp:DataList ID="lstSearchKeywordDisplay" runat="server" OnItemDataBound="lstSearchKeywordDisplay_ItemDataBound">
        <HeaderTemplate>
            <asp:Label ID="lblSearchCriteria" runat="server" Text="Keywords" CssClass="menuWidgetTitleRight"></asp:Label>
            
        </HeaderTemplate>
        <ItemTemplate>
            <asp:Label ID="lblKeyword" CssClass="keywordsList" runat="server" Text='<%# Eval("Keyword") %>'></asp:Label>
        </ItemTemplate>
        
    </asp:DataList>
    <div class="passive_section_line">
    </div>
  
</asp:Content>
