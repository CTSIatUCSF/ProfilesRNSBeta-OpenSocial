<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ProfilesPage.master"
    CodeFile="Direct.aspx.cs" Inherits="Direct_Direct" %>

<%--
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
 --%>
<asp:Content ID="Content4" ContentPlaceHolderID="HeadContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadingContentPlaceHolder" runat="Server">
    <meta http-equiv="Expires" content="0">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="Private">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Distributed Interoperable Research Experts Collaboration Tool (DIRECT)</title>
    <link rel="stylesheet" type="text/css" href="CSS/Direct.css" />

    <script language="javascript" type="text/javascript">

function OnEnter(e){
    if (window.event && window.event.keyCode == 13) {
      document.getElementById('btndirectsearch').click();
	return false;
    }
    else if (e.which && e.which == 13) {
      document.getElementById('btndirectsearch').click();
	return false;
    }
    return true;
 }
    
//****** List Table JavaScript

	var hasClickedListTable = false;
	function doListTableRowOver(x) {
		x.className = 'overRow';
		x.style.backgroundColor = '#c8dddd';
		x.style.color = '#FFF';
		for (var i=0; i<x.childNodes.length; i++) {
			if (x.childNodes[i].childNodes.length > 0) {
				if (x.childNodes[i].childNodes[0].className == 'listTableLink') {
					x.childNodes[i].childNodes[0].style.color = '#1E416C';
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
			x.style.backgroundColor = '#F2F7F7';
		}
		x.style.color = '';
		for (var i=0; i<x.childNodes.length; i++) {
			if (x.childNodes[i].childNodes.length > 0) {
				if (x.childNodes[i].childNodes[0].className == 'listTableLink') {
					x.childNodes[i].childNodes[0].style.color = '#000000';
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
				document.getElementById('FSSiteDescription').style.display = "";
				
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
			document.getElementById('SITE_STATUS_'+fsObject[i].SiteID).childNodes[0].innerHTML = '<img src="<%Response.Write(DirectWaitingImageURL());%>" border="0" style="position:relative;top:-2px;" />';
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
		
		
		var u = '<%Response.Write(DirectServiceURL());%>?blank=N&request=outgoingcount&SearchPhrase='+s+'&r='+m;
		
		document.getElementById('FSAJAXFrame').src = u;
	
	}
	function doAuto() {	
		<%
			if( GetKeywordString() != ""){
				Response.Write("var f = document.getElementById('FSSearchPhrase');");				
				Response.Write("f.value = " + cs(GetKeywordString()) + ";");
				Response.Write("doDirectSearch();");
			}
		%>
	}

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MiddleContentPlaceHolder" runat="Server">
    <div class="searchForm">
        <div class="pageTitle">
            National Search (pilot)</div>
        <div class="pageSubTitle" style="padding-top:10px">This new tool, called 
            <a style="color:#CA7C29;font-size:13px;text-decoration:none" 
            title="Distributed Interoperable Research Experts Collaboration Tool">DIRECT</a>, 
            finds experts at multiple institutions.</div>
        <div class="pageSubTitleCaption" style="padding-bottom:10px">
            <asp:HyperLink ID="searchUCSF" runat="server" Text="Return to search UCSF only" NavigateUrl="~/"></asp:HyperLink>
        </div>
        <div class="searchForm" style="margin-left:0">
            <input type="hidden" name="request" value="outgoingcount" />
            <%
                Int64 rnd = 0;
                Random r = new Random();
                rnd = r.Next();      
            %>
            <input type="hidden" name="r" value="<%=rnd%>" />
            <div class="searchSection" style="width: 600px;margin-left:0">
                <table>
                    <tr>
                        <td>
                            &nbsp;Keywords
                        </td>
                        <td  class="fieldMain">
                            <input type='text' name="SearchPhrase" id="FSSearchPhrase" value="<%Response.Write(GetSearchPhrase()); %>"
                                class="inputText" onkeypress="return OnEnter(event);"/>
                        </td>
                        <td class="fieldOptions">
                            <input type='button' value="Search" name="btndirectsearch" id="btndirectsearch" class="inputButton"
                                style="margin-top:-1px" onclick="JavaScript:doDirectSearch();" />
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
            <div class="pageTitle" style="padding: 8px 0 10px;">Search Results
            </div>
            <div class="pageSubTitle" style="padding-top:4px; padding-bottom:8px">Click an institution name to find experts.  
            </div>
            <%Response.Write(DrawMyTable()); %>
            <iframe name="FSAJAXFrame" id="FSAJAXFrame" src="<%Response.Write(DirectServiceURL());%>?request=outgoingcount&blank=y&r=rnd"
                frameborder="0" scrolling="no" style="width: 0px; height: 0px;" />
            </iframe> <b>&nbsp;&nbsp;Preview</b>
            <div id="sitePreview" style="width: 600px; height: 300px; border: 1px solid #CCC;">
            </div>
        </div>
    </div>

    <script type="text/javascript"> doAuto();</script>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
        <div class="passive_section_head">
           A Network For All Facilitated by the CTSA&nbsp;Consortium
        </div>
        <p style="margin-left:4px">
          <strong>DIRECT</strong> is a pilot project implemented by the 
          <a href="http://ctsaweb.org" title="Visit the CTSA website" target="_new">CTSA consortium</a>. 
          This collaboration, facilitated through UCSF CTSI's 
          <a href="ProfileDetails.aspx?From=SE&Person=4999751">leadership role</a>, provides a proof-of-concept
          for linking many different software systems to enable the search of research expertise nationwide. 
          <a href="http://direct2experts.org" title="Visit the DIRECT website" target="_new">More about DIRECT 
        </p>
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
</asp:Content>




