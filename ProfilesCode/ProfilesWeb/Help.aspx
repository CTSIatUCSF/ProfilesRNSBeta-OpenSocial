<%@ Page Language="C#" MasterPageFile="~/ProfilesPage.master" AutoEventWireup="true" 
CodeFile="Help.aspx.cs" Title="Help" Inherits="Help" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MiddleContentPlaceHolder" Runat="Server">
<div id="contentPosition">
  <div class="pageTitle" style="line-height: 26px;">
    UCSF Profiles Help</div>


  <div class="content-block">
    <h2>What are the Data Sources?</h2>
    <p><strong>UCSF Profiles</strong> currently gets data about campus researchers via:</p>
    <ul>
      <li>PubMed</li>
      <li>Campus Locator System</li>
      <li>Directly from UCSF researchers</li>
    </ul>
    <p><strong>UCSF Profiles</strong>, powered by 
       <strong><a href="http://ctsi.ucsf.edu/about">CTSI</a></strong>, is a research networking tool that 
       allows users to search for investigators based on their expertise and to explore network 
       relationships between investigators, such as co-authorship or similar research topics. 
    </p>
  </div>

  <div class="content-block">
    <h2>Found an Error?</h2>
    <p><strong>Publications</strong>: To add, remove, or fix a publication, 
       <asp:HyperLink ID="hypLogMeIn2" runat="server">login to edit</asp:HyperLink> your profile page.
    </p>
    <p><strong>Photo</strong>: To add or remove a photo, 
       <asp:HyperLink ID="hypLogMeIn3" runat="server">login to edit</asp:HyperLink> your profile page.
    </p>
    <p><strong>Name/Degree/Contact Information</strong>: We get this data from the UCSF Campus 
       Locator System.Changes to your data should be directed to the Payroll/Personnel Analyst for 
       your UCSF campus department. If unsure who this person is, contact your department's Business  
       Officer. You can also contact ITS at 415-514-4100 (option 2) for more information. 
    </p>
    <h2>Need Help?</h2>
      <p>Email us at <a href="mailto:ctsi@ucsf.edu">ctsi@ucsf.edu</a>. We're happy to help!</p>
  </div>

</div>
</asp:Content>

