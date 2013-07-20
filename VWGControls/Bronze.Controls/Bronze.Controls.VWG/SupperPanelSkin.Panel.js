function SupperPanel_Init(id, img) {
    if (!img.loaded) {
        img.loaded = true;
        var control = Web_GetElementByDataId(id);
        var objNode = Data_GetNode(id);
        var $ctl = $(control);
        var $inner = $ctl.children("div:first");

        function conactStyle(style1, style2) {
            if (!/;$/.test(style1)) {
                style1 += ";";
            }
            return style1 + style2;
        }

        //must found the div who have the class attribute
        if (!$inner.attr("class")) {
            $inner = $inner.children("div:first");
        }
        
        var radius = Xml_GetAttribute(objNode, "Radius");
        var boxShadow = Xml_GetAttribute(objNode, "BoxShadow");
        var linearGradient = Xml_GetAttribute(objNode, "Linear");
        var innerStyle = '';
        if (radius) {
            innerStyle = conactStyle(innerStyle, radius);
        }

        if (linearGradient) {
            innerStyle = conactStyle(innerStyle, linearGradient);
        }

        var opacity = Xml_GetAttribute(objNode, "Attr.Opacity");
        if (opacity) {
            innerStyle= conactStyle(innerStyle, opacity);
        }

        if (innerStyle && innerStyle != "") {
            $inner.attr("style", conactStyle($inner.attr("style"), innerStyle));
        }
        

        if (boxShadow) {
            $ctl.addClass("SupperPanel-Radius");
            var newStyle = $ctl.attr("style") + ";" + boxShadow + ";" + radius || "";
            $ctl.attr("style", newStyle);
        }

        //处理三角形
        var arrowPosition = Xml_GetAttribute(objNode, "ArrowPosition");
        if (arrowPosition && arrowPosition != "") {
            var posTeam = ['top', "bottom", 'left', "right"];
            var pos = arrowPosition;
            var anti_pos;

            var idx = $.inArray(pos, posTeam);
            if (idx % 2 == 0) {
                anti_pos = posTeam[idx + 1];
            }
            else {
                anti_pos = posTeam[idx - 1];
            }

            var html = "<div class='SupperPanel-Arrow arrow-{0}' name='arrow' ></div><div name='in' class='SupperPanel-Arrow arrow-{0}-in'></div>";
            html = html.replace(/\{0\}/g, pos);
            $ctl.append(html).css('padding-' + pos, '9px');
            var $arrow = $ctl.find("[name='arrow']");
            var $in = $ctl.find("[name='in']")


            var arrowStart = Xml_GetAttribute(objNode, "ArrowStart")*1;
       

            if (pos == "bottom") {
                $arrow.css("top", $ctl.height()).css("left",arrowStart);
                $in.css("top", $ctl.height() - 1).css("left", arrowStart);
                $inner.height($ctl.height() );
            }
            else if (pos == "top") {
                $arrow.css("top", 0).css("left", arrowStart);
                $in.css("top", 1).css("left", arrowStart);
                $inner.height($ctl.height());
            }
            else if (pos == "right") {
                $arrow.css("left", $ctl.width()).css("top", arrowStart);
                $in.css("left", $ctl.width() - 1).css("top", arrowStart);
                $inner.width($ctl.width());
            }
            else if (pos == "left") {
                $arrow.css("left", 0).css("top", arrowStart);
                $in.css("left", 1).css("top", arrowStart);
                $inner.width($ctl.width());
            }


            $arrow.css("border-" + anti_pos + "-color", $inner.css("border-" + pos + "-color"));
            $in.css("border-" + anti_pos + "-color", $inner.css("background-color"));

            
        }
    }
}



//run server method
function runServer(method, param){
    var objEvent = Events_CreateEvent(mstrWindowGuid, "RunServerMethod");
    if (method) {
        var args = Array.prototype.slice.call(arguments);
        var json = JSON.stringify(args);
        Events_SetEventAttribute(objEvent, "params", json);
        Events_RaiseEvents();
    }
}

var _json_stringify = JSON.stringify;
JSON.stringify = function (value) {
    var _array_tojson = Array.prototype.toJSON;
    delete Array.prototype.toJSON;
    var r = _json_stringify(value);
    Array.prototype.toJSON = _array_tojson;
    return r;
};