<%@ page title="An Error Has Occurred" language="C#" autoeventwireup="true" CodeFile="UCSFErrorPage.aspx.cs"
inherits="UCSFErrorPage" masterpagefile="~/ProfilesPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MiddleContentPlaceHolder" runat="Server">
   <asp:Literal runat="server" ID="litError"></asp:Literal>

<p>If you have gotten to this page by clicking on one of your bookmarks, please check the web address of your bookmark and update it if necessary. </p>

<p><asp:HyperLink ID="hypUCSFProfiles" runat="server" Text="Return to UCSF Profiles" NavigateUrl="~/"></asp:HyperLink></p>
</asp:Content>

