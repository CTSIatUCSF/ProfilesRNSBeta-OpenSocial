<%@ Page Title="" Language="C#" MasterPageFile="~/ProfilesPage.master" AutoEventWireup="true"
    CodeFile="Categories.aspx.cs" Inherits="Categories" %>

<%@ Register Src="UserControls/ucProfileRightSide.ascx" TagName="ProfileRightSide"
    TagPrefix="ucProfile" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MiddleContentPlaceHolder" runat="Server">
<script type="text/javascript" src="scripts/querystring.js"></script>
    <script type="text/javascript">

        var qs = new Querystring();
        var personId = qs.get("Person", "0");

        function set_Keywords() {
            window.location = 'Keywords.aspx?Person=' + personId;
        }     

    </script>

    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <div class="pageTitle">
                    <asp:Literal ID="ltProfileName" runat="server" /></div>
                <div  class="pageSubTitle">
                    <asp:Literal ID="ltsubHeader" runat="server" /></div>
            </td>
            <td valign="top">
                <div style="text-align: right; padding-right: 8px;padding-top:8px;">
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
                <div class='tabContainer'>
                    <div class='disabledTab'>
                        <a href='javascript:set_Keywords();'>
                            <div class='tabLeft'>
                            </div>
                            <div class='tabCenter'>
                                Keyword Cloud</div>
                            <div class='tabRight'>
                            </div>
                        </a>
                    </div>
                    <div class='activeTab'>
                        <div class='tabLeft'>
                        </div>
                        <div class='tabCenter'>
                            Categories</div>
                        <div class='tabRight'>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Literal ID="ltCategories" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="upnlRightCol" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="rightColumnWidget">
                <ucProfile:ProfileRightSide ID="ProfileRightSide1" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
