<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProfileRightSide.ascx.cs" Inherits="ucProfileRightSide" %>
<%@ Register src="ucKeywords.ascx" tagname="KeywordList" tagprefix="ucKeywords" %>
<%@ Register src="ucCoAuthors.ascx" tagname="CoAuthorList" tagprefix="ucCoAuthor" %>
<%@ Register src="ucNeighbors.ascx" tagname="NeighborList" tagprefix="ucNeighbor" %>
<%@ Register src="ucSameDept.ascx" tagname="SameDeptList" tagprefix="ucSameDept" %>
<%@ Register src="ucSimilarPeople.ascx" tagname="SimilarPeopleList" tagprefix="ucSimilarPeople" %>
<div style="width: 130px;">
    <ucKeywords:KeywordList runat="server" ID="KeywordList1" />
    <div class="LineSeperatorRightMenu" id="line1" runat="server" visible="false"></div>
    <ucCoAuthor:CoAuthorList runat="server" ID="AuthorList1" />
    <div class="LineSeperatorRightMenu" id="line2" runat="server" visible="false"></div>
    <ucSimilarPeople:SimilarPeopleList runat="server" ID="SimilarPeopleList1" />
    <div class="LineSeperatorRightMenu" id="line3" runat="server" visible="false"></div>
    <ucSameDept:SameDeptList runat="server" ID="SameDeptList1" />
    <div class="LineSeperatorRightMenu" id="line4" runat="server" visible="false"></div>
    <ucNeighbor:NeighborList runat="server" ID="NeighborList1" />
</div>
