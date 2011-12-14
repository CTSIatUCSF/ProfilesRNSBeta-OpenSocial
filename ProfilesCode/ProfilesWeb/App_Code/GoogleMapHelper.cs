using System;
using System.Data;
using System.Collections.Generic;
using Connects.Profiles.BusinessLogic;
using Connects.Profiles.Utility;

/// <summary>
/// Summary description for GoogleMapHelper
/// </summary>
public class GoogleMapHelper
{
    public GoogleMapHelper()  { }

    public string MapPlotPeople(int personId, IDataReader reader, IDataReader reader2)
    {
        System.Text.StringBuilder value = new System.Text.StringBuilder();
        

        value.AppendLine("<script type=\"text/javascript\">");

        value.AppendLine("var map = null;");

        value.Append("function initialize() {");
        value.AppendLine("function myLoc(xLoc,yLoc,theStr) {");
        value.AppendLine("this.x = xLoc;");
        value.AppendLine("this.y = yLoc;");
        value.AppendLine("this.str = theStr;"); 
        value.AppendLine("}");

        value.AppendLine("var locs = [];");

        value.AppendLine("function myCoAu(x1Loc,y1Loc,x2Loc,y2Loc,thisP) {");
        value.AppendLine("this.x1 = x1Loc;");
        value.AppendLine("this.y1 = y1Loc;");
        value.AppendLine("this.x2 = x2Loc;");
        value.AppendLine("this.y2 = y2Loc;");
        value.AppendLine("this.p = thisP;");
        value.AppendLine("}");

        value.AppendLine("var coau = [];");    
        
        try
        {
            if (personId != 0)
            {
                string prev = "";
                string str = "";
                string x = "";
                string y = "";
                string a = "";
                string html = "";
                Int32 l = 0;

                while (reader.Read())
                {
                    a = reader["address1"].ToString().Replace("'", "\\'") + "<br />" + reader["address2"].ToString().Replace("'", "\\'");
                    x = reader["latitude"].ToString();
                    y = reader["longitude"].ToString();
                    if ((x+y) != prev)
                    {
                        if (prev != "")
                        {
                            html = "<div style=\"text-align:left\">";
                            html = html + "<div style=\"font-weight:bold;font-size:14px;\">" + a + "</div>";
                            html = html + str;
                            html = html + "</div><br />";
                            html = html.Replace("'", "\'");
                            value.AppendLine("locs[" + l + "] = new myLoc(" + x + "," + y + ",'" + html + "');");
                            l = l + 1;
                        }
                        prev = (x + y);
                        str = "";
                    }
                    str = str + "<a href=\"javascript:goPerson(" + reader["PersonId"].ToString() + ");\">" + reader["display_name"].ToString().Replace("'", "\\'") + "</a><br>";
                }

                reader.Close();

                if (str.Length > 0)
                {
                    html = "<div style=\"text-align:left\">";
                    html = html + "<div style=\"font-weight:bold;font-size:14px;\">" + a + "</div>";
                    html = html + str;
                    html = html + "</div><br />";
                    html = html.Replace("'", "\'");
                    value.AppendLine("locs[" + l + "] = new myLoc(" + x + "," + y + ",'" + html + "');");
                }

                l = 0;
                while (reader2.Read())
                {
                    value.AppendLine("coau[" + l + "] = new myCoAu(" + reader2["x1"].ToString() + "," + reader2["y1"].ToString() + "," + reader2["x2"].ToString() + "," + reader2["y2"].ToString() + "," + reader2["is_person"].ToString() + ");");
                    l = l + 1;
                }
            }
        }
        catch (Exception ex)
        {
            string err = ex.Message;
        }
        finally
        {
            if (reader != null)
            { if (!reader.IsClosed) { reader.Close(); } }
        }

        //value.Append("function initialize() {");
        
        value.AppendLine("if (GBrowserIsCompatible()) {");
        value.AppendLine("map = new GMap2(document.getElementById(\"map_canvas\"));");
               

        List<String> mapDefault = new SystemBL().GetGoogleMapDefaultLocation();

        if (mapDefault.Count > 0)
        {
            value.AppendLine(String.Format("map.setCenter(new GLatLng({0}, {1}), {2});", mapDefault[0], mapDefault[1], mapDefault[2]));
        }
        else
        {
            decimal cLat = Convert.ToDecimal(ConfigUtil.GetConfigItem("GoogleMapCenterLatitude"));
            decimal cLong = Convert.ToDecimal(ConfigUtil.GetConfigItem("GoogleMapCenterLongitude"));
            value.AppendLine(String.Format("map.setCenter(new GLatLng({0}, {1}), 13);", cLat, cLong));
        }

        value.AppendLine("map.addControl(new GLargeMapControl());");
        value.AppendLine("map.addControl(new GMapTypeControl());");
        value.AppendLine("map.addControl(new GOverviewMapControl());");

        value.AppendLine("geocoder = new GClientGeocoder();");

        // Create a base icon for all of our markers that specifies the
        // shadow, icon dimensions, etc.
        value.AppendLine("var baseIcon = new GIcon();");
        value.AppendLine("baseIcon.shadow = \"http://www.google.com/mapfiles/shadow50.png\";");
        value.AppendLine("baseIcon.iconSize = new GSize(20, 34);");
        value.AppendLine("baseIcon.shadowSize = new GSize(37, 34);");
        value.AppendLine("baseIcon.iconAnchor = new GPoint(9, 34);");
        value.AppendLine("baseIcon.infoWindowAnchor = new GPoint(9, 2);");
        value.AppendLine("baseIcon.infoShadowAnchor = new GPoint(18, 25);");
        value.AppendLine();
        value.AppendLine("function createMarker(number) {");
        value.AppendLine("var point = new GLatLng(locs[number].x, locs[number].y);");
        // Create a lettered icon for this point using our icon class
        value.AppendLine("var letter = String.fromCharCode(\"A\".charCodeAt(0) + number);");
        value.AppendLine("var letteredIcon = new GIcon(baseIcon);");
        value.AppendLine("letteredIcon.image = \"http://www.google.com/mapfiles/marker.png\";");
        // Set up our GMarkerOptions object
        value.AppendLine("markerOptions = { icon:letteredIcon };");
        value.AppendLine("var marker = new GMarker(point, markerOptions);");
        value.AppendLine("GEvent.addListener(marker, \"click\", function() {");
        value.AppendLine("	var myHtml = locs[number].str;");
        value.AppendLine("	map.openInfoWindowHtml(point, myHtml);");
        value.AppendLine("});");
        value.AppendLine("return marker;");
        value.AppendLine("}");
        value.AppendLine();
        value.AppendLine("for (var i = 0; i < locs.length; i++) {");
        value.AppendLine("	map.addOverlay(createMarker(i));");
        value.AppendLine("}");
        value.AppendLine();
        value.AppendLine("for (var i = 0; i < coau.length; i++) {");
        value.AppendLine("	var poly = [] ;");
        value.AppendLine("	poly[0] = new GLatLng(coau[i].x1,coau[i].y1);");
        value.AppendLine("	poly[1] = new GLatLng(coau[i].x2,coau[i].y2);");
        value.AppendLine("	if (coau[i].p == 1) {");
        value.AppendLine("		var line = new GPolyline(poly,'#9900CC', 6, 0.5);");
        value.AppendLine("		map.addOverlay(line);");
        value.AppendLine("	}");
        value.AppendLine("	var line = new GPolyline(poly,'#0000FF', 2, 0.5);");
        value.AppendLine("	map.addOverlay(line);");
        value.AppendLine("}}}");

        //Add event to page load
        value.AppendLine(" if (window.attachEvent) {window.attachEvent('onload', initialize);}");
        value.AppendLine("</script>");

        return value.ToString();
    }

}
