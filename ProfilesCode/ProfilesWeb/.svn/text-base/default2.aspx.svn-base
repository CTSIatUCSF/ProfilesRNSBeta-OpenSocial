<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<?xml version="1.0" encoding="utf-8" ?>
<html>
<head id="ctl00_ctl00_Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title></title>
    <!--[if IE 6]>
    <link rel="stylesheet" type="text/css" href="CSS/IEmasterLayout.css" />
    <![endif]-->
    <!--[if !IE]><!-->
    <link rel="stylesheet" type="text/css" href="CSS/masterLayout.css" />
    <!--<![endif]-->
    <!--[if gte IE 7]><!-->
    <link rel="stylesheet" type="text/css" href="CSS/masterLayout.css" />
    <!--<![endif]-->
    <base href="http://localhost:9276/profilesweb/" />
    <link rel="stylesheet" type="text/css" href="CSS/People.css" />
    <link rel="stylesheet" type="text/css" href="CSS/resnav.css" />
    <link rel="stylesheet" type="text/css" href="CSS/header_footer.css" />
    <link rel="stylesheet" type="text/css" href="CSS/profiles.css" />
    <link rel="stylesheet" type="text/css" href="JQuery/ui.dropdownchecklist.css" />
    <link rel="stylesheet" type="text/css" href="CSS/comboTreeCheck.css" />
</head>
<body id="ctl00_ctl00_bodyMaster">
    <div id="page-container">
        <div style="cursor: pointer" onclick="javascript:document.location.href='search.aspx';">
            <img id="ctl00_ctl00_heading_ucHeader_imgHeader" src="Images/banner_generic.jpg"
                style="border-width: 0px;" />
        </div>
        <meta http-equiv="Expires" content="0">
        <meta http-equiv="Pragma" content="no-cache">
        <meta http-equiv="Cache-Control" content="Private">
        <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
        <title>Distributed Interoperable Research Experts Collaboration Tool (DIRECT)</title>
        <link rel="stylesheet" type="text/css" href="Direct.css" />

        <script language="javascript" type="text/javascript">

function NoEnter(){
    if (window.event && window.event.keyCode == 13)
      document.getElementById('btnsearch').click();
    return true;
 }
    
//****** List Table JavaScript

	var hasClickedListTable = false;
	function doListTableRowOver(x) {
		x.className = 'overRow';
		x.style.backgroundColor = '#5A719C';
		x.style.color = '#FFF';
		for (var i=0; i<x.childNodes.length; i++) {
			if (x.childNodes[i].childNodes.length > 0) {
				if (x.childNodes[i].childNodes[0].className == 'listTableLink') {
					x.childNodes[i].childNodes[0].style.color = '#FFF';
				}
			}
		}
	}
	function doListTableRowOut(x,eo) {
		if (eo==1) {
			x.className = 'oddRow';
			x.style.backgroundColor = '#FFFFFF';
		} else {
			x.className = 'evenRow';
			x.style.backgroundColor = '#F0F4F6';
		}
		x.style.color = '';
		for (var i=0; i<x.childNodes.length; i++) {
			if (x.childNodes[i].childNodes.length > 0) {
				if (x.childNodes[i].childNodes[0].className == 'listTableLink') {
					x.childNodes[i].childNodes[0].style.color = '#36C';
				}
			}
		}
	}
	function doListTableCellOver(x) {
		x.className = 'listTableLinkOver';
		x.style.backgroundColor = '#36C';
	}
	function doListTableCellOut(x) {
		x.className = 'listTableLink';
		x.style.backgroundColor = '';
	}
	function doListTableCellClick(x) {
		hasClickedListTable = true;
	}

	//****** Federated Search (DIRECT) JavaScript

	var fsObject = [];
	var dsLoading = 0;

	function siteResult(SiteID,ResultError,ResultCount,ResultDetailsURL,ResultPopType,ResultPrevURL,FSID) {
	    
		var el1 = document.getElementById('SITE_STATUS_'+SiteID);
		
		var el2 = el1.childNodes[0];
		if ((ResultError == 0)&&(ResultCount!='')) {
			el2.innerHTML = ResultCount;
			var el3 = document.createElement("div");
			el3.innerHTML = '<div id="SITE_PREVIEW_'+SiteID+'" style="display:none;" ><div style="border:none;"><IFRAME src="'+ResultPrevURL+'" style="width:600px;height:300px;border:0px;" frameborder="0" /></div></div>';
			document.getElementById('sitePreview').appendChild(el3);
		} else {
			ResultPopType = 'No results were returned by this institution.';
			el2.innerHTML = '0';
		}

		for (var i=0; i<fsObject.length; i++) {
			if (fsObject[i].SiteID == SiteID) {
				fsObject[i].ResultPopType = ResultPopType;
				fsObject[i].ResultDetailsURL = ResultDetailsURL;
				fsObject[i].FSID = FSID;
			}
		}
	}
	function doLocalPersonSearch(directserviceURL, SiteID) {
		for (var i=0; i<fsObject.length; i++) {
			if (fsObject[i].SiteID == SiteID) {
				if ((fsObject[i].ResultCount != '')&&(fsObject[i].ResultDetailsURL != '')&&(fsObject[i].FSID != '')) {
					window.open(directserviceURL + '?request=outgoingdetails&fsid=' + fsObject[i].FSID);
				}
			}
		}
	}
	function doSiteHoverOver(SiteID) {
	
		document.getElementById('FSSiteDescription').innerHTML = '';
		
		for (var i=0; i<fsObject.length; i++) {
			if (fsObject[i].SiteID == SiteID) {
				document.getElementById('FSSiteDescription').innerHTML = fsObject[i].ResultPopType;
				document.getElementById('FSSiteDescription').style.display = "block";
			}
		}
		for (var i=0; i<fsObject.length; i++) {
			var el = document.getElementById('SITE_PREVIEW_'+fsObject[i].SiteID);
			if (el) {el.style.display = 'none';}
		}
		
		var el = document.getElementById('SITE_PREVIEW_'+SiteID);
		if (el) {el.style.display = '';}
	}
	function doSiteHoverOut(SiteID) {
		document.getElementById('FSSiteDescription').innerHTML = 'Important information about an institution\'s data will appear here when you place your mouse over the institution\'s name.';
	}
	
	function doDirectSearch() {		 
		
		for (var i=0; i<fsObject.length; i++) {
			fsObject[i].ResultPopType = 'Please wait while this institution processes the request.';
			fsObject[i].ResultDetailsURL = '';
			document.getElementById('SITE_STATUS_'+fsObject[i].SiteID).childNodes[0].innerHTML = '<img src="images/yui-loading.gif" border="0" style="position:relative;top:-2px;" />';
		}	
	
	    try{
		document.getElementById('FSResultsBox').style.display='block';
		}catch(err){}
		try{
		document.getElementById('FSPassiveResultsBox').style.display='block';
		}catch(err){}
		try{
		document.getElementById('sitePreview').innerHTML = '';
		}catch(err){}
		
		var f = document.getElementById("FSSearchPhrase");
		
		var s = f.value;
		
		var m = Math.random();
		
		
		var u = 'http://localhost:9276/ProfilesWeb/DirectService.aspx?blank=N&request=outgoingcount&SearchPhrase='+s+'&r='+m;
		
		document.getElementById('FSAJAXFrame').src = u;
	
	}
	function doAuto() {	
		var f = document.getElementById('FSSearchPhrase');f.value = 'ear';doDirectSearch();
	}

        </script>

        <div id="ctl00_ctl00_divContainer" class="colmask holygrail">
            <div class="col13top">
                <div id="ctl00_ctl00_divCol13topSpace" class="col13topSpace">
                </div>
            </div>
            <!-- Start Container -->
            <div class="colmid">
                <div class="colleft">
                    <form name="aspnetForm" method="post" action="direct.aspx?SearchPhrase=ear" id="aspnetForm">
                    <div>
                        <input type="hidden" name="ctl00_ctl00_container_scmPeople_HiddenField" id="ctl00_ctl00_container_scmPeople_HiddenField"
                            value="" />
                        <input type="hidden" name="__EVENTTARGET" id="__EVENTTARGET" value="" />
                        <input type="hidden" name="__EVENTARGUMENT" id="__EVENTARGUMENT" value="" />
                        <input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="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" />
                    </div>

                    <script type="text/javascript">
//<![CDATA[
var theForm = document.forms['aspnetForm'];
if (!theForm) {
    theForm = document.aspnetForm;
}
function __doPostBack(eventTarget, eventArgument) {
    if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
        theForm.__EVENTTARGET.value = eventTarget;
        theForm.__EVENTARGUMENT.value = eventArgument;
        theForm.submit();
    }
}
//]]>
                    </script>

                    <script src="/ProfilesWeb/WebResource.axd?d=Cr6NY1haBII3CUWgTf-vRxkAVYzK1FJ6XORbJp5zHXYb1faJ2WnIXBUQYE-i4nGMszzp_Bd8NNpxf0uVdI32lDKWS0A1&amp;t=634208634757546466"
                        type="text/javascript"></script>

                    <script src="/ProfilesWeb/ScriptResource.axd?d=Fp78RnKYjWCBVNLstb8FMbYQ-Jya8rE0FFUPl_YA971RHxOEbyWvd2yc_svLjBwtWOlgOGW-zRBTX2BRt_N95ibCbvMd7Nb7Lt2KFXU1xE0VR7BN-kCc_5-xDfTX8DKYM7ZX5FSswQ8EWJl52MIobmurCGTANXPKLiIaWDyqj6fJQ9QN0&amp;t=5c2f384e"
                        type="text/javascript"></script>

                    <script type="text/javascript">
//<![CDATA[
if (typeof(Sys) === 'undefined') throw new Error('ASP.NET Ajax client-side framework failed to load.');
//]]>

                    </script>

                    <script src="/ProfilesWeb/ScriptResource.axd?d=4E-N9V-KtUC4Q4CAej6LyN5oTxa_zyWVtbop-_cKcicxwHzgqGgR1ltDULTMTiPrMhOjKfQ1XeeCSTtIz5zaH_LypvpUlk4ACKl_AqhrdrxioYtZSEcahich7ToEpgOhnS2AIAz-b2qsCpo1WrfKkBkTE5qlHlJdn6iW2OFYkAav1tgd0&amp;t=5c2f384e"
                        type="text/javascript"></script>

                    <div>
                        <input type="hidden" name="__VIEWSTATEENCRYPTED" id="__VIEWSTATEENCRYPTED" value="" />
                        <input type="hidden" name="__EVENTVALIDATION" id="__EVENTVALIDATION" value="3PxHb2MDb+wQG5Pd4acehJkjL4VflHW02NvnRmBfrgfMd17z87emPvWNWRi6CH3W1wgRSbBckbHti3BKhG7DbH8G8P9oayrry4U2tD0GNLycJw9XJnlP31rvFdLjDys/KkWWT8iX7iFrpclk+j2t2slsHAKGOnPGBj2KtReKqal6xQvwExqZ1AaZnQps5dl3mU7SKKQIjAcKnV4q8tGn17EBfvTQGfiwELu0ymD4CshUozCn2pk2YqIkweG1odVWpdMq+89Jmdkgit6HNI56fk0agVXo+wKhb40ihkFkM1B6Uy1ZP2wNx3HhehVfEs6ExeaygnDc1yInha+eZ34HQpDksnu5tL/x8CugB5h/UNd31XgCWpIhfozy5dr8bOSEMd9zmc7tqxq8ial5sJaMXqvZwR0=" />
                    </div>

                    <script type="text/javascript">
//<![CDATA[
Sys.WebForms.PageRequestManager._initialize('ctl00$ctl00$container$scmPeople', document.getElementById('aspnetForm'));
Sys.WebForms.PageRequestManager.getInstance()._updateControls(['tctl00$ctl00$left$upnlMinisearch','tctl00$ctl00$left$UpdatePanel1'], [], [], 90);
//]]>
                    </script>

                    <div class="col1wrap">
                        <div id="ctl00_ctl00_divCol1" class="col1">
                            <div class="searchForm">
                                <div class="pageTitle">
                                    National Search</div>
                                <div class="pageSubTitle">
                                    Distributed Interoperable Research Experts Collaboration Tool (DIRECT)</div>
                                <div class="pageSubTitleCaption">
                                    DIRECT is pilot project to demonstrate federated search across multiple institutions.</div>
                                <div class="searchForm">
                                    <input type="hidden" name="request" value="outgoingcount" />
                                    <input type="hidden" name="r" value="1168904361" />
                                    <div class="searchSection" style="width: 600px;">
                                        <table>
                                            <tr>
                                                <td>
                                                    Keywords
                                                </td>
                                                <td class="fieldMain">
                                                    <input type='text' name="SearchPhrase" id="FSSearchPhrase" value="ear" class="inputText" />
                                                </td>
                                                <td class="fieldOptions">
                                                    <input type='button' value="Search" name="btnsearch" id="btnsearch" class="inputButton"
                                                        onclick="JavaScript:doDirectSearch();" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div id="siteDesc" style="display: none">
                                    <div style="padding: 0px 2px">
                                        Details</div>
                                    <div id="siteDescText">
                                        testing</div>
                                </div>
                                <div id="FSResultsBox" style="margin-top: 20px; display: none;">
                                    <div style="margin-bottom: 15px;">
                                        Below are the number of matching people at participating institutions. Click an
                                        institution name to view the list of people. As you move your mouse over the different
                                        institution names, you will see important notes about that institution's data on
                                        the right and a preview/summary of the matching people at the bottom of this page.
                                    </div>
                                    <div class='listTable' style='margin-top: 6px; margin-bottom: 18px;'>
                                        <table>
                                            <tr style='font-weight: bold; background-color: #F0F4F6'>
                                                <td style='width: 450px; text-align: left;'>
                                                    Institution</a>
                                                </td>
                                                <td style='width: 150px; text-align: center;'>
                                                    Matches</a>
                                                </td>
                                            </tr>
                                            <tr style='cursor: pointer; background-color: #FFFFFF' onmouseover="doListTableRowOver(this);doSiteHoverOver(1);"
                                                onmouseout="doListTableRowOut(this,1);doSiteHoverOut(1);" onclick="doLocalPersonSearch('http://localhost:9276/ProfilesWeb/DirectService.aspx',1);">
                                                <td style='text-align: left;'>
                                                    <div style='width: 438px;'>
                                                        Cornell University</div>
                                                </td>
                                                <td style='text-align: center;'>
                                                    <div style='width: 138px;'>
                                                        <div id='SITE_STATUS_1'>
                                                            <div class='siteresult' style='height: 16px;'>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style='cursor: pointer; background-color: #F0F4F6' onmouseover="doListTableRowOver(this);doSiteHoverOver(2);"
                                                onmouseout="doListTableRowOut(this,0);doSiteHoverOut(2);" onclick="doLocalPersonSearch('http://localhost:9276/ProfilesWeb/DirectService.aspx',2);">
                                                <td style='text-align: left;'>
                                                    <div style='width: 438px;'>
                                                        Harvard University</div>
                                                </td>
                                                <td style='text-align: center;'>
                                                    <div style='width: 138px;'>
                                                        <div id='SITE_STATUS_2'>
                                                            <div class='siteresult' style='height: 16px;'>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style='cursor: pointer; background-color: #FFFFFF' onmouseover="doListTableRowOver(this);doSiteHoverOver(3);"
                                                onmouseout="doListTableRowOut(this,1);doSiteHoverOut(3);" onclick="doLocalPersonSearch('http://localhost:9276/ProfilesWeb/DirectService.aspx',3);">
                                                <td style='text-align: left;'>
                                                    <div style='width: 438px;'>
                                                        Indiana University</div>
                                                </td>
                                                <td style='text-align: center;'>
                                                    <div style='width: 138px;'>
                                                        <div id='SITE_STATUS_3'>
                                                            <div class='siteresult' style='height: 16px;'>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style='cursor: pointer; background-color: #F0F4F6' onmouseover="doListTableRowOver(this);doSiteHoverOver(4);"
                                                onmouseout="doListTableRowOut(this,0);doSiteHoverOut(4);" onclick="doLocalPersonSearch('http://localhost:9276/ProfilesWeb/DirectService.aspx',4);">
                                                <td style='text-align: left;'>
                                                    <div style='width: 438px;'>
                                                        Ponce School of Medicine</div>
                                                </td>
                                                <td style='text-align: center;'>
                                                    <div style='width: 138px;'>
                                                        <div id='SITE_STATUS_4'>
                                                            <div class='siteresult' style='height: 16px;'>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style='cursor: pointer; background-color: #FFFFFF' onmouseover="doListTableRowOver(this);doSiteHoverOver(6);"
                                                onmouseout="doListTableRowOut(this,1);doSiteHoverOut(6);" onclick="doLocalPersonSearch('http://localhost:9276/ProfilesWeb/DirectService.aspx',6);">
                                                <td style='text-align: left;'>
                                                    <div style='width: 438px;'>
                                                        The Scripps Research Institute</div>
                                                </td>
                                                <td style='text-align: center;'>
                                                    <div style='width: 138px;'>
                                                        <div id='SITE_STATUS_6'>
                                                            <div class='siteresult' style='height: 16px;'>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style='cursor: pointer; background-color: #F0F4F6' onmouseover="doListTableRowOver(this);doSiteHoverOver(7);"
                                                onmouseout="doListTableRowOut(this,0);doSiteHoverOut(7);" onclick="doLocalPersonSearch('http://localhost:9276/ProfilesWeb/DirectService.aspx',7);">
                                                <td style='text-align: left;'>
                                                    <div style='width: 438px;'>
                                                        University of California, San Francisco</div>
                                                </td>
                                                <td style='text-align: center;'>
                                                    <div style='width: 138px;'>
                                                        <div id='SITE_STATUS_7'>
                                                            <div class='siteresult' style='height: 16px;'>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style='cursor: pointer; background-color: #FFFFFF' onmouseover="doListTableRowOver(this);doSiteHoverOver(8);"
                                                onmouseout="doListTableRowOut(this,1);doSiteHoverOut(8);" onclick="doLocalPersonSearch('http://localhost:9276/ProfilesWeb/DirectService.aspx',8);">
                                                <td style='text-align: left;'>
                                                    <div style='width: 438px;'>
                                                        University of Florida</div>
                                                </td>
                                                <td style='text-align: center;'>
                                                    <div style='width: 138px;'>
                                                        <div id='SITE_STATUS_8'>
                                                            <div class='siteresult' style='height: 16px;'>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style='cursor: pointer; background-color: #F0F4F6' onmouseover="doListTableRowOver(this);doSiteHoverOver(9);"
                                                onmouseout="doListTableRowOut(this,0);doSiteHoverOut(9);" onclick="doLocalPersonSearch('http://localhost:9276/ProfilesWeb/DirectService.aspx',9);">
                                                <td style='text-align: left;'>
                                                    <div style='width: 438px;'>
                                                        University of Iowa</div>
                                                </td>
                                                <td style='text-align: center;'>
                                                    <div style='width: 138px;'>
                                                        <div id='SITE_STATUS_9'>
                                                            <div class='siteresult' style='height: 16px;'>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style='cursor: pointer; background-color: #FFFFFF' onmouseover="doListTableRowOver(this);doSiteHoverOver(10);"
                                                onmouseout="doListTableRowOut(this,1);doSiteHoverOut(10);" onclick="doLocalPersonSearch('http://localhost:9276/ProfilesWeb/DirectService.aspx',10);">
                                                <td style='text-align: left;'>
                                                    <div style='width: 438px;'>
                                                        University of Minnesota</div>
                                                </td>
                                                <td style='text-align: center;'>
                                                    <div style='width: 138px;'>
                                                        <div id='SITE_STATUS_10'>
                                                            <div class='siteresult' style='height: 16px;'>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style='cursor: pointer; background-color: #F0F4F6' onmouseover="doListTableRowOver(this);doSiteHoverOver(11);"
                                                onmouseout="doListTableRowOut(this,0);doSiteHoverOut(11);" onclick="doLocalPersonSearch('http://localhost:9276/ProfilesWeb/DirectService.aspx',11);">
                                                <td style='text-align: left;'>
                                                    <div style='width: 438px;'>
                                                        Washington University in St. Louis</div>
                                                </td>
                                                <td style='text-align: center;'>
                                                    <div style='width: 138px;'>
                                                        <div id='SITE_STATUS_11'>
                                                            <div class='siteresult' style='height: 16px;'>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style='cursor: pointer; background-color: #FFFFFF' onmouseover="doListTableRowOver(this);doSiteHoverOver(12);"
                                                onmouseout="doListTableRowOut(this,1);doSiteHoverOut(12);" onclick="doLocalPersonSearch('http://localhost:9276/ProfilesWeb/DirectService.aspx',12);">
                                                <td style='text-align: left;'>
                                                    <div style='width: 438px;'>
                                                        Weill Cornell Medical College</div>
                                                </td>
                                                <td style='text-align: center;'>
                                                    <div style='width: 138px;'>
                                                        <div id='SITE_STATUS_12'>
                                                            <div class='siteresult' style='height: 16px;'>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>

                                    <script>var t = {}; t.SiteID = 1; t.ResultPopType = ''; t.ResultDetailsURL = ''; t.FSID = ''; fsObject.push(t);
var t = {}; t.SiteID = 2; t.ResultPopType = ''; t.ResultDetailsURL = ''; t.FSID = ''; fsObject.push(t);
var t = {}; t.SiteID = 3; t.ResultPopType = ''; t.ResultDetailsURL = ''; t.FSID = ''; fsObject.push(t);
var t = {}; t.SiteID = 4; t.ResultPopType = ''; t.ResultDetailsURL = ''; t.FSID = ''; fsObject.push(t);
var t = {}; t.SiteID = 6; t.ResultPopType = ''; t.ResultDetailsURL = ''; t.FSID = ''; fsObject.push(t);
var t = {}; t.SiteID = 7; t.ResultPopType = ''; t.ResultDetailsURL = ''; t.FSID = ''; fsObject.push(t);
var t = {}; t.SiteID = 8; t.ResultPopType = ''; t.ResultDetailsURL = ''; t.FSID = ''; fsObject.push(t);
var t = {}; t.SiteID = 9; t.ResultPopType = ''; t.ResultDetailsURL = ''; t.FSID = ''; fsObject.push(t);
var t = {}; t.SiteID = 10; t.ResultPopType = ''; t.ResultDetailsURL = ''; t.FSID = ''; fsObject.push(t);
var t = {}; t.SiteID = 11; t.ResultPopType = ''; t.ResultDetailsURL = ''; t.FSID = ''; fsObject.push(t);
var t = {}; t.SiteID = 12; t.ResultPopType = ''; t.ResultDetailsURL = ''; t.FSID = ''; fsObject.push(t);

                                    </script>

                                    <iframe name="FSAJAXFrame" id="FSAJAXFrame" src="http://localhost:9276/ProfilesWeb/DirectService.aspx?request=outgoingcount&blank=y&r=rnd"
                                        frameborder="0" scrolling="no" style="width: 0px; height: 0px;" />
                                    </iframe> <b>&nbsp;&nbsp;Preview</b>
                                    <div id="sitePreview" style="width: 600px; height: 300px; border: 1px solid #999;">
                                    </div>
                                </div>
                            </div>

                            <script type="text/javascript"> doAuto();</script>

                        </div>
                    </div>
                    <div id="ctl00_ctl00_divCol2" class="col2">
                        <div id="ctl00_ctl00_left_divLeftTop">
                            <div id="ctl00_ctl00_left_activeTop" class="activeTop">
                                &nbsp;</div>
                            <div id="ctl00_ctl00_left_activeMainWrapper" class="activeMainWrapper">
                                <div class="activeMain">
                                    <div class="leftColumnWidgetGroup">
                                        <div class="leftColumnWidgetSearch">
                                            <div id="ctl00_ctl00_left_upnlMinisearch">
                                                <div id="ctl00_ctl00_left_ucMiniSearch_pnlMiniSearch" onkeypress="javascript:return WebForm_FireDefaultButton(event, 'ctl00_ctl00_left_ucMiniSearch_BtnMiniSearch')">
                                                    <!--***** Table Mini Search *****-->
                                                    <div style="font-weight: bold; padding-top: 4px;">
                                                        Keyword
                                                    </div>
                                                    <div>
                                                        <input name="ctl00$ctl00$left$ucMiniSearch$txtKword" type="text" id="ctl00_ctl00_left_ucMiniSearch_txtKword"
                                                            style="width: 140px;" />
                                                    </div>
                                                    <div style="font-weight: bold;">
                                                        Last Name
                                                    </div>
                                                    <div>
                                                        <input name="ctl00$ctl00$left$ucMiniSearch$txtLName" type="text" id="ctl00_ctl00_left_ucMiniSearch_txtLName"
                                                            style="width: 140px;" />
                                                    </div>
                                                    <div id="ctl00_ctl00_left_ucMiniSearch_divInstitution">
                                                        <div style="font-weight: bold; padding-top: 4px;">
                                                            Institution
                                                        </div>
                                                        <div>
                                                            <select name="ctl00$ctl00$left$ucMiniSearch$ddlInst" id="ctl00_ctl00_left_ucMiniSearch_ddlInst"
                                                                style="width: 98%;">
                                                                <option selected="selected" value="--Select--" title="--Select--">--Select--</option>
                                                                <option value="BIDMC" title="Beth Israel Deaconess Medical Center">Beth Israel Deaconess
                                                                    Medical Center</option>
                                                                <option value="BWH" title="Brigham and Women's Hospital">Brigham and Women's Hospital</option>
                                                                <option value="CHALLIANCE" title="Cambridge Health Alliance">Cambridge Health Alliance</option>
                                                                <option value="CHILDRENS" title="Children's Hospital Boston">Children's Hospital Boston</option>
                                                                <option value="DFCI" title="Dana-Farber Cancer Institute">Dana-Farber Cancer Institute</option>
                                                                <option value="FAS" title="Faculty of Arts &amp; Sciences">Faculty of Arts &amp; Sciences</option>
                                                                <option value="FORSYTH" title="Forsyth Institute">Forsyth Institute</option>
                                                                <option value="EDU" title="Graduate School of Education">Graduate School of Education</option>
                                                                <option value="DIV" title="Harvard Divinity School">Harvard Divinity School</option>
                                                                <option value="HIM" title="Harvard Insitutes of Medicine">Harvard Insitutes of Medicine</option>
                                                                <option value="LAW" title="Harvard Law School">Harvard Law School</option>
                                                                <option value="HMS" title="Harvard Medical School">Harvard Medical School</option>
                                                                <option value="HVMA" title="Harvard Pilgrim Healthcare">Harvard Pilgrim Healthcare</option>
                                                                <option value="HSDM" title="Harvard School of Dental Medicine">Harvard School of Dental
                                                                    Medicine</option>
                                                                <option value="SPH" title="Harvard School of Public Health">Harvard School of Public
                                                                    Health</option>
                                                                <option value="OPR" title="Harvard University">Harvard University</option>
                                                                <option value="HEBREW RHB" title="Hebrew Rehabilitation Center">Hebrew Rehabilitation
                                                                    Center</option>
                                                                <option value="IDI" title="Immune Disease Institute">Immune Disease Institute</option>
                                                                <option value="KSG" title="John F. Kennedy School of Government">John F. Kennedy School
                                                                    of Government</option>
                                                                <option value="JOSLIN" title="Joslin Diabetes Center">Joslin Diabetes Center</option>
                                                                <option value="JBCC" title="Judge Baker Children's Center">Judge Baker Children's Center</option>
                                                                <option value="LAHEY" title="Lahey Clinic Medical Center">Lahey Clinic Medical Center</option>
                                                                <option value="BIDMC MMHC" title="Mass Mental Health Center">Mass Mental Health Center</option>
                                                                <option value="MEEI" title="Massachusetts Eye and Ear Infirmary">Massachusetts Eye and
                                                                    Ear Infirmary</option>
                                                                <option value="MGH" title="Massachusetts General Hospital">Massachusetts General Hospital</option>
                                                                <option value="MIT" title="Massachusetts Institute of Technology">Massachusetts Institute
                                                                    of Technology</option>
                                                                <option value="MCLEAN" title="McLean Hospital">McLean Hospital</option>
                                                                <option value="MTA" title="Mount Auburn Hospital">Mount Auburn Hospital</option>
                                                                <option value="NE BAPTIST" title="New England Baptist Hospital">New England Baptist
                                                                    Hospital</option>
                                                                <option value="NEWTN-WSLY" title="Newton-Wellesley Hospital">Newton-Wellesley Hospital</option>
                                                                <option value="HVMA" title="Other">Other</option>
                                                                <option value="SERI" title="Schepens Eye Research Institute">Schepens Eye Research Institute</option>
                                                                <option value="SEAS" title="School of Engineering and Applied Sciences">School of Engineering
                                                                    and Applied Sciences</option>
                                                                <option value="SPAULDING" title="Spaulding Rehabilitation Hospital">Spaulding Rehabilitation
                                                                    Hospital</option>
                                                                <option value="VA" title="Veterans Affairs Boston Healthcare System">Veterans Affairs
                                                                    Boston Healthcare System</option>
                                                            </select>
                                                        </div>
                                                    </div>
                                                    <div style="margin-top: 12px; text-align: center;">
                                                        <input type="submit" name="ctl00$ctl00$left$ucMiniSearch$BtnMiniSearch" value="Search"
                                                            id="ctl00_ctl00_left_ucMiniSearch_BtnMiniSearch" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <input type="submit" name="ctl00$ctl00$left$ucMiniSearch$btnMiniClear" value="Clear"
                                                            id="ctl00_ctl00_left_ucMiniSearch_btnMiniClear" />
                                                    </div>
                                                    <div style="text-align: center; margin-top: 10px;">
                                                        <a id="ctl00_ctl00_left_ucMiniSearch_hyplnkOptions" class="SearchListLink" href="Search.aspx">
                                                            More Search Options</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="activeBottom">
                                &nbsp;</div>
                        </div>
                        <div class="activeTop">
                            &nbsp;</div>
                        <div class="activeMainWrapper">
                            <div class="activeMain">
                                <div>
                                    <div class="leftColumnWidget">
                                        <div id="ctl00_ctl00_left_UpdatePanel1">
                                            <div id="ctl00_ctl00_left_pnlMenu">
                                                <div class="menuWidgetTitle">
                                                    Menu</div>
                                                <div style="margin-top: 3px;">
                                                    <a id="ctl00_ctl00_left_hypSearch" class="SearchListLink" href="Search.aspx">New Search</a>
                                                </div>
                                                <div style="margin-top: 3px;">
                                                    <a id="ctl00_ctl00_left_hypAboutProfiles" class="SearchListLink" href="About.aspx">About
                                                        Profiles</a>
                                                </div>
                                            </div>
                                            <div id="ctl00_ctl00_left_pnlNotLoggedIn">
                                                <div style="margin-top: 3px;">
                                                    <a id="ctl00_ctl00_left_hypNotLoggedIn" class="SearchListLink" href="http://localhost:9276/ProfilesWeb/login.aspx?EditMyProfile=true">
                                                        Edit My Profile</a>
                                                </div>
                                                <div style="margin-top: 3px; margin-bottom: 3px;">
                                                    <a id="ctl00_ctl00_left_hypLogMeIn" class="SearchListLink" href="http://localhost:9276/ProfilesWeb/login.aspx">
                                                        Login To Profiles</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="activeBottom">
                            &nbsp;</div>
                    </div>
                    <div id="ctl00_ctl00_divCol3" class="col3">
                        <div class="DirectSidebar">
                            <div id="FSPassiveResultsBox" >
                                <div class="passive_section_head">
                                    <div style="margin-bottom: 5px;">
                                        Data Comments</div>
                                </div>
                                <div class="passive_section_body">
                                    <div id="FSSiteDescription">
                                        Important information about an institution's data will appear here when you place
                                        your mouse over the institution's name.</div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <script type="text/javascript">
//<![CDATA[
Sys.Application.initialize();
//]]>
                    </script>

                    </form>
                </div>
            </div>
        </div>
        <!-- End Container -->
        <div id="ctl00_ctl00_divMainContainerBottom" class="main_container_bottom">
        </div>
    </div>
</body>
</html>
