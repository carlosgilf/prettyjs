function SupperPanel_Init(id, img) {
    if (!img.loaded) {
        img.loaded = true;
        var control = Web_GetElementByDataId(id);
        var objNode = Data_GetNode(id);
        var $ctl = $(control);
        var layer1 = $ctl.children("div:first");

        //must found the div who have the class attribute
        if (!layer1.attr("class")) {
            layer1 = layer1.children("div:first");
        }
        
        var radius = Xml_GetAttribute(objNode, "Radius");
        var boxShadow = Xml_GetAttribute(objNode, "BoxShadow");
        if (radius) {
            var newStyle = layer1.attr("style") + ";" + radius
            layer1.attr("style", newStyle);
        }

        var opacity = Xml_GetAttribute(objNode, "Attr.Opacity");
        if (opacity) {
            var _style = layer1.attr("style");
            if (!/;$/.test(_style)) {
                _style += ";";
            }
            var newStyle = _style + opacity
            layer1.attr("style", newStyle);
        }

        if (boxShadow) {
            $ctl.addClass("SupperPanel-Radius");
            var newStyle = $(control).attr("style") + ";" + boxShadow + ";" + radius || "";
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
                layer1.height($ctl.height() );
            }
            else if (pos == "top") {
                $arrow.css("top", 0).css("left", arrowStart);
                $in.css("top", 1).css("left", arrowStart);
                layer1.height($ctl.height());
            }
            else if (pos == "right") {
                $arrow.css("left", $ctl.width()).css("top", arrowStart);
                $in.css("left", $ctl.width() - 1).css("top", arrowStart);
                layer1.width($ctl.width());
            }
            else if (pos == "left") {
                $arrow.css("left", 0).css("top", arrowStart);
                $in.css("left", 1).css("top", arrowStart);
                layer1.width($ctl.width());
            }


            $arrow.css("border-" + anti_pos + "-color", layer1.css("border-" + pos + "-color"));
            $in.css("border-" + anti_pos + "-color", layer1.css("background-color"));

            
        }
    }
}