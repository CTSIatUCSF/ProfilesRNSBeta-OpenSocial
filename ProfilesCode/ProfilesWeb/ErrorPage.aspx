<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrorPage.aspx.cs" Inherits="ErrorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Profiles</h1>
        <h4>An application error has occurred</h4>              
        This error has been logged to the server event log and should be reviewed.
        <br />
        <asp:Literal runat="server" ID="litError"></asp:Literal>
        <br />
        <br />
        <a href="Search.aspx">Click here to return home</a>
        
    </div>
    </form>
</body>
</html>
