<%@ Page Language="C#" MasterPageFile="~/ProfilesPage.master" AutoEventWireup="true" CodeFile="HowProfilesWorks.aspx.cs" Inherits="About" Title="About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MiddleContentPlaceHolder" Runat="Server">
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
<div id="contentPosition">
    <div class="pageTitle">
        How Profiles Works</div>

<ul> 
  <li><a href="HowProfilesWorks.aspx#info">Information about the Tool</a></li>
  <li><a href="HowProfilesWorks.aspx#faq">Frequently Asked Questions</a></li>
  <li>What can <em>UCSF Profiles</em> do for you? 
      <asp:HyperLink ID="hypIntroduction" runat="server" NavigateUrl="~/Introduction.pdf" target="_new">
      View an Introduction</asp:HyperLink>
      <span style="font-size:11px;color:#999999">(pdf 2MB)</span></li>
  <li><a href="HowProfilesWorks.aspx#contributors">Contributors and Acknowledgements</a></li>
</ul>

<p>UCSF Profiles enables the discovery of research expertise at UCSF, allowing for new ways to network and collaborate between researchers, between mentors and mentees, between researchers and community or industry partners, and much more. </p> 
<p>Whether you are UCSF faculty, a trainee, staff, Affiliate organization member, Community partner, Industry partner, or other member of the UCSF ecosystem, we encourage you to <a href="mailto:ctsi@ucsf.edu">get in touch</a> with us about your ideas on how to improve this tool.  We especially look forward to hearing from you if UCSF Profiles has enabled your research in any way.  Your success stories allow us to continue to build on such tools and to continue to get support.</p>

<div class="sectionHeader"><a name="info" style="color:#CA7C29;font-size:13px">Information about the Tool</a></div>
<h3>When you view a person's profile, three types of information are displayed:</h3>

<ol> 
  <li>Managed Descriptions
	<p>This is the typical information listed in a research profile, including name, titles, affiliation, phone number and email address. Faculty can edit their own profiles, adding publications, awards, narrative, and a photo. </p></li>
  <li>Passive Networks
	<p>Passive networks are formed automatically when faculty share common traits such as being in the same department, working in the same building, co-authoring the same paper, or researching the same topics (as defined, for example, by the "MeSH" keywords or other keywords assigned to their publications). The passive networks a person belongs to are shown on the right side of the page when viewing a profile. </p></li>
  <li>Active Networks
	<p>Active networks are the ones that you define. When UCSF users login to the website and view other people's profiles, they can mark those people as collaborators, advisors, or advisees. In other words, you can build your own network of people that you know. Currently, you can only see the networks that you build. In the future you will be able to share these lists with others. Active networks are shown on your left sidebar.</p></li>
</ol> 

<div class="sectionHeader"><a name="faq" style="color:#CA7C29;font-size:13px">Frequently Asked Questions</a></div>
<ul> 
  <li><a href="HowProfilesWorks.aspx#who">Who is listed in UCSF Profiles?</a></li>
  <li><a href="HowProfilesWorks.aspx#view">Who can view UCSF Profiles?</a></li>
  <li><a href="HowProfilesWorks.aspx#login">How do I login to UCSF Profiles?</a></li>
  <li><a href="HowProfilesWorks.aspx#edit">How do I edit my Profile?</a></li>
  <li><a href="HowProfilesWorks.aspx#data">What are the sources of data for UCSF Profiles?</a></li>
  <li><a href="HowProfilesWorks.aspx#network">What are the lists of networks on the right side of my profile?</a></li>
  <li><a href="HowProfilesWorks.aspx#missing">Why are there missing or incorrect publications in my profile?</a></li>
  <li><a href="HowProfilesWorks.aspx#update">How frequently are the data in the profiles updated?</a></li>
  <li><a href="HowProfilesWorks.aspx#keyword">Can I edit my keywords, co-authors, or list of similar people?</a></li>
  <li><a href="HowProfilesWorks.aspx#mynetwork">How can I create or edit “my network”?</a></li>
  <li><a href="HowProfilesWorks.aspx#learn">How can I learn more about the UCSF Profiles tool?</a></li>
  <li><a href="HowProfilesWorks.aspx#ideas">Where should I send my ideas on how to improve the tool?</a></li>
  <li><a href="HowProfilesWorks.aspx#sysreq">What are the system requirements for using UCSF Profiles?</a></li>
</ul>

<h3><a name="who" style="color:#333">Who is listed in UCSF Profiles?</a></h3>

<ul>
  <li>The initial collection of profiles primarily includes UCSF faculty members, researchers with academic leadership appointments, and postdoctoral scholars. We expect to expand Profiles to include other populations in the future. </li>
  <li>Please note: there may be a lag between a person’s hire date and generation of their full profile with publications.</li>
</ul>

<h3><a name="view" style="color:#333">Who can view UCSF Profiles?</a></h3>
<ul>
  <li>UCSF Profiles is searchable by people both inside and outside the UCSF community. However, people with a UCSF MyAccess account can login for additional features, such as editing their profile (see <a href="HowProfilesWorks.aspx#edit">How do I edit my Profile?</a> below).</li>
</ul>

<h3><a name="login" style="color:#333">How do I login to UCSF Profiles?</a></h3>
<p>To facilitate UCSF's transition to a "one username and password" environment, we've integrated UCSF Profiles with the UCSF's Federated Login system called "MyAccess”. The MyAccess login/password is the same used for the Campus VPN.</p>
<ul>
  <li>If you have a MyAccess account, you should automatically be directed back to UCSF Profiles after logging in. TIP: The MyAccess login/password is the same used for the Campus VPN.</li>
  <li>If you have never used your MyAccess account or for password support: go to <a href="https://myaccess.ucsf.edu/" title="Go to the UCSF ITS website" target="_new">https://myaccess.ucsf.edu/</a> or call ITS Customer Support at (415) 514-4100 (option 2).</li> 
  <li><a href="http://oaais.ucsf.edu/service_catalog/MyAccess.html" title="Go to the UCSF ITS website" target="_new">Learn more about MyAccess</a></li>
</ul>

<h3 id="edit"><a name="edit" style="color:#333">How do I edit my Profile?</a></h3>
<ul>
  <li>To edit your profile, click the Edit My Profile link on the left sidebar. You will be prompted to login with your MyAccess account. </li>
  <li>Your profile is divided into several sections: directory information, photo, awards and honors, narrative, and publications.</li> 
  <li>UCSF Profiles uses Campus Locator System data for your directory entry. Changes should be directed to the Payroll/Personnel Analyst for your UCSF campus department. If unsure who this person is, contact your department's Business Officer.</li>
  <li>You can display or hide each section, except directory information, by clicking the hide/show links. </li>
  <li>You can upload a custom photo and also edit the content in the awards, narrative, and publications sections. </li>
  <li>Keywords are derived automatically from the PubMed articles listed with your profile. You cannot edit keywords directly, but you can improve these lists by keeping your publications up to date. </li>
  <li><a href="mailto:ctsi@ucsf.edu">Contact us</a> if you have questions about editing your profile.</li>

</ul>
<h3><a name="data" style="color:#333">What are the sources of data for UCSF Profiles?</a></h3> 
<ul>
  <li>All data shown by default on this website are currently available on other public websites.</li> 
  <li>Directory information was obtained from the Campus Locator System, which feeds the central UCSF Directory.</li>
  <li>Publications are derived from the MEDLINE/PubMed citation database. </li>
</ul>
<h3><a name="network" style="color:#333">What are the lists of networks on the right side of my profile?</a></h3>
<ul>
  <li>The lists at the right side of a profile page are passive networks that are formed automatically when people share common traits, such as being in the same department.</li>

  <li>The profiles also provide a summary of the expertise represented in a person’s publications. </li>
  <li>This summary is organized in a series of MeSH terms used by the National Library of Medicine (NLM) to index the MEDLINE publications in each UCSF profile. </li>
  <li>Lists of keywords, co-authors and similar people at UCSF are derived from publications and are created automatically based on the MeSH terms.</li>
  <li>Department lists are determined automatically and reflect people in your home department.</li>
</ul>
<h3><a name="missing" style="color:#333">Why are there missing or incorrect publications in my profile?</a></h3> 
<ul>
  <li>Publications are added automatically from PubMed but also can be edited manually (see <a href="HowProfilesWorks.aspx#edit">How do I edit my Profile?</a> above). </li>
  <li>Unfortunately, there is no easy way to match articles in PubMed to the profiles on this website. The algorithm used to find articles from PubMed attempts to minimize the number of publications incorrectly added to a profile; however, this method results in some missing publications. </li>
  <li>People with common names or whose articles were written at other institutions are most likely to have incomplete publication lists. </li>
  <li>We encourage you to login to the site and add any missing publications or remove incorrect ones. To tell us how we’re doing or for questions regarding publications please send a note to <a href="mailto:ctsi@ucsf.edu">ctsi@ucsf.edu</a></li>
</ul>
<h3><a name="update" style="color:#333">How frequently are the data in the profiles updated?</a></h3>
<ul>

  <li>Directory information, such as names, degrees, and contact information will be automatically updated from changes made at your HR department. We will update these changes at least once a week.</li>
  <li>Publications will be updated from PubMed at least monthly.</li>
  <li>UCSF faculty can edit portions of their profiles, including publications, at any time by logging in via MyAccess. Passive networks that are derived from publications, such as keywords and similar people, will be then be updated nightly.</li>
</ul>
<h3><a name="keyword" style="color:#333">Can I edit my keywords, co-authors, or list of similar people?</a></h3>
<ul>
  <li>Keywords and co-authors at UCSF are derived automatically from the PubMed articles listed with your profile. You cannot edit these directly, but you can improve these lists by keeping your publications up to date. Please note that it takes up to 24 hours for the system to update your keywords, co-authors, and similar people after you have modified your publications. </li>
  <li>Keyword rankings and similar people lists are based on algorithms that weigh multiple factors including the number of corresponding publications, how relevant the concepts are to the overall topics of the publications, how long ago the publications were written, whether the person was the first or senior author and how many other people have written about the same topic. Your feedback is essential to helping us refine these algorithms.</li> 
  <li>A future version of this website will allow users to add custom keywords to their profiles. These will be separate from the automatically derived terms.</li>

</ul>
<h3><a name="mynetwork" style="color:#333">How can I create or edit “my network”?</a></h3>
<ul>
  <li>Active networks are shown on the left side of the page and are the ones that you define. </li>
  <li>When UCSF users login to the website and view other people's profiles, they can mark those people as collaborators, advisors, or advisees. In other words, you can build your own network of people that you know. </li>
  <li>Currently, only you can see the networks that you build. In the future you will be able to share these lists with others. </li>
</ul>

<h3><a name="learn" style="color:#333">How can I learn more about the UCSF Profiles tool?</a></h3>
<ul>
  <li><a href="AboutUCSFProfiles.aspx">Read more</a> about the Profiles tool, ongoing development and exciting collaborations.</li>
</ul>

<h3><a name="ideas" style="color:#333">Where should I send my ideas on how to improve the tool?</a></h3> 
<ul>
  <li>We encourage you to <a href="mailto:ctsi@ucsf.edu">get in touch</a> with us about your ideas on how to improve UCSF Profiles.  We especially look forward to hearing from you if Profiles has enabled your research in any way.  Your success stories allow us to continue to build on such tools and to continue to get support.</li>
  <li>To tell us how we’re doing or for questions please send a note to <a href="mailto:ctsi@ucsf.edu">ctsi@ucsf.edu</a></li>
</ul>

<h3><a name="sysreq" style="color:#333">What are the system requirements for using UCSF Profiles?</a></h3>
<ul>
  <li>UCSF Profiles works best using any of the following Operating Systems / Browsers:
    <ul>
      <li>Windows / Internet Explorer 7, 8</li>
      <li>Windows / Firefox 3+</li>
      <li>Macintosh / Firefox 3+</li>
      <li>Macintosh / Safari 3+</li>
    </ul></li>
  <li>If you are using an older browser or a browser not listed above such as Chrome, you may experience some errors in functionality. </li>
</ul>

<div class="sectionHeader"><a name="contributors" style="color:#CA7C29;font-size:13px">Contributors & Thanks!</a></div>
<p>At UCSF: </p>
<ul>
  <li>The CTSI Virtual Home team</li>
  <li>The ITS MyAccess and Data teams</li>
</ul>
<p>At Harvard: </p>
<ul>
  <li>Harvard Medical School, Harvard Catalyst, and Griffin Weber, MD, PhD</li>
</ul>
<h3  style="color:#CA7C29;font-size:13px">Acknowledgements: </h3>
<p>This service is made possible by the Profiles Research Networking Software developed under the supervision of Griffin M Weber, MD, PhD, with support from Grant Number 1 UL1 RR025758-01 to Harvard Catalyst: The Harvard Clinical and Translational Science Center from the National Center for Research Resources and support from Harvard University and its affiliated academic healthcare centers.</p>
</div>
</asp:Content>
