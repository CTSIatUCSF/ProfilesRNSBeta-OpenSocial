<%@ Page Language="C#" MasterPageFile="~/ProfilesPage.master" AutoEventWireup="true" CodeFile="GadgetLibrary.aspx.cs" Inherits="GadgetLibrary" Title="Gadget Library" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MiddleContentPlaceHolder" Runat="Server">
<div id="contentPosition">
<div class="pageTitle" style="line-height: 26px;">
    How UCSF Has Extended Profiles
</div>
<div id="forDevelopers">
<div style="float:right;width:227px;background-color:#457272;margin: -20px 1px 0 20px">
<p style="padding:6px 8px;margin:0;font-size:15px;color:#fff;">OpenSocial is a standard API for running embedded applications (gadgets) within a containing website.</p>
<p style="padding:6px 8px;margin:0;font-size:15px;color:#fff;">OpenSocial is supported by industry and research leaders such as Google, LinkedIn, Nature Network, and Elsevier SciVerse.
</p>
</div>
<p>UCSF has built a shareable library of OpenSocial applications to extend Profiles functionality. This extension supports the OpenSocial standard and will soon be available to any institution that wants to utilize these gadgets. <a href="mailto:ctsi@ucsf.edu">Contact us</a> to find out how.</p>
<p><a href="http://www.slideshare.net/CTSIatUCSF/informatics-profiles-opensocial" title="View the presentation on SlideShare" target="_blank">
  <img src="template_files/opensocial-slideset.jpeg" alt="Presentation thumbnail" align="top" /> View a presentation about UCSF's OpenSocial Profiles extensions </a></p>
<p>Learn more about OpenSocial:</p>
  <ul class="square">
    <li><a href="https://sites.google.com/a/opensocial.org/opensocial/Home" title="Visit the Google OpenSocial website">Google opensocial.org</a></li>
    <li><a href="http://docs.opensocial.org/display/OS/Home" title="Visit the OpenSocial 2.0 website">OpenSocial wiki</a></li>
<!--
    <li>Select one of the gadgets below to add to your installation of Profiles.</li>
    <li>See how to develop your own gadget and share it with the Profiles community.</li>
-->
</ul>

<h2 style="padding-top:20px;font-size:16px">Profile Enhancement Gadgets</h2>
  <ul class="square">
    <li><img src="template_files/mentorGadget.png" alt="Mentorship Gadget" style="float:right;padding-left:30px;padding-right:228px" />
        <strong>Faculty Mentoring</strong>: This gadget allows users to add data to their profile that indicates their interest in 
        mentoring faculty. It includes mentor types, a mentor-focused narrative and contact information. 
        <p><a href="ProfileDetails.aspx?From=SE&Person=4669955#gadgets-view">See an example</a> </p></li>
    <li style="margin-top:30px"><img src="template_files/presentationGadget.png" alt="Featured Presentations Gadget" style="float:right;padding-left:30px;padding-right:228px" />
        <strong>Featured Presentations</strong>: Profile owners can add presentations to their profile with this gadget. 
        Presentations are hosted at Slideshare. 
        <p><a href="ProfileDetails.aspx?From=SE&Person=5380156#gadgets-view">See an example</a></p></li>
    <li style="margin-top:57px"><img src="template_files/linksGadget.png" alt="Websites Gadget" style="float:right;padding-left:30px;padding-right:228px" />
        <strong>Websites</strong>: This gadget supports including links to the profile owner’s lab, department, or other research sites
        &mdash; requested by more users than any other gadget.  
        <p><a href="ProfileDetails.aspx?From=SE&Person=4991461#gadgets-view">See an example</a> </p></li>
</ul>

 
<h2 style="padding-top:30px;font-size:16px">Utility Gadgets</h2>
  <ul class="square">
    <li><img src="template_files/googleGadget.png" alt="Google Search Gadget" style="float:right;padding-left:30px;padding-right:228px" />
        <strong>Google Search</strong>: This gadget broadens the existing Profiles search to include the free-text fields like
        the profile narrative and awards.
        <p><a href="Search.aspx?From=SP&Keyword=pessin_prize#gadgets-search">See an example</a></p></li>
    <li style="margin-top:22px"><img src="template_files/listGadget.png" alt="Profile List Tool" style="float:right;padding-left:26px;padding-right:228px" />
        <strong>Profile List Tool</strong>: This tool allows logged-in users to build a list of profiles, based on search results, 
        co-author networks or profile-by-profile.  She or he can then export selected data from the profiles for administrative 
        purposes.  
        <p>Access to this gadget is limited to certain users. Please <a href="mailto:ctsi@ucsf.edu">contact us</a> for more         information.</p></li>
    <li style="margin-top:10px"><img src="template_files/pubsGadget.png" alt="Publication Export Gadget" style="float:right;padding-left:30px;padding-right:228px" />
        <strong>Publications Export</strong>: This tool allows logged-in users to export publications from any profile, in different
        formats. Easily convert PMIDs to PMCIDs and more.
        <p>To see it in action, login and look for the gadget at the bottom left column of any profile page.</p></li>

<div style="clear:both"></div>
</div>

</div>
</asp:Content>

