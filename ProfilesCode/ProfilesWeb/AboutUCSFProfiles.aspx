<%@ Page Language="C#" MasterPageFile="~/ProfilesPage.master" AutoEventWireup="true" 
CodeFile="AboutUCSFProfiles.aspx.cs" Title="About UCSF Profiles" Inherits="AboutUCSFProfiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MiddleContentPlaceHolder" Runat="Server">
<style type="text/css">
a { font-size: 100% }
</style>
<div id="contentPosition">
<div class="pageTitle" style="line-height: 26px;">
    What is UCSF Profiles?</div>
<h3 style="text-align:center;font-size:20px;padding:10px 0 16px;color:#999;">A Research Networking and Expertise Mining Tool</h3>
<table cellspacing="0" id="about">
<!--
 <tr>
  <td colspan="3" id="what-is">
    A Networking Tool <span>that reveals research expertise &amp; connections between investigators</span>
  </td>
 </tr>
-->
 <tr>
  <td style="background-color:#B8D0D0;padding:0 8px">
    <h2>Search</h2>
    <img src="template_files/search-icon.gif" alt="Magnifying Glass" class="sdn" style="padding:0 0 8px 25px" />
    <h3 style="text-align:center;color:#333">Experts, Collaborators, Mentors</h3>
    <ul class="square">
       <li>85,000+ publications</li>
       <li>2400+ UCSF faculty</li>
       <li>1000+ UCSF postdocs</li>
       <li>25+ biomedical institutions nationwide</li>
       <li>Directory information</li>
       <li>Soon to include UCSF residents, fellows, research staff</li>
    </ul>
  </td>

  <td style="padding:0 8px">
    <h2>Discover Networks</h2>
    <img src="template_files/profiles.jpg" alt="Discover Networks" class="sdn" style="padding:0 0 8px 30px" />
    <h3 style="text-align:center;color:#333">Peoples' Research Connections</h3>
    <ul class="square">
       <li>Who co-authored together</li>
       <li>Who worked on similar research topics</li>
       <li>Who are a person's physical neighbors</li>
    </ul>
  </td>

  <td style="background-color:#B8D0D0;padding:0 8px">
    <h2>Edit Your Profile</h2>
    <img src="template_files/develop-profile.gif" alt="Develop Your Profile" class="sdn" style="padding:0 0 8px 20px" />
    <h3 style="text-align:center;color:#333">Information about Your Research</h3>
    <ul class="square">
       <li>Narrative to describe your work</li>
       <li>Photo, website links, and awards</li>
       <li>Mentoring information</li>
       <li>Your presentations on SlideShare</li>
       <li>Edit your publications if necessary</li>
    </ul>
     <p style="text-align:center;margin:15px 40px 6px;padding:5px 0;border-left: solid 1px #8fb5b5;
       border-top: solid 1px #8fb5b5;background-color:#FFF;*margin:0 10px 6px">
       <asp:HyperLink ID="hypLogMeIn" runat="server" style="font-size: 14px; 
       background: url(template_files/arrows.gif) no-repeat scroll right 4px transparent; 
       padding-right: 13px;">Edit your profile now</asp:HyperLink></a></p>
 </td>
 </tr>
<!--
 <tr>
  <td style="background-color:#B8D0D0;text-align:center;">
    <p style="margin-top:15px">
      <a href="template_files/profiles.jpg" rel="example1"  title="Something about networks" class="watch">Show me how</a>
      <br /></a><span class="slides">(4 slides)</span></p>
    <p style="display:none"><a href="template_files/network.png" rel="example1"  title="It's stretchy">
      Grouped Photo 2</a></p>
    <p style="display:none"><a href="template_files/search-icon.gif" rel="example1"  title="Search for people or concepts">
      Grouped Photo 3</a></p>
  </td>
  <td style="text-align:center;">
    <p style="margin-top:15px">
      <a href="template_files/feed.jpg" rel="example3"  title="Embed data into your website" class="watch">Show me how
      <br /></a><span class="slides">(6 slides)</span></p>
    <p style="display:none"><a href="template_files/minisearch.png" rel="example3"  title="It's a little search box">
      Grouped Photo 2</a></p>
    <p style="display:none"><a href="template_files/develop-profile.gif" rel="example3"  title="Develop your profile">
      Grouped Photo 3</a></p>
  </td>
  <td style="background-color:#B8D0D0;">&nbsp;
  </td>
 </tr>
-->
 <tr>
  <td colspan="3" align="center">
    <p style="padding-bottom:10px"><a href="./"><img src="template_files/tryit.gif" alt="Try it!" style="border:none" /></a></p>
  </td>
 </tr>
 <tr>
  <td style="padding:8px 0 0 20px; font-size: 110%; border-bottom: 2px solid #B8D0D0;
    background: transparent url(template_files/gear.gif) no-repeat 20px 14px;">
    <h3 style="padding: 12px 0 8px 40px">Toolbox</h3> 
    <ul class="square" style="margin-left: 0;">
      <li><a href="ForDevelopers.aspx">Profiles data tools for your website</a></li>
      <li><a href="GadgetLibrary.aspx">Profiles OpenSocial extensions</a></li>
    </ul>
  </td>
  <td style="padding:8px 0 0 20px; font-size: 110%; border-bottom: 2px solid #B8D0D0;
    background: transparent url(template_files/help.gif) no-repeat 20px 12px;">
    <h3 style="padding: 12px 0 8px 40px">Help</h3>
    <ul class="square" style="margin-left: 0;">
      <li><a href="HowProfilesWorks.aspx#faq">Frequently Asked Questions</a></li>
      <li><a href="Help.aspx">Found an error?</a></li>
      <li><a href="mailto:ctsi@ucsf.edu">Contact us</a></li>
    </ul>
  </td>
  <td style="padding:8px 0 0 20px; font-size: 110%; border-bottom: 2px solid #B8D0D0;
    background: transparent url(template_files/comment.gif) no-repeat 20px 14px;">
     <h3 style="padding: 12px 0 15px 40px">Feedback</h3> 
     <p style="margin:0 0 0 2px">Share your ideas and success stories at the 
     <a href="http://ctsi.ucsf.edu/forums/ucsfprofiles" target="_blank">UCSF Profiles Open Forum</a></p>
  </td>
 </tr>
</table>

<h3 style="padding-top:20px">Acknowledgement</h3>
<p>UCSF Profiles is UCSF’s version of the ground-breaking, open source "Profiles Research Networking Software" that was developed under the supervision of Griffin M Weber, MD, PhD, with support from Grant Number 1 UL1 RR025758-01 to <a href="http://catalyst.harvard.edu/" target="_new">Harvard Catalyst: The Harvard Clinical and Translational Science Center</a> from the National Center for Research Resources and support from Harvard University and its affiliated academic healthcare centers.</p>

<p>Harvard Catalyst Profiles is available as an <a href="http://connects.catalyst.harvard.edu/profiles/about/opensource" target="_new">open source platform</a> for institutions seeking a web-based means of facilitating collaboration among their academic researchers. </p>
	
<script language="javascript" type="text/javascript">
  $(document).ready(function(){
    $("a[rel='example1']").colorbox({transition:"none", width:"75%", height:"75%"});			
    $("a[rel='example3']").colorbox({transition:"none", width:"75%", height:"75%"});			
  });
</script>


</div>
</asp:Content>



