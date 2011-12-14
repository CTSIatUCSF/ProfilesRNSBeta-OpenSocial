
function attachEvent(target, eventName, handlerName) {
    if (target.addEventListener)
        target.addEventListener(eventName, handlerName, false);
    else if (target.attachEvent)
        target.attachEvent("on" + eventName, handlerName);
    else
        target["on" + eventName] = handlerName;
}
attachEvent(document, 'click', handleCTC);
//document.onclick = handleCTC;

function handleCTC() {
    var mainContainers = $("div[id*=divCTC_]");
    if (mainContainers && mainContainers.length > 0) {
        for (var i = 0; i < mainContainers.length; i++) {
            var l_isOver = mainContainers.get(i).getAttribute('isover');

            if (l_isOver == undefined) {                
                var l_divMaster = $("div[id=divMasterContent]", mainContainers.get(i)).get(0);
                l_divMaster.style.display = 'none';
            }
        }        
    }
}

function overCTC(sender) {
    //alert(sender.id);
    sender.setAttribute("isover", "1");
}

function outCTC(sender) {
    sender.removeAttribute("isover");    
}

function GetCTCMainDiv(controlID) {
    var mainContainer = $("div[id=divCTC_" + controlID + "]");
    return mainContainer.get(0);
}

function ShowMainContent(controlID) {
    var l_main = GetCTCMainDiv(controlID);
    var l_divMaster = $("div[id=divMasterContent]", l_main).get(0); // <- main div here

    if (l_divMaster.style.display == 'block') {
        l_divMaster.style.display = 'none';
    } else l_divMaster.style.display = 'block';
}

function ShowDetailContent(controlID, masterID) {
    var l_main = GetCTCMainDiv(controlID);
    var l_MasterDiv = $("div[id=divMaster_CTC" + masterID + "]", l_main).get(0);
    checkExpandCTC(l_MasterDiv, true);

}

function checkExpandCTC(masterDiv, modify) {
    var l_hdnControl = $("input[id*=hdnIsExpand]", masterDiv).get(0);
    if (modify) {
        if (l_hdnControl.value == '1') {
            l_hdnControl.value = '0';
        } else { l_hdnControl.value = '1'; }
    }

    if (l_hdnControl.value == '0') {
        $("div[id*=divDetail]", masterDiv).get(0).style.display = 'none';
        $("img[id*=imgExpand]", masterDiv).get(0).className = 'CTCprefixCollapsed';
    } else {
        $("div[id*=divDetail]", masterDiv).get(0).style.display = 'inline';
        $("img[id*=imgExpand]", masterDiv).get(0).className = 'CTCprefixExpanded';
    }
}

function ClickCheckBox(controlID, sender) {
    UpadateAllCTC(controlID, false);
}


function UpadateAllCTC(controlID, expandUpdate) {
    var l_main = GetCTCMainDiv(controlID);
    var l_AllMains = $("div[id*=divMaster_CTC]", l_main);

    var l_HeaderText = '';
    if (l_AllMains && l_AllMains.length > 0) {
        for (var i = 0; i < l_AllMains.length; i++) {
            if (expandUpdate) {
                checkExpandCTC(l_AllMains.get(i), false);
            }

            var l_MasterText = $("span[id*=lMasterText]", l_AllMains.get(i)).get(0);
            var l_AtLeastOneSel = false;

            var l_AllDetails = $("div[id*=divDetailCheck]", l_AllMains.get(i));
            if (l_AllDetails && l_AllDetails.length > 0) {
                for (var j = 0; j < l_AllDetails.length; j++) {
                    var l_isChecked = $("input[id*=checkDetailText]", l_AllDetails.get(j)).get(0).checked;

                    if (l_isChecked) {
                        l_AtLeastOneSel = true;
                        if (l_HeaderText.length > 0) { l_HeaderText = l_HeaderText + ', '; }
                        l_HeaderText = l_HeaderText + $("input[id*=hdnDetailText]", l_AllDetails.get(j)).get(0).value;
                    }
                }

            }

            if (l_AtLeastOneSel) {
                l_MasterText.className = 'ExistSelectCTC';
            } else l_MasterText.className = '';

        }
    }
    if (l_HeaderText == '') {
        l_HeaderText = '--Select--';
    }

    var l_SelectText = $("span[id*=lSelectText]", l_main).get(0);
    var l_HdnSelectText = $("input[id*=hdnSelectedText]", l_main).get(0);
    
    if (l_SelectText != null) {
        l_SelectText.innerHTML = l_HeaderText;
        l_SelectText.title = l_HeaderText;

        l_HdnSelectText.value = l_HeaderText;
    }
}