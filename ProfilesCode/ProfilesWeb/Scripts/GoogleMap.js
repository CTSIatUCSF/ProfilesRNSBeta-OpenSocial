<script type="text/javascript">
function initialize()
{
    var map = null;
    
    function myLoc(yLoc,xLoc,theStr)
    {
        this.x = xLoc;
        this.y = yLoc;
        this.str = theStr;
    }
    
    var locs = [];
    
    function myCoAu(y1Loc,x1Loc,y2Loc,x2Loc,thisP)
    {
        this.x1 = x1Loc;
        this.y1 = y1Loc;
        this.x2 = x2Loc;
        this.y2 = y2Loc;
        this.p = thisP;
    }
    
    var coau = [];
    
    if (GBrowserIsCompatible())
    {
        map = new GMap2(document.getElementById("map_canvas"));
        map.setCenter(new GLatLng(42.347637, -71.144168), 12);
        map.setCenter(new GLatLng(42.354637, -71.089168), 13);
        map.addControl(new GLargeMapControl());
        map.addControl(new GMapTypeControl());
        map.addControl(new GOverviewMapControl());
        
        geocoder = new GClientGeocoder();
        var baseIcon = new GIcon();
        baseIcon.shadow = "http://www.google.com/mapfiles/shadow50.png";
        baseIcon.iconSize = new GSize(20, 34);
        baseIcon.shadowSize = new GSize(37, 34);
        baseIcon.iconAnchor = new GPoint(9, 34);
        baseIcon.infoWindowAnchor = new GPoint(9, 2);
        baseIcon.infoShadowAnchor = new GPoint(18, 25);
        
        function createMarker(number)
        {
            var point = new GLatLng(locs[number].x, locs[number].y);
            var letter = String.fromCharCode("A".charCodeAt(0) + number);
            var letteredIcon = new GIcon(baseIcon);
            
            letteredIcon.image = "http://www.google.com/mapfiles/marker.png";
            markerOptions = { icon:letteredIcon };
            var marker = new GMarker(point, markerOptions);
            
            GEvent.addListener(marker, "click", function() {
                var myHtml = locs[number].str;
                map.openInfoWindowHtml(point, myHtml);});
                
                return marker;
            }
            
            for (var i = 0; i < locs.length; i++)
            {
                map.addOverlay(createMarker(i));
            }
            
            for (var i = 0; i < coau.length; i++)
            {
                var poly = [] ;
                poly[0] = new GLatLng(coau[i].x1,coau[i].y1);
                poly[1] = new GLatLng(coau[i].x2,coau[i].y2);
                
                if (coau[i].p == 1)
                {
                    var line = new GPolyline(poly,'#9900CC', 6, 0.5);
                    map.addOverlay(line);
                }
                
                var line = new GPolyline(poly,'#0000FF', 2, 0.5);
                map.addOverlay(line);}}}
                
                if (window.attachEvent)
                {
                    window.attachEvent('onload', initialize);
                } else if (window.addEventListener)
                {
                    window.addEventListener('load', initialize, false);
                } else {document.addEventListener('load', initialize, false);
                }
                
</script> 