<%@ Page Language="C#" MasterPageFile="~/ProfilesPage.master" AutoEventWireup="true" CodeFile="Keywords.aspx.cs" Inherits="Keywords" %>
<%@ Register Src="UserControls/ucKeywordMap.ascx" TagName="KeywordMap" TagPrefix="ucKeywordMap" %>
<%@ Register Src="UserControls/ucProfileRightSide.ascx" TagName="ProfileRightSide" TagPrefix="ucProfile" %>
 <%--
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
 --%> 
<asp:Content ID="Content1" ContentPlaceHolderID="MiddleContentPlaceHolder" runat="Server">
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <div class="pageTitle">
                    <asp:Literal ID="ltProfileName" runat="server" /></div>
            </td>
            <td>
                <div style="text-align: right; padding-right: 8px;">
                    <asp:PlaceHolder ID="phEditModeLabel" runat="server" Visible="false">
                        <asp:Label ID="lblEditMode" runat="server" Text="EDIT MODE" Style="font-weight: bold;
                            color: #cc0000;"></asp:Label>
                        &nbsp;|&nbsp;<asp:HyperLink ID="hypLnkReturn" runat="server" Text="View profile"
                            CssClass="hypLinks" />
                    </asp:PlaceHolder>
                    <asp:HyperLink ID="hypLnkViewProfile" runat="server" Text="Back to Profile" CssClass="hypLinks"
                        Visible="false" />
                    <asp:HyperLink ID="hypBack" runat="server" Style="cursor: pointer;" Visible="false">Back</asp:HyperLink>
                    <asp:HiddenField ID="hdnBack" runat="server" />
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <ucKeywordMap:KeywordMap ID="KeywordMap" runat="server" />
                <asp:HiddenField ID="hdnValue" runat="server" Visible="true" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="upnlRightCol" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="rightColumnWidget">
                <ucProfile:ProfileRightSide ID="ProfileRightSide1" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
