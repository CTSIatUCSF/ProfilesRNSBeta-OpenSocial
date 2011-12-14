<%@ Page Title="" Language="C#" MasterPageFile="~/ProfilesPage.master" AutoEventWireup="true"
    CodeFile="gPeople.aspx.cs" Inherits="gPeople" %>

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

    <script type="text/javascript" src="JQuery/jquery.js"></script>

    <style type="text/css">
        div.slider div.handle
        {
            top: -7px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MiddleContentPlaceHolder" runat="Server">

    <script type="text/javascript" src="scripts/querystring.js"></script>

    <script type="text/javascript">

        var qs = new Querystring();
        var personId = qs.get("Person", "0");

        function set_NetworkView() {
            window.location = 'SimilarPeople.aspx?Person=' + personId;
        }

        function set_ListView() {
            window.location = 'SimilarPeople.aspx?Person=' + personId;
        }
        function GMapGoPerson(x) {

            document.location = "default.aspx?redirect=profiledetails.aspx?person=" + x;

        }

    </script>

    <asp:Literal ID="litGoogleCode1" runat="server"></asp:Literal>
    <table>
        <tr>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <div class="pageTitle">
                            <asp:Label ID="lblPerson" runat="server"></asp:Label>
                        </div>
                    </td>
                    <td valign="top" style="padding-top: 8px; padding-right: 8px;">
                        <div style="text-align: right;">
                            <asp:HyperLink ID="hypBack" runat="server" CssClass="hypLinks">Back Profile</asp:HyperLink>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan='2'>
                        <div class="pageSubTitle">
                            <asp:Literal ID="ltsubHeader" runat="server" />
                        </div>
                        <div class="pageSubTitleCaption">
                            Similar people share similar sets of concepts, but are not necessarily co-authors.</div>
                        </div>
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
                <div class='activeTab'>
                    <div class='tabLeft'>
                    </div>
                    <div class='tabCenter'>
                        Map View</div>
                    <div class='tabRight'>
                    </div>
                </div>
            </div>
            <%--  <div style="padding-left: 8px">
                <div>
                    <span style="color: #C00; font-weight: bold;">Red markers</span> indicate people
                    similar to
                    <asp:HyperLink ID="lnkBack" runat="server">[lnkBack]</asp:HyperLink><br />
                    <span style="color: #00C; font-weight: bold;">Blue lines</span> connect people who
                    have published papers together.</div>
                <div style="background-color: #999; width: 552px; height: 1px; overflow: hidden;
                    margin: 5px 0px;">
                </div>
                <div style="margin-bottom: 5px;">
                    <b>Zoom To</b>:&nbsp;&nbsp;
                    <asp:DataList ID="dlGoogleMapLinks" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
                        <ItemTemplate>
                            <a id="lnkMapLink" runat="server" onclick='<%# "JavaScript:zoomMap(" + Eval("ZoomLevel") + "," + Eval("Latitude") + "," + Eval("Longitude") + "); "%>'
                                style="cursor: pointer">
                                <asp:Label ID="lblMapLink" runat="server" Text='<%#Eval("Label")%>'></asp:Label></a>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            &nbsp;|&nbsp;</SeparatorTemplate>
                    </asp:DataList>
                </div>
                <div id="map_canvas" style="width: 550px; height: 550px; border: 1px solid #999;">
                </div>
            </div>--%>
            <iframe src='gPeople2.aspx?Person=<%=Request.QueryString["Person"] + "&Displayname=" + GetDisplayName()%>'
                scrolling="no" class="gmapIframe" frameborder="0"></iframe>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="rightColumnWidget">
                <ucProfile:ProfileRightSide ID="ProfileRightSide1" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
