<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gPeople2.aspx.cs" Inherits="gPeople2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 <%--
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
 --%> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="CSS/People.css" />
    <link rel="stylesheet" type="text/css" href="CSS/resnav.css" />
    <link rel="stylesheet" type="text/css" href="CSS/header_footer.css" />
    <link rel="stylesheet" type="text/css" href="CSS/profiles.css" />   

</head>
 <script src="JQuery/jquery.js" type="text/javascript"></script>
 <script type="text/javascript" src="scripts/querystring.js"></script>
  <script type="text/javascript">
      var qs = new Querystring();
      var personId = qs.get("Person", "0");
      function zoomMap(zoom, latitude, longitude) {
          map.setCenter(new GLatLng(latitude, longitude), zoom);
      }

      function moreInfo(number) {
          document.location = 'Details.aspx?id=' + locs[number].atlasId;
      }

      function set_ListView() {

          window.location = 'SimilarPeople.aspx?Person=' + personId;
      }
      function goPerson(x) {
          parent.GMapGoPerson(x);
      }
               
        
        
    </script>


<body>
    <form id="form1" runat="server">
    <asp:Literal ID="litGoogleCode1" runat="server"></asp:Literal>
    <asp:Literal ID="litGoogleCode2" runat="server"></asp:Literal>
    <div>
        <div>
            <span style="color: #C00; font-weight: bold;">Red markers</span> indicate people
            similar to
            <asp:Label ID="lblPerson" runat="server"></asp:Label><br />
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
    </div>

    <script type="text/javascript">
        $(document).ready(function() {
            initialize();
        }); </script>

    </form>
</body>
</html>
