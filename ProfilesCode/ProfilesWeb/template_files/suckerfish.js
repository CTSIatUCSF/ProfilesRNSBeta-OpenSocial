sfHover = function() {
	var sfEls = document.getElementById("suckerfishmenu").getElementsByTagName("LI");
	for (var i=0; i<sfEls.length; i++) {
		sfEls[i].onmouseover=function() {
			this.className+=" sfhover";
		}
		sfEls[i].onmouseout=function() {
			this.className=this.className.replace(new RegExp(" sfhover\\b"), "");
		}
	}
}
if (window.attachEvent) window.attachEvent("onload", sfHover);

$(document).ready(function(){
        if(document.all && $("select").size() > 0) {
                var ifShim = document.createElement('iframe');
                ifShim.src = "javascript:false";
                ifShim.style.width=175+"px";
                ifShim.style.height=$("#block-menu-menu-ctsi-main-navig ul.menu li a").parent().find("> li").size()*25+40+"px";
                ifShim.style.filter="progid:DXImageTransform.Microsoft.Alpha(style=0,opacity=0)";
                ifShim.style.zIndex="0";
                $("#block-menu-menu-ctsi-main-navig ul.menu li a").parent().prepend(ifShim);
        }
});

