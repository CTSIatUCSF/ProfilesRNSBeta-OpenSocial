<%@ Page Language="C#" MasterPageFile="~/ProfilesPage.master" AutoEventWireup="true"
    CodeFile="ProfileDetails.aspx.cs" Inherits="ProfileDetails" EnableEventValidation="false" Title="UCSF Profiles"
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
    <style type="text/css">
       #ctl00_ctl00_divContainer {
            background:url("template_files/border.gif") no-repeat scroll 202px 36px transparent !important; 
       }
    </style>
    <div class="vcard">
    
    <script src="Scripts/JScript.js" type="text/jscript"></script>
    
    <table width="100%">
        <tr>
            <td>
                <h1 class="pageTitle fn">
                    <asp:Literal ID="ltProfileName" runat="server" /><asp:Image ID="imgReach" runat="server"
                        BorderStyle="None" Visible="false" CssClass="reachImage" /></h1>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlReadOnlySection" runat="server" Visible="true">
        <table width="100%" cellpadding="1" cellspacing="1">
            <tr>
                <td>
                    <ucProfileBaseInfo:ProfileBaseInfo ID="ucProfileBaseInfo" runat="server" Visible="true" />
                </td>
                <td style="vertical-align: top; width: 140px; padding-top: 5px;">
                    <asp:Image ID="imgReadPhoto" runat="server" Width="120px" 
                        Style="border: solid 1px #999; margin-bottom:20px;" class="photo"
                        ImageUrl="images/photobigconf.jpg" />
            <asp:HyperLink ID="hypAboutProfiles" runat="server" CssClass="DisclosureLink"               NavigateUrl="~/HowProfilesWorks.aspx#edit">How do I edit my profile?</asp:HyperLink>
                </td>
            </tr>
        </table>
        <div style="clear: both">
        </div>

        <div id="network-links-with-image" class="network-connections">
            <h2>Who Is Connected to <%=GetFirstName()%> <%=GetLastName()%>?</h2>
            <a href="SimilarPeople.aspx?Person=<%=GetPersonID()%>">
                 Discover Similar Researchers</a>
            <a href="CoAuthors.aspx?Person=<%=GetPersonID()%>">
                 Explore Co-Author Network</a>
            <a href="CoAuthorNet.aspx?Person=<%=GetPersonID()%>">
                 <img src="template_files/network.png" alt="network" /></a>
        </div>

        <div id="pnlReadoOnlyAwardsHonors" runat="server" visible="true">
            <div class="sectionHeader">
                <asp:Literal ID="ltrReadAwardsHonors" runat="server" Text="Awards and Honors" Visible="true" />
            </div>
            <div>
                <asp:Repeater ID="RptrReadAwardsHonors" runat="server">
                    <HeaderTemplate>
                        <table cellpadding="2" cellspacing="2" border="0" id="awards">
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
        <div id="pnlReadOnlyNarrative" runat="server" class="box">
            <div class="sectionHeader">
                <asp:Literal ID="ltrReadNarrative" runat="server" Text="Narrative" Visible="true" />
            </div>
            <div>
                <asp:Label ID="lblReadOnlyNarrative" runat="server" CssClass="narrativeText" />
            </div>
        </div>
        
        <%-- Profiles OpenSocial Extension by UCSF --%>    
        <div id="pnlOpenSocialGadgets" runat="server" style="margin-top:18px">
            <script type="text/javascript" language="javascript">
                my.current_view = "profile";
            </script>                
            <div id="gadgets-view" class="gadgets-gadget-parent"></div>
        </div>
        <div style="clear: both">
        </div>
        
        <div id="pnlReadOnlyPublications" runat="server">
            <div class="sectionHeader">
                <asp:Literal ID="ltrReadPublications" runat="server" Text="Publications" Visible="true" />
                <div class="subSectionHeader">
                    <div class="disclosureText"><asp:Literal ID="Literal1" runat="server" Text="Publications listed below are derived from "/>
                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="DisclosureLink" NavigateUrl="http://www.ncbi.nlm.nih.gov/pubmed/">MEDLINE/PubMed</asp:HyperLink><asp:Literal ID="Literal5" runat="server" Text=". The automated process used emphasizes accuracy but not completeness. Faculty can make  "/>
                    <asp:HyperLink ID="HyperLink4" runat="server" CssClass="DisclosureLink" NavigateUrl="~/HowProfilesWorks.aspx#edit">corrections and additions</asp:HyperLink><asp:Literal ID="Literal6" runat="server" Text=", or "/>
                    <asp:HyperLink ID="HyperLink5" runat="server" CssClass="DisclosureLink" NavigateUrl="mailto:ctsi@ucsf.edu">contact us</asp:HyperLink>
                    <asp:Literal ID="Literal7" runat="server" Text=" for help."/></div>
                </div>
            </div>
            <div>
                <asp:Repeater ID="rptPublications" runat="server">
                    <HeaderTemplate>
                        <table cellpadding="0" cellspacing="0" border="0">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td valign="top" align="left">
                                <asp:Label ID="lblPubIndex" runat="server" Text='<%# String.Format("{0}.", Container.ItemIndex + 1) %>'
                                    CssClass="publicationRowText" />
                            </td>
                            <td>
                                <asp:Label ID="lblPubRef" runat="server" Text='<%# Eval("PublicationReference") %>'
                                    CssClass="publicationRowText" />
                            </td>
                        </tr>
                        <div id="divPublicationSource" runat="server">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Repeater ID="rptPubSource" runat="server" DataSource='<%# Eval("PublicationSourceList") %>'
                                        OnItemDataBound="rptPubSource_ItemDataBound">
                                        <HeaderTemplate>
                                            <span class="viewInLabel">View in:</span>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="lnkPubLoc" runat="server" Text='<%# Eval("Name") %>' NavigateUrl='<%# Eval("URL") %>'
                                                Target="_new" OnDataBinding="lnkPubLoc_DataBinding"></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                        </div>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <div class="LineSeperatorPubs" style="width: 100%">
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table></FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </asp:Panel>
    <div class="subSectionHeader">
        <asp:Literal ID="txtProfileProblem" runat="server"></asp:Literal></div>
                <div class="subSectionHeader">
                    <div class="disclosureText"><asp:Literal ID="Literal2" runat="server" Text="Publications listed above are derived from "/>
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="DisclosureLink" NavigateUrl="http://www.ncbi.nlm.nih.gov/pubmed/">MEDLINE/PubMed</asp:HyperLink><asp:Literal ID="Literal3" runat="server" Text=". The automated process used emphasizes accuracy but not completeness. You can make corrections and additions "/>
                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="DisclosureLink" NavigateUrl="~/HowProfilesWorks.aspx#edit">yourself</asp:HyperLink><asp:Literal ID="Literal4" runat="server" Text=", or "/>
                    <asp:HyperLink ID="HyperLink6" runat="server" CssClass="DisclosureLink" NavigateUrl="mailto:ctsi@ucsf.edu">contact us</asp:HyperLink>
                    <asp:Literal ID="Literal8" runat="server" Text=" for help."/></div>
                </div>
    <%--    <asp:Panel ID="pnlControl" runat="server" Visible="false">
        <asp:PlaceHolder ID="plToControl" runat="server" />
    </asp:Panel>--%>
    <%--    <asp:HiddenField ID="hdnValue" runat="server" Visible="true" />--%>
   </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="upnlRightCol" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="rightColumnWidget">
                 <div class="pageBackLink" style="margin: 0 10px 0 0;">
                    <asp:HyperLink ID="hypBack" runat="server" Style="cursor: pointer;" Visible="false">
                      Back to Search Results</asp:HyperLink>
                    <asp:HiddenField ID="hdnBack" runat="server" />
                </div>
                <div style="height:36px">&nbsp;</div>
                <ucProfile:ProfileRightSide ID="ProfileRightSide1" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
<script language="javascript" type="text/javascript">
    if (!document.getElementById("ctl00_ctl00_right_RightContentPlaceHolder_ProfileRightSide1_AuthorList1_grdAuthors")) {
        document.getElementById("network-links-with-image").style.display = "none";
    }
    if ($('span#ctl00_ctl00_middle_MiddleContentPlaceHolder_lblReadOnlyNarrative').text().length < 500) {
        $('div#ctl00_ctl00_middle_MiddleContentPlaceHolder_pnlReadOnlyNarrative').removeClass('box');
    }
    $('.box').addClass('box-collapsed');
    $('span#ctl00_ctl00_middle_MiddleContentPlaceHolder_lblReadOnlyNarrative').append(" <span class='spacer'>&nbsp;</span>");
    $('.box').prepend("<div class='plusbutton'><span> <strong>...</strong> Show more</span> <img src='Images/icon_squareArrow.gif' alt='+' style='vertical-align:top' /></div><div class='minusbutton'><span>Show less</span> <img src='Images/icon_squareDownArrow.gif' alt='-' style='vertical-align:top' /></div>");
    $('.plusbutton').click(function () {
        $(this).parent().removeClass('box-collapsed');
        $(this).siblings().show();
        $(this).hide();
    });
    $('.minusbutton').click(function () {
        $(this).parent().addClass('box-collapsed');
        $(this).siblings().show();
        $(this).hide();
    });

    var awardsrows = $('#awards tr');
    var awardstbody = $('#awards tbody');
    var arr = $.makeArray(awardsrows);
    arr.reverse(); // reverse the order of awards 
    $(arr).appendTo(awardstbody);
    if ($('#awards tr').length > 4) {
        $('#awards tr:gt(2)').hide();
        $('#awards tr td:nth-child(2)').css('width', '547px');
        $("<div class='atog' id='moreawards'><span> <strong>...</strong> Show more</span> <img src='Images/icon_squareArrow.gif' alt='+' style='vertical-align:top' /></div>").insertAfter('#awards tr:nth-child(3) td:nth-child(2) span');
        $("<div class='atog' id='lessawards'><span>Show less</span> <img src='Images/icon_squareDownArrow.gif' alt='-' style='vertical-align:top' /></div>").insertAfter('#awards tr:last-child td:nth-child(2) span');
    }
    $('#moreawards').click(function () {
        $('#awards tr:gt(2)').toggle();
        $('#moreawards').hide();
        $('#lessawards').show();
    });
    $('#lessawards').click(function () {
        $('#awards tr:gt(2)').toggle();
        $('#moreawards').show();
        $('#lessawards').hide();
    });
    $('#menuContainer').insertAfter('#belowgadgets').css('margin-top', '-8px');
    if (!$('#ctl00_ctl00_left_hypLogout').length) {
        var badge = "<ul id='badge'>"
            + "<li><a href='http://open-proposals.ucsf.edu/opensocial-gadgets' target='_blank'>"
            + "<div class='badge contest' style='margin:10px 0 10px 10px;width:150px;padding-left:8px;'>"
            + "<p>Got a great idea for a new Profiles feature? "
            + "You could win an iPad for suggesting it in the <br /><strong>"
            + "Gadget Contest</strong>.</p></div></a></li>"
            + "<li><a href='" + g_hypLogin + "'>"
            + "<div class='badge chatter-group' style='margin:10px 0 10px 10px;width:150px;padding-left:8px;'>"
            + "<p style='padding-top:90px'><strong>Login</strong> to create a "
            + "UCSF Chatter group right from UCSF Profiles!</p></div></a></li>"
            + "<li><a href='" + g_hypLogin + "'>"
            + "<div class='badge chatter-follow' style='margin:10px 0 10px 10px;width:150px;padding-left:8px;'>"
            + "<p style='padding-top:90px'><strong>Login</strong> and follow people on UCSF Chatter! "
            + "Receive updates when people you follow publish new articles.</p></div></a></li></ul>";
        $(badge).insertBefore('#menuContainer');
        $("#badge li").hide();
        this.randomtip = function () {
            var length = $("#badge li").length;
            var ran = Math.floor(Math.random() * length) + 1;
            $("#badge li:nth-child(" + ran + ")").show();
        };
        $(document).ready(function () {
            randomtip();
        });
    }

    // addition by Eric Meeks to create activity in Javascript so that bots will not trigger the activity
    osapi.activities.create(
    { 'userId': gadgets.util.getUrlParameters()['Person'],
        'activity': { 'postedTime': new Date().getTime(), 'title': 'profile was viewed' }
    }).execute(function (response) { });
  
</script>
</asp:Content>


