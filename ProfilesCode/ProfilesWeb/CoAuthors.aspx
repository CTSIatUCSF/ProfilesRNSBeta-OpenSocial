<%@ Page Language="C#" MasterPageFile="~/ProfilesPage.master" AutoEventWireup="true"
    CodeFile="CoAuthors.aspx.cs" Inherits="CoAuthors" EnableEventValidation="false"
    ValidateRequest="false" %>

<%@ Register Src="UserControls/ucCoAuthorGrid.ascx" TagName="CoAuthorMap" TagPrefix="ucCoAuthorMap" %>
<%@ Register Src="UserControls/ucProfileRightSide.ascx" TagName="ProfileRightSide"
    TagPrefix="ucProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MiddleContentPlaceHolder" runat="Server">

    <script type="text/javascript" src="scripts/querystring.js"></script>

    <script type="text/javascript">
        function set_NetworkView() {
            var qs = new Querystring()
            var personId = qs.get("Person", "0")

            window.location = 'CoAuthorNet.aspx?Person=' + personId;
        }

        function set_MapView() {
            var qs = new Querystring()
            var personId = qs.get("Person", "0")

            window.location = 'gCoAuth.aspx?Person=' + personId;
        }
        $(document).ready(function () {
            $('#menuContainer').insertAfter('#belowgadgets').css('margin-top', '-8px');
        });
    </script>

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
                    <asp:HyperLink ID="hypBack" runat="server" Style="cursor: pointer;" Visible="false">Return to Profiles</asp:HyperLink>
                    <asp:HiddenField ID="hdnBack" runat="server" />
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div class="pageSubTitle">
                    <asp:Label ID="lblSubTitle" runat="server"></asp:Label></div>
                <div class="pageSubTitleCaption">
                    Co-authors are people in Profiles who have published together.</div>
            </td>
        </tr>
    </table>
    <div class='tabContainer'>
        <div class='activeTab'>
            <div class='tabLeft'>
            </div>
            <div class='tabCenter'>
                List View</div>
            <div class='tabRight'>
            </div>
        </div>
        <div class='disabledTab' id="div1" runat="server">
            <a href='javascript:set_NetworkView();'>
                <div class='tabLeft'>
                </div>
                <div class='tabCenter'>
                    Network View</div>
                <div class='tabRight'>
                </div>
            </a>
        </div>
        <div class='disabledTab' id="divMapView" runat="server">
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
    <div class="PersonList">
        <ul>
            <asp:Repeater ID="rptCoAuthor" runat="server">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="hypLnkCoAuthor" runat="server" Text='<%#Eval("Text") %>' NavigateUrl='<%# "~\\ProfileDetails.aspx?Person=" + Eval("PersonId") %>' /></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="rightColumnWidget">
                <ucProfile:ProfileRightSide ID="ProfileRightSide1" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>