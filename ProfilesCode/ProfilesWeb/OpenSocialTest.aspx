<%@ Page Language="C#" MasterPageFile="~/ProfilesPage.master" AutoEventWireup="true"
    CodeFile="OpenSocialTest.aspx.cs" Inherits="OpenSocialTest" EnableEventValidation="false"
    ValidateRequest="false" %>

<%@ Register Src="UserControls/ucProfileRightSide.ascx" TagName="ProfileRightSide"
    TagPrefix="ucProfile" %>
<%@ Register Src="UserControls/ucModifyNetwork.ascx" TagName="ModifyNetwork" TagPrefix="ucModifyNetwork" %>
<%@ Register Src="UserControls/ucProfileBaseInfo.ascx" TagName="ProfileBaseInfo"
    TagPrefix="ucProfileBaseInfo" %>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftContentPlaceHolder" runat="Server">
    <ucModifyNetwork:ModifyNetwork ID="ucModifyNetwork" runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MiddleContentPlaceHolder" runat="Server">

    <script src="Scripts/JScript.js" type="text/jscript"></script>

    <table width="100%">
        <tr>
            <td>
                <div class="pageTitle">
                    <asp:Literal ID="ltProfileName" runat="server" /><asp:Image ID="imgReach" runat="server"
                        BorderStyle="None" Visible="false" CssClass="reachImage" /></div>
            </td>
            <td align="right" valign="top">
                <div class="pageBackLink">
                    <asp:HyperLink ID="hypBack" runat="server" Style="cursor: pointer;" Visible="false">Back</asp:HyperLink>
                    <asp:HiddenField ID="hdnBack" runat="server" />
                </div>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlReadOnlySection" runat="server" Visible="true">
        <table width="100%" cellpadding="1" cellspacing="1">
            <tr>
                <td>
                    <ucProfileBaseInfo:ProfileBaseInfo ID="ucProfileBaseInfo" runat="server" Visible="true" />
                </td>
                <td style="vertical-align: top; width: 120px">
                    <asp:Image ID="imgReadPhoto" runat="server" Height="120px" Width="120px" Style="border: solid 1px #999;"
                        ImageUrl="images/photobigconf.jpg" />
                </td>
            </tr>
        </table>
        <div style="clear: both">
        </div>
        <div id="pnlReadoOnlyAwardsHonors" runat="server" visible="true">
            <div class="sectionHeader">
                <asp:Literal ID="ltrReadAwardsHonors" runat="server" Text="Awards and Honors" Visible="true" />
            </div>
            <div>
                <asp:Repeater ID="RptrReadAwardsHonors" runat="server">
                    <HeaderTemplate>
                        <table cellpadding="2" cellspacing="2" border="0">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lblAwardStartYear" runat="server" Text='<%#Eval("AwardStartYear") %>' />
                            </td>
                            <td>
                                <asp:Label ID="lblAwardName" runat="server" Text='<%# String.Format("{0} {1}", Eval("AwardInstitution_Fullname"), Eval("AwardName")) %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table></FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div id="pnlReadOnlyNarrative" runat="server">
            <div class="sectionHeader">
                <asp:Literal ID="ltrReadNarrative" runat="server" Text="Narrative" Visible="true" />
            </div>
            <div>
                <asp:Label ID="lblReadOnlyNarrative" runat="server" CssClass="narrativeText" />
            </div>
        </div>

        <div id="pnlReadOnlyPublications" runat="server">
        </div>
    </asp:Panel>
    <div class="subSectionHeader">
        <asp:Literal ID="txtProfileProblem" runat="server"></asp:Literal>
    </div>

    <asp:Panel ID="pnlGadgetIframe" runat="server" Visible="true">
    <%--
    <iframe id="gadgetFrame" width="100%" height="500" frameborder="0" runat="server">
      <p>Your browser does not support iframes.</p>
    </iframe>

    <iframe id='<%= "remote_iframe_" + OpenSocial().GetAppId()%>' name='<%= "remote_iframe_" + OpenSocial().GetAppId() %>' width="100%" height="500" frameborder="0" src='<%= OpenSocial().GetFrameSrc() %>'>
      <p>Your browser does not support iframes.</p>
    </iframe>
    <%= OpenSocial().GetIFrameHTML() %>
    --%>
    <asp:Repeater ID="RptrGadgets" runat="server">
        <HeaderTemplate>
            <span class="viewInLabel">Gadgets!</span></p>
        </HeaderTemplate>
        <ItemTemplate>
            <iframe id='<%# Eval("AppId", "remote_iframe_{0}") %>' name=<%# Eval("AppId", "remote_iframe_{0}") %>' width='100%' height='500' frameborder='0' 
                        src='<%# Eval("FrameSrc") %>'>
            <p>Your browser does not support iframes.</p></iframe>
        </ItemTemplate>
    </asp:Repeater>    
    </asp:Panel>

   <div id="gadget-chrome-x" class="gadgets-gadget-chrome"></div>

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
