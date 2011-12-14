<%@ Page Title="" Language="C#" AutoEventWireup="true" 
MasterPageFile="~/ProfilesPage.master" 
CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MiddleContentPlaceHolder" runat="Server">
<asp:Panel ID="pnlSearch" runat="server" CssClass="loginPanel">
 
               <asp:Login ID="loginControl" runat="server" DestinationPageUrl="~/Search.aspx" onloggedin="loginControl_LoggedIn"
                    TitleText="Login" TitleTextStyle-CssClass="loginTitle" LabelStyle-CssClass="loginLabelText" CssClass="loginControl"></asp:Login>
                    
         
</asp:Panel>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
&nbsp;
</asp:Content>