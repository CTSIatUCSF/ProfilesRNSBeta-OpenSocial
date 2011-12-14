<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Network Browser</title>
<style>
form {margin:0px;padding:0px;}
</style>

<link rel="stylesheet" type="text/css" href="CSS/style.css" />

<script type="text/javascript" src="http://localhost:15643/ProfilesWeb/scriptaculous/prototype.js"></script>
<script type="text/javascript" src="http://localhost:15643/ProfilesWeb/scriptaculous/scriptaculous.js"></script>
<script type="text/javascript" src="http://localhost:15643/ProfilesWeb/networkBrowserClass.js"></script>


<script language="JavaScript" type="text/javascript">
<!--
//v1.7
// Flash Player Version Detection
// Detect Client Browser type
// Copyright 2005-2008 Adobe Systems Incorporated.  All rights reserved.
var isIE  = (navigator.appVersion.indexOf("MSIE") != -1) ? true : false;
var isWin = (navigator.appVersion.toLowerCase().indexOf("win") != -1) ? true : false;
var isOpera = (navigator.userAgent.indexOf("Opera") != -1) ? true : false;
function ControlVersion()
{
	var version;
	var axo;
	var e;
	// NOTE : new ActiveXObject(strFoo) throws an exception if strFoo isn't in the registry
	try {
		// version will be set for 7.X or greater players
		axo = new ActiveXObject("ShockwaveFlash.ShockwaveFlash.7");
		version = axo.GetVariable("$version");
	} catch (e) {
	}
	if (!version)
	{
		try {
			// version will be set for 6.X players only
			axo = new ActiveXObject("ShockwaveFlash.ShockwaveFlash.6");

			// installed player is some revision of 6.0
			// GetVariable("$version") crashes for versions 6.0.22 through 6.0.29,
			// so we have to be careful.

			// default to the first public version
			version = "WIN 6,0,21,0";
			// throws if AllowScripAccess does not exist (introduced in 6.0r47)
			axo.AllowScriptAccess = "always";
			// safe to call for 6.0r47 or greater
			version = axo.GetVariable("$version");
		} catch (e) {
		}
	}
	if (!version)
	{
		try {
			// version will be set for 4.X or 5.X player
			axo = new ActiveXObject("ShockwaveFlash.ShockwaveFlash.3");
			version = axo.GetVariable("$version");
		} catch (e) {
		}
	}
	if (!version)
	{
		try {
			// version will be set for 3.X player
			axo = new ActiveXObject("ShockwaveFlash.ShockwaveFlash.3");
			version = "WIN 3,0,18,0";
		} catch (e) {
		}
	}
	if (!version)
	{
		try {
			// version will be set for 2.X player
			axo = new ActiveXObject("ShockwaveFlash.ShockwaveFlash");
			version = "WIN 2,0,0,11";
		} catch (e) {
			version = -1;
		}
	}

	return version;
}
// JavaScript helper required to detect Flash Player PlugIn version information
function GetSwfVer(){
	// NS/Opera version >= 3 check for Flash plugin in plugin array
	var flashVer = -1;

	if (navigator.plugins != null && navigator.plugins.length > 0) {
		if (navigator.plugins["Shockwave Flash 2.0"] || navigator.plugins["Shockwave Flash"]) {
			var swVer2 = navigator.plugins["Shockwave Flash 2.0"] ? " 2.0" : "";
			var flashDescription = navigator.plugins["Shockwave Flash" + swVer2].description;
			var descArray = flashDescription.split(" ");
			var tempArrayMajor = descArray[2].split(".");
			var versionMajor = tempArrayMajor[0];
			var versionMinor = tempArrayMajor[1];
			var versionRevision = descArray[3];
			if (versionRevision == "") {
				versionRevision = descArray[4];
			}
			if (versionRevision[0] == "d") {
				versionRevision = versionRevision.substring(1);
			} else if (versionRevision[0] == "r") {
				versionRevision = versionRevision.substring(1);
				if (versionRevision.indexOf("d") > 0) {
					versionRevision = versionRevision.substring(0, versionRevision.indexOf("d"));
				}
			}
			var flashVer = versionMajor + "." + versionMinor + "." + versionRevision;
		}
	}
	// MSN/WebTV 2.6 supports Flash 4
	else if (navigator.userAgent.toLowerCase().indexOf("webtv/2.6") != -1) flashVer = 4;
	// WebTV 2.5 supports Flash 3
	else if (navigator.userAgent.toLowerCase().indexOf("webtv/2.5") != -1) flashVer = 3;
	// older WebTV supports Flash 2
	else if (navigator.userAgent.toLowerCase().indexOf("webtv") != -1) flashVer = 2;
	else if ( isIE && isWin && !isOpera ) {
		flashVer = ControlVersion();
	}
	return flashVer;
}
// When called with reqMajorVer, reqMinorVer, reqRevision returns true if that version or greater is available
function DetectFlashVer(reqMajorVer, reqMinorVer, reqRevision)
{
	versionStr = GetSwfVer();
	if (versionStr == -1 ) {
		return false;
	} else if (versionStr != 0) {
		if(isIE && isWin && !isOpera) {
			// Given "WIN 2,0,0,11"
			tempArray         = versionStr.split(" "); 	// ["WIN", "2,0,0,11"]
			tempString        = tempArray[1];			// "2,0,0,11"
			versionArray      = tempString.split(",");	// ['2', '0', '0', '11']
		} else {
			versionArray      = versionStr.split(".");
		}
		var versionMajor      = versionArray[0];
		var versionMinor      = versionArray[1];
		var versionRevision   = versionArray[2];
        	// is the major.revision >= requested major.revision AND the minor version >= requested minor
		if (versionMajor > parseFloat(reqMajorVer)) {
			return true;
		} else if (versionMajor == parseFloat(reqMajorVer)) {
			if (versionMinor > parseFloat(reqMinorVer))
				return true;
			else if (versionMinor == parseFloat(reqMinorVer)) {
				if (versionRevision >= parseFloat(reqRevision))
					return true;
			}
		}
		return false;
	}
}
function AC_AddExtension(src, ext)
{
  if (src.indexOf('?') != -1)
    return src.replace(/\?/, ext+'?');
  else
    return src + ext;
}
function AC_Generateobj(objAttrs, params, embedAttrs)
{
  var str = '';
  if (isIE && isWin && !isOpera)
  {
    str += '<object ';
    for (var i in objAttrs)
    {
      str += i + '="' + objAttrs[i] + '" ';
    }
    str += '>';
    for (var i in params)
    {
      str += '<param name="' + i + '" value="' + params[i] + '" /> ';
    }
    str += '</object>';
  }
  else
  {
    str += '<embed ';
    for (var i in embedAttrs)
    {
      str += i + '="' + embedAttrs[i] + '" ';
    }
    str += '> </embed>';
  }
  document.write(str);
}
function AC_FL_RunContent(){
  var ret =
    AC_GetArgs
    (  arguments, ".swf", "movie", "clsid:d27cdb6e-ae6d-11cf-96b8-444553540000"
     , "application/x-shockwave-flash"
    );
  AC_Generateobj(ret.objAttrs, ret.params, ret.embedAttrs);
}
function AC_SW_RunContent(){
  var ret =
    AC_GetArgs
    (  arguments, ".dcr", "src", "clsid:166B1BCA-3F9C-11CF-8075-444553540000"
     , null
    );
  AC_Generateobj(ret.objAttrs, ret.params, ret.embedAttrs);
}
function AC_GetArgs(args, ext, srcParamName, classid, mimeType){
  var ret = new Object();
  ret.embedAttrs = new Object();
  ret.params = new Object();
  ret.objAttrs = new Object();
  for (var i=0; i < args.length; i=i+2){
    var currArg = args[i].toLowerCase();
    switch (currArg){
      case "classid":
        break;
      case "pluginspage":
        ret.embedAttrs[args[i]] = args[i+1];
        break;
      case "src":
      case "movie":
        args[i+1] = AC_AddExtension(args[i+1], ext);
        ret.embedAttrs["src"] = args[i+1];
        ret.params[srcParamName] = args[i+1];
        break;
      case "onafterupdate":
      case "onbeforeupdate":
      case "onblur":
      case "oncellchange":
      case "onclick":
      case "ondblclick":
      case "ondrag":
      case "ondragend":
      case "ondragenter":
      case "ondragleave":
      case "ondragover":
      case "ondrop":
      case "onfinish":
      case "onfocus":
      case "onhelp":
      case "onmousedown":
      case "onmouseup":
      case "onmouseover":
      case "onmousemove":
      case "onmouseout":
      case "onkeypress":
      case "onkeydown":
      case "onkeyup":
      case "onload":
      case "onlosecapture":
      case "onpropertychange":
      case "onreadystatechange":
      case "onrowsdelete":
      case "onrowenter":
      case "onrowexit":
      case "onrowsinserted":
      case "onstart":
      case "onscroll":
      case "onbeforeeditfocus":
      case "onactivate":
      case "onbeforedeactivate":
      case "ondeactivate":
      case "type":
      case "codebase":
      case "id":
        ret.objAttrs[args[i]] = args[i+1];
        break;
      case "width":
      case "height":
      case "align":
      case "vspace":
      case "hspace":
      case "class":
      case "title":
      case "accesskey":
      case "name":
      case "tabindex":
        ret.embedAttrs[args[i]] = ret.objAttrs[args[i]] = args[i+1];
        break;
      default:
        ret.embedAttrs[args[i]] = ret.params[args[i]] = args[i+1];
    }
  }
  ret.objAttrs["classid"] = classid;
  if (mimeType) ret.embedAttrs["type"] = mimeType;
  return ret;
}
// -->
</script>

<script>
	function XPathQuery(xmlDoc, xPath) {
		var retArray = [];
		if (!xmlDoc) {
			console.warn("An invalid XMLDoc was passed to i2b2.h.XPath");
			return retArray;
		}
		try {
			if (window.ActiveXObject) {
				// Microsoft's XPath implementation
				// HACK: setProperty attempts execution when placed in IF statements' test condition, forced to use try-catch
				try {
					xmlDoc.setProperty("SelectionLanguage", "XPath");
				} catch(e) {
					try {
						xmlDoc.ownerDocument.setProperty("SelectionLanguage", "XPath");
					} catch(e) {}
				}
				retArray = xmlDoc.selectNodes(xPath);
			}
			else if (document.implementation && document.implementation.createDocument) {
				// W3C XPath implementation (Internet standard)
				var ownerDoc = xmlDoc.ownerDocument;
				if (!ownerDoc) {ownerDoc = xmlDoc; }
				var nodes = ownerDoc.evaluate(xPath, xmlDoc, null, XPathResult.ANY_TYPE, null);
				var rec = nodes.iterateNext();
				while (rec) {
					retArray.push(rec);
					rec = nodes.iterateNext();
				}
			}
		} catch (e) {
			return undefined;
		}
		return retArray;
	}
	function parseXml(xmlString){
		var xmlDocRet = false;
		try //Internet Explorer
		{
			xmlDocRet = new ActiveXObject("Microsoft.XMLDOM");
			xmlDocRet.async = "false";
			xmlDocRet.loadXML(xmlString);
			xmlDocRet.setProperty("SelectionLanguage", "XPath");
		}
		catch (e) {
			try //Firefox, Mozilla, Opera, etc.
			{
				parser = new DOMParser();
				xmlDocRet = parser.parseFromString(xmlString, "text/xml");
			}
			catch (e) {
				console.error(e.message)
			}
		}
		return xmlDocRet;
	}



	function getValRange() {
		var t = $('dataType');
		var objType = t.options[t.selectedIndex].value;
		var attribName = $('attribName').value
		network_browser.getDataRange(objType, attribName);
	}

	function loadPerson(centerID) {
		// save this for later
		network_browser.center_id = centerID;
		network_browser.loadNetwork(centerID);
	}



</script>
<style>
  div.slider div.handle { top:-7px !important; }
</style>
</head>

<body style="background: #FFF;">





<%
dim uid as string
uid = lcase(request("uid"))

%>

	<div id="body">
		<script type="text/javascript">
		window.onload = function() {
		network_browser.Init('http://localhost:54672/NetworkBrowserService.svc/profiles/');            
            network_browser.loadNetwork('<%=uid%>');
		}
		</script>
	</div>


	<div id="content">


<div style="width:600px;text-align:center;">

<style type="text/css">
  div.slider { width:180px; margin-right:14px; background-color:#FFF; height:10px; position: relative; }
  div.slider div.handle { width:10px; height:15px; border:#900 1px solid; background-color:#FCC; cursor:move; position: absolute; }
  div.slider div.span { margin-top:7px;border:1px solid #666;background-color:#666; }
  div#zoom_element { width:50px; height:50px; background:#2d86bd; position:relative; }
</style>

<table>
	<tr>
		<td style="text-align:left;">Publications</td>
		<td style="text-align:left;">Co-Publications</td>
		<td style="text-align:left;">Most Recent Co-publications</td>
	</tr>
	<tr>
		<td>
			<div id="copubs" class="slider">
			  <div id="copubs_handle" class="handle"></div>
			  <div id="copubs_track" class="span"></div>
			</div>
		</td>
		<td>
			<div id="pub_cnt" class="slider">
			  <div id="pub_cnt_handle" class="handle"></div>
			  <div id="pub_cnt_track" class="span"></div>
			</div>
		</td>
		<td>
			<div id="pub_date" class="slider">
			  <div id="pub_date_handle" class="handle"></div>
			  <div id="pub_cnt_track" class="span"></div>
			</div>
		</td>
	</tr>
	<tr style="line-height:6px; text-align:right; color:#555; font-size:10px; padding-top:0px; margin-top:0px">
		<td style="padding-right:16px" id="lbl_pubs">any number</td>
		<td style="padding-right:16px" id="lbl_copubs">any collaboration</td>
		<td style="padding-right:16px" id="lbl_recent">any year</td>
	</tr>
</table>

</div>


<div style="margin-top:15px;border:1px solid #666;border-bottom:none;width:600px;height:20px;text-align:center;background-color:#f5e4cc"><div id="person_name"><b><%=request("dn")%></b></div></div>
<div style="border:1px solid #666;width:600px;height:600px;">

<script language="JavaScript" type="text/javascript">
    AC_FL_RunContent(
		'codebase', 'http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=10,0,0,0',
		'width', '600',
		'height', '600',
		'src', 'network_browserFLASH',
		'quality', 'high',
		'pluginspage', 'http://www.adobe.com/go/getflashplayer',
		'align', 'middle',
		'play', 'true',
		'loop', 'true',
		'scale', 'showall',
		'wmode', 'window',
		'devicefont', 'false',
		'id', 'network_browserFLASH',
		'bgcolor', '#ffffff',
		'name', 'network_browserFLASH',
		'menu', 'true',
		'allowFullScreen', 'false',
		'allowScriptAccess', 'always',
		'movie', 'network_browser',
		'salign', ''
		); //end AC code
</script>

	<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=10,0,0,0" width="800" height="800" id="network_browserFLASH" align="middle">
	<param name="movie" value="network_browserFLASH.swf" /><param name="quality" value="high" /><param name="bgcolor" value="#ffffff" />
    <embed src="network_browserFLASH.swf" quality="high" bgcolor="#ffffff" width="800" height="800" name="network_browserFLASH" align="middle" allowScriptAccess="sameDomain" allowFullScreen="false" type="application/x-shockwave-flash" pluginspage="http://www.adobe.com/go/getflashplayer" />
	</object>


</div>


<div style="display:none;">

	<div id="nodeData" style="background:#999999; width:390px; padding:5px; margin-bottom:20px; height:180px; float:left;"></div>
	<div id="edgeData" style="background:#999999; width:390px; padding:5px; margin-bottom:20px; height:180px; float:left;"></div>

	<div style="clear:both; margin-top:20px"></div>

</div>



<!--


		<form style="clear:both;">
		<table width="100%"">
			<tr>
				<td>Author ID</td>
				<td><input id="authorID" value="GMW3"></td>
				<td><input type="button" value="Load Network" onclick="loadPerson($('authorID').value)"></td>
			</tr>
			<tr><td>&nbsp;</td></tr>
			<tr>
				<td>DataRange:</td>
				<td><select id="dataType"><option value="NODE">Node</option><option value="EDGE">Edge</option></select></td>
				<td>Attribute Name:<br /><input id="attribName"></td>
				<td>Min:<div id="minVal"></div> Max:<div id="maxVal"></div></td>
				<td><input type="button" value="Get Value Range" onclick="getValRange()"></td>
			</tr>
		</table>
		</form>

-->


	</div>

</body>
</html>
