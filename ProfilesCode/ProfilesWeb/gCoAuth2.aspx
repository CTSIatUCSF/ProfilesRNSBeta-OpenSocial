<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gCoAuth2.aspx.cs" Inherits="gCoAuth2" %>

<%@ Register Src="UserControls/ucProfileRightSide.ascx" TagName="ProfileRightSide"
    TagPrefix="ucProfile" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="CSS/People.css" />
    <link rel="stylesheet" type="text/css" href="CSS/resnav.css" />
    <link rel="stylesheet" type="text/css" href="CSS/header_footer.css" />
    <link rel="stylesheet" type="text/css" href="CSS/profiles.css" />    
    
     <style type="text/css">
        div.slider div.handle
        {
            top: -7px !important;
        }
    </style>
</head>
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
        
    </script>
   
<body>
    <form id="form1" runat="server">
     <asp:Literal ID="litGoogleCode1" runat="server"></asp:Literal>
     <asp:Literal ID="litGoogleCode2" runat="server"></asp:Literal>
    <script type="text/javascript">
        function zoomMap(zoom, latitude, longitude) {
            map.setCenter(new GLatLng(latitude, longitude), zoom);
        }

        function moreInfo(number) {
            document.location = 'Details.aspx?id=' + locs[number].atlasId;
        }

        function goPerson(x) {
            parent.GMapGoPerson(x);           
            
        }
        
    </script>
   
    <div>
        <div>
            <span style="color: #C00; font-weight: bold;">Red markers</span> indicate the co-authors
            of
            <asp:Label ID="lblPerson" runat="server"></asp:Label><br />
            <span style="color: #00C; font-weight: bold;">Blue lines</span> connect people who
            have published papers together.<br />
	    Please note: we are working to improve the address data for the map view. You may see errors on 
            these maps.</div>
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
         <script type="text/javascript">             
                 initialize();
             
        </script>

    </div>    
    </form>
</body>
</html>
