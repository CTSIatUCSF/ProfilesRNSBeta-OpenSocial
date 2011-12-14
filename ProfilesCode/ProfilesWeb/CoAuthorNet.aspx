<%@ Page Title="Profiles Network Browser" Language="C#" MasterPageFile="ProfilesPage.master"
    AutoEventWireup="true" CodeFile="CoAuthorNet.aspx.cs" Inherits="CoAuthorNet" %>

<%@ Register Src="UserControls/ucProfileRightSide.ascx" TagName="ProfileRightSide"
    TagPrefix="ucProfile" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContentPlaceHolder2" runat="Server">
    <link rel="stylesheet" type="text/css" href="CSS/style.css" />

    <script type="text/javascript" src="scripts/querystring.js"></script>

  

    <style type="text/css">
        div.slider div.handle
        {
            top: -7px !important;
        }
        .nbIframe
        {
            width: 603px;
            height: 750px;
            border: none;
        }
    </style>

    <script type="text/javascript">
        var qs = new Querystring();
        var personId = qs.get("Person", "0");

        function set_ListView() {
            window.location = 'CoAuthors.aspx?Person=' + personId;
        }

        function set_MapView() {
            var qs = new Querystring()
            var personId = qs.get("Person", "0")

            window.location = 'gCoAuth.aspx?Person=' + personId;
        }

     
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MiddleContentPlaceHolder" runat="Server">
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
            <tr>
                <td colspan="2">
                    <div class="pageSubTitle">
                        <asp:Label ID="lblSubTitle" runat="server"></asp:Label></div>
                    <div class="pageSubTitleCaption">
                        Co-authors are people in Profiles who have published together.</div>
                </td>
            </tr>
        </tr>
    </table>
    <div class='tabContainer'>
        <div class='disabledTab'>
            <a href='javascript:set_ListView();'>
                <div class='tabLeft'>
                </div>
                <div class='tabCenter'>
                    List View</div>
                <div class='tabRight'>
                </div>
            </a>
        </div>
        <div class='activeTab'>
            <div class='tabLeft'>
            </div>
            <div class='tabCenter'>
                Network View</div>
            <div class='tabRight'>
            </div>
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

    <script type="text/javascript">
        function GoNetwork(x, y) {                   
            document.getElementById('nb').src = 'rb/default.aspx?Person=' + x;
        }
        function GoPerson(x) {
            document.location = '<%=ConfigurationManager.AppSettings["URLBase"].ToString() %>ProfileDetails.aspx?Person=' + x;
        }
    </script>

    <iframe src="rb/default.aspx?Person=<%=Request["Person"]%>" id="nb" class="nbIframe"
        frameborder="0" scrolling="no"></iframe>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="rightColumnWidget">
                <ucProfile:ProfileRightSide ID="ProfileRightSide1" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="FooterPlaceHolder1" runat="Server">
</asp:Content>
