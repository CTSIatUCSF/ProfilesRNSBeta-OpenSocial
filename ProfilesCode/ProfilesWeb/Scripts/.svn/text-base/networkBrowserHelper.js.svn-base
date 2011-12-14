/*  
 
Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
National Center for Research Resources and Harvard University.


Code licensed under a BSD License. 
For details, see: LICENSE.txt 
  
*/
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
            } catch (e) {
                try {
                    xmlDoc.ownerDocument.setProperty("SelectionLanguage", "XPath");
                } catch (e) { }
            }
            retArray = xmlDoc.selectNodes(xPath);
        }
        else if (document.implementation && document.implementation.createDocument) {
            // W3C XPath implementation (Internet standard)
            var ownerDoc = xmlDoc.ownerDocument;
            if (!ownerDoc) { ownerDoc = xmlDoc; }
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
function parseXml(xmlString) {
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