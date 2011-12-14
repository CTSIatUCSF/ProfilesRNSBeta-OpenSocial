<%@ Page Title="" Language="C#" MasterPageFile="~/ProfilesPage.master" AutoEventWireup="true"
    CodeFile="gCoAuth.aspx.cs" Inherits="gCoAuth" %>

<%@ Register Src="UserControls/ucProfileRightSide.ascx" TagName="ProfileRightSide"
    TagPrefix="ucProfile" %>
     <%--
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
 --%> 
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContentPlaceHolder2" runat="Server">

    <script type="text/javascript" src="scripts/querystring.js"></script>

    <script type="text/javascript">
        var qs = new Querystring();
        var personId = qs.get("Person", "0");

        function set_NetworkView() {
            window.location = 'CoAuthorNet.aspx?Person=' + personId;
        }

        function set_ListView() {
            window.location = 'CoAuthors.aspx?Person=' + personId;
        }


        function GMapGoPerson(x) {
            
            document.location = "default.aspx?redirect=profiledetails.aspx?person=" + x;

        }
</script>
        
        
    </script>

    <style type="text/css">
        div.slider div.handle
        {
            top: -7px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MiddleContentPlaceHolder" runat="Server">
    <asp:Literal ID="litGoogleCode1" runat="server"></asp:Literal>
  

    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <div class="pageTitle">
                    <asp:Literal ID="ltProfileName" runat="server" /></div>
            </td>
            <td valign="top">
                <div style="text-align: right;padding-top:8px;padding-right:8px">
                    <asp:HyperLink ID="hypBack" runat="server" CssClass="hypLinks">Back to Profile</asp:HyperLink>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div class="pageSubTitle">
                    <asp:Label ID="lblSubTitle" runat="server"></asp:Label></div>
                <div class="pageSubTitleCaption">
                    Co-authors are people in Profiles who have published together.</div>
            </td>
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
        <div class='disabledTab'>
            <a href='javascript:set_NetworkView();'>
                <div class='tabLeft'>
                </div>
                <div class='tabCenter'>
                    Network View</div>
                <div class='tabRight'>
                </div>
            </a>
        </div>
        <div class='activeTab'>
            <div class='tabLeft'>
            </div>
            <div class='tabCenter'>
                Map View</div>
            <div class='tabRight'>
            </div>
        </div>
    </div>   

  <%--  <div style="padding-left:8px">
        <div>
            <span style="color: #C00; font-weight: bold;">Red markers</span> indicate the co-authors
            of
            <asp:HyperLink ID="linkPerson" runat="server"></asp:HyperLink><br />
            <span style="color: #00C; font-weight: bold;">Blue lines</span> connect people who
            have published papers together.</div>
        <div style="background-color: #999; width: 590px; height: 1px; overflow: hidden;
            margin: 5px 0px;">
        </div>
        <div style="margin-bottom: 5px;">
            <b>Zoom</b>:&nbsp;&nbsp;
            <asp:DataList ID="dlGoogleMapLinks" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <ItemTemplate>
                    <a style="cursor:pointer" id="lnkMapLink" runat="server" onclick='<%# "JavaScript:zoomMap(" + Eval("ZoomLevel") + "," + Eval("Latitude") + "," + Eval("Longitude") + "); "%>'>
                        <asp:Label ID="lblMapLink" runat="server" Text='<%#Eval("Label")%>'></asp:Label></a>
                </ItemTemplate>
                <SeparatorTemplate>
                    &nbsp;|&nbsp;</SeparatorTemplate>
            </asp:DataList>
        </div>
        <div id="map_canvas" style="width: 590px; height: 500px; border: 1px solid #999;
            text-align: center;">
        </div>
    </div>--%>
    
    <iframe src='gCoAuth2.aspx?Person=<%=Request.QueryString["Person"] + "&displayname=" + GetDisplayName()%> ' scrolling="no" class="gmapIframe" frameborder="0"></iframe>
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
